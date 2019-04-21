using System;
using System.Windows.Forms;
using PortForwarder.Shared;

namespace PortForwarder
{
    public partial class AddPortForward : Form
    {
        public AddPortForward()
        {
            InitializeComponent();
        }



        private void AddPortForward_Load(object sender, EventArgs e)
        {
            textBoxSourceIP.Text = IpHelpers.GetLocalIPAddress();
        }

    }
}
