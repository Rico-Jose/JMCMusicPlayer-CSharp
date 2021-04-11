/*
 * You have been hired as the new programmer by the Jupiter Mining Corporation
 * to produce a test program for the company,
 * this program will be fully documented and tested.
 * With this project you are coming up with a program to show your range of skills
 * and abilities to your new boss.
 * You have been given an example of what your boss is expecting to see
 * The example they have given is an advanced music player
 * that allows the ability to sort and search the songs stored in a binary tree
 * (any sort and search algorithm you select will have to be approved
 * if it is not merge sort and binary search),
 * the GUI should display the sorted track list and highlight and play the searched track,
 * it should save the track list to a csv using a 3rd party library.
 * The music player must load and play files and met the requirements laid out in Question 3.
 * If you choose not to implement this project
 * you must negotiate a project of equal complexity that meets the requirements in Question 3.
 * Jose Rico Imbang
 * 30019932
 * 26/11/2020
 * AT3 - Project
 */

using System;
using System.Text;
using System.Windows.Forms;
using wyUpdate;
using System.Security.Cryptography;

namespace Pipes
{
    public partial class FormServer : Form
    {
        private PipeServer pipeServer = new PipeServer();

        public FormServer()
        {
            InitializeComponent();

            pipeServer.MessageReceived += pipeServer_MessageReceived;
            pipeServer.ClientDisconnected += pipeServer_ClientDisconnected;
            StartServer();
        }

        private void StartServer()
        {
            string tempPipeName = @"\\.\pipe\myNamedPipe";
            //start the pipe server if it's not already running
            if (!pipeServer.Running)
            {
                pipeServer.Start(tempPipeName);
                tbPipeName.Text = "Server is ready";
            }
            else
                MessageBox.Show("Server already running.");
        }

        private void pipeServer_ClientDisconnected()
        {
            Invoke(new PipeServer.ClientDisconnectedHandler(ClientDisconnected));
        }

        private void ClientDisconnected()
        {
            MessageBox.Show("Total connected clients: " + pipeServer.TotalConnectedClients);
        }

        private void pipeServer_MessageReceived(byte[] message)
        {
            Invoke(new PipeServer.MessageReceivedHandler(ProcessMessage),
                new object[] { message });
        }

        private void ProcessMessage(byte[] message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);
            string[] arrStr = str.Split(' ');
            string serverUsername = "admin";
            string serverPassword = GetMD5("password");
            string clientUsername = arrStr[0];
            string clientPassword = GetMD5(arrStr[1]);

            if (serverUsername.Equals(clientUsername) && serverPassword.Equals(clientPassword))
                Send("yes");
            else
                Send("no");
        }

        #region ****************************HASHING TECHNIQUE****************************
        private static string GetMD5(string pw)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pw));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }
        #endregion

        private void Send(string str)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] messageBuffer = encoder.GetBytes(str);

            pipeServer.SendMessage(messageBuffer);
        }
    }
}