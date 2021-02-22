using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalR.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/NotifyHub")
                .Build();
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
            connection.StartAsync();
        }
        HubConnection connection;
        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var newMessage = $"ReceiveMessage from server {user}: {message}";
                Console.WriteLine(newMessage);
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
            }
        }

        private async void button2_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessage", "111", "222");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
