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
    public partial class Arac_Kayit : Form
    {
        Arac_Kiralama arac_kiralama = new Arac_Kiralama();
        public Arac_Kayit()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();                                   //resim secmemiz icin
            pictureBox1.ImageLocation = openFileDialog1.FileName;          //resmin goruntulenmesi
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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
        komut2.Parameters.AddWithValue("@seri", comboBox2.Text);
            komut2.Parameters.AddWithValue("@yil", textBox2.Text);
            komut2.Parameters.AddWithValue("@renk", textBox3.Text);
            komut2.Parameters.AddWithValue("@km", textBox4.Text);
            komut2.Parameters.AddWithValue("@yakit", comboBox3.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", textBox5.Text);
                        komut2.Parameters.AddWithValue("@marka", comboBox1.Text);
            komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            komut2.Parameters.AddWithValue("@durumu", "BOS");

        private void button1_Click_1(object sender, EventArgs e)
        {
            string cumle = "insert into arac(plaka, marka, seri, yil, renk, km, yakit, kiraucreti, resim, tarih, durumu) values" +
            "(@plaka, @marka, @seri, @yil, @renk, @km, @yakit, @kiraucreti, @resim, @tarih, @durumu)"; //kayit eklemek icin sql insert into komutu kullandim.
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", textBox1.Text); 
            //...hepsini Paramters.AddWithValue ile aldim
            arac_kiralama.ekle_sil_guncelle(komut2, cumle);
            comboBox2.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox1.ImageLocation = "";
        }

        private void Arac_Kayit_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 yeni = new Form1();
            yeni.Show();
            this.Hide();
        }
    }
}
