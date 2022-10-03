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
    public partial class Sozlesme : Form
    {
        public Sozlesme()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        Arac_Kiralama arac = new Arac_Kiralama();
        private void Sozlesme_Load(object sender, EventArgs e)
        {
            Bos_Araclar();
            Yenile();
        }

        private void Bos_Araclar()
        {
            string sorgu2 = "select *from arac where durumu ='BOS'";
            arac.Bos_Araclar(comboBox1, sorgu2);
        }

        private void Yenile()
        {
            string sorgu3 = "select *from sozlesme";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arac.listele(adtr2, sorgu3);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select *from arac where plaka like '" + comboBox1.SelectedItem + "'";
            arac.CombadanGetir(comboBox1, textBox7, textBox8, textBox9, textBox10, sorgu2);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select *from arac where plaka like '" + comboBox1.SelectedItem + "'";
            arac.Ucret_Hesapla(comboBox2, textBox14, sorgu2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TimeSpan gun = DateTime.Parse(dateTimePicker2.Text) - DateTime.Parse(dateTimePicker1.Text);
            int gun2 = gun.Days;
            textBox13.Text = gun2.ToString();
            textBox12.Text = (gun2 * int.Parse(textBox14.Text)).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            comboBox2.Text = "";
            textBox14.Text = "";
            textBox13.Text = "";
            textBox13.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu2 = "insert into sozlesme (tc, adsoyad, telefon, ehliyetno, e_tarih, e_yer, plaka, marka, seri, yil, renk, kirasekli, kiraucreti, gun, tutar, ctarih, dtarih) values (@tc, @adsoyad, @telefon, @ehliyetno, @e_tarih, @e_yer, @plaka, @marka, @seri, @yil, @renk, @kirasekli, @kiraucreti, @gun, @tutar, @ctarih, @dtarih)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", textBox1.Text);
            komut2.Parameters.AddWithValue("@adsoyad", textBox2.Text);
            komut2.Parameters.AddWithValue("@telefon", textBox3.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", textBox4.Text);
            komut2.Parameters.AddWithValue("@e_tarih", textBox5.Text);
            komut2.Parameters.AddWithValue("@e_yer", textBox6.Text);
            komut2.Parameters.AddWithValue("@plaka", comboBox1.Text);
            komut2.Parameters.AddWithValue("@marka", textBox7.Text);
            komut2.Parameters.AddWithValue("@seri", textBox8.Text);
            komut2.Parameters.AddWithValue("@yil", textBox9.Text);
            komut2.Parameters.AddWithValue("@renk", textBox10.Text);
            komut2.Parameters.AddWithValue("@kirasekli", comboBox2.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(textBox14.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(textBox13.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(textBox12.Text));
            komut2.Parameters.AddWithValue("@ctarih", dateTimePicker1.Text);
            komut2.Parameters.AddWithValue("@dtarih", dateTimePicker2.Text);
            arac.ekle_sil_guncelle(komut2, sorgu2);
            string sorgu3 = "update arac set durumu = 'DOLU' where plaka='" + comboBox1.Text + "'";
            SqlCommand komut3 = new SqlCommand();
            arac.ekle_sil_guncelle(komut3, sorgu3);
            comboBox1.Items.Clear();
            Bos_Araclar();
            Yenile();
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            comboBox1.Text = "";
            Temizle();
            MessageBox.Show("Sozlesme Eklendi");
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox11.Text == "") foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            string sorgu2 = "select *from musteri where tc like '" + textBox11.Text + "%'";  
            //like komutu ile tc si ayn olan kisilerin diger bilgileri geliyor
            arac.Tc_Ara(textBox11, textBox1, textBox2, textBox3, sorgu2);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu2 = " update sozlesme set tc=@tc, adsoyad=@adsoyad, telefon=@telefon, ehliyetno=@ehliyetno, e_tarih=@e_tarih, e_yer=@e_yer, marka=@marka, seri=@seri, yil=@yil, renk=@renk, kirasekli=@kirasekli, kiraucreti=@kiraucreti, gun=@gun, tutar=@tutar, ctarih=@ctarih, dtarih=dtarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", textBox1.Text);
            komut2.Parameters.AddWithValue("@adsoyad", textBox2.Text);
            komut2.Parameters.AddWithValue("@telefon", textBox3.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", textBox4.Text);
            komut2.Parameters.AddWithValue("@e_tarih", textBox5.Text);
            komut2.Parameters.AddWithValue("@e_yer", textBox6.Text);
            komut2.Parameters.AddWithValue("@plaka", comboBox1.Text);
            komut2.Parameters.AddWithValue("@marka", textBox7.Text);
            komut2.Parameters.AddWithValue("@seri", textBox8.Text);
            komut2.Parameters.AddWithValue("@yil", textBox9.Text);
            komut2.Parameters.AddWithValue("@renk", textBox10.Text);
            komut2.Parameters.AddWithValue("@kirasekli", comboBox2.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(textBox14.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(textBox13.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(textBox12.Text));
            komut2.Parameters.AddWithValue("@ctarih", dateTimePicker1.Text);
            komut2.Parameters.AddWithValue("@dtarih", dateTimePicker2.Text);
            arac.ekle_sil_guncelle(komut2, sorgu2);
          
            comboBox1.Items.Clear();
            Bos_Araclar();
            Yenile();
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            comboBox1.Text = "";
            Temizle();
            MessageBox.Show("Sozlesme Guncellendi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells[0].Value.ToString();
            textBox2.Text = satir.Cells[1].Value.ToString();
            textBox3.Text = satir.Cells[2].Value.ToString();
            textBox4.Text = satir.Cells[3].Value.ToString();
            textBox5.Text = satir.Cells[4].Value.ToString();
            textBox6.Text = satir.Cells[5].Value.ToString();
            comboBox1.Text = satir.Cells[6].Value.ToString();
            textBox7.Text = satir.Cells[7].Value.ToString();
            textBox8.Text = satir.Cells[8].Value.ToString();
            textBox9.Text = satir.Cells[9].Value.ToString();
            textBox10.Text = satir.Cells[10].Value.ToString();
            comboBox2.Text = satir.Cells[11].Value.ToString();
            textBox14.Text = satir.Cells[12].Value.ToString();
            textBox13.Text = satir.Cells[13].Value.ToString();
            textBox12.Text = satir.Cells[14].Value.ToString();
            dateTimePicker1.Text = satir.Cells[15].Value.ToString();
            dateTimePicker1.Text = satir.Cells[16].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox15.Text != "")
            {
                DataGridViewRow satir = dataGridView1.CurrentRow;
                DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
                int ucret = int.Parse(satir.Cells["kiraucreti"].Value.ToString());
                int tutar = int.Parse(satir.Cells["tutar"].Value.ToString());
                DateTime cikis = DateTime.Parse(satir.Cells["ctarih"].Value.ToString());
                TimeSpan gun = bugun - cikis;
                int _gun = gun.Days;
                int toplamtutar = _gun * ucret;
                string sorgu1 = "delete from sozlesme where plaka='" + satir.Cells["plaka"].Value.ToString() + "'";
                SqlCommand komut = new SqlCommand();
                arac.ekle_sil_guncelle(komut, sorgu1);
                string sorgu2 = "update arac set durumu = 'BOS' where plaka='" + satir.Cells["plaka"].Value.ToString() + "'";
                SqlCommand komut3 = new SqlCommand();
                arac.ekle_sil_guncelle(komut3, sorgu2);

                string sorgu3 = "insert into satis (tc, adsoyad, plaka, marka, seri, yil, renk,  gun, fiyat, tutar, tarih1, tarih2) values (@tc, @adsoyad, @plaka, @marka, @seri, @yil, @renk, @gun, @fiyat, @tutar, @tarih1, @tarih2)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@tc", satir.Cells["tc"].Value.ToString());
                komut2.Parameters.AddWithValue("@adsoyad", satir.Cells["adsoyad"].Value.ToString());
                komut2.Parameters.AddWithValue("@plaka", satir.Cells["plaka"].Value.ToString());
                komut2.Parameters.AddWithValue("@marka", satir.Cells["marka"].Value.ToString());
                komut2.Parameters.AddWithValue("@seri", satir.Cells["seri"].Value.ToString());
                komut2.Parameters.AddWithValue("@yil", satir.Cells["yil"].Value.ToString());
                komut2.Parameters.AddWithValue("@renk", satir.Cells["renk"].Value.ToString());
                komut2.Parameters.AddWithValue("@gun", _gun);
                komut2.Parameters.AddWithValue("@tutar", toplamtutar);            
                komut2.Parameters.AddWithValue("@tarih1", satir.Cells["ctarih"].Value.ToString());
                komut2.Parameters.AddWithValue("@tarih2", DateTime.Now.ToShortDateString());
                komut2.Parameters.AddWithValue("@fiyat", ucret);
                arac.ekle_sil_guncelle(komut2, sorgu3);
                MessageBox.Show("Arac teslim edildi");
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                Bos_Araclar();
                Yenile();
                foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
                comboBox1.Text = "";
                Temizle();
                textBox15.Text = "";
                
            }
            else if(textBox15.Text == "")
            {
                MessageBox.Show("Lutfen secim yapiniz", "Uyari");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime donus = DateTime.Parse(satir.Cells["dtarih"].Value.ToString());
            int ucret = int.Parse(satir.Cells["kiraucreti"].Value.ToString());
            TimeSpan gunfarki = bugun - donus;
            int _gunfarki = gunfarki.Days;
            int ucretfarki;
            ucretfarki = _gunfarki * ucret;
            textBox15.Text = ucretfarki.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 yeni = new Form1();
            yeni.Show();
            this.Hide();

        }
    }
}
