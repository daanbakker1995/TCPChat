using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ServerForm : Form
    {
        List<TcpClient> _tcpClients = new List<TcpClient>();
        TcpListener _tcpListener;
        private string _endOfTransitionCharacter = "@-_@";
        
        protected delegate void UpdateChat(string message);

        public ServerForm()
        {
            InitializeComponent();
        }

        /**
         * Add message to chatlist
         */
        private void AddMessage(string message)
        {
            if (ChatList.InvokeRequired)
            {
                ChatList.Invoke(new UpdateChat(UpdateDisplay), message);
            }
            else
            {
                UpdateDisplay(message);
            }
        }

        /**
         * client update display 
         */
        private void UpdateDisplay(string message)
        {
            ChatList.Items.Add(message);
            //AUTO SCROLL TO BOTTOM CHAT.
            ChatList.SelectedIndex = ChatList.Items.Count - 1;
            ChatList.SelectedIndex = -1;
        }

        /**
         * Event handler button listen
         */
        private void btnListen_Click(object sender, EventArgs e)
        {
            int portNr = int.Parse(txtPortNr.Text);
            string ip = txtIPAdress.Text;

            if (IsValidPortNumber(portNr))
            {
                AddMessage("ERROR: Invalid port number.");
            }
            else if (!IsValidIPv4(ip))
            {
                AddMessage("Invalid IPAddress.");
            }
            else
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                TcpConnect(ipAddress, portNr);
                Task.Run(AcceptClients);
            }
        }

        private void AcceptClients()
        {
            while (true)
            {
                TcpClient client = _tcpListener.AcceptTcpClient();
                _tcpClients.Add(client);

                AddMessage("New client connected");
                Task.Run(() => ReceiveData(client));
            }
        }

        /**
         * ReceiveData from server messages
         */
        private void ReceiveData(TcpClient client)
        {
            NetworkStream networkStream = null;
            try
            {
                networkStream = client.GetStream();
            }
            catch (ObjectDisposedException e)
            {
                AddMessage("Error: " + e.Message);
            }
            catch (InvalidOperationException e)
            {
                AddMessage("Error: " + e.Message);
            }
            catch (Exception e)
            {
                AddMessage(e.Message);
            }

            int bufferSize = int.Parse(txtBufferSize.Text);
            string message;
            StringBuilder stringBuilder = new StringBuilder();

            while (networkStream != null && networkStream.CanRead)
            {
                byte[] byteArray = new byte[bufferSize];
                int resultSize = networkStream.Read(byteArray, 0, bufferSize);
                message = Encoding.ASCII.GetString(byteArray, 0, resultSize);

                stringBuilder.Append(message);
                if(message.EndsWith(_endOfTransitionCharacter))
                {
                    string clientMessage = stringBuilder.ToString();
                    clientMessage = clientMessage.Remove(clientMessage.Length - _endOfTransitionCharacter.Length);
                    if (clientMessage == "bye")
                        break;
                    AddMessage(clientMessage);
                    BreadCastMessage(client, clientMessage);
                    stringBuilder = new StringBuilder();
                }
            }
            CloseConnection(client, networkStream);
        }

        /**
         * a method that does what is needed to properly close the connection to the client.
         */
        private void CloseConnection(TcpClient client, NetworkStream networkStream)
        {
            // send bye to client
            byte[] byteArray = Encoding.ASCII.GetBytes("bye");
            networkStream.Write(byteArray, 0, byteArray.Length);
            // close connection with client
            networkStream.Close();
            client.Close();
            _tcpClients.Remove(client);
            AddMessage("Client disconnected.");
        }

        /**
         * Event handler button send
         */
        private void btnSend_Click(object sender, EventArgs e)
        {
            // check if _tcpListener is active before sending message.
            if (_tcpListener != null)
            {
                string message = txtMessage.Text;
                if (message != "")
                {
                    AddMessage(message);
                    BreadCastMessage(null, message);
                }

                txtMessage.Clear();
                txtMessage.Focus();
            }
            else
            {
                AddMessage("no connection has been made");
            }
        }
    
        /**
         * Broadcast a message to all tcpClients except the tcpClient that sends the message.
         */
        private void BreadCastMessage(TcpClient tcpClient, string message)
        {
            message += _endOfTransitionCharacter;
            foreach (var client in _tcpClients.Where(client => client != tcpClient)) // LINQ Expression
            {
                var networkStream = client.GetStream();
                var buffer = Encoding.ASCII.GetBytes(message);
                networkStream.Write(buffer, 0, buffer.Length);
            }
        }

        /**
         * Check if portnumber is higher than min and lower than max for the tcp protocol.
         * Based on: https://en.wikipedia.org/wiki/List_of_TCP_and_UDP_port_numbers#Dynamic,_private_or_ephemeral_ports
         */
        private static bool IsValidPortNumber(int portNumber)
        {
            const int minValidPortNumber = 49152;
            const int maxValidPortNumber = 65535;
            if (portNumber >= minValidPortNumber && portNumber <= maxValidPortNumber)
            {
            }

            return false;
        }

        /**
         * Check if string parameter is valid ip4 
         */
        private static bool IsValidIPv4(string ipString)
        {
            const int allowedSplitValues = 4;
            if (string.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            var splitValues = ipString.Split('.');
            if (splitValues.Length != allowedSplitValues) // Check if split value is 4.
            {
                return false;
            }

            return splitValues.All(r => byte.TryParse(r, out _));
        }

        private void TcpConnect(IPAddress ipAddress, int portNumber)
        {
            try
            {
                _tcpListener = new TcpListener(ipAddress, portNumber);
                _tcpListener.Start();
                AddMessage("Server started...");
            }
            catch (Exception exception)
            {
                AddMessage($"ERROR :{exception.Message}");
            
        }
        
        /**
         * Check on keypress if key is digit
         */
        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}