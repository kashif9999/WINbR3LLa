

using System;
using System.Collections.Generic;
using System.Text;

namespace CFManzana
{
	/// <summary>
	/// Represents the method that will handle the <see>Connected</see> and <see>Disconnected</see> event.
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="args">A <see>ConnectEventArgs</see> that contains the data.</param>
	public delegate void ConnectEventHandler(object sender, ConnectEventArgs args);
}
