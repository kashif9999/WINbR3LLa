using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CFManzana {
	/// <summary>
	/// Exposes a stream to a file on an iDevice, supporting both synchronous and asynchronous read and write operations
	/// </summary>
	public class iDeviceFile : Stream {
		private enum OpenMode {
			None = 0,
			Read = 2,
			Write = 3
		}

		#region Fields
		private OpenMode	mode;
		private long		handle;
		private iDevice		phone;
		#endregion	// Fields;

		#region Constructors
		private iDeviceFile(iDevice phone, long handle, OpenMode mode) : base() {
			this.phone = phone;
			this.mode = mode;
			this.handle = handle;
		}

		#endregion	// Constructors

		#region Public Properties
		/// <summary>
		/// gets a value indicating whether the current stream supports reading.
		/// </summary>
		public override bool CanRead {
			get { 
				return (mode == OpenMode.Read);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the current stream supports seeking.
		/// </summary>
		public override bool CanSeek {
			get { return false; }
		}

		/// <summary>
		/// Gets a value that determines whether the current stream can time out. 
		/// </summary>
		public override bool CanTimeout {
			get {
				return true;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the current stream supports writing
		/// </summary>
		public override bool CanWrite {
			get {
                return (mode == OpenMode.Write);
			}
		}

		/// <summary>
		/// Gets the length in bytes of the stream . 
		/// </summary>
		public override long Length {
			get { throw new Exception("The method or operation is not implemented."); }
		}

		/// <summary>
		/// Gets or sets the position within the current stream
		/// </summary>
		unsafe public override long Position {
			get {
				uint ret;
				ret = 0;

				MobileDevice.AFCFileRefTell(phone.AFCHandle, handle, ref ret);
				return (long)ret;
			}
			set {
				this.Seek(value, SeekOrigin.Begin);
			}
		}

		/// <summary>
		/// Sets the length of this stream to the given value. 
		/// </summary>
		/// <param name="value">The new length of the stream.</param>
		unsafe public override void SetLength(long value) {
			int ret;

			ret = MobileDevice.AFCFileRefSetFileSize(phone.AFCHandle, handle, (uint)value);
		}
		#endregion	// Public Properties

		#region Public Methods
		/// <summary>
		/// Releases the unmanaged resources used by iDeviceFile
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		unsafe protected override void Dispose(bool disposing) {
			if (disposing) {
				if (handle != 0) {
					MobileDevice.AFCFileRefClose(phone.AFCHandle, handle);
					handle = 0;
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read
		/// </summary>
		/// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source. </param>
		/// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
		/// <param name="count">The maximum number of bytes to be read from the current stream.</param>
		/// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.</returns>
		unsafe public override int Read(byte[] buffer, int offset, int count) {
			if (!CanRead)
				throw new NotImplementedException("Stream open for writing only");

            byte[] temp;

            if (offset == 0)
				temp = buffer;
			else
				temp = new byte[count];

			uint len = (uint)count;
			int ret = MobileDevice.AFCFileRefRead(phone.AFCHandle, handle, temp, ref len);
			if (ret != 0)
				throw new IOException("AFCFileRefRead error = " + ret.ToString());

			if (temp != buffer)
				Buffer.BlockCopy(temp, 0, buffer, offset, (int)len);

			return (int)len;
		}

		/// <summary>
		/// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written. 
		/// </summary>
		/// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
		/// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
		/// <param name="count">The number of bytes to be written to the current stream.</param>
		unsafe public override void Write(byte[] buffer, int offset, int count) {
			if (!CanWrite)
				throw new NotImplementedException("Stream open for reading only");

            byte[] temp;

            if (offset == 0)
				temp = buffer;
            else {
				temp = new byte[count];
				Buffer.BlockCopy(buffer, offset, temp, 0, count);
			}

			int ret = MobileDevice.AFCFileRefWrite(phone.AFCHandle, handle, temp, (uint)count);
		}

		/// <summary>
		/// Sets the position within the current stream
		/// </summary>
		/// <param name="offset">A byte offset relative to the <c>origin</c> parameter</param>
		/// <param name="origin">A value of type <see cref="SeekOrigin"/> indicating the reference point used to obtain the new position</param>
		/// <returns>The new position within the stream</returns>
		unsafe public override long Seek(long offset, SeekOrigin origin) {
			int ret;

			ret = MobileDevice.AFCFileRefSeek(phone.AFCHandle, handle, (uint)offset, 0);
			Console.WriteLine("ret = {0}", ret);
			return offset;
		}

		/// <summary>
		/// Clears all buffers for this stream and causes any buffered data to be written to the underlying device. 
		/// </summary>
		unsafe public override void Flush() {
			MobileDevice.AFCFlushData(phone.AFCHandle, handle);
		}
		#endregion	// Public Methods

		#region Static Methods
		/// <summary>
		/// Opens an iDeviceFile stream on the specified path
		/// </summary>
		/// <param name="phone">A valid iDevice object</param>
		/// <param name="path">The file to open</param>
		/// <param name="openmode">A <see cref="FileAccess"/> value that specifies the operations that can be performed on the file</param>
		/// <returns></returns>
		unsafe public static iDeviceFile Open(iDevice phone, string path, FileAccess openmode) {
			OpenMode	mode;
			int			ret;
			long		handle;
			string		full_path;

			mode = OpenMode.None;
			switch(openmode) {
				case FileAccess.Read: mode = OpenMode.Read; break;
				case FileAccess.Write: mode = OpenMode.Write; break;
				case FileAccess.ReadWrite: throw new NotImplementedException("Read+Write not (yet) implemented");
			}

			full_path = phone.FullPath(phone.CurrentDirectory, path);
			ret = MobileDevice.AFCFileRefOpen(phone.AFCHandle, full_path, (int)mode, 0, out handle);
			if (ret != 0) {
				phone.ReConnect();
				throw new IOException("AFCFileRefOpen failed with error " + ret.ToString());
			}

			return new iDeviceFile(phone, handle, mode);
		}

		/// <summary>
		/// Opens a file for reading
		/// </summary>
		/// <param name="phone">A valid iDevice object</param>
		/// <param name="path">The file to be opened for reading</param>
		/// <returns>An unshared <c>iDeviceFile</c> object on the specified path with Write access. </returns>
		public static iDeviceFile OpenRead(iDevice phone, string path) {
			return iDeviceFile.Open(phone, path, FileAccess.Read);
		}

		/// <summary>
		/// Opens a file for writing
		/// </summary>
		/// <param name="phone">A valid iDevice object</param>
		/// <param name="path">The file to be opened for writing</param>
		/// <returns>An unshared <c>iDeviceFile</c> object on the specified path with Write access. </returns>
		public static iDeviceFile OpenWrite(iDevice phone, string path) {
			return iDeviceFile.Open(phone, path, FileAccess.Write);
		}
		#endregion	// Static Methods
	}
}
