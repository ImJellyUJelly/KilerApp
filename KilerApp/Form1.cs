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
        List<string> waarden = new List<string>();
        List<string> tabels = new List<string>();
        public Form1()
        {
            InitializeComponent();
            lijstVullen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var V in db.Search(cbValues.Text, tbSValues.Text))
            {
                lbSearch.Items.Add(V.ToString());
            }
        }
        private void lijstVullen()
        {
            tabels.Add("Adres");
            tabels.Add("Album");
            tabels.Add("Band");
            tabels.Add("Bandregel");
            tabels.Add("Genre");
            tabels.Add("Lied");
            tabels.Add("Muzikant");
            tabels.Add("Playlist");
            tabels.Add("Playlistliedje");
            foreach (var T in tabels)
            {
                cbValues.Items.Add(T);
                cbInsert.Items.Add(T);
            }
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            db.Insert(tbIValue1.Text, tbIValue2.Text, tbIValue3.Text, tbIValue4.Text, tbIValue5.Text);
        }
    }
}
