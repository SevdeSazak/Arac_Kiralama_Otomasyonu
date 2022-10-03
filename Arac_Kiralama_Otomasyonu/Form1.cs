using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteri_Ekleme musteri_kayit = new Musteri_Ekleme();
            musteri_kayit.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Musteri_Listeleme musteri_kayit = new Musteri_Listeleme();
            musteri_kayit.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Arac_Kayit arac_kayit = new Arac_Kayit();
            arac_kayit.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Arac_Listeleme arac_kayit = new Arac_Listeleme();
            arac_kayit.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sozlesme sozlesme = new Sozlesme();
            sozlesme.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Satis satis = new Satis();
            satis.Show();
            this.Hide();
        }
    }
}
