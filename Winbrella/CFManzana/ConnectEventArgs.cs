
using System;
using System.Collections.Generic;
using System.Text;

namespace CFManzana
{
	/// <summary>
	/// Provides data for the <see>Connected</see> and <see>Disconnected</see> events.
	/// </summary>
	public class ConnectEventArgs : EventArgs{
		private NotificationMessage	message;
		unsafe private void* device;
 
		unsafe internal ConnectEventArgs(AMDeviceNotificationCallbackInfo cbi) {
			message = cbi.msg;
			device = cbi.dev;
		}

		/// <summary>
		/// Returns the information for the device that was connected or disconnected.
		/// </summary>
		unsafe public void* Device {
			get { return device; }
		}

		/// <summary>
		/// Returns the type of event.
		/// </summary>
		public NotificationMessage Message {
			get { return message; }
		}
	}
}
