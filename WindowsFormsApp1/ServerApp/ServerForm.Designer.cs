﻿namespace WindowsFormsApp1
{
    partial class ServerForm
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
            this.btnListen = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.txtIPAdress = new System.Windows.Forms.TextBox();
            this.txtPortNr = new System.Windows.Forms.TextBox();
            this.lblPortNr = new System.Windows.Forms.Label();
            this.txtBufferSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChatList
            // 
            this.ChatList.FormattingEnabled = true;
            this.ChatList.HorizontalScrollbar = true;
            this.ChatList.ItemHeight = 32;
            this.ChatList.Location = new System.Drawing.Point(22, 20);
            this.ChatList.Name = "ChatList";
            this.ChatList.Size = new System.Drawing.Size(613, 484);
            this.ChatList.TabIndex = 0;
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(664, 332);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(232, 46);
            this.btnListen.TabIndex = 1;
            this.btnListen.Text = "Start Server";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(22, 525);
            this.txtMessage.MaxLength = 50;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(482, 39);
            this.txtMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSend.Location = new System.Drawing.Point(517, 521);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(118, 46);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblServerIP
            // 
            this.lblServerIP.Location = new System.Drawing.Point(667, 26);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(229, 35);
            this.lblServerIP.TabIndex = 6;
            this.lblServerIP.Text = "ServerIP";
            // 
            // txtIPAdress
            // 
            this.txtIPAdress.Location = new System.Drawing.Point(667, 77);
            this.txtIPAdress.Name = "txtIPAdress";
            this.txtIPAdress.Size = new System.Drawing.Size(229, 39);
            this.txtIPAdress.TabIndex = 7;
            this.txtIPAdress.Text = "127.0.0.1";
            // 
            // txtPortNr
            // 
            this.txtPortNr.Location = new System.Drawing.Point(666, 169);
            this.txtPortNr.Name = "txtPortNr";
            this.txtPortNr.Size = new System.Drawing.Size(229, 39);
            this.txtPortNr.TabIndex = 8;
            this.txtPortNr.Text = "49152";
            this.txtPortNr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly_KeyPress);
            // 
            // lblPortNr
            // 
            this.lblPortNr.Location = new System.Drawing.Point(666, 131);
            this.lblPortNr.Name = "lblPortNr";
            this.lblPortNr.Size = new System.Drawing.Size(229, 35);
            this.lblPortNr.TabIndex = 9;
            this.lblPortNr.Text = "Port nummer:";
            // 
            // txtBufferSize
            // 
            this.txtBufferSize.Location = new System.Drawing.Point(669, 268);
            this.txtBufferSize.Name = "txtBufferSize";
            this.txtBufferSize.Size = new System.Drawing.Size(229, 39);
            this.txtBufferSize.TabIndex = 11;
            this.txtBufferSize.Text = "1024";
            this.txtBufferSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly_KeyPress);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(669, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 35);
            this.label1.TabIndex = 12;
            this.label1.Text = "Buffer size:";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 654);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBufferSize);
            this.Controls.Add(this.lblPortNr);
            this.Controls.Add(this.txtPortNr);
            this.Controls.Add(this.txtIPAdress);
            this.Controls.Add(this.lblServerIP);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.ChatList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ServerForm";
            this.Text = "chatApp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ListBox ChatList;
        private System.Windows.Forms.Label lblPortNr;
        private System.Windows.Forms.TextBox txtPortNr;
        private System.Windows.Forms.TextBox txtBufferSize;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.TextBox txtIPAdress;
        private System.Windows.Forms.Label label1;
    }
}