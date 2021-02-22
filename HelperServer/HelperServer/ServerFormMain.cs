using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HelperServerLib;
using HelperShareLib;
using System.Pipeline;

namespace HelperServer
{
    public partial class ServerFormMain : Form
    {
        public ServerFormMain()
        {
            InitializeComponent();
        }
        private IServerController controller;
        private void button1_Click(object sender, EventArgs e)
        {
            IDevice device = null;
            controller
                .WithScript(typeof(如果的世界))
                .WithAccount(@"c:\账号.txt")
                .WithImageInfos(@"c:\imageInfos.txt")
                .WithCommands("")
                .BuildServer()
                .Run();

            controller.Stop();
            controller.GetClient(device).Run();
            controller.GetClient(device).Stop();
            controller.GetClientDetail();
        }

        private void 启动SignalR服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            signalr.server
        }
    }
    class 如果的世界
    {

    }
}
