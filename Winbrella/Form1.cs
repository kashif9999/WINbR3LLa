using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CFManzana;
using System.Numerics;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.IO;
using PlistCS;
using ICSharpCode.SharpZipLib.GZip;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;



namespace Winbrella
{
    unsafe public partial class winbrella : Form
    {
        
        WebClient webconnect;
        WebClient ifconnect;
        public static string appversion = "v 1.3.1";
        public string nativefolder = "Winbrella";
        public static string gsappleurl = "gs.apple.com.akadns.net"; // http://gs.apple.com.akadns.net/TSS/controller?action=2
        public static string ifaithcheckurl = "http://iacqua.ih8sn0w.com/submit.php?ecid=";
        public static string cydiacheckurl = "http://cydia.saurik.com/tss@home/api/check/";
        public static string nealtss = "http://api.ineal.me/tss/";
        public static string nealbetatss = "http://api.ineal.me/tss/beta/";
        public static string cydiaxmlmanifest = "http://cydia.saurik.com/tss@home/api/manifest.xml";

        public static string cydiadownloadblob = "http://cydia.saurik.com/TSS/controller?action=2";
        public static string cydiablobsubmit = "http://cydia.saurik.com/tss@home/api/store/";
        public static string appledownloadblob = "http://" + gsappleurl + "/TSS/controller?action=2";
        public static string result1;

        public iDevice Interface;
        public IEnumerator movenext;
        public string iDeviceBoard;
        public string buildid;
        public string producttype;
        public string iosnumber;
        public int BoardID;
        public int ChipID;
        public int cydiachipid;
        public int i9;
        public string hexecid = string.Empty;
        public string chipidhex = string.Empty;
        public string str = (string)null;
     //   public string shshdir = "ifaithshsh";
        public string subPath;

        public string cydiaurl;
        public string ifaithurl;
        public string nealurl;
        public string manifestresuilt1 = string.Empty;
        public string buildmanifestresult1 = string.Empty;

