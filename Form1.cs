using System.Diagnostics;
using System.Security.Policy;

namespace Rainifider
{
    public partial class Form1 : Form
    {
        public List<Label> LabelList = new List<Label>();
        public List<TabPage> TabList = new List<TabPage>();
        public Form1()
        {
            InitializeComponent();
            Text = "Rainifider";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ActiveForm.Text = "Rainifider";
        }
#pragma warning disable
        private string[] ToArray(string self)
        {
            return self.Split(',');
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            TabPage page = (sender as Button).Parent as TabPage;
            for (int i = 0; i < LabelList.Count; i++)
            {
                LabelList[i].Visible = false;
                if (page is not null)
                {
                    page.Controls.Remove(LabelList[i]);
                    continue;
                }
                Controls.Remove(LabelList[i]);
            }
            LabelList = new List<Label>();
            var pluginData = new PlugData
            {
                name = textBox1.Text,
                authors = textBox2.Text,
                id = textBox3.Text,
                version = textBox5.Text,
                description = textBox6.Text,
                requirements = ToArray(textBox9.Text),
                requirements_names = ToArray(textBox10.Text),
                priorities = ToArray(textBox11.Text),
                tags = ToArray(textBox12.Text),
                checksum_override_version = checkBox1.Checked,

            };
            Rainifider.directory = textBox4.Text;
            List<Label> labels = Rainifider.ApplyData(pluginData, false);
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Size = new Size(800, 17);
                LabelList.Add(labels[i]);
                if (page is not null)
                {
                    page.Controls.Add(labels[i]);
                    continue;
                }
                Controls.Add(labels[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage page = (sender as Button).Parent as TabPage;
            for (int i = 0; i < LabelList.Count; i++)
            {
                LabelList[i].Visible = false;
                if (page is not null)
                {
                    page.Controls.Remove(LabelList[i]);
                    continue;
                }
                Controls.Remove(LabelList[i]);
            }
            LabelList = new List<Label>();
            var pluginData = new PlugData
            {
                name = textBox1.Text,
                authors = textBox2.Text,
                id = textBox3.Text,
                version = textBox5.Text,
                description = textBox6.Text,
                requirements = ToArray(textBox9.Text),
                requirements_names = ToArray(textBox10.Text),
                priorities = ToArray(textBox11.Text),
                tags = ToArray(textBox12.Text),
                checksum_override_version = checkBox1.Checked,
            };
            Rainifider.directory = textBox4.Text;
            List<Label> labels = Rainifider.ApplyData(pluginData, true);
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].Size = new Size(800, 17);
                LabelList.Add(labels[i]);
                if (page is not null)
                {
                    page.Controls.Add(labels[i]);
                    continue;
                }
                Controls.Add(labels[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    textBox4.Text = fbd.SelectedPath;
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox12.Text = e.Link.LinkData as string;
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://rainworldmodding.miraheze.org/wiki/Downpour_Reference/Mod_Directories") { UseShellExecute = true });
        }
    }
}
