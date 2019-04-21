using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortForwarder
{
    public partial class MainForm : Form
    {
        private string _commandText = "";

        public MainForm()
        {
            InitializeComponent();
        }




        private async void buttonList_Click(object sender, EventArgs e)
            => await ListPortForwardRules();

        private void UpdateOutput(string outputText)
            => UpdateUi(() => richTextBox1.Text = outputText);

        private void UpdateStatus(string statusText)
            => UpdateUi(() => toolStripStatusLabel.Text = statusText);

        private void UpdateCommand(string commandText)
            => UpdateUi(() => textBoxCommand.Text = commandText);

        private async void Form1_Load(object sender, EventArgs e)
            => await ListPortForwardRules();

        private async void toolStripButtonListPortForwarding_Click(object sender, EventArgs e)
            => await ListPortForwardRules();


        private void Form1_Shown(object sender, EventArgs e)
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);

            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                MessageBox.Show("You must run this application as administrator to add/delete port forward routes.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private async void toolStripButtonAddPortForward_Click(object sender, EventArgs e)
        {
            var dlg = new AddPortForward();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            _commandText = $"netsh interface portproxy add v4tov4 listenport={dlg.textBoxSourcePort.Text} listenaddress={dlg.textBoxSourceIP.Text} connectport={dlg.textBoxDestPort.Text} connectaddress={dlg.textBoxDestIP.Text}";

            UpdateCommand(_commandText);
            UpdateStatus("Adding Port Forward Rule");

            var netStat = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                    Arguments = $@"/C {_commandText}",
                    RedirectStandardOutput = true
                }
            };
            netStat.Start();
            var output = await netStat.StandardOutput.ReadToEndAsync();

            UpdateOutput(output);

            UpdateStatus("Ready...");
        }

        private async void toolStripButtonDeletePortForward_Click(object sender, EventArgs e)
        {
            var dlg = new DeletePortForward();
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            _commandText = $"netsh interface portproxy delete v4tov4 listenport={dlg.textBoxSourcePort.Text} listenaddress={dlg.textBoxSourceIP.Text}";

            UpdateCommand(_commandText);
            UpdateStatus("Adding Port Forward Rule");

            var netStat = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                    Arguments = $@"/C {_commandText}",
                    RedirectStandardOutput = true
                }
            };
            netStat.Start();
            var output = await netStat.StandardOutput.ReadToEndAsync();

            UpdateOutput(output);

            UpdateStatus("Ready...");
        }


        private async Task ListPortForwardRules()
        {
            try
            {
                _commandText = "netsh interface portproxy show all";

                UpdateCommand(_commandText);
                UpdateStatus("Getting List of Current Port Forward Rules");

                var netStat = new Process
                {
                    StartInfo =
                    {
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        FileName = "cmd.exe",
                        Arguments = $@"/C {_commandText}",
                        RedirectStandardOutput = true
                    }
                };
                netStat.Start();

                var output = await netStat.StandardOutput.ReadToEndAsync();

                if (string.IsNullOrEmpty(output))
                    output = "No portforwarding setup!";

                UpdateOutput(output);

                UpdateStatus("Ready...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateUi(MethodInvoker method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }
    }
}
