using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

namespace IPScanner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //Threads
        Thread ScanThread; /* 1 */

        //IPv4 Octet Fix Format Method
        private string IPFixFormat(string Octet)
        {
            for (int Index = 0; Index <= Octet.Length; Index++)
            {
                if (Octet[0] == '0') { Octet = Octet.Substring(1, Octet.Length - 1); /* Trim String */ }

                else { break; } /* Stop When Other Digit Appears */      
            }

            return Octet;
        }

        //IPv4 Address Validation (IPAdress.TryParse is Not Working Properly)
        private bool IPValidation(string IPAddress)
        {
            string[] IPAddressSplit = IPAddress.Split('.');

            if (IPAddressSplit.Length != 4) { return false; } /* Return False */

            else
            {
                for (int Index = 0; Index < 4; Index++)
                {
                    int Octet = 0;
                        
                    bool IntValidation = Int32.TryParse(IPAddressSplit[Index], out Octet);

                    if (IntValidation == false) { return false; } /* Return False */

                    if (Octet > 255) { return false; } /* Return False */

                    if ((Index == 0) &&(Octet == 0)) { return false; } /* Return False - 1st Octet Validation */
                }
            }

            return true; /* Return True */
        }

        //Text Colors Enums
        enum TextColors { Black, Green, Red };

        //Rich Text Box AppendText
        private void RTBAppendText(string Text, TextColors Color)
        {
            switch (Color)
            {
                case TextColors.Black:
                    RTB.Invoke(new MethodInvoker(delegate { RTB.SelectionColor = System.Drawing.Color.Black; RTB.AppendText(Text); }));
                    break;

                case TextColors.Green:
                    RTB.Invoke(new MethodInvoker(delegate { RTB.SelectionColor = System.Drawing.Color.Green; RTB.AppendText(Text); }));
                    break;

                case TextColors.Red:
                    RTB.Invoke(new MethodInvoker(delegate { RTB.SelectionColor = System.Drawing.Color.Red; RTB.AppendText(Text); }));
                    break;

                default:
                    break;
            }                  
        }

        //Rich Text Box Clear
        private void RTBClear()
        {
            RTB.Invoke(new MethodInvoker(delegate { RTB.Clear(); }));
        }

        //Rich Text Box Refresh
        private void RTBRefresh()
        {
            RTB.Invoke(new MethodInvoker(delegate { RTB.Refresh(); }));
        }

        //Action Button Swich Action (Scan\Stop)
        int Action = 0; /* Default = Scan */

        private void ActionButtonSwich()
        {
            if (Action == 0) /* Scan */
            {
                ActionBtn.Invoke(new MethodInvoker(delegate 
                { 
                    ActionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));

                    ActionBtn.Text = "Stop";
                }));

                Action = 1; /* Switch Action */
            }

            else if (Action == 1) /* Stop */
            {
                ActionBtn.Invoke(new MethodInvoker(delegate
                {
                    ActionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));

                    ActionBtn.Text = "Scan";
                }));

                Action = 0; /* Switch Action */
            }
        }

        //Scan Method
        public void Scan()
        {
            ActionButtonSwich(); /* Scan */

            RTBClear(); 

            //Source Address
            string SourceAddress = this.SourceText.Text;

            //Time Out
            int TimeOut = 0;

            Int32.TryParse(this.TimeOutText.Text, out TimeOut);

            if (this.TimeOutText.Text.Contains(' '))
            {
                RTBAppendText("[Error] Invalid Timeout Expression!" + "\n", TextColors.Black);

                TimeOut = 0; /* Set to Default Timeout */
            }

            if (TimeOut == 0)
            {
                TimeOut = 1000;

                RTBAppendText("Timeout Set to 1000ms (Default)" + " \n", TextColors.Black);

                RTBRefresh();
            }

            else { RTBAppendText("Timeout Set to " + TimeOut.ToString() + "ms" + "\n", TextColors.Black); }

            //Destination Address
            string DestAddress = this.DestText.Text;

            //# Validation #
            bool SourceValidation = IPValidation(SourceAddress);

            bool DestValidation = IPValidation(DestAddress);

            if ((SourceValidation == false) || (DestValidation == false))
            {
                RTBAppendText("Source Address: " + SourceAddress + "\n", TextColors.Black);

                RTBAppendText("Destination Address: " + DestAddress + "\n", TextColors.Black);

                RTBAppendText("[Error] Invalid Source or Destination Addresses!" + "\n", TextColors.Black);

                RTBRefresh();
            }

            else
            {
                long SourceLong = Convert.ToInt64(SourceAddress.Replace(".", ""));

                long DestLong = Convert.ToInt64(DestAddress.Replace(".", ""));

                if (SourceLong >= DestLong)
                {
                    RTBAppendText("Source Address: " + SourceAddress + "\n", TextColors.Black);

                    RTBAppendText("Destination Address: " + DestAddress + "\n", TextColors.Black);

                    RTBAppendText("[Error] Invalid IP Addresses Range!" + "\n", TextColors.Black);

                    RTBRefresh();
                }

                else
                {
                    //Fix IP Address Format

                    //Source
                    string[] SourceSplit = SourceAddress.Split('.');
                    string SourceOctetOne = IPFixFormat(SourceSplit[0]);
                    string SourceOctetTwo = IPFixFormat(SourceSplit[1]);
                    string SourceOctetThree = IPFixFormat(SourceSplit[2]);
                    string SourceOctetFour = IPFixFormat(SourceSplit[3]);
                    SourceAddress = SourceOctetOne + "." + SourceOctetTwo + "." + SourceOctetThree + "." + SourceOctetFour; /* Modify Source Address */
                    System.Net.IPAddress SourceIP = System.Net.IPAddress.Parse(SourceAddress); /* Source IP */

                    //Destination
                    string[] DestSplit = DestAddress.Split('.');
                    string DestOctetOne = IPFixFormat(DestSplit[0]);
                    string DestOctetTwo = IPFixFormat(DestSplit[1]);
                    string DestOctetThree = IPFixFormat(DestSplit[2]);
                    string DestOctetFour = IPFixFormat(DestSplit[3]);
                    DestAddress = DestOctetOne + "." + DestOctetTwo + "." + DestOctetThree + "." + DestOctetFour; /* Modify Destination Address */
                    System.Net.IPAddress DestIP = System.Net.IPAddress.Parse(DestAddress); /* Destination IP */

                    Byte[] SourceBytes = SourceIP.GetAddressBytes();

                    while (true)
                    {
                        SourceBytes[3] = (byte)(SourceBytes[3] + 1); /* 4th Octet */

                        if (SourceBytes[3] == 0)
                        {
                            SourceBytes[2] = (byte)(SourceBytes[2] + 1); /* 3rd Octet */

                            if (SourceBytes[2] == 0)
                            {
                                SourceBytes[1] = (byte)(SourceBytes[1] + 1); /* 2nd Octet */

                                if (SourceBytes[1] == 0)
                                {
                                    SourceBytes[0] = (byte)(SourceBytes[0] + 1); /* 1st Octet */
                                }
                            }
                        }

                        string CurrentAddress = SourceBytes[0].ToString() + "." + SourceBytes[1].ToString() + "." + SourceBytes[2].ToString() + "." + SourceBytes[3].ToString();

                        //Test Communication
                        Ping Pinger = new Ping();

                        PingReply Reply = Pinger.Send(CurrentAddress, TimeOut);

                        if (Reply.Status == IPStatus.Success)
                        {
                            RTBAppendText("[" + CurrentAddress + "]" + " Connection Established!" + "\n", TextColors.Green);
                        }

                        else
                        {
                            RTBAppendText("[" + CurrentAddress + "]" + " Device is Unavailable!" + "\n", TextColors.Red);
                        }

                        Pinger.Dispose();

                        RTBRefresh();

                        if (CurrentAddress == DestAddress) { break; /* Break Condition */ }                        
                    }
                }
            }

            RTBAppendText("Finished!" + "\n", TextColors.Black);

            ActionButtonSwich(); /* Stop */
        }

        private void ActionBtnClick(object sender, EventArgs e)
        {
            if (Action == 0) /* Scan */
            {
                ScanThread = new Thread(new ThreadStart(Scan));

                ScanThread.IsBackground = true;

                ScanThread.Start();
            } 

            else if (Action == 1) /* Stop */
            {
                ActionButtonSwich();

                ScanThread.Suspend();

                ScanThread.Abort();

                RTBAppendText("Stopped!" + "\n", TextColors.Black);
            } 
        }

        private void ExitBtnClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread(); /* Exit Application */
        }

        private void RTBTextChange(object sender, EventArgs e)
        {
            RTB.SelectionStart = RTB.Text.Length;

            RTB.ScrollToCaret();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Check Multiple Instances
            bool SingleInstance;

            Mutex Mutex = new Mutex(true, "Application", out SingleInstance);

            if (!SingleInstance)
            {
                MessageBox.Show("Instance of 'IPv4 Scanner' Is Already Running !", "IPv4 Scanner");

                //Exit Application
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
