using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rap__chieu_phim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int tontien;
        List<phim> list = new List<phim>()
        {
            new phim(){name = "spiderman", ghedachon= new List<Button> ()},
            new phim(){name = "kungfu panda", ghedachon= new List<Button>()}
        }; 
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control ctr in tableLayoutPanel1.Controls)
            {
                if (ctr is Button)
                {
                    ctr.BackColor = Color.Transparent;
                    ctr.Enabled = true;
                }
            }
            tontien = 0;
                phim selecting = cb_tenphim.SelectedItem as phim;
            foreach (Button btt in selecting.ghedachon)
            {
                btt.BackColor = Color.Red;
                btt.Enabled = false;
            }
        }
        List<Button> ghekhachchon = new List<Button>();

        private void Form1_Load(object sender, EventArgs e)
        {
            cb_tenphim.DataSource = list;
            cb_tenphim.DisplayMember = "name";
            
        }
        class phim
        {
            public string name { get; set;}
            public List<Button> ghedachon = new List<Button>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;


            phim selecting = cb_tenphim.SelectedItem as phim;
            selecting.ghedachon.Add(bt);
            ghekhachchon.Add(bt);
            if (bt.BackColor == Color.Transparent)
            {
                bt.BackColor = Color.Green;
                if (int.TryParse(bt.Tag.ToString(), out int giatien))
                {
                    tontien += giatien;
                    tb_thanhtien.Text = tontien.ToString();
                }

            }else
            {
                bt.BackColor = Color.Transparent;

                if (int.TryParse(bt.Tag.ToString(), out int giatien))
                {
                    tontien -= giatien;
                    tb_thanhtien.Text = tontien.ToString();
                }

            }
        }

        private void button37_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Thanh toan thanh cong");
            foreach(Button bt in ghekhachchon)
            {
                if (bt != null)
                {
                    bt.BackColor = Color.Red;
                    bt.Enabled = false;
                }
            }
            tontien = 0;
            tb_thanhtien.Text = "0";
        }
    }
}
