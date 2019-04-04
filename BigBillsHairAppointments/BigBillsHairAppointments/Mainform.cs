using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBillsHairAppointments
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            Splash newSplash = new Splash();
            newSplash.ShowDialog();

            Login newLogin = new Login();
            newLogin.ShowDialog();
            if (newLogin.DialogResult != DialogResult.OK)
            {
                this.Close();
            }
        }
        #region "SetUpStatusStrip"
        private void SetUpStatusStrip()
        {
            statusStrip1.LayoutStyle = ToolStripLayoutStyle.Table;

            toolStripStatusLabel1.Text = System.DateTime.Now.ToShortTimeString();
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Right;

            toolStripStatusLabel2.Text = Environment.UserName;
            toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel2.BorderSides = ToolStripStatusLabelBorderSides.Right;

            toolStripStatusLabel3.Text = "Position: 0 of 0";
            toolStripStatusLabel3.TextAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel3.BorderSides = ToolStripStatusLabelBorderSides.Right;

            toolStripStatusLabel4.Text = "OK";
            toolStripStatusLabel4.TextAlign = ContentAlignment.MiddleRight;
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = System.DateTime.Now.ToShortTimeString();
        }
    }
}
