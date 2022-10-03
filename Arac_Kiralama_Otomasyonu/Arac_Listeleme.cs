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
    public partial class Arac_Listeleme : Form
    {
        Arac_Kiralama arac_kiralama = new Arac_Kiralama();
        public Arac_Listeleme()
        {
            InitializeComponent();
        }

        private void Arac_Listeleme_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["plaka"].Value.ToString();
            comboBox1.Text = satir.Cells["marka"].Value.ToString();
            comboBox2.Text = satir.Cells["seri"].Value.ToString();
            textBox2.Text = satir.Cells["yil"].Value.ToString();
            textBox3.Text = satir.Cells["renk"].Value.ToString();
            textBox4.Text = satir.Cells["km"].Value.ToString();
            comboBox3.Text = satir.Cells["yakit"].Value.ToString();
            textBox5.Text = satir.Cells["kiraucreti"].Value.ToString();
            pictureBox2.ImageLocation = satir.Cells["resim"].Value.ToString();

        }

        private void Arac_Listeleme_Load(object sender, EventArgs e)
        {
            YeniAraclarListesi();
            try
            {
                comboBox2.SelectedIndex = 0;
            }
            catch
            {

                ;
            }
        }

        private void YeniAraclarListesi()
        {
            string cumle = "select *from arac"; //verilerin gelmesini sagliyor
            SqlDataAdapter adtr2 = new SqlDataAdapter(); //veri almak ve kaydetmek için veri tabani arasindaki baglanti
            dataGridView1.DataSource = arac_kiralama.listele(adtr2, cumle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cumle = "update arac set marka=@marka, seri=@seri, yil=@yil, renk=@renk, km=@km, yakit=@yakit, kiraucreti=@kiraucreti, resim=@resim, tarih=@tarih where plaka=@plaka";
            //update komutu ile verilerin guncellenmesini sagliyor
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", textBox1.Text);
            komut2.Parameters.AddWithValue("@marka", comboBox1.Text);
            komut2.Parameters.AddWithValue("@seri", comboBox2.Text);
            komut2.Parameters.AddWithValue("@yil", textBox2.Text);
            komut2.Parameters.AddWithValue("@renk", textBox3.Text);
            komut2.Parameters.AddWithValue("@km", textBox4.Text);
            komut2.Parameters.AddWithValue("@yakit", comboBox3.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", textBox5.Text);
            komut2.Parameters.AddWithValue("@resim", pictureBox2.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            komut2.Parameters.AddWithValue("@durumu", "BOS");
            arac_kiralama.ekle_sil_guncelle(komut2, cumle);
            comboBox2.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = "";
            YeniAraclarListesi(); //guncelnene verilerin goruntulenmesini saglar
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            string cumle = "delete from arac where plaka='" + satir.Cells["plaka"].Value.ToString() + "'"; //verileri silmek icin delete komutu
            SqlCommand komut2 = new SqlCommand();
            arac_kiralama.ekle_sil_guncelle(komut2, cumle);
            YeniAraclarListesi();
            pictureBox2.ImageLocation = "";
            comboBox2.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Items.Clear();
                if (comboBox1.SelectedItem.ToString() == "Opel") 
                {
                    comboBox2.Items.Add("Astra");
                    comboBox2.Items.Add("Vectra");
                    comboBox2.Items.Add("Corsa");
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    comboBox2.Items.Add("Megane");
                    comboBox2.Items.Add("Clio");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    comboBox2.Items.Add("Linea");
                    comboBox2.Items.Add("Egea");
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    comboBox2.Items.Add("Fiesta");
                    comboBox2.Items.Add("Focus");
                }

            }
            catch
            {

                ;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox4.SelectedIndex == 0)
                {
                    YeniAraclarListesi();
                }
                if (comboBox4.SelectedIndex == 1)
                {
                    string cumle = "select *from arac where durumu = 'BOS'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arac_kiralama.listele(adtr2, cumle);
                }
                if (comboBox4.SelectedIndex == 2)
                {
                    string cumle = "select *from arac where durumu = 'DOLU'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arac_kiralama.listele(adtr2, cumle);
                }
            }
            catch 
            {

                ;
            }
        }

        private void button5_Click(object sender, EventArgs e)
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
