using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class ClientForm : Form
    {
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private bool _connected;
        private const int PortNumberMin = 49152;
        private const int PortNumberMax = 65535;
        private const int BufferSizeMin = 2;
        private const int BufferSizeMax = 1024;
        private string _endOfTransitionCharacter = "@-_@";

        private delegate void UpdateChat(string message);

        public ClientForm()
        {
            _connected = false;
            InitializeComponent();
        } 
        
        /**
         * Add message to chat list
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
         * Receive Data from server messages
         */
        private void ReceiveData()
        {
            _networkStream = _tcpClient.GetStream();
            AddMessage("Connected!");

            int bufferSize = int.Parse(txtBufferSize.Text);
            string message;
            StringBuilder stringBuilder = new StringBuilder();

            while (_networkStream != null && _networkStream.CanRead)
            {
                byte[] byteArray = new byte[bufferSize];
                int resultSize = _networkStream.Read(byteArray, 0, bufferSize);
                message = Encoding.ASCII.GetString(byteArray, 0, resultSize);

                stringBuilder.Append(message);
                if(message.EndsWith(_endOfTransitionCharacter))
                {
                    string clientMessage = stringBuilder.ToString();
                    clientMessage = clientMessage.Remove(clientMessage.Length - _endOfTransitionCharacter.Length);
                    if (clientMessage == "bye")
                        break;
                    AddMessage(clientMessage);
                    stringBuilder = new StringBuilder();
                }
            }
            CloseConnection();
        }
        
        /**
         * a method that does what is needed to properly close the connection to the client.
         */
        private void CloseConnection()
        {
            // send bye
            byte[] byteArray = Encoding.ASCII.GetBytes("bye");
            _networkStream.Write(byteArray, 0, byteArray.Length);
            // close connection with client
            _networkStream.Close();
            _tcpClient.Close();
            _connected = false;
            AddMessage("Connection closed");
        }

        /**
         * Event handler button connect
         */
        private void btnConnect_click(object sender, EventArgs eventArgs)
        {
            if (!_connected)
            {
                int portNr = int.Parse(txtPortNr.Text);
                int bufferSize = int.Parse(txtBufferSize.Text);
                string ipAddress = txtServerIP.Text;

                // validate input
                if (!IsValidPortNumber(portNr))
                {
                    AddMessage("Error: Port number not valid.");
                }
                else if (!IsValidIPv4(ipAddress))
                {
                    AddMessage("Error: IP Address not valid.");
                }
                else if (!IsValidBufferSize(bufferSize))
                {
                    AddMessage("Error: BufferSize not valid.");
                }
                else
                {
                    AddMessage("Connecting...");
                    ConnectTcp(ipAddress, portNr);
                    Task.Run(ReceiveData);
                }
            }
            else
            {
                AddMessage("Connection is already made.");
            }
        }

        private static bool IsValidBufferSize(int bufferSize)
        {
            return bufferSize >= BufferSizeMin && bufferSize <= BufferSizeMax;
        }

        private void ConnectTcp(string ipAddress, int portNr)
        {
            try
            {
                _tcpClient = new TcpClient(ipAddress, portNr);
                _connected = true;
            }
            catch (Exception e)
            {
                AddMessage($"CONNECTION ERROR: {e.Message}");
            }
        }

        /**
         * Event handler button send
         */
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!_connected)
            {
                AddMessage("no connection has been made");
            }
            else
            {
                string message = txtMessage.Text;

                if (message != "")
                {
                    AddMessage(message);
                    message += _endOfTransitionCharacter;
                    byte[] buffer = Encoding.ASCII.GetBytes(message);
                    _networkStream.Write(buffer, 0, buffer.Length);
                }
                txtMessage.Clear();
                txtMessage.Focus(); 
            }
        }
        
        /**
         * Check if string parameter is valid ip4 
         */
        private static bool IsValidIPv4(string ipString)
        {
            const int allowedSplitValues = 4;
            if (String.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != allowedSplitValues) // Check if split values is 4.
            {
                return false;
            }

            return splitValues.All(r => byte.TryParse(r, out _));
        }
        
        /**
         * Check if portnumber is higher than min and lower than max for the tcp protocol.
         * Based on: https://en.wikipedia.org/wiki/List_of_TCP_and_UDP_port_numbers#Dynamic,_private_or_ephemeral_ports
         */
        private static bool IsValidPortNumber(int portNumber)
        {
            return portNumber >= PortNumberMin  && portNumber <= PortNumberMax;
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