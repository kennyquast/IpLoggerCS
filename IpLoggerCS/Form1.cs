using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpLoggerCS
{
    public partial class Form1 : Form
    {
        public static class Globals
        {
            public static string CurrentIpAddress = "999.999.999.999"; //create a new Ipaddress to be modified later
            public static string PreviousIPAddress = "000.000.000.000";

        }
        public Form1()
        {
            InitializeComponent();
            //
        }


        public static string ComparePublicIP()
        { 
            if (Globals.PreviousIPAddress == Globals.CurrentIpAddress)
                {
            
                        MessageBox.Show("IP's Match - Previous IP :" + Globals.PreviousIPAddress + " | Current IP: " + Globals.CurrentIpAddress);
                            return null;
                }
            else 
                {
                        MessageBox.Show("IP's DO NOT Match - Previous IP :" + Globals.PreviousIPAddress + " | Current IP: " + Globals.CurrentIpAddress);
                            return null;

                }


        }



                
            public static string GetPublicIP()
        {
            //Visit a site, and get the IP address we're currently using. and trim it up to a usable format.
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            Globals.CurrentIpAddress = a4;
            return a4;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetPublicIP();
            LblCurrentIp.Text = "Current Ip Address : " +  Globals.CurrentIpAddress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComparePublicIP();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Globals.PreviousIPAddress = Globals.CurrentIpAddress;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Globals.PreviousIPAddress = "123.456.789";
        }
    }
}
