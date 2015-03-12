using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CFManzana
{
    /// <summary>
    /// Exposes access to the Apple iPhone
    /// This is a heavily stripped down version of original iPhone.cs,
    /// it just acts as a connect/disconnect listener now.
    /// </summary>
    public class MultiPhone
    {
        #region Locals
        private DeviceNotificationCallback dnc;

        unsafe internal void* iPhoneHandle;
        #endregion      // Locals

        #region Constructors
        /// <summary>
        /// Initializes a new iPhone object.
        /// </summary>
        unsafe private void doConstruction()
        {
            dnc = new DeviceNotificationCallback(NotifyCallback);

            void* notification;

            int ret = MobileDevice.AMDeviceNotificationSubscribe(dnc, 0, 0, 0, out notification);
            if (ret != 0)
            {
                throw new Exception("AMDeviceNotificationSubscribe failed with error " + ret);
            }
        }

        /// <summary>
        /// Creates a new iPhone object. If an iPhone is connected to the computer, a connection will automatically be opened.
        /// </summary>
        public MultiPhone()
        {
            doConstruction();
        }

        /// <summary>
        /// Constructor for iPhone object
        /// </summary>
        /// <param name="myConnectHandler"></param>
        /// <param name="myDisconnectHandler"></param>
        public MultiPhone(ConnectEventHandler myConnectHandler, ConnectEventHandler myDisconnectHandler)
        {
            Connect += myConnectHandler;
            Disconnect += myDisconnectHandler;
            doConstruction();
        }
        #endregion      // Constructors

        #region Events
        /// <summary>
        /// The <c>Connect</c> event is triggered when a iPhone is connected to the computer
        /// </summary>
        public event ConnectEventHandler Connect;

        /// <summary>
        /// Raises the <see>Connect</see> event.
        /// </summary>
        /// <param name="args">A <see cref="ConnectEventArgs"/> that contains the event data.</param>
        protected void OnConnect(ConnectEventArgs args)
        {
            ConnectEventHandler handler = Connect;

            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// The <c>Disconnect</c> event is triggered when the iPhone is disconnected from the computer
        /// </summary>
        public event ConnectEventHandler Disconnect;

        /// <summary>
        /// Raises the <see>Disconnect</see> event.
        /// </summary>
        /// <param name="args">A <see cref="ConnectEventArgs"/> that contains the event data.</param>
        protected void OnDisconnect(ConnectEventArgs args)
        {
            ConnectEventHandler handler = Disconnect;

            if (handler != null)
            {
                handler(this, args);
            }
        }
        #endregion      // Events

        #region Private Methods
        unsafe private bool ConnectToPhone()
        {
            if (MobileDevice.AMDeviceConnect(iPhoneHandle) == 1)
            {
                throw new Exception("Phone in recovery mode, support not yet implemented");
            }
            if (MobileDevice.AMDeviceIsPaired(iPhoneHandle) == 0)
            {
                return false;
            }
            int chk = MobileDevice.AMDeviceValidatePairing(iPhoneHandle);
            if (chk != 0)
            {
                return false;
            }

            if (MobileDevice.AMDeviceStartSession(iPhoneHandle) == 1)
            {
                return false;
            }
            return true;
        }

        unsafe private void NotifyCallback(ref AMDeviceNotificationCallbackInfo callback)
        {
            if (callback.msg == NotificationMessage.Connected)
            {
                iPhoneHandle = callback.dev;
                if (ConnectToPhone())
                {
                    OnConnect(new ConnectEventArgs(callback));
                }
            }
            else if (callback.msg == NotificationMessage.Disconnected)
            {
                OnDisconnect(new ConnectEventArgs(callback));
            }
        }

        #endregion      // Private Methods
    }
}
