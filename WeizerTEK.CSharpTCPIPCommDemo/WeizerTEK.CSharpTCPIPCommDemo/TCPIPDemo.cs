using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WeizerTEK.CSharpTCPIPCommDemo
{
    // ReSharper disable once IdentifierTypo
    public partial class TcpipDemo : Form
    {
        readonly TcpClient _clientSocket = new TcpClient();
        NetworkStream _serverStream = default(NetworkStream);
        string _readData;

        // ReSharper disable once IdentifierTypo
        public TcpipDemo()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _clientSocket.Connect(txtbxIPAddress.Text, Int32.Parse(txtbxPort.Text));
                if (_clientSocket.Connected)
                {
                    txtbxErrorHistory.Text = @"Client Connection: OK";
                }
                else
                {
                    txtbxErrorHistory.Text = @"Client Connection: FAIL";
                }


                var clientThread = new Thread(GetMessage);
                clientThread.Start();
            }
            catch(Exception exception)
            {
                txtbxErrorHistory.Text = exception.Message;
            }
        }

        private void GetMessage()
        {
            while (true)
            {
                _serverStream = _clientSocket.GetStream();
                var bufferSize = _clientSocket.ReceiveBufferSize;
                byte[] inStream = new byte[bufferSize];

                _serverStream.Read(inStream, 0, bufferSize);

                var returnData = Encoding.ASCII.GetString(inStream);
                _readData = returnData;

                OutputMessage();
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private void OutputMessage()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(OutputMessage));
            }
            else
            {
                txtbxIncomingMessage.Text = _readData;
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            byte[] outStream = Encoding.ASCII.GetBytes(txtbxOutgoingMessage.Text);
            _serverStream.Write(outStream, 0, outStream.Length);
        }
    }
}
