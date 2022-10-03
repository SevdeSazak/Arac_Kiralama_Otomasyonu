using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    public partial class Musteri_Ekleme : Form
    {
        Arac_Kiralama arac_kiralama = new Arac_Kiralama();
        public Musteri_Ekleme()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cumle = "insert into musteri (tc, adsoyad, telefon, adres, eamil) values (@tc, @adsoyad, @telefon, @adres, @eamil)";
            //insert into komutu ile yeni verilerin eklenmesini sagladim
            SqlCommand komut2 = new SqlCommand(); //yeni bir komut olusturdum
            komut2.Parameters.AddWithValue("@tc", textBox1.Text);
            komut2.Parameters.AddWithValue("@adsoyad", textBox2.Text);
            komut2.Parameters.AddWithValue("@telefon", textBox3.Text);
            komut2.Parameters.AddWithValue("@adres", textBox4.Text);
            komut2.Parameters.AddWithValue("@eamil", textBox5.Text);
            arac_kiralama.ekle_sil_guncelle(komut2, cumle); //verilerin veritabanina kaydedilmesini sagladim
            foreach (Control item in Controls) if (item is TextBox) item.Text = ""; 
           
        }

        private void Musteri_Ekleme_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 yeni = new Form1();
            yeni.Show();
            this.Hide();
        }
    }
}
