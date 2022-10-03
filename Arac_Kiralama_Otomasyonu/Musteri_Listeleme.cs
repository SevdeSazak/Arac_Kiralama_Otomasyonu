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
    public partial class Musteri_Listeleme : Form
    {
        Arac_Kiralama arac_kiralama = new Arac_Kiralama();
        public Musteri_Listeleme()
        {
            InitializeComponent();
        }

        private void Musteri_Listeleme_Load(object sender, EventArgs e)
        {
            YenileListele();
        }

        private void YenileListele()
        {
            string cumle = "select *from musteri"; // select verilerin goruntulenmesini sagliyor
            SqlDataAdapter adtr2 = new SqlDataAdapter(); //veri almak ve kaydetmek icin kullanilir
            dataGridView1.DataSource = arac_kiralama.listele(adtr2, cumle); //datagridView verilerin gösterilmesini saglar
            dataGridView1.Columns[0].HeaderText = "TC"; //data view 1. sutunda goruntulenmesi
            dataGridView1.Columns[1].HeaderText = "ADI SOYADI";
            dataGridView1.Columns[2].HeaderText = "TELEFON";
            dataGridView1.Columns[3].HeaderText = "ADRES";
            dataGridView1.Columns[4].HeaderText = "E-MAIL";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string cumle = "select *from musteri where tc like '%"+textBox6.Text+"%'";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arac_kiralama.listele(adtr2, cumle);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells[0].Value.ToString();
            textBox2.Text = satir.Cells[1].Value.ToString();
            textBox3.Text = satir.Cells[2].Value.ToString();
            textBox4.Text = satir.Cells[3].Value.ToString();
            textBox5.Text = satir.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cumle = "update musteri set adsoyad=@adsoyad, telefon=@telefon, adres=@adres, eamil=@eamil where tc=@tc";
            // update komutu ile guncellenmesini sagliyor
            SqlCommand komut2 = new SqlCommand(); // veritabanı üzerinde sorgulama, ekleme, güncelleme, silme işlemlerini yapmak için kullanilir.
            komut2.Parameters.AddWithValue("@tc", textBox1.Text);
            komut2.Parameters.AddWithValue("@adsoyad", textBox2.Text);
            komut2.Parameters.AddWithValue("@telefon", textBox3.Text);
            komut2.Parameters.AddWithValue("@adres", textBox4.Text);
            komut2.Parameters.AddWithValue("@eamil", textBox5.Text);
            arac_kiralama.ekle_sil_guncelle(komut2, cumle);  // guncellenen verileri veritabanina gonderiyor
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            YenileListele(); //verileri goruntulmek icin
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            string cumle = "delete from musteri where tc ='" + satir.Cells["tc"].Value.ToString() + "'";
            // delete komutu ile silinmesini sagladim
            SqlCommand komut2 = new SqlCommand();
            arac_kiralama.ekle_sil_guncelle(komut2, cumle); // guncellenen verileri veritabanina gonderiyor
            YenileListele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 yeni = new Form1();
            yeni.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
