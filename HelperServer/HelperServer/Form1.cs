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
    public partial class Form1 : Form
    {
        public Form1()
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
    }
    class 如果的世界
    {

    }
}