        private ProcessStartInfo startInfo;
        private Process process;
        

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        private void grabECIDifPossible()
        {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM  Win32_PnPEntity");
            Regex hexecid = new Regex("ECID:#?[0-9A-Fa-f]{16}");
            
            ManagementObjectCollection.ManagementObjectEnumerator enumerator;
            try
            {
                enumerator = managementObjectSearcher.Get().GetEnumerator();
                while (enumerator.MoveNext())
                {
                    ManagementObject managementObject = (ManagementObject)enumerator.Current;
                    if (managementObject["Service"] != null && managementObject["Name"].ToString().Contains("Apple") && hexecid.IsMatch(managementObject.ToString()))
                    {
                        str = hexecid.Match(managementObject.ToString()).Value.Split(new char[1] { ':' })[1];
                        if (str != null)
                        {
                            this.txtecidhex.Text = str;
                            Thread.Sleep(200);

                            String hexnumber = str.Replace("X", string.Empty);
                            long result = 0;
                            long.TryParse(hexnumber, System.Globalization.NumberStyles.HexNumber, null, out result);
                            this.txteciddec.Text = result.ToString();
                        }
                        else
                        {
                            int num1 = (int)Interaction.MsgBox((object)"Could not find ECID!", MsgBoxStyle.OkOnly, (object)null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void webcon()
        {
            try
            {
                webconnect = new WebClient();
                webconnect.Proxy = WebRequest.DefaultWebProxy;
                webconnect.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                webconnect.Credentials = System.Net.CredentialCache.DefaultCredentials;
                webconnect.Headers.Add("user-agent", "Winbrella");
            }
            catch (Exception ex)
            {
                MessageBox.Show("W|NbR3LL@ encountered an error while trying to communicate with server\n\t" + ex.InnerException, "W|NbR3LL@", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Try Again", "W|NbR3LL@ " + appversion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        void ifaithcon()
        {
            try
            {
                ifconnect = new WebClient();
                ifconnect.Proxy = WebRequest.DefaultWebProxy;
                ifconnect.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                ifconnect.Credentials = System.Net.CredentialCache.DefaultCredentials;
                ifconnect.Headers.Add("user-agent", "iacqua-1.5-941");
            }
            catch (Exception ex)
            {
                MessageBox.Show("W|NbR3LL@ encountered an error while trying to communicate with server\n\t" + ex.InnerException, "W|NbR3LL@", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Try Again", "W|NbR3LL@ " + appversion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        public void checkwithcydia(string ecid)
        {
            this.toolStripStatusblob.Text = "Communicating with Cydia...";
            webcon();
            cydiaurl = cydiacheckurl + this.txteciddec.Text;
            webconnect.DownloadStringAsync(new Uri(cydiaurl));
            webconnect.DownloadStringCompleted += new DownloadStringCompletedEventHandler(cydia_donwloadstringcompleted);
            while (webconnect.IsBusy)
            {
                Application.DoEvents();
            }

        }

        private void cydia_donwloadstringcompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.toolStripStatusblob.Text = "Fetching Blobs from Cydia Server...";
                Thread.Sleep(200);
                if (!e.Cancelled && (e.Error == null))
                {
                    if ((string.Compare(e.Result.Replace(" ", ""), string.Empty, false) == 0) | (string.Compare(e.Result.Replace(" ", ""), "[]", false) == 0))
                    {
                        this.lstcydiablobs.Items.Add("None");
                        this.toolStripStatusblob.Text = "No blobs available";

                    }
                    else
                    {
                        string result1 = string.Empty;
                        object result = Strings.Split(e.Result, "}", -1, CompareMethod.Binary);
                        this.toolStripStatusblob.Text = "Fetching Blobs list from Cydia...";
                        Thread.Sleep(200);
                        try
                        {
                            movenext = ((IEnumerable)result).GetEnumerator();
                            while (movenext.MoveNext())
                            {
                                result1 = Convert.ToString(movenext.Current);

                                if (result1.Contains("firmware"))
                                {
                                    int r1 = checked(result1.IndexOf("firmware") + 12);
                                    int r2 = checked(result1.IndexOf("\"", r1) - r1);
                                    int r3 = checked(result1.IndexOf("build") + 9);
                                    int r4 = checked(result1.IndexOf("\"", r3) - r3);
                                    string ring = result1.Substring(r1, r2);
                                    string ring1 = result1.Substring(r3, r4);
                                    Application.DoEvents();
                                    this.lstcydiablobs.Items.Add(ring + " (" + ring1 + ")");
                                    this.btncydiadownload.Enabled = true;
                                    this.toolStripStatusblob.Text = "Done Fetching from Cydia !!!";
                                    Thread.Sleep(200);
                                }
                            }
                        }
                        finally
                        {
                            if (movenext is IDisposable)
                                (movenext as IDisposable).Dispose();
                        }
                    }
                    Application.DoEvents();
                }
            }
            catch (Exception e1)
            {
                this.lstcydiablobs.Items.Add("None");
            }
        }

        public void checkwithifaith(string ecid, string board)
        {
            string boarddesc = this.txtboardmodel.Text;
            this.toolStripStatusblob.Text = "Communicating with iFaith Server...";
            Thread.Sleep(200);
            ifaithcon();
            ifaithurl = ifaithcheckurl + this.txtecidhex.Text + "&board=" + boarddesc;
            ifconnect.DownloadStringAsync(new Uri(ifaithurl));
            ifconnect.DownloadStringCompleted += new DownloadStringCompletedEventHandler(ifaith_downloadstringcompleted);
            while (ifconnect.IsBusy)
            {
                Application.DoEvents();
            }
        }

        private void ifaith_downloadstringcompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.toolStripStatusblob.Text = "Fetching Blobs from iFaith Server...";
                Thread.Sleep(200);
                if (e.Cancelled && (e.Error == null))
                {
                    this.lstifaithblobs.Items.Add("None");
                    this.toolStripStatusblob.Text = "No blobs available";
                }
                else
                {
                    try
                    {
                        string result = Strings.Replace(e.Result, ".shsh", "");
                        this.lstifaithblobs.Items.Add(result);
                        if (result.Contains("None"))
                        {

                        }
                        else
                        {
                            this.btnifaithdownload.Enabled = true;
                        }
                        this.toolStripStatusblob.Text = "Done Fetching from iFaith !!!";
                            Thread.Sleep(200);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); this.lstifaithblobs.Items.Add("None"); this.toolStripStatusblob.Text = "Error fetching Blobs from iFaith - Try again!!!"; }

                }
            }
            finally
            { }
        }

        public void checkwithapple(string device)
        {
            this.toolStripStatusblob.Text = "Communicating with Apple...";
            Thread.Sleep(200);
            webcon();
            nealurl = nealtss + this.txtdevicemodel.Text + "/noindent";
            webconnect.DownloadStringAsync(new Uri(nealurl));
            webconnect.DownloadStringCompleted += new DownloadStringCompletedEventHandler(neal_DownloadStringCompleted);
            while (webconnect.IsBusy)
            {
                Application.DoEvents();
            }
        }     

        private void neal_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled && (e.Error == null))
                {
                    this.lstcydiablobs.Items.Add("None");
                    this.toolStripStatusblob.Text = "No blobs available";
                }
                else
                {
                    string result1 = string.Empty;
                    object result = Strings.Split(e.Result, "}", -1, CompareMethod.Binary);
                    this.toolStripStatusblob.Text = "Fetching Blobs list from Apple...";
                    Thread.Sleep(200);
                    try
                    {
                        movenext = ((IEnumerable)result).GetEnumerator();
                        while (movenext.MoveNext())
                        {
                            result1 = Convert.ToString(movenext.Current);

                            if (result1.Contains("true"))
                            {
                                int r1 = checked(result1.IndexOf("version") + 10);
                                int r2 = checked(result1.IndexOf("\"", r1) - r1);
                                int r3 = checked(result1.IndexOf("build") + 8);
                                int r4 = checked(result1.IndexOf("\"", r3) - r3);
                                string ring = result1.Substring(r1, r2);
                                string ring1 = result1.Substring(r3, r4);
                                Application.DoEvents();
                                this.lstappleblobs.Items.Add(ring + " (" + ring1 + ")");
                                this.btnappledownload.Enabled = true;
                                this.toolStripStatusblob.Text = "Done Fetching from Apple!!!";
                                Thread.Sleep(200);
                            }
                        }
                    }
                    finally
                    {
                        if (movenext is IDisposable)
                            (movenext as IDisposable).Dispose();
                    }
                }
                Application.DoEvents();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                this.lstappleblobs.Items.Add("None");
                Application.DoEvents();
            }
        }

        public void checkwithappleforbeta(string device)
        {
            this.toolStripStatusblob.Text = "Communicating with Apple...";
            Thread.Sleep(200);
            webcon();
            nealurl = nealbetatss + this.txtboardmodel.Text;
            webconnect.DownloadStringAsync(new Uri(nealurl));
            webconnect.DownloadStringCompleted += new DownloadStringCompletedEventHandler(beta_downloadstringcompleted);
            while (webconnect.IsBusy)
            {
                Application.DoEvents();
            }
        }

        private void beta_downloadstringcompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled && (e.Error == null))
                {
                    this.lstcydiablobs.Items.Add("None");
                    this.toolStripStatusblob.Text = "No Beta's available";
                }
                else
                {
                    string result1 = string.Empty;
                    object result = Strings.Split(e.Result, "}", -1, CompareMethod.Binary);
                    this.toolStripStatusblob.Text = "Fetching Beta Blobs list from Apple...";
                    Thread.Sleep(200);
                    try
                    {
                        movenext = ((IEnumerable)result).GetEnumerator();
                        while (movenext.MoveNext())
                        {
                            result1 = Convert.ToString(movenext.Current);

                            if (result1.Contains("true"))
                            {
                                int r1 = checked(result1.IndexOf("version") + 10);
                                int r2 = checked(result1.IndexOf("\"", r1) - r1);
                                int r3 = checked(result1.IndexOf("build") + 8);
                                int r4 = checked(result1.IndexOf("\"", r3) - r3);
                                string ring = result1.Substring(r1, r2);
                                string ring1 = result1.Substring(r3, r4);
                                Application.DoEvents();
                                this.lstbetaapple.Items.Add(ring + " (" + ring1 + ")");
                                this.btnbetaapledownload.Enabled = true;
                                this.toolStripStatusblob.Text = "Done Fetching from Apple!!!";
                                Thread.Sleep(200);
                            }
                        }
                    }
                    finally
                    {
                        if (movenext is IDisposable)
                            (movenext as IDisposable).Dispose();
                    }
                }
                Application.DoEvents();
            }
            catch (Exception e1)
            {
                // MessageBox.Show(e1.Message);
                this.lstbetaapple.Items.Add("Not Available");
                Application.DoEvents();
            }
        }

        public winbrella()
        {
            InitializeComponent();
            this.Text = "W|NbR3LL@ " + appversion + " by :: ih8x0r";
            startInfo = new ProcessStartInfo();
            process = new Process();
            if (IsConnectedToInternet())
            {
                this.toolstripinternet.Text = "Internet Connection Available";
                toolstripinternet.ForeColor = Color.Blue;
            }
            else
            {
                this.toolstripinternet.Text = "Internet Connection Not-Available";
                toolstripinternet.ForeColor = Color.Red;
                this.btncheck.Enabled = false;
            }

            DirectoryInfo chk = new DirectoryInfo(nativefolder);

            if (chk.Exists)
            {
                return;
            }
            else
            {
                Directory.CreateDirectory(nativefolder);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Interface = new iDevice();
            Interface.Connect += Interface_Connect;
            Interface.Disconnect += Interface_Disconnect;
            Interface.RecoveryModeEnter += Interface_RecoveryModeEnter;
            Interface.RecoveryModeLeave += Interface_RecoveryModeLeave;
            Interface.DfuConnect += Interface_DfuConnect;
            Interface.DfuDisconnect += Interface_DfuDisconnect;
        }

        void Interface_DfuDisconnect(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    this.toolstripconnectinfo.Text = "Device Disconnected";
                }));
            }
            else
            {
                this.toolstripconnectinfo.Text = "Device Disconnected";
            }
        }

        void Interface_DfuConnect(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    this.toolstripconnectinfo.Text = "Device Connected in DFU Mode!";
                    this.btncheck.Enabled = false;
                    MessageBox.Show("Support not yet implemented", "W|NbR3LL@ " + appversion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            else
            {
                this.toolstripconnectinfo.Text = "Device Connected in DFU Mode!";
                this.btncheck.Enabled = false;
                MessageBox.Show("Support not yet implemented", "W|NbR3LL@ " + appversion, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Interface_RecoveryModeLeave(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    this.toolstripconnectinfo.Text = "Device Disconnected";
                    cleanup();
                }));
            }
            else
            {
                this.toolstripconnectinfo.Text = "Device Disconnected";
                cleanup();
            }
        }

        void Interface_RecoveryModeEnter(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    this.toolstripconnectinfo.Text = "Device is connected in Recovery Mode!";
                    Thread.Sleep(300);
                    manual man = new manual();
                    man.Show();
                    man.FormClosed += new FormClosedEventHandler(man_FormClosed);                 
                }));
            }
            else
            {
                this.toolstripconnectinfo.Text = "Device is connected in Recovery Mode!";
                Thread.Sleep(300);
                manual man = new manual();
                man.Show();
                man.FormClosed += new FormClosedEventHandler(man_FormClosed);                 
            }
        }

        void man_FormClosed(object sender, FormClosedEventArgs e)
        {
          this.txtdevicemodel.Text = global.identifier;
          this.txtboardmodel.Text = global.board;
          this.txtChipid.Text = Convert.ToString(global.ChipID);
          this.txtchipidhex.Text = "...";
          this.txtversion.Text = "...";
          this.txtbuildver.Text = "...";
          this.txtbbversion.Text = "...";
          this.txtserialno.Text = "...";
          this.txtimei.Text = "...";
          this.lstcydiablobs.Items.Clear();
          this.lstifaithblobs.Items.Clear();
          this.lstappleblobs.Items.Clear();
          this.lstbetaapple.Items.Clear();
          this.btnappledownload.Enabled = false;
          this.btnbetaapledownload.Enabled = false;
          this.btncydiadownload.Enabled = false;
          this.btnifaithdownload.Enabled = false;
          this.btncheck.Enabled = true;
          Thread.Sleep(200);
          grabECIDifPossible();
        }

        void Interface_Disconnect(object sender, ConnectEventArgs args)
        {
            cleanup();          
        }

        public void cleanup()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    this.txtdevicemodel.Text = "";
                    this.txtboardmodel.Text = "";
                    this.txtChipid.Text = "";
                    this.txtchipidhex.Text = "";
                    this.txtversion.Text = "";
                    this.txtbuildver.Text = "";
                    this.txtbbversion.Text = "";
                    this.txteciddec.Text = "";
                    this.txtecidhex.Text = "";
                    this.txtserialno.Text = "";
                    this.txtimei.Text = "";
                    this.toolstripconnectinfo.Text = "";
                    this.toolStripStatusblob.Text = "";
                    this.devicecontainer.Items.Clear();
                    this.lstcydiablobs.Items.Clear();
                    this.lstifaithblobs.Items.Clear();
                    this.lstappleblobs.Items.Clear();
                    this.lstbetaapple.Items.Clear();
                    this.btnappledownload.Enabled = false;
                    this.btnbetaapledownload.Enabled = false;
                    this.btncydiadownload.Enabled = false;
                    this.btnifaithdownload.Enabled = false;
                    this.btncheck.Enabled = false;

                }));
            }
            else
            {
                this.txtdevicemodel.Text = "";
                this.txtboardmodel.Text = "";
                this.txtChipid.Text = "";
                this.txtchipidhex.Text = "";
                this.txtversion.Text = "";
                this.txtbuildver.Text = "";
                this.txtbbversion.Text = "";
                this.txteciddec.Text = "";
                this.txtecidhex.Text = "";
                this.txtserialno.Text = "";
                this.txtimei.Text = "";
                this.toolstripconnectinfo.Text = "";
                this.toolStripStatusblob.Text = "";
                this.devicecontainer.Items.Clear();
                this.lstcydiablobs.Items.Clear();
                this.lstifaithblobs.Items.Clear();
                this.lstappleblobs.Items.Clear();
                this.lstbetaapple.Items.Clear();
                this.btnappledownload.Enabled = false;
                this.btnbetaapledownload.Enabled = false;
                this.btncydiadownload.Enabled = false;
                this.btnifaithdownload.Enabled = false;
                this.btncheck.Enabled = false;
            }
        }
              
        public void informationextrator()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {

                    Decimal ecidh = Convert.ToInt64(Interface.CopyValue("UniqueChipID"));
                    var gvalue = new BigInteger(ecidh);

                    this.txtdevicemodel.Text = Interface.CopyValue("ProductType");
                    this.txtboardmodel.Text = Interface.CopyValue("HardwareModel");
                    string cid = Interface.CopyValue("HardwarePlatform");
                    cid = Strings.Replace(cid, "s", "").Replace("5l", "").Replace("x", "");
                    this.txtChipid.Text = cid;
                    Decimal chipid = Convert.ToInt64(cid);
                    var chipidval = new BigInteger(chipid);
                    this.txtchipidhex.Text = chipidval.ToString("X");
                    int chipidlen = this.txtchipidhex.Text.Length;
                    int xx = chipidlen;
                    chipidhex = this.txtchipidhex.Text;
                    while (xx < 5)
                    {
                        if (xx < 5)
                        {
                            chipidhex = "0x" + chipidhex;
                        }
                        xx = xx + 1;
                    }
                    this.txtchipidhex.Text = chipidhex.ToLower();
                    this.txtbbversion.Text = Interface.CopyValue("BasebandVersion");
                    this.txtimei.Text = Interface.CopyValue("InternationalMobileEquipmentIdentity");
                    this.txtserialno.Text = Interface.CopyValue("UniqueDeviceID");
                    this.txtversion.Text = Interface.CopyValue("ProductVersion");
                    this.txtbuildver.Text = Interface.CopyValue("BuildVersion");
                    this.txteciddec.Text = Interface.CopyValue("UniqueChipID");
                    this.txtecidhex.Text = gvalue.ToString("X");
                    int len = this.txtecidhex.Text.Length;
                    int x = len;
                    hexecid = this.txtecidhex.Text;
                    while (x < 16)
                    {
                        if (x < 16)
                        {
                            hexecid = "0" + hexecid;
                        }
                        x = x + 1;
                    }
                    this.txtecidhex.Text = hexecid;
                    if (Interface.CopyValue("ProductType") == "iPhone1,1")
                    {
                        this.devicecontainer.Items.Add("iPhone 2G");
                        this.toolstripconnectinfo.Text = "iPhone 2G " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 0;
                        cydiachipid = 0;
                        iDeviceBoard = this.txtboardmodel.Text;
                    }

                    else if (Interface.CopyValue("ProductType") == "iPhone1,2")
                    {
                        this.devicecontainer.Items.Add("iPhone 3G");
                        this.toolstripconnectinfo.Text = "iPhone 3G " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 4;
                        ChipID = 8900;
                        cydiachipid = 35072;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone2,1")
                    {
                        this.devicecontainer.Items.Add("iPhone 3G[S]");
                        this.toolstripconnectinfo.Text = "iPhone 3G[S] " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 8920;
                        cydiachipid = 35104;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone3,1")
                    {
                        this.devicecontainer.Items.Add("iPhone 4 (GSM)");
                        this.toolstripconnectinfo.Text = "iPhone 4 (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 8930;
                        cydiachipid = 35120;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone3,2")
                    {
                        this.devicecontainer.Items.Add("iPhone 4 (GSM / 2012)");
                        this.toolstripconnectinfo.Text = "iPhone 4 (GSM / 2012) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 4;
                        ChipID = 8930;
                        cydiachipid = 35120;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone3,3")
                    {
                        this.devicecontainer.Items.Add("iPhone 4 (CDMA)");
                        this.toolstripconnectinfo.Text = "iPhone 4 (CDMA) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 6;
                        ChipID = 8930;
                        cydiachipid = 35120;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone4,1")
                    {
                        this.devicecontainer.Items.Add("iPhone 4[S]");
                        this.toolstripconnectinfo.Text = "iPhone 4[S] " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 8;
                        ChipID = 8940;
                        cydiachipid = 35136;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone5,1")
                    {
                        this.devicecontainer.Items.Add("iPhone 5 (GSM)");
                        this.toolstripconnectinfo.Text = "iPhone 5 (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 8950;
                        cydiachipid = 35152;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone5,2")
                    {
                        this.devicecontainer.Items.Add("iPhone 5 (Global)");
                        this.toolstripconnectinfo.Text = "iPhone 5 (Global) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 2;
                        ChipID = 8950;
                        cydiachipid = 35152;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone5,3")
                    {
                        this.devicecontainer.Items.Add("iPhone 5c (GSM)");
                        this.toolstripconnectinfo.Text = "iPhone 5c (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 10;
                        ChipID = 8950;
                        cydiachipid = 35152;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone5,4")
                    {
                        this.devicecontainer.Items.Add("iPhone 5c (Global)");
                        this.toolstripconnectinfo.Text = "iPhone 5c (Global) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 14;
                        ChipID = 8950;
                        cydiachipid = 35152;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone6,1")
                    {
                        this.devicecontainer.Items.Add("iPhone 5s (GSM)");
                        this.toolstripconnectinfo.Text = "iPhone 5s (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 8960;
                        cydiachipid = 35168;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPhone6,2")
                    {
                        this.devicecontainer.Items.Add("iPhone 5s (Global)");
                        this.toolstripconnectinfo.Text = "iPhone 5s (Global) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 2;
                        ChipID = 8960;
                        cydiachipid = 35168;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPod1,1")
                    {
                        this.devicecontainer.Items.Add("iPod touch 1G");
                        this.toolstripconnectinfo.Text = "iPod touch 1G " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 0;
                        cydiachipid = 0;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPod2,1")
                    {
                        this.devicecontainer.Items.Add("iPod touch 2G");
                        this.toolstripconnectinfo.Text = "iPod touch 2G " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 8720;
                        cydiachipid = 34592;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPod3,1")
                    {
                        this.devicecontainer.Items.Add("iPod touch 3");
                        this.toolstripconnectinfo.Text = "iPod touch 3 " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 2;
                        ChipID = 8922;
                        cydiachipid = 35106;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPod4,1")
                    {
                        this.devicecontainer.Items.Add("iPod touch 4");
                        this.toolstripconnectinfo.Text = "iPod touch 4 " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 8;
                        ChipID = 8930;
                        cydiachipid = 35120;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPod5,1")
                    {
                        this.devicecontainer.Items.Add("iPod touch 5");
                        this.toolstripconnectinfo.Text = "iPod touch 5 " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 8942;
                        cydiachipid = 35138;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad1,1")
                    {
                        this.devicecontainer.Items.Add("iPad 1");
                        this.toolstripconnectinfo.Text = "iPad 1 " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 2;
                        ChipID = 8930;
                        cydiachipid = 35120;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad2,1")
                    {
                        this.devicecontainer.Items.Add("iPad 2 (WiFi)");
                        this.toolstripconnectinfo.Text = "iPad 2 (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 4;
                        ChipID = 8940;
                        cydiachipid = 35136;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad2,2")
                    {
                        this.devicecontainer.Items.Add("iPad 2 (GSM)");
                        this.toolstripconnectinfo.Text = "iPad 2 (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 6;
                        ChipID = 8940;
                        cydiachipid = 35136;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad2,3")
                    {
                        this.devicecontainer.Items.Add("iPad 2 (CDMA)");
                        this.toolstripconnectinfo.Text = "iPad 2 (CDMA) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 2;
                        ChipID = 8940;
                        cydiachipid = 35136;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad2,4")
                    {
                        this.devicecontainer.Items.Add("iPad 2 (Mid 2012)");
                        this.toolstripconnectinfo.Text = "iPad 2 (Mid 2012) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 6;
                        ChipID = 8942;
                        cydiachipid = 35138;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad2,5")
                    {
                        this.devicecontainer.Items.Add("iPad Mini (WiFi)");
                        this.toolstripconnectinfo.Text = "iPad Mini (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 10;
                        ChipID = 8942;
                        cydiachipid = 35138;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad2,6")
                    {
                        this.devicecontainer.Items.Add("iPad Mini (GSM)");
                        this.toolstripconnectinfo.Text = "iPad Mini (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 12;
                        ChipID = 8942;
                        cydiachipid = 35138;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad2,7")
                    {
                        this.devicecontainer.Items.Add("iPad Mini (Global)");
                        this.toolstripconnectinfo.Text = "iPad Mini (Global) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 14;
                        ChipID = 8942;
                        cydiachipid = 35138;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }

                    else if (Interface.CopyValue("ProductType") == "iPad3,1")
                    {
                        this.devicecontainer.Items.Add("iPad 3 (WiFi)");
                        this.toolstripconnectinfo.Text = "iPad 3 (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 8945;
                        cydiachipid = 35141;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad3,2")
                    {
                        this.devicecontainer.Items.Add("iPad 2 (CDMA)");
                        this.toolstripconnectinfo.Text = "iPad 2 (CDMA) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 2;
                        ChipID = 8945;
                        cydiachipid = 35141;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad3,3")
                    {
                        this.devicecontainer.Items.Add("iPad 3 (GSM)");
                        this.toolstripconnectinfo.Text = "iPad 3 (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 4;
                        ChipID = 8945;
                        cydiachipid = 35141;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad3,4")
                    {
                        this.devicecontainer.Items.Add("iPad 4 (WiFi)");
                        this.toolstripconnectinfo.Text = "iPad 4 (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 8955;
                        cydiachipid = 35157;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad3,5")
                    {
                        this.devicecontainer.Items.Add("iPad 4 (GSM)");
                        this.toolstripconnectinfo.Text = "iPad 4 (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 2;
                        ChipID = 8955;
                        cydiachipid = 35157;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad3,6")
                    {
                        this.devicecontainer.Items.Add("iPad 4 (Global)");
                        this.toolstripconnectinfo.Text = "iPad 4 (Global) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 4;
                        ChipID = 8955;
                        cydiachipid = 35157;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad4,1")
                    {
                        this.devicecontainer.Items.Add("iPad Air (WiFi)");
                        this.toolstripconnectinfo.Text = "iPad Air (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 16;
                        ChipID = 8960;
                        cydiachipid = 35168;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad4,2")
                    {
                        this.devicecontainer.Items.Add("iPad Air (Cellular)");
                        this.toolstripconnectinfo.Text = "iPad Air (Cellular) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 18;
                        ChipID = 8960;
                        cydiachipid = 35168;
                        iDeviceBoard = this.txtboardmodel.Text;
                    }
                    else if (Interface.CopyValue("ProductType") == "iPad4,4")
                    {
                        this.devicecontainer.Items.Add("iPad Mini Retina (WiFi)");
                        this.toolstripconnectinfo.Text = "iPad Mini Retina (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 10;
                        ChipID = 8960;
                        cydiachipid = 35168;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "iPad4,5")
                    {
                        this.devicecontainer.Items.Add("iPad Mini Retina (Cellular)");
                        this.toolstripconnectinfo.Text = "iPad Mini Retina (Cellular) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 12;
                        ChipID = 8960;
                        cydiachipid = 35168;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "AppleTV2,1")
                    {
                        this.devicecontainer.Items.Add("Apple TV 2G");
                        this.toolstripconnectinfo.Text = "Apple TV 2G " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 16;
                        ChipID = 8930;
                        cydiachipid = 35120;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "AppleTV3,1")
                    {
                        this.devicecontainer.Items.Add("Apple TV 3");
                        this.toolstripconnectinfo.Text = "Apple TV 3 " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 8;
                        ChipID = 8942;
                        cydiachipid = 35138;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }
                    else if (Interface.CopyValue("ProductType") == "AppleTV3,2")
                    {
                        this.devicecontainer.Items.Add("Apple TV 3 (2013)");
                        this.toolstripconnectinfo.Text = "Apple TV 3 (2013) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                        BoardID = 0;
                        ChipID = 8947;
                        cydiachipid = 35143;
                        iDeviceBoard = this.txtboardmodel.Text;

                    }


                    else if (Interface.CopyValue("ProductType") == "")
                    {
                        this.txtdevicemodel.Text = "Unknow Device - " + "Connected";
                    }
                    this.btncheck.Enabled = true;
                }));
            }
            else
            {
                Decimal ecidh = Convert.ToInt64(Interface.CopyValue("UniqueChipID"));
                var gvalue = new BigInteger(ecidh);

                this.txtdevicemodel.Text = Interface.CopyValue("ProductType");
                this.txtboardmodel.Text = Interface.CopyValue("HardwareModel");
                string cid = Interface.CopyValue("HardwarePlatform");
                cid = Strings.Replace(cid, "s", "").Replace("5l", "").Replace("x", "");
                this.txtChipid.Text = cid;
                Decimal chipid = Convert.ToInt64(cid);
                var chipidval = new BigInteger(chipid);
                this.txtchipidhex.Text = chipidval.ToString("X");
                int chipidlen = this.txtchipidhex.Text.Length;
                int xx = chipidlen;
                chipidhex = this.txtchipidhex.Text;
                while (xx < 5)
                {
                    if (xx < 5)
                    {
                        chipidhex = "0x" + chipidhex;
                    }
                    xx = xx + 1;
                }
                this.txtchipidhex.Text = chipidhex.ToLower();
                this.txtbbversion.Text = Interface.CopyValue("BasebandVersion");
                this.txtimei.Text = Interface.CopyValue("InternationalMobileEquipmentIdentity");
                this.txtserialno.Text = Interface.CopyValue("UniqueDeviceID");
                this.txtversion.Text = Interface.CopyValue("ProductVersion");
                this.txtbuildver.Text = Interface.CopyValue("BuildVersion");
                this.txteciddec.Text = Interface.CopyValue("UniqueChipID");
                this.txtecidhex.Text = gvalue.ToString("X");
                int len = this.txtecidhex.Text.Length;
                int x = len;
                hexecid = this.txtecidhex.Text;
                while (x < 16)
                {
                    if (x < 16)
                    {
                        hexecid = "0" + hexecid;
                    }
                    x = x + 1;
                }
                this.txtecidhex.Text = hexecid;
                if (Interface.CopyValue("ProductType") == "iPhone1,1")
                {
                    this.devicecontainer.Items.Add("iPhone 2G");
                    this.toolstripconnectinfo.Text = "iPhone 2G " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 0;
                    cydiachipid = 0;
                    iDeviceBoard = this.txtboardmodel.Text;
                }

                else if (Interface.CopyValue("ProductType") == "iPhone1,2")
                {
                    this.devicecontainer.Items.Add("iPhone 3G");
                    this.toolstripconnectinfo.Text = "iPhone 3G " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 4;
                    ChipID = 8900;
                    cydiachipid = 35072;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone2,1")
                {
                    this.devicecontainer.Items.Add("iPhone 3G[S]");
                    this.toolstripconnectinfo.Text = "iPhone 3G[S] " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 8920;
                    cydiachipid = 35104;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone3,1")
                {
                    this.devicecontainer.Items.Add("iPhone 4 (GSM)");
                    this.toolstripconnectinfo.Text = "iPhone 4 (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 8930;
                    cydiachipid = 35120;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone3,2")
                {
                    this.devicecontainer.Items.Add("iPhone 4 (GSM / 2012)");
                    this.toolstripconnectinfo.Text = "iPhone 4 (GSM / 2012) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 4;
                    ChipID = 8930;
                    cydiachipid = 35120;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone3,3")
                {
                    this.devicecontainer.Items.Add("iPhone 4 (CDMA)");
                    this.toolstripconnectinfo.Text = "iPhone 4 (CDMA) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 6;
                    ChipID = 8930;
                    cydiachipid = 35120;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone4,1")
                {
                    this.devicecontainer.Items.Add("iPhone 4[S]");
                    this.toolstripconnectinfo.Text = "iPhone 4[S] " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 8;
                    ChipID = 8940;
                    cydiachipid = 35136;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone5,1")
                {
                    this.devicecontainer.Items.Add("iPhone 5 (GSM)");
                    this.toolstripconnectinfo.Text = "iPhone 5 (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 8950;
                    cydiachipid = 35152;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone5,2")
                {
                    this.devicecontainer.Items.Add("iPhone 5 (Global)");
                    this.toolstripconnectinfo.Text = "iPhone 5 (Global) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 2;
                    ChipID = 8950;
                    cydiachipid = 35152;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone5,3")
                {
                    this.devicecontainer.Items.Add("iPhone 5c (GSM)");
                    this.toolstripconnectinfo.Text = "iPhone 5c (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 10;
                    ChipID = 8950;
                    cydiachipid = 35152;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone5,4")
                {
                    this.devicecontainer.Items.Add("iPhone 5c (Global)");
                    this.toolstripconnectinfo.Text = "iPhone 5c (Global) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 14;
                    ChipID = 8950;
                    cydiachipid = 35152;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone6,1")
                {
                    this.devicecontainer.Items.Add("iPhone 5s (GSM)");
                    this.toolstripconnectinfo.Text = "iPhone 5s (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 8960;
                    cydiachipid = 35168;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPhone6,2")
                {
                    this.devicecontainer.Items.Add("iPhone 5s (Global)");
                    this.toolstripconnectinfo.Text = "iPhone 5s (Global) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 2;
                    ChipID = 8960;
                    cydiachipid = 35168;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPod1,1")
                {
                    this.devicecontainer.Items.Add("iPod touch 1G");
                    this.toolstripconnectinfo.Text = "iPod touch 1G " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 0;
                    cydiachipid = 0;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPod2,1")
                {
                    this.devicecontainer.Items.Add("iPod touch 2G");
                    this.toolstripconnectinfo.Text = "iPod touch 2G " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 8720;
                    cydiachipid = 34592;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPod3,1")
                {
                    this.devicecontainer.Items.Add("iPod touch 3");
                    this.toolstripconnectinfo.Text = "iPod touch 3 " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 2;
                    ChipID = 8922;
                    cydiachipid = 35106;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPod4,1")
                {
                    this.devicecontainer.Items.Add("iPod touch 4");
                    this.toolstripconnectinfo.Text = "iPod touch 4 " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 8;
                    ChipID = 8930;
                    cydiachipid = 35120;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPod5,1")
                {
                    this.devicecontainer.Items.Add("iPod touch 5");
                    this.toolstripconnectinfo.Text = "iPod touch 5 " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 8942;
                    cydiachipid = 35138;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad1,1")
                {
                    this.devicecontainer.Items.Add("iPad 1");
                    this.toolstripconnectinfo.Text = "iPad 1 " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 2;
                    ChipID = 8930;
                    cydiachipid = 35120;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad2,1")
                {
                    this.devicecontainer.Items.Add("iPad 2 (WiFi)");
                    this.toolstripconnectinfo.Text = "iPad 2 (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 4;
                    ChipID = 8940;
                    cydiachipid = 35136;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad2,2")
                {
                    this.devicecontainer.Items.Add("iPad 2 (GSM)");
                    this.toolstripconnectinfo.Text = "iPad 2 (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 6;
                    ChipID = 8940;
                    cydiachipid = 35136;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad2,3")
                {
                    this.devicecontainer.Items.Add("iPad 2 (CDMA)");
                    this.toolstripconnectinfo.Text = "iPad 2 (CDMA) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 2;
                    ChipID = 8940;
                    cydiachipid = 35136;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad2,4")
                {
                    this.devicecontainer.Items.Add("iPad 2 (Mid 2012)");
                    this.toolstripconnectinfo.Text = "iPad 2 (Mid 2012) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 6;
                    ChipID = 8942;
                    cydiachipid = 35138;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad2,5")
                {
                    this.devicecontainer.Items.Add("iPad Mini (WiFi)");
                    this.toolstripconnectinfo.Text = "iPad Mini (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 10;
                    ChipID = 8942;
                    cydiachipid = 35138;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad2,6")
                {
                    this.devicecontainer.Items.Add("iPad Mini (GSM)");
                    this.toolstripconnectinfo.Text = "iPad Mini (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 12;
                    ChipID = 8942;
                    cydiachipid = 35138;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad2,7")
                {
                    this.devicecontainer.Items.Add("iPad Mini (Global)");
                    this.toolstripconnectinfo.Text = "iPad Mini (Global) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 14;
                    ChipID = 8942;
                    cydiachipid = 35138;
                    iDeviceBoard = this.txtboardmodel.Text;

                }

                else if (Interface.CopyValue("ProductType") == "iPad3,1")
                {
                    this.devicecontainer.Items.Add("iPad 3 (WiFi)");
                    this.toolstripconnectinfo.Text = "iPad 3 (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 8945;
                    cydiachipid = 35141;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad3,2")
                {
                    this.devicecontainer.Items.Add("iPad 2 (CDMA)");
                    this.toolstripconnectinfo.Text = "iPad 2 (CDMA) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 2;
                    ChipID = 8945;
                    cydiachipid = 35141;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad3,3")
                {
                    this.devicecontainer.Items.Add("iPad 3 (GSM)");
                    this.toolstripconnectinfo.Text = "iPad 3 (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 4;
                    ChipID = 8945;
                    cydiachipid = 35141;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad3,4")
                {
                    this.devicecontainer.Items.Add("iPad 4 (WiFi)");
                    this.toolstripconnectinfo.Text = "iPad 4 (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 8955;
                    cydiachipid = 35157;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad3,5")
                {
                    this.devicecontainer.Items.Add("iPad 4 (GSM)");
                    this.toolstripconnectinfo.Text = "iPad 4 (GSM) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 2;
                    ChipID = 8955;
                    cydiachipid = 35157;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad3,6")
                {
                    this.devicecontainer.Items.Add("iPad 4 (Global)");
                    this.toolstripconnectinfo.Text = "iPad 4 (Global) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 4;
                    ChipID = 8955;
                    cydiachipid = 35157;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad4,1")
                {
                    this.devicecontainer.Items.Add("iPad Air (WiFi)");
                    this.toolstripconnectinfo.Text = "iPad Air (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 16;
                    ChipID = 8960;
                    cydiachipid = 35168;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad4,2")
                {
                    this.devicecontainer.Items.Add("iPad Air (Cellular)");
                    this.toolstripconnectinfo.Text = "iPad Air (Cellular) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 18;
                    ChipID = 8960;
                    cydiachipid = 35168;
                    iDeviceBoard = this.txtboardmodel.Text;
                }
                else if (Interface.CopyValue("ProductType") == "iPad4,4")
                {
                    this.devicecontainer.Items.Add("iPad Mini Retina (WiFi)");
                    this.toolstripconnectinfo.Text = "iPad Mini Retina (WiFi) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 10;
                    ChipID = 8960;
                    cydiachipid = 35168;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "iPad4,5")
                {
                    this.devicecontainer.Items.Add("iPad Mini Retina (Cellular)");
                    this.toolstripconnectinfo.Text = "iPad Mini Retina (Cellular) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 12;
                    ChipID = 8960;
                    cydiachipid = 35168;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "AppleTV2,1")
                {
                    this.devicecontainer.Items.Add("Apple TV 2G");
                    this.toolstripconnectinfo.Text = "Apple TV 2G " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 16;
                    ChipID = 8930;
                    cydiachipid = 35120;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "AppleTV3,1")
                {
                    this.devicecontainer.Items.Add("Apple TV 3");
                    this.toolstripconnectinfo.Text = "Apple TV 3 " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 8;
                    ChipID = 8942;
                    cydiachipid = 35138;
                    iDeviceBoard = this.txtboardmodel.Text;

                }
                else if (Interface.CopyValue("ProductType") == "AppleTV3,2")
                {
                    this.devicecontainer.Items.Add("Apple TV 3 (2013)");
                    this.toolstripconnectinfo.Text = "Apple TV 3 (2013) " + "with iOS " + Interface.CopyValue("ProductVersion") + " - Connected";
                    BoardID = 0;
                    ChipID = 8947;
                    cydiachipid = 35143;
                    iDeviceBoard = this.txtboardmodel.Text;

                }

                else if (Interface.CopyValue("ProductType") == "")
                {
                    this.txtdevicemodel.Text = "Unknow Device - " + "Connected";
                }
                this.btncheck.Enabled = true;
            }
        }

        public void recheck()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    lstappleblobs.Items.Clear();
                    btnappledownload.Enabled = false;
                    lstbetaapple.Items.Clear();
                    btnbetaapledownload.Enabled = false;
                    lstcydiablobs.Items.Clear();
                    btnifaithdownload.Enabled = false;
                    lstifaithblobs.Items.Clear();
                    btncydiadownload.Enabled = false;
                }));
            }
            else
            {
                lstappleblobs.Items.Clear();
                btnappledownload.Enabled = false;
                lstbetaapple.Items.Clear();
                btnbetaapledownload.Enabled = false;
                lstcydiablobs.Items.Clear();
                btnifaithdownload.Enabled = false;
                lstifaithblobs.Items.Clear();
                btncydiadownload.Enabled = false;
            }

        }

        public void cancel_Request()
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    if (webconnect.IsBusy)
                    {
                        webconnect.Dispose();
                    }
                    else if (ifconnect.IsBusy)
                    {
                        ifconnect.Dispose();
                    }
                }));
            }
            else
            {
                if (webconnect.IsBusy)
                {
                    webconnect.Dispose();
                }
                else if (ifconnect.IsBusy)
                {
                    ifconnect.Dispose();
                }
            }

        }

        void Interface_Connect(object sender, ConnectEventArgs args)
        {
            informationextrator();
            this.btncheck.Enabled = true;
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            Thread.Sleep(300);
            this.btncheck.Enabled = false;
            recheck();
            checkwithcydia(this.txteciddec.Text);
            var stopwatch = Stopwatch.StartNew();
            Thread.Sleep(1000);
            stopwatch.Stop();
            checkwithifaith(this.txtecidhex.Text, this.txtboardmodel.Text);
            var stopwatch1 = Stopwatch.StartNew();
            Thread.Sleep(1000);
            stopwatch1.Stop();
            checkwithapple(this.txtdevicemodel.Text);
            var stopwatch2 = Stopwatch.StartNew();
            Thread.Sleep(1000);
            stopwatch2.Stop();
            checkwithappleforbeta(this.txtboardmodel.Text);
            var stopwatch3 = Stopwatch.StartNew();
            Thread.Sleep(1000);
            stopwatch3.Stop();
            this.toolStripStatusblob.Text = "Done fetching from Cydia | iFaith | Apple";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cancel_Request();
            Application.ExitThread();
            Application.Exit();
        }

        private void requestmanifest()
        {
            try
            {
                string ecidhex = this.txteciddec.Text;
                DirectoryInfo checkcydiadir = new DirectoryInfo(nativefolder + "Manifests");
                if (checkcydiadir.Exists == true)
                {
                    webcon();
                    string urlmanifest = "http://api.ineal.me/tss/manifest/" + iDeviceBoard + "/" + buildid;
                    Stream manifest1 = webconnect.OpenRead(urlmanifest);
                    StreamReader manifestreader = new StreamReader(manifest1);
                    string manifestresult = manifestreader.ReadToEnd();
                    manifestresuilt1 = manifestresult.Replace("<string>$ECID$</string>", "<integer>" + ecidhex + "</integer>");
                    System.IO.File.WriteAllText(savefolder.SelectedPath + nativefolder + "\\Manifests\\" + iDeviceBoard + ".plist", manifestresuilt1);
                }
                else
                {
                    Directory.CreateDirectory(nativefolder + "\\Manifests\\");
                    webcon();
                    string urlmanifest = "http://api.ineal.me/tss/manifest/" + iDeviceBoard + "/" + buildid;
                    Stream manifest1 = webconnect.OpenRead(urlmanifest);
                    StreamReader manifestreader = new StreamReader(manifest1);
                    string manifestresult = manifestreader.ReadToEnd();
                    manifestresuilt1 = manifestresult.Replace("<string>$ECID$</string>", "<integer>" + ecidhex + "</integer>");
                    System.IO.File.WriteAllText(savefolder.SelectedPath + nativefolder + "\\Manifests\\" + iDeviceBoard + ".plist", manifestresuilt1);
                }
            }
            catch (WebException err)
            {
               // MessageBox.Show(err.Message);
                request_manifest_from_cydia();
            }
            finally
            {

            }
        }

        private void request_manifest_from_cydia()
        {
            try
            {
                string ecidhex = this.txteciddec.Text;
                iDeviceBoard = this.txtboardmodel.Text;
                DirectoryInfo checkcydiadir = new DirectoryInfo(nativefolder + "Manifests");
                if (checkcydiadir.Exists == true)
                {
                    webcon();
                    string urlmanifest = cydiaxmlmanifest + "/" + buildid + "/" + cydiachipid + "/" + BoardID;
                    Stream manifest1 = webconnect.OpenRead(urlmanifest);
                    StreamReader manifestreader = new StreamReader(manifest1);
                    string manifestresult = manifestreader.ReadToEnd();
                    manifestresuilt1 = manifestresult.Replace("<string>$ECID$</string>", "<integer>" + ecidhex + "</integer>");
                    MessageBox.Show(manifestresuilt1);
                    System.IO.File.WriteAllText(savefolder.SelectedPath + nativefolder + "\\Manifests\\" + iDeviceBoard + ".plist", manifestresuilt1);
                }
                else
                {
                    Directory.CreateDirectory(nativefolder + "\\Manifests\\");
                    webcon();
                    string urlmanifest = cydiaxmlmanifest + "/" + buildid + "/" + cydiachipid + "/" + BoardID;
                    Stream manifest1 = webconnect.OpenRead(urlmanifest);
                    StreamReader manifestreader = new StreamReader(manifest1);
                    string manifestresult = manifestreader.ReadToEnd();
                    manifestresuilt1 = manifestresult.Replace("<string>$ECID$</string>", "<integer>" + ecidhex + "</integer>");
                    MessageBox.Show(manifestresuilt1);
                    System.IO.File.WriteAllText(savefolder.SelectedPath + nativefolder + "\\Manifests\\" + iDeviceBoard + ".plist", manifestresuilt1);
                }
            }
            catch (WebException err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {

            }
        }

        private void cydiamanifestrequest()
        {
            try
            {
                string selectedblob = "";
                foreach (var item in lstcydiablobs.SelectedItems)
                {
                    selectedblob += item.ToString();
                }
                string blobslist = selectedblob.ToString();
                string ecidhex = this.txteciddec.Text;
                DirectoryInfo checkcydiadir = new DirectoryInfo(nativefolder + "Cydiablobs");
                if (checkcydiadir.Exists == true)
                {
                    var uri = new Uri(cydiadownloadblob);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                    var service = ServicePointManager.FindServicePoint(uri);
                    service.Expect100Continue = false;
                    request.Method = "POST";
                    request.ContentType = "text/xml; charset=utf8";
                    string postData = manifestresuilt1;
                    byte[] bytes = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = bytes.Length;
                    Stream requeststream = request.GetRequestStream();
                    requeststream.Write(bytes, 0, bytes.Length);
                    WebResponse response = request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);

                    var result = reader.ReadToEnd();
                    if (result.Contains("STATUS=0&MESSAGE=SUCCESS&REQUEST_STRING="))
                    {
                        string result1 = result.Replace("STATUS=0&MESSAGE=SUCCESS&REQUEST_STRING=", "");
                        this.toolStripStatusblob.Text = "Response Received | Downloading Blob!!";
                        System.IO.File.WriteAllText(savefolder.SelectedPath + nativefolder + "\\CydiaBlobs\\" + ecidhex + "_" + producttype + "_" + blobslist + ".shsh", result1);
                        stream.Dispose();
                        reader.Dispose();
                        this.toolStripStatusblob.Text = "Blob Downloaded from Cydia";
                    }
                    else
                    {
                        this.toolStripStatusblob.Text = "Error received from Cydia - no blob downloaded";
                        return;
                    }
                }
                else
                {
                    Directory.CreateDirectory(nativefolder + "\\Cydiablobs\\");
                    var uri = new Uri(cydiadownloadblob);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                    var service = ServicePointManager.FindServicePoint(uri);
                    service.Expect100Continue = false;
                    request.Method = "POST";
                    request.ContentType = "text/xml; charset=utf8";
                    string postData = manifestresuilt1;
                    byte[] bytes = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = bytes.Length;
                    Stream requeststream = request.GetRequestStream();
                    requeststream.Write(bytes, 0, bytes.Length);
                    WebResponse response = request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);

                    var result = reader.ReadToEnd();
                    if (result.Contains("STATUS=0&MESSAGE=SUCCESS&REQUEST_STRING="))
                    {
                        string result1 = result.Replace("STATUS=0&MESSAGE=SUCCESS&REQUEST_STRING=", "");
                        this.toolStripStatusblob.Text = "Response Received | Downloading Blob!!";
                        System.IO.File.WriteAllText(savefolder.SelectedPath + nativefolder + "\\CydiaBlobs\\" + ecidhex + "_" + producttype + "_" + blobslist + ".shsh", result1);
                        stream.Dispose();
                        reader.Dispose();
                        this.toolStripStatusblob.Text = "Blob Downloaded from Cydia";
                    }
                    else
                    {
                        this.toolStripStatusblob.Text = "Unknow Response from Cydia - No blob Downloaded";
                        return;
                    }
                }
            }
            catch(WebException err)
            {
                MessageBox.Show("While Download Blobs from Cydia Following error has occured\n" + err.Message, "W|NbR3LL@" + appversion, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ifaithblobdownload()
        {
            DirectoryInfo checkifaithdir = new DirectoryInfo(nativefolder + "iFaithblobs");
            if (checkifaithdir.Exists == true)
            {
                //  savefolder.ShowDialog();
                //  if (string.IsNullOrEmpty(savefolder.SelectedPath)) { return; }
                //    subPath = "iFaith-Blobs";
                //    bool isExists = System.IO.Directory.Exists(subPath);
                //    if (!isExists)
                //         System.IO.Directory.CreateDirectory(subPath);;
                string hexecid = this.txtecidhex.Text;
                iDeviceBoard = this.txtboardmodel.Text;
                string selectedblob = "";
                foreach (var item in lstifaithblobs.SelectedItems)
                {
                    selectedblob += item.ToString();
                }
                string blobslist = selectedblob.ToString();
                ifaithcon();
                string downloadurl = ifaithcheckurl + hexecid + "&board=" + iDeviceBoard + "&ios=" + blobslist.Replace(" ", "%20");
                Stream ifaithblob = ifconnect.OpenRead(downloadurl);
                StreamReader blobreader = new StreamReader(ifaithblob);
                string ifaithresult = blobreader.ReadToEnd();
                System.IO.File.WriteAllText(savefolder.SelectedPath + nativefolder + "\\iFaithBlobs\\" + hexecid + "_" + producttype + "_" + blobslist + ".ifaith", ifaithresult);
                ifaithblob.Close();
                blobreader.Close();
                this.toolStripStatusblob.Text = "Blob Downloaded from iFaith";
            }
            else
            {
                Directory.CreateDirectory(nativefolder + "\\iFaithBlobs\\");
                string hexecid = this.txtecidhex.Text;
                iDeviceBoard = this.txtboardmodel.Text;
                string selectedblob = "";
                foreach (var item in lstifaithblobs.SelectedItems)
                {
                    selectedblob += item.ToString();
                }
                string blobslist = selectedblob.ToString();
                ifaithcon();
                string downloadurl = ifaithcheckurl + hexecid + "&board=" + iDeviceBoard + "&ios=" + blobslist.Replace(" ", "%20");;
                Stream ifaithblob = ifconnect.OpenRead(downloadurl);
                StreamReader blobreader = new StreamReader(ifaithblob);
                string ifaithresult = blobreader.ReadToEnd();
                System.IO.File.WriteAllText(savefolder.SelectedPath + nativefolder + "\\iFaithBlobs\\" + hexecid + "_" + producttype + "_" + blobslist + ".ifaith", ifaithresult);
                ifaithblob.Close();
                blobreader.Close();
                this.toolStripStatusblob.Text = "Blob Downloaded from iFaith";
            }
        }

        private void normalapplerequest()
        {
            string ecidhex = this.txteciddec.Text;
            string savingprocess = nativefolder + "\\Appleblobs\\" + ecidhex + "_" + producttype + "_" + iosnumber + "_" + buildid + ".shsh";
            try
            {
                string selectedblob = "";

                foreach (var item in lstappleblobs.SelectedItems)
                {
                    selectedblob += item.ToString();
                }
                string blobslist = lstappleblobs.ToString();
                DirectoryInfo appledir = new DirectoryInfo(nativefolder + "Appleblobs");
                if (appledir.Exists == true)
                {
                    var uri = new Uri(appledownloadblob);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                    var service = ServicePointManager.FindServicePoint(uri);
                    service.Expect100Continue = false;
                    request.Method = "POST";
                    request.ContentType = "text/xml; charset=utf8";
                    request.Headers.Add("HTTP_USER_AGENT", "InetURL/1.0");
                    string postData = manifestresuilt1;
                    byte[] bytes = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = bytes.Length;
                    Stream requeststream = request.GetRequestStream();
                    requeststream.Write(bytes, 0, bytes.Length);
                    WebResponse response = request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    var result = reader.ReadToEnd();
                    if (result.Contains("STATUS=0&MESSAGE=SUCCESS"))
                    {
                        result1 = result.Replace("STATUS=0&MESSAGE=SUCCESS&REQUEST_STRING=", "");
                        string blobname = ecidhex + "_" + producttype + "_" + blobslist + ".shsh";
                        this.toolStripStatusblob.Text = "Blob Downloaded from Apple...";
                        File.WriteAllText(nativefolder + "\\Appleblobs\\" + "\\appleresponse.xml", result1.Substring(result1.IndexOf("<?xml"), result1.IndexOf("</plist>") - result1.IndexOf("<?xml") + 8));
                        plistconverter(nativefolder + "\\Appleblobs\\" + "\\appleresponse.xml", nativefolder + "\\Appleblobs\\" + "\\appleresponse.plist");
                        using (Stream stream1 = File.OpenRead(nativefolder + "\\Appleblobs\\" + "\\tss-response.plist"))
                        using (FileStream fileStream = File.Create(savingprocess))
                        {
                            using (Stream stream2 = new GZipOutputStream(fileStream))
                            {
                                byte[] bArr = new byte[4095];
                                while (InlineAssignHelper<int>(ref i9, stream1.Read(bArr, 0, checked((int)bArr.Length))) != 0)
                                {
                                    stream2.Write(bArr, 0, i9);
                                }
                            }
                        }
                        stream.Dispose();
                        reader.Dispose();
                         }
                          else
                          {
                              this.toolStripStatusblob.Text = "Unknow Error from Apple - No Blob Downloaded";
                              return;
                           }
                }
                else
                {
                    Directory.CreateDirectory(nativefolder + "\\Appleblobs\\");
                    var uri = new Uri(appledownloadblob);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                    var service = ServicePointManager.FindServicePoint(uri);
                    service.Expect100Continue = false;
                    request.Method = "POST";
                    request.ContentType = "text/xml; charset=utf8";
                    request.Headers.Add("HTTP_USER_AGENT", "InetURL/1.0");
                    string postData = manifestresuilt1;
                    byte[] bytes = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = bytes.Length;
                    Stream requeststream = request.GetRequestStream();
                    requeststream.Write(bytes, 0, bytes.Length);
                    WebResponse response = request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    var result = reader.ReadToEnd();
                 if (result.Contains("STATUS=0&MESSAGE=SUCCESS"))
                    {
                      result1 = result.Replace("STATUS=0&MESSAGE=SUCCESS&REQUEST_STRING=", "");
                      string blobname = ecidhex + "_" + producttype + "_" + blobslist + ".shsh";
                        this.toolStripStatusblob.Text = "Blob Downloaded from Apple...";
                        File.WriteAllText(nativefolder + "\\Appleblobs\\" + "\\appleresponse.xml", result1.Substring(result1.IndexOf("<?xml"), result1.IndexOf("</plist>") - result1.IndexOf("<?xml") + 8));
                        plistconverter(nativefolder + "\\Appleblobs\\" + "\\appleresponse.xml", nativefolder + "\\Appleblobs\\" + "\\appleresponse.plist");
                        using (Stream stream1 = File.OpenRead(nativefolder + "\\Appleblobs\\" + "\\appleresponse.plist"))
                        using (FileStream fileStream = File.Create(savingprocess))
                        {
                            using (Stream stream2 = new GZipOutputStream(fileStream))
                            {
                                byte[] bArr = new byte[4095];
                                while (InlineAssignHelper<int>(ref i9, stream1.Read(bArr, 0, checked((int)bArr.Length))) != 0)
                                {
                                    stream2.Write(bArr, 0, i9);

                                }
                            }
                        }
                        stream.Dispose();
                        reader.Dispose();
                    }
                    else
                    {
                        this.toolStripStatusblob.Text = "Unknow Error from Apple - No Blob Downloaded";
                        return;
                    }
               }
            }
            catch(WebException err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            { }
        }
        // Fixme this is not working
        private void submittocydia()
        {
            this.toolStripStatusblob.Text = "Submitting blob to Cydia Server...";
            string stccpid = Convert.ToString(cydiachipid);
            string stcboardid = Convert.ToString(BoardID);
            string stcecid = this.txteciddec.Text;
            var uri = new Uri(cydiablobsubmit + stccpid + "/" + stcboardid + "/" + stcecid);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            var service = ServicePointManager.FindServicePoint(uri);
            service.Expect100Continue = false;
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf8";
            request.Headers.Add("HTTP_USER_AGENT", "Winbrella");
            string postData = result1;
            byte[] bytes = Encoding.ASCII.GetBytes(postData);
            request.ContentLength = bytes.Length;
            Stream requeststream = request.GetRequestStream();
            requeststream.Write(bytes, 0, bytes.Length);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var result = reader.ReadToEnd();
            this.toolStripStatusblob.Text = "Blobs Submitted to Cydia Server!";
        }
        public static T InlineAssignHelper<T>(ref T target, T value)
        {
            target = value;
            return value;
        }

        public static void plistconverter(string xml, string plistfile)
        {
            Dictionary<string, object> dictionary = (Dictionary<string, object>)Plist.readPlist(xml);
            Plist.writeBinary(dictionary, plistfile);
            dictionary.Clear();
        }

        private void btncydiadownload_Click(object sender, EventArgs e)
        {
            iDeviceBoard = this.txtboardmodel.Text;
            producttype = this.txtdevicemodel.Text;

            if (lstcydiablobs.SelectedIndex == -1)
            {
                MessageBox.Show("You have not selected any blob to Download","W|NbR3LL@ " + appversion,MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            else
            {
                string selectedblob = "";
                foreach (var item in lstcydiablobs.SelectedItems)
                {
                    selectedblob += item.ToString();
                }
                string blobslist = selectedblob.ToString();
                string num1 = blobslist;
                var num1a = num1.Split(' ')[1].Replace("(", "").Replace(")", "");
                string iosbuild = num1a;
                string iosnum = blobslist.Replace(iosbuild, "").Replace("(", "").Replace(")", "");
                buildid = num1a;
                iosnumber = iosnum;
                requestmanifest();
                cydiamanifestrequest();
            }
        }

        private void btnifaithdownload_Click(object sender, EventArgs e)
        {

            if (lstifaithblobs.SelectedIndex == -1)
            {
                MessageBox.Show("You have not selected any blob to Download", "W|NbR3LL@ " + appversion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ifaithblobdownload();
            }
        }

        private void btnappledownload_Click(object sender, EventArgs e)
        {
            iDeviceBoard = this.txtboardmodel.Text;
            producttype = this.txtdevicemodel.Text;

            if (lstappleblobs.SelectedIndex == -1)
            {
                MessageBox.Show("You have not selected any blob to Download", "W|NbR3LL@ " + appversion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string selectedblob = "";
                foreach (var item in lstappleblobs.SelectedItems)
                {
                    selectedblob += item.ToString();
                }
                string blobslist = selectedblob.ToString();
                string num1 = blobslist;
                var num1a = num1.Split(' ')[1].Replace("(", "").Replace(")", "");
                string iosbuild = num1a;
                string iosnum = blobslist.Replace(iosbuild, "").Replace("(", "").Replace(")", "");
                buildid = num1a;
                iosnumber = iosnum;
                requestmanifest();
                normalapplerequest();
                var stopwatch = Stopwatch.StartNew();
                Thread.Sleep(1000);
                stopwatch.Stop();
                submittocydia();
                File.Delete(nativefolder + "\\Appleblobs\\" + "\\appleresponse.xml");
                File.Delete(nativefolder + "\\Appleblobs\\" + "\\appleresponse.plist");
            }
            
        }

        private void btnbetaapledownload_Click(object sender, EventArgs e)
        {
            iDeviceBoard = this.txtboardmodel.Text;
            producttype = this.txtdevicemodel.Text;

            if (lstbetaapple.SelectedIndex == -1)
            {
                MessageBox.Show("You have not selected any blob to Download", "W|NbR3LL@ " + appversion, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string selectedblob = "";
                foreach (var item in lstbetaapple.SelectedItems)
                {
                    selectedblob += item.ToString();
                }
                string blobslist = selectedblob.ToString();
                string num1 = blobslist;
                var num1a = num1.Split(' ')[1].Replace("(", "").Replace(")", "");
                string iosbuild = num1a;
                string iosnum = blobslist.Replace(iosbuild, "").Replace("(", "").Replace(")", "");
                buildid = num1a;
                iosnumber = iosnum;
                requestmanifest();
                normalapplerequest();
                Thread.Sleep(200);
                File.Delete(nativefolder + "\\Appleblobs\\" + "\\appleresponse.xml");
                File.Delete(nativefolder + "\\Appleblobs\\" + "\\appleresponse.plist");
            }
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            credits crd = new credits();
            crd.Show();
        }

    /*    private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo donate = new ProcessStartInfo("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=F7CKFKT5E6NK8&lc=US&item_name=iDMT&item_number=iDeviceTool&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted");
            Process.Start(donate);
        }*/

        private void btnrecovery_Click(object sender, EventArgs e)
        {
            if(Interface.IsConnected == false)
            {
                MessageBox.Show("No Device Connceted", "W|NbR3LL@ " + appversion,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Interface.Reboot_Device_into_Recovery();
                this.toolStripStatusblob.Text = "Command sent to iDevice";
            }
            
        }

/// <summary>
/// This is where the exit recovery methods are 
/// </summary>
        private void saveEnvironment()
        {
            Thread.Sleep(500);
            startInfo.Arguments = "-c \"saveenv\"";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void setEnvironment()
        {
            Thread.Sleep(500);
            startInfo.Arguments = "-c \"setenv auto-boot true\"";
            process.StartInfo = startInfo;
            process.Start();
        }

        private void rebootDevice()
        {
            Thread.Sleep(500);
            startInfo.Arguments = "-c \"reboot\"";
            process.StartInfo = startInfo;
            process.Start();
        }

        public void exit_recovery()
        {
            startInfo.FileName = nativefolder + "\\s-irecovery.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            this.toolstripconnectinfo.Text = "Command send - iDevice Rebooting...";
            Thread.Sleep(150);
            setEnvironment();
            saveEnvironment();
            rebootDevice();
            Thread.Sleep(150);
            this.toolstripconnectinfo.Text = "Device Rebooted Sucessfully";

        }

        private void btnexitrecovery_Click(object sender, EventArgs e)
        {
            FileInfo check = new FileInfo(nativefolder + "\\s-irecovery.exe");
            //FileInfo check = new FileInfo(".\\s-irecovery.exe");
            if (!check.Exists)
            {
                global.SaveToDisk("s-irecovery.exe", nativefolder + ".\\s-irecovery.exe");
                check.Attributes = FileAttributes.Hidden;
                exit_recovery();
                Thread.Sleep(500);
                File.Delete(nativefolder + "\\s-irecovery");
                //File.Delete(".\\s-irecovery.exe");
            }
            else
            {
                exit_recovery();
                Thread.Sleep(500);
                File.Delete(nativefolder + ".\\s-irecovery");
                //File.Delete(".\\s-irecovery.exe");
            }
        }

    }
}
