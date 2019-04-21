using System;
using System.Windows.Forms;
using PortForwarder.Shared;

namespace PortForwarder
{
    public partial class DeletePortForward : Form
    {
        public DeletePortForward()
        {
            InitializeComponent();
        }



        private void DeletePortForward_Load(object sender, EventArgs e)
        {
            textBoxSourceIP.Text = IpHelpers.GetLocalIPAddress();
        }
    }
}
