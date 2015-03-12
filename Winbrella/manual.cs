using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winbrella
{
    unsafe public partial class manual : Form
    {
        public string model;
        winbrella checker = new winbrella();
        public manual()
        {
            InitializeComponent();

        }

        private void cbdevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbdevice.SelectedItem != null)
            {
                global.idevice = this.cbdevice.SelectedItem.ToString();
                switch (global.idevice)
                {
                    case "iPhone":
                        this.cbmodel.Items.Clear();
                        this.cbmodel.Items.Add("iPhone 2G");
                        this.cbmodel.Items.Add("iPhone 3G");
                        this.cbmodel.Items.Add("iPhone 3G[S]");
                        this.cbmodel.Items.Add("iPhone 4");
                        this.cbmodel.Items.Add("iPhone 4 Rev A");
                        this.cbmodel.Items.Add("iPhone 4[CDMA]");
                        this.cbmodel.Items.Add("iPhone 4[S]");
                        this.cbmodel.Items.Add("iPhone 5[GSM]");
                        this.cbmodel.Items.Add("iPhone 5[GLOBAL]");
                        this.cbmodel.Items.Add("iPhone 5[C] GSM");
                        this.cbmodel.Items.Add("iPhone 5[C] GLOBAL");
                        this.cbmodel.Items.Add("iPhone 5[S] GSM");
                        this.cbmodel.Items.Add("iPhone 5[S] GLOBAL");
                        break;
                    case "iPod":
                        this.cbmodel.Items.Clear();
                        this.cbmodel.Items.Add("iPod Touch 1G");
                        this.cbmodel.Items.Add("iPod Touch 2G");
                        this.cbmodel.Items.Add("iPod Touch 3G");
                        this.cbmodel.Items.Add("iPod Touch 4G");
                        this.cbmodel.Items.Add("iPod Touch 5G");
                        break;
                    case "iPad":
                        this.cbmodel.Items.Clear();
                        this.cbmodel.Items.Add("iPad 1G");
                        this.cbmodel.Items.Add("iPad 2 WiFi");
                        this.cbmodel.Items.Add("iPad 2 WiFi Rev A");
                        this.cbmodel.Items.Add("iPad 2 GSM");
                        this.cbmodel.Items.Add("iPad 2 CDMA");
                        this.cbmodel.Items.Add("iPad 3 WiFi");
                        this.cbmodel.Items.Add("iPad 3 CDMA");
                        this.cbmodel.Items.Add("iPad 3 GLOBAL");
                        this.cbmodel.Items.Add("iPad 4 WiFi");
                        this.cbmodel.Items.Add("iPad 4 GSM");
                        this.cbmodel.Items.Add("iPad 4 GLOBAL");
                        this.cbmodel.Items.Add("iPad Air WiFi");
                        this.cbmodel.Items.Add("iPad Air GSM");
                        this.cbmodel.Items.Add("iPad Mini 1G WiFi");
                        this.cbmodel.Items.Add("iPad Mini 1G GSM");
                        this.cbmodel.Items.Add("iPad Mini 1G GLOBAL");
                        this.cbmodel.Items.Add("iPad Mini 2G WiFi");
                        this.cbmodel.Items.Add("iPad Mini 2G GSM");
                        break;
                }
                this.cbmodel.DroppedDown = true;
            }
            else
            {
                return;
            } 
        }

        private void cbmodel_SelectedIndexChanged(object sender, EventArgs e)
        {
            global.model = this.cbmodel.SelectedItem.ToString();
            if (global.model == "iPhone 2G")
            {
                global.identifier = "iPhone1,1";
                global.board = "m68ap";
                global.BoardID = 0;
                global.ChipID = 0;
                global.cydiachipid = 0;
            }
            else if (global.model == "iPhone 3G")
            {
                global.identifier = "iPhone1,2";
                global.board = "n82ap";
                global.BoardID = 4;
                global.ChipID = 8900;
                global.cydiachipid = 35072;
            }
            else if (global.model == "iPhone 3G[S]")
            {
                global.identifier = "iPhone2,1";
                global.board = "n88ap";
                global.BoardID = 4;
                global.ChipID = 8900;
                global.cydiachipid = 35072;
            }
            else if (global.model == "iPhone 4")
            {
                global.identifier = "iPhone3,1";
                global.board = "n90ap";
                global.BoardID = 0;
                global.ChipID = 8930;
                global.cydiachipid = 35120;
            }
            else if (global.model == "iPhone 4 Rev A")
            {
                global.identifier = "iPhone3,2";
                global.board = "n90bap";
                global.BoardID = 4;
                global.ChipID = 8930;
                global.cydiachipid = 35120;
            }
            else if (global.model == "iPhone 4[CDMA]")
            {
                global.identifier = "iPhone3,3";
                global.board = "n92ap";
                global.BoardID = 6;
                global.ChipID = 8930;
                global.cydiachipid = 35120;
            }
            else if (global.model == "iPhone 4[S]")
            {
                global.identifier = "iPhone4,1";
                global.board = "n94ap";
                global.BoardID = 8;
                global.ChipID = 8940;
                global.cydiachipid = 35136;
            }
            else if (global.model == "iPhone 5[GSM]")
            {
                global.identifier = "iPhone5,1";
                global.board = "n41ap";
                global.BoardID = 0;
                global.ChipID = 8950;
                global.cydiachipid = 35152;
            }
            else if (global.model == "iPhone 5[GLOBAL]")
            {
                global.identifier = "iPhone5,2";
                global.board = "n42ap";
                global.BoardID = 2;
                global.ChipID = 8950;
                global.cydiachipid = 35152;
            }
            else if (global.model == "iPhone 5[C] GSM")
            {
                global.identifier = "iPhone5,3";
                global.board = "n48ap";
                global.BoardID = 10;
                global.ChipID = 8950;
                global.cydiachipid = 35152;
            }
            else if (global.model == "iPhone 5[C] GLOBAL")
            {
                global.identifier = "iPhone5,4";
                global.board = "n49ap";
                global.BoardID = 14;
                global.ChipID = 8950;
                global.cydiachipid = 35152;
            }
            else if (global.model == "iPhone 5[S] GSM")
            {
                global.identifier = "iPhone6,1";
                global.board = "n51ap";
                global.BoardID = 0;
                global.ChipID = 8960;
                global.cydiachipid = 35168;
            }
            else if (global.model == "iPhone 5[S] GLOBAL")
            {
                global.identifier = "iPhone6,2";
                global.board = "n53ap";
                global.BoardID = 2;
                global.ChipID = 8960;
                global.cydiachipid = 35168;
            }
            else if (global.model == "iPod touch 1G")
            {
                global.identifier = "iPod1,1";
                global.board = "n45ap";
                global.BoardID = 0;
                global.ChipID = 0;
                global.cydiachipid = 0;
            }
            else if (global.model == "iPod touch 2G")
            {
                global.identifier = "iPod2,1";
                global.board = "n72ap";
                global.BoardID = 0;
                global.ChipID = 8720;
                global.cydiachipid = 34592;
            }
            else if (global.model == "iPod touch 3G")
            {
                global.identifier = "iPod3,1";
                global.board = "n18ap";
                global.BoardID = 2;
                global.ChipID = 8922;
                global.cydiachipid = 35106;
            }
            else if (global.model == "iPod touch 4G")
            {
                global.identifier = "iPod4,1";
                global.board = "n81ap";
                global.BoardID = 8;
                global.ChipID = 8930;
                global.cydiachipid = 35120;
            }
            else if (global.model == "iPod touch 5G")
            {
                global.identifier = "iPod5,1";
                global.board = "n78ap";
                global.BoardID = 0;
                global.ChipID = 8942;
                global.cydiachipid = 35138;
            }
            else if (global.model == "iPad 1G")
            {
                global.identifier = "iPad1,1";
                global.board = "k48ap";
                global.BoardID = 2;
                global.ChipID = 8930;
                global.cydiachipid = 35120;
            }
            else if (global.model == "iPad 2 WiFi")
            {
                global.identifier = "iPad2,1";
                global.board = "k93ap";
                global.BoardID = 4;
                global.ChipID = 8940;
                global.cydiachipid = 35136;
            }
            else if (global.model == "iPad 2 GSM")
            {
                global.identifier = "iPad2,2";
                global.board = "k94ap";
                global.BoardID = 6;
                global.ChipID = 8940;
                global.cydiachipid = 35136;
            }
            else if (global.model == "iPad 2 CDMA")
            {
                global.identifier = "iPad2,3";
                global.board = "k95ap";
                global.BoardID = 2;
                global.ChipID = 8940;
                global.cydiachipid = 35136;
            }
            else if (global.model == "iPad 2 WiFi Rev A")
            {
                global.identifier = "iPad2,4";
                global.board = "k93aap";
                global.BoardID = 6;
                global.ChipID = 8942;
                global.cydiachipid = 35138;
            }
            else if (global.model == "iPad 3 WiFi")
            {
                global.identifier = "iPad3,1";
                global.board = "j1ap";
                global.BoardID = 0;
                global.ChipID = 8945;
                global.cydiachipid = 35141;

            }
            else if (global.model == "iPad 3 GLOBAL")
            {
                global.identifier = "iPad3,2";
                global.board = "j2ap";
                global.BoardID = 2;
                global.ChipID = 8945;
                global.cydiachipid = 35141;
            }
            else if (global.model == "iPad 3 GSM")
            {
                global.identifier = "iPad3,3";
                global.board = "j2aap";
                global.BoardID = 4;
                global.ChipID = 8945;
                global.cydiachipid = 35141;
            }
            else if (global.model == "iPad 4 WiFi")
            {
                global.identifier = "iPad3,4";
                global.board = "p101ap";
                global.BoardID = 0;
                global.ChipID = 8955;
                global.cydiachipid = 35157;
            }
            else if (global.model == "iPad 4 GSM")
            {
                global.identifier = "iPad3,5";
                global.board = "p102ap";
                global.BoardID = 2;
                global.ChipID = 8955;
                global.cydiachipid = 35157;
            }
            else if (global.model == "iPad 4 GLOBAL")
            {
                global.identifier = "iPad3,6";
                global.board = "p103ap";
                global.BoardID = 4;
                global.ChipID = 8955;
                global.cydiachipid = 35157;
            }
            else if (global.model == "iPad Air WiFi")
            {
                global.identifier = "iPad4,1";
                global.board = "j71ap";
                global.BoardID = 16;
                global.ChipID = 8960;
                global.cydiachipid = 35168;
            }
            else if (global.model == "iPad Air GSM")
            {
                global.identifier = "iPad4,2";
                global.board = "j72ap";
                global.BoardID = 18;
                global.ChipID = 8960;
                global.cydiachipid = 35168;
            }
            else if (global.model == "iPad Mini 1G WiFi")
            {
                global.identifier = "iPad2,5";
                global.board = "p105ap";
                global.BoardID = 10;
                global.ChipID = 8942;
                global.cydiachipid = 35138;
            }
            else if (global.model == "iPad Mini 1G GSM")
            {
                global.identifier = "iPad2,6";
                global.board = "p106ap";
                global.BoardID = 12;
                global.ChipID = 8942;
                global.cydiachipid = 35138;
            }
            else if (global.model == "iPad Mini 1G GLOBAL")
            {
                global.identifier = "iPad2,7";
                global.board = "p107ap";
                global.BoardID = 14;
                global.ChipID = 8942;
                global.cydiachipid = 35138;
            }
            else if (global.model == "iPad Mini 2G WiFi")
            {
                global.identifier = "iPad4,4";
                global.board = "j85ap";
                global.BoardID = 10;
                global.ChipID = 8960;
                global.cydiachipid = 35168;
            }
            else if (global.model == "iPad Mini 2G GSM")
            {
                global.identifier = "iPad4,5";
                global.board = "j86ap";
                global.BoardID = 12;
                global.ChipID = 8960;
                global.cydiachipid = 35168;
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
        //   MessageBox.Show(global.identifier + global.idevice + global.board + global.BoardID + global.ChipID + global.model + global.cydiachipid);
           this.Close();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            global.identifier = string.Empty;
            global.board = string.Empty;
            global.BoardID = 0;
            global.ChipID = 0;
            global.cydiachipid = 0;
            this.cbmodel.Items.Clear();
            this.Hide();

        }
    }
}
