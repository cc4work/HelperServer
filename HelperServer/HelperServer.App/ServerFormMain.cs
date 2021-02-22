using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using SignalR.Server;
namespace HelperServer.App
{
    public partial class ServerFormMain : Form
    {
        public ServerFormMain()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name.Contains("Start"))
            {
                // 启动web服务
                //Task.Run(()=> SignalR.Server.Program.Main(null));
                Debug.WriteLine("start");
                Console.WriteLine();   
            }
            else
            {
                Console.WriteLine("Stop");
            }
        }
    }
}
