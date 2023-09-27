namespace WOL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            txt_ip = new TextBox();
            lb_ip = new Label();
            txt_port = new TextBox();
            lb_port = new Label();
            panel2 = new Panel();
            btnSend = new Button();
            panel3 = new Panel();
            txt_mac = new MaskedTextBox();
            lb_mac = new Label();
            lb_pcStatus = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(txt_ip);
            panel1.Controls.Add(lb_ip);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 5);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(266, 40);
            panel1.TabIndex = 0;
            // 
            // txt_ip
            // 
            txt_ip.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_ip.Location = new Point(98, 8);
            txt_ip.Margin = new Padding(0, 0, 15, 0);
            txt_ip.Name = "txt_ip";
            txt_ip.PlaceholderText = "Enter IP or Hostname";
            txt_ip.Size = new Size(153, 23);
            txt_ip.TabIndex = 1;
            txt_ip.TextChanged += txt_ip_TextChanged;
            // 
            // lb_ip
            // 
            lb_ip.AutoSize = true;
            lb_ip.Location = new Point(15, 12);
            lb_ip.Name = "lb_ip";
            lb_ip.Size = new Size(80, 15);
            lb_ip.TabIndex = 0;
            lb_ip.Text = "IP/Hostname:";
            // 
            // txt_port
            // 
            txt_port.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_port.Location = new Point(98, 8);
            txt_port.Margin = new Padding(0, 0, 15, 0);
            txt_port.Name = "txt_port";
            txt_port.PlaceholderText = "Enter Port (default: 9)";
            txt_port.Size = new Size(76, 23);
            txt_port.TabIndex = 1;
            txt_port.Text = "9";
            txt_port.TextChanged += txt_port_TextChanged;
            // 
            // lb_port
            // 
            lb_port.AutoSize = true;
            lb_port.Location = new Point(15, 12);
            lb_port.Name = "lb_port";
            lb_port.Size = new Size(32, 15);
            lb_port.TabIndex = 0;
            lb_port.Text = "Port:";
            // 
            // panel2
            // 
            panel2.Controls.Add(txt_port);
            panel2.Controls.Add(lb_port);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(5, 45);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(266, 40);
            panel2.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(104, 154);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(txt_mac);
            panel3.Controls.Add(lb_mac);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(5, 85);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(266, 40);
            panel3.TabIndex = 3;
            // 
            // txt_mac
            // 
            txt_mac.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txt_mac.Location = new Point(100, 9);
            txt_mac.Margin = new Padding(0, 0, 15, 0);
            txt_mac.Mask = "AA-AA-AA-AA-AA-AA";
            txt_mac.Name = "txt_mac";
            txt_mac.Size = new Size(151, 23);
            txt_mac.TabIndex = 1;
            txt_mac.TextChanged += txt_mac_TextChanged;
            // 
            // lb_mac
            // 
            lb_mac.AutoSize = true;
            lb_mac.Location = new Point(15, 12);
            lb_mac.Name = "lb_mac";
            lb_mac.Size = new Size(82, 15);
            lb_mac.TabIndex = 0;
            lb_mac.Text = "MAC Address:";
            // 
            // lb_pcStatus
            // 
            lb_pcStatus.AutoSize = true;
            lb_pcStatus.Location = new Point(20, 139);
            lb_pcStatus.Name = "lb_pcStatus";
            lb_pcStatus.Size = new Size(43, 15);
            lb_pcStatus.TabIndex = 4;
            lb_pcStatus.Text = "Offline";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(276, 185);
            Controls.Add(lb_pcStatus);
            Controls.Add(btnSend);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Padding = new Padding(5);
            Text = "Wake on LAN";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txt_ip;
        private Label lb_ip;
        private TextBox txt_port;
        private Label lb_port;
        private Panel panel2;
        private Button btnSend;
        private Panel panel3;
        private MaskedTextBox txt_mac;
        private Label lb_mac;
        private Label lb_pcStatus;
    }
}