using System;
using System.Text;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class LogInForm : Form
    {
        private PipeClient pipeClient;

        public LogInForm()
        {
            InitializeComponent();
            CreateNewPipeClient();
            ConnectToServer();
            TBPassword.PasswordChar = '\u25CF';
        }

        private void CreateNewPipeClient()
        {
            if (pipeClient != null)
            {
                pipeClient.MessageReceived -= pipeClient_MessageReceived;
                pipeClient.ServerDisconnected -= pipeClient_ServerDisconnected;
            }

            pipeClient = new PipeClient();
            pipeClient.MessageReceived += pipeClient_MessageReceived;
            pipeClient.ServerDisconnected += pipeClient_ServerDisconnected;
        }

        private void ConnectToServer()
        {
            string tempPipeName = @"\\.\pipe\myNamedPipe";
            pipeClient.Connect(tempPipeName);
        }

        private void pipeClient_ServerDisconnected()
        {
            Invoke(new PipeClient.ServerDisconnectedHandler(EnableStartButton));
        }

        private void EnableStartButton() { }

        private void pipeClient_MessageReceived(byte[] message)
        {
            Invoke(new PipeClient.MessageReceivedHandler(DisplayReceivedMessage),
                new object[] { message });
        }

        private void DisplayReceivedMessage(byte[] message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);

            if (str.Equals("yes"))
            {
                MusicPlayerForm musicPlayerForm = new MusicPlayerForm();
                this.Hide();
                musicPlayerForm.Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();

            string temp = TBUsername.Text + " " + TBPassword.Text;
            pipeClient.SendMessage(encoder.GetBytes(temp));
        }
    }
}
