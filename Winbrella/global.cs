using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Numerics;
using System.IO;
using CFManzana;
using System.Reflection;
using System.Diagnostics;


namespace Winbrella
{
    class global
    {
        public static bool open = false;
        public static string idevice;
        public static string model;
        public static string board;
        public static string identifier;
        public static int BoardID;
        public static int ChipID;
        public static int cydiachipid;

        public static void SaveToDisk(string resourceName, string fileName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] sArr = assembly.GetManifestResourceNames();
            for (int i = 0; i < checked((int)sArr.Length); i++)
            {
                string s = sArr[i];
                if (s.ToLower().IndexOf(resourceName.ToLower()) != -1)
                {
                    using (Stream stream = assembly.GetManifestResourceStream(s))
                    {
                        if (stream != null)
                        {
                            using (BinaryReader binaryReader = new BinaryReader(stream))
                            {
                                byte[] bArr = binaryReader.ReadBytes((int)stream.Length);
                                using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                                {
                                    using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                                    {
                                        binaryWriter.Write(bArr);
                                        goto label_1;
                                    }
                                    goto label_1;
                                }
                            }
                        }
                    label_1:
                        goto label_2;
                    }
                    break;
                }
            }
        label_2:
            while (!File_Exists(fileName))
            {
                Application.DoEvents();
            }
        }

        public static bool File_Exists(string strFile)
        {
            bool functionReturnValue = false;

            if (strFile.Length != 0)
            {
                FileInfo oFile = new FileInfo(strFile);
                if (oFile.Exists == true)
                {
                    functionReturnValue = true;
                }
                else
                {
                    functionReturnValue = false;
                }
            }
            return functionReturnValue;
        }

        // Delay Method by iH8sn0w from iFaith - github
        public static void Delay(double dblSecs)
        {
            const double OneSec = 1.0 / (1440.0 * 60.0);
            System.DateTime dblWaitTil = default(System.DateTime);
            DateAndTime.Now.AddSeconds(OneSec);
            dblWaitTil = DateAndTime.Now.AddSeconds(OneSec).AddSeconds(dblSecs);
            while (!(DateAndTime.Now > dblWaitTil))
            {
                Application.DoEvents();
            }
        }

    }
}
