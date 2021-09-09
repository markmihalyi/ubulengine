using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace UbulEngine
{
    public partial class AvailabilityChanger : Form
    {
        public AvailabilityChanger()
        {
            InitializeComponent();
        }

        private void comboBox_Click(object sender, EventArgs e)
        {
            API.ChangeAvailability(comboBox.SelectedIndex);
        }
    }
}
