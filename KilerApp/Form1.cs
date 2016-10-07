using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KilerApp
{
    public partial class Form1 : Form
    {
        Database db = new Database();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var V in db.Search())
            {
                lbSearch.Items.Add(V.ToString());
            }
        }
    }
}
