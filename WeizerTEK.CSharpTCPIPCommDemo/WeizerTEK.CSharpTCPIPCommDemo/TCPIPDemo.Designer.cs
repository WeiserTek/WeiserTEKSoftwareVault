namespace WeizerTEK.CSharpTCPIPCommDemo
{
    partial class TcpipDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtbxIPAddress = new System.Windows.Forms.TextBox();
            this.txtbxPort = new System.Windows.Forms.TextBox();
            this.txtbxOutgoingMessage = new System.Windows.Forms.TextBox();
            this.lblOutgoingMessage = new System.Windows.Forms.Label();
            this.txtbxIncomingMessage = new System.Windows.Forms.TextBox();
            this.lblIncomingMessage = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtbxErrorHistory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(74, 46);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(58, 13);
            this.lblIPAddress.TabIndex = 0;
            this.lblIPAddress.Text = "IP Address";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(105, 79);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port";
            // 
            // txtbxIPAddress
            // 
            this.txtbxIPAddress.Location = new System.Drawing.Point(138, 46);
            this.txtbxIPAddress.Name = "txtbxIPAddress";
            this.txtbxIPAddress.Size = new System.Drawing.Size(129, 20);
            this.txtbxIPAddress.TabIndex = 2;
            this.txtbxIPAddress.Text = "127.0.0.1";
            // 
            // txtbxPort
            // 
            this.txtbxPort.Location = new System.Drawing.Point(138, 79);
            this.txtbxPort.Name = "txtbxPort";
            this.txtbxPort.Size = new System.Drawing.Size(129, 20);
            this.txtbxPort.TabIndex = 3;
            this.txtbxPort.Text = "23";
            // 
            // txtbxOutgoingMessage
            // 
            this.txtbxOutgoingMessage.Location = new System.Drawing.Point(138, 148);
            this.txtbxOutgoingMessage.Multiline = true;
            this.txtbxOutgoingMessage.Name = "txtbxOutgoingMessage";
            this.txtbxOutgoingMessage.Size = new System.Drawing.Size(357, 95);
            this.txtbxOutgoingMessage.TabIndex = 4;
            // 
            // lblOutgoingMessage
            // 
            this.lblOutgoingMessage.AutoSize = true;
            this.lblOutgoingMessage.Location = new System.Drawing.Point(28, 148);
            this.lblOutgoingMessage.Name = "lblOutgoingMessage";
            this.lblOutgoingMessage.Size = new System.Drawing.Size(96, 13);
            this.lblOutgoingMessage.TabIndex = 5;
            this.lblOutgoingMessage.Text = "Outgoing Message";
            // 
            // txtbxIncomingMessage
            // 
            this.txtbxIncomingMessage.Location = new System.Drawing.Point(138, 262);
            this.txtbxIncomingMessage.Multiline = true;
            this.txtbxIncomingMessage.Name = "txtbxIncomingMessage";
            this.txtbxIncomingMessage.Size = new System.Drawing.Size(357, 87);
            this.txtbxIncomingMessage.TabIndex = 6;
            // 
            // lblIncomingMessage
            // 
            this.lblIncomingMessage.AutoSize = true;
            this.lblIncomingMessage.Location = new System.Drawing.Point(28, 262);
            this.lblIncomingMessage.Name = "lblIncomingMessage";
            this.lblIncomingMessage.Size = new System.Drawing.Size(96, 13);
            this.lblIncomingMessage.TabIndex = 7;
            this.lblIncomingMessage.Text = "Incoming Message";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(294, 46);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(515, 148);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // txtbxErrorHistory
            // 
            this.txtbxErrorHistory.Location = new System.Drawing.Point(138, 368);
            this.txtbxErrorHistory.Multiline = true;
            this.txtbxErrorHistory.Name = "txtbxErrorHistory";
            this.txtbxErrorHistory.Size = new System.Drawing.Size(357, 87);
            this.txtbxErrorHistory.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "User Messages";
            // 
            // TCPIPDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 495);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxErrorHistory);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblIncomingMessage);
            this.Controls.Add(this.txtbxIncomingMessage);
            this.Controls.Add(this.lblOutgoingMessage);
            this.Controls.Add(this.txtbxOutgoingMessage);
            this.Controls.Add(this.txtbxPort);
            this.Controls.Add(this.txtbxIPAddress);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIPAddress);
            this.Name = "TcpipDemo";
            this.Text = "TCPIPDemo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtbxIPAddress;
        private System.Windows.Forms.TextBox txtbxPort;
        private System.Windows.Forms.TextBox txtbxOutgoingMessage;
        private System.Windows.Forms.Label lblOutgoingMessage;
        private System.Windows.Forms.TextBox txtbxIncomingMessage;
        private System.Windows.Forms.Label lblIncomingMessage;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtbxErrorHistory;
        private System.Windows.Forms.Label label1;
    }
}