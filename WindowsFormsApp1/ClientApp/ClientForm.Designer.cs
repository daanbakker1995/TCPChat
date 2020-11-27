using System;
using System.Windows.Forms;

namespace ClientApp
{
    partial class ClientForm
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
            this.ChatList = new System.Windows.Forms.ListBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.LabelChatserverIP = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBufferSize = new System.Windows.Forms.TextBox();
            this.lblBufferSize = new System.Windows.Forms.Label();
            this.txtPortNr = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.LabelUsername = new System.Windows.Forms.Label();
            this.lblPortNumber = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatList
            // 
            this.ChatList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.ChatList.FormattingEnabled = true;
            this.ChatList.HorizontalScrollbar = true;
            this.ChatList.ItemHeight = 29;
            this.ChatList.Location = new System.Drawing.Point(22, 20);
            this.ChatList.Name = "ChatList";
            this.ChatList.Size = new System.Drawing.Size(613, 497);
            this.ChatList.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(22, 548);
            this.txtMessage.MaxLength = 50;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(482, 39);
            this.txtMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSend.Location = new System.Drawing.Point(517, 544);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(118, 46);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Verstuur";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(23, 195);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(191, 39);
            this.txtServerIP.TabIndex = 4;
            this.txtServerIP.Text = "127.0.0.1";
            this.txtServerIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly_KeyPress);
            // 
            // LabelChatserverIP
            // 
            this.LabelChatserverIP.Location = new System.Drawing.Point(15, 148);
            this.LabelChatserverIP.Name = "LabelChatserverIP";
            this.LabelChatserverIP.Size = new System.Drawing.Size(183, 44);
            this.LabelChatserverIP.TabIndex = 5;
            this.LabelChatserverIP.Text = "Chatserver IP:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(15, 457);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(202, 49);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Verbind";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBufferSize);
            this.groupBox1.Controls.Add(this.lblBufferSize);
            this.groupBox1.Controls.Add(this.txtPortNr);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.LabelUsername);
            this.groupBox1.Controls.Add(this.lblPortNumber);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.LabelChatserverIP);
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Location = new System.Drawing.Point(667, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 525);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect met server";
            // 
            // txtBufferSize
            // 
            this.txtBufferSize.Location = new System.Drawing.Point(23, 378);
            this.txtBufferSize.Name = "txtBufferSize";
            this.txtBufferSize.Size = new System.Drawing.Size(193, 39);
            this.txtBufferSize.TabIndex = 13;
            this.txtBufferSize.Text = "1024";
            this.txtBufferSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly_KeyPress);
            // 
            // lblBufferSize
            // 
            this.lblBufferSize.Location = new System.Drawing.Point(23, 342);
            this.lblBufferSize.Name = "lblBufferSize";
            this.lblBufferSize.Size = new System.Drawing.Size(183, 44);
            this.lblBufferSize.TabIndex = 12;
            this.lblBufferSize.Text = "Buffer Groote:";
            // 
            // txtPortNr
            // 
            this.txtPortNr.Location = new System.Drawing.Point(23, 284);
            this.txtPortNr.Name = "txtPortNr";
            this.txtPortNr.Size = new System.Drawing.Size(193, 39);
            this.txtPortNr.TabIndex = 11;
            this.txtPortNr.Text = "49152";
            this.txtPortNr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly_KeyPress);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(23, 92);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(194, 39);
            this.txtUserName.TabIndex = 10;
            this.txtUserName.Text = "Gebruiker123445";
            // 
            // LabelUsername
            // 
            this.LabelUsername.Location = new System.Drawing.Point(14, 44);
            this.LabelUsername.Name = "LabelUsername";
            this.LabelUsername.Size = new System.Drawing.Size(195, 45);
            this.LabelUsername.TabIndex = 9;
            this.LabelUsername.Text = "Gebruikersnaam:";
            // 
            // lblPortNumber
            // 
            this.lblPortNumber.Location = new System.Drawing.Point(14, 253);
            this.lblPortNumber.Name = "lblPortNumber";
            this.lblPortNumber.Size = new System.Drawing.Size(183, 44);
            this.lblPortNumber.TabIndex = 7;
            this.lblPortNumber.Text = "Portnummer:";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(943, 654);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.ChatList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ClientForm";
            this.Text = "ChatClient";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblPortNumber;
        private System.Windows.Forms.Label LabelUsername;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label LabelChatserverIP;
        private System.Windows.Forms.ListBox ChatList;
        private System.Windows.Forms.TextBox txtPortNr;
        private System.Windows.Forms.Label lblBufferSize;
        private System.Windows.Forms.TextBox txtBufferSize;
    }
}