using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;

namespace WOL
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer statusCheckTimer = new System.Windows.Forms.Timer();
        private bool OnFlying = false;
        private Ping ping = new Ping();
        private ConfigManager configManager = new ConfigManager();
        public Form1()
        {
            InitializeComponent();
            InitializeTimer();

            ping.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);

            InitializeConfig();
        }

        private void InitializeConfig()
        {
            txt_ip.Text = configManager.Config.txt_ip;
            txt_mac.Text = configManager.Config.txt_mac;
            txt_port.Text = configManager.Config.txt_port ?? "9";
        }
        /// <summary>
        /// Serialize the input ip hostname
        /// </summary>
        /// <returns>string</returns>
        private string? GetIpAddress()
        {
            string inputIp = txt_ip.Text;
            if (string.IsNullOrEmpty(inputIp)) return null;

            if (ValidateIPv4(inputIp)) return inputIp;
            try
            {
                IPAddress[] ips = Dns.GetHostAddresses(inputIp);

                return ips[0].ToString();
            }
            catch
            {
                return null;
            }

        }

        private void InitializeTimer()
        {
            statusCheckTimer.Interval = 1000;
            statusCheckTimer.Tick += new EventHandler(StatusCheckTimer_Tick);
            statusCheckTimer.Start();
        }

        private void StatusCheckTimer_Tick(object sender, EventArgs e)
        {
            if (OnFlying) return;
            string? ip = GetIpAddress();
            if (ip == null) return;

            OnFlying = true;
            IPAddress address = IPAddress.Parse(ip);
            try
            {

                // Wait 5 seconds for a reply.
                int timeout = 5000;
                ping.SendAsync(address, timeout);
                return;
            }
            catch (PingException)
            {
                return;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string? ip = GetIpAddress();
            if (string.IsNullOrEmpty(ip)) return;

            IPAddress address = IPAddress.Parse(ip);
            WOL client = new WOL();
            client.Connect(address, 9);
            client.SetClientToBrodcastMode();
            client.MacAddress = Regex.Replace(txt_mac.Text, "-", "");
            client.SendMagicPacket();
            client.Close();

            MessageBox.Show($"Đã gửi Magic Packet đến {txt_ip.Text}:{txt_port.Text}({txt_mac.Text})");
        }

        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            OnFlying = false;

            if (e.Cancelled || e.Error != null || e.Reply == null)
            {
                lb_pcStatus.Text = "Offline";
                lb_pcStatus.ForeColor = Color.Red;
                return;
            }

            PingReply reply = e.Reply;

            bool isSuccess = reply.Status == IPStatus.Success;
            if (isSuccess)
            {
                lb_pcStatus.Text = "Online";
                lb_pcStatus.ForeColor = Color.Green;
            }
            else
            {
                lb_pcStatus.Text = "Offline";
                lb_pcStatus.ForeColor = Color.Red;
            }
        }

        public static bool ValidateIPv4(string ip)
        {
            IPAddress address;
            return ip != null && ip.Count(c => c == '.') == 3 &&
                IPAddress.TryParse(ip, out address);
        }

        private void txt_ip_TextChanged(object sender, EventArgs e)
        {
            configManager.SetValue(txt_ip.Name, txt_ip.Text);
        }

        private void txt_port_TextChanged(object sender, EventArgs e)
        {
            configManager.SetValue(txt_port.Name, txt_port.Text);
        }

        private void txt_mac_TextChanged(object sender, EventArgs e)
        {
            configManager.SetValue(txt_mac.Name, txt_mac.Text);
        }
    }
}