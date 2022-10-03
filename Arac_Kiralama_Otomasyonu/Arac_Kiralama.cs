using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kiralama_Otomasyonu
{
    class Arac_Kiralama
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MFQQ60B;Initial Catalog=Arac_Kiralama;Integrated Security=True"); //Baglantiyi sagliyor
        DataTable tablo;
        public void ekle_sil_guncelle(SqlCommand komut, string sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();  //Kayit almada kullanilir, gonderilen parametrelleri veri tabanina alir.
            baglanti.Close();
        }
        public DataTable listele(SqlDataAdapter adtr, string sorgu)
        {
            tablo = new DataTable();
            adtr = new SqlDataAdapter(sorgu, baglanti);                      //Veri almak ve kaydetmek icin kullanilir
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public void Bos_Araclar(ComboBox combo, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read["plaka"].ToString());
            }
            baglanti.Close();
        }
        public void Tc_Ara(TextBox tcara, TextBox tc, TextBox adsoyad, TextBox telefon, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                tc.Text = read["tc"].ToString();
                adsoyad.Text = read["adsoyad"].ToString();
                telefon.Text = read["telefon"].ToString();
            }
            baglanti.Close();
        }
        public void Ucret_Hesapla(ComboBox comboBox2, TextBox ucret, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (comboBox2.SelectedIndex == 0) ucret.Text = (int.Parse(read["kiraucreti"].ToString()) * 1).ToString();
                if (comboBox2.SelectedIndex == 1) ucret.Text = (int.Parse(read["kiraucreti"].ToString()) * 0.80).ToString();
                if (comboBox2.SelectedIndex == 2) ucret.Text = (int.Parse(read["kiraucreti"].ToString()) * 0.70).ToString();
            }
            baglanti.Close();
        }

        public void CombadanGetir(ComboBox araclar,TextBox marka, TextBox seri, TextBox yil, TextBox renk, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                marka.Text = read["marka"].ToString();
                seri.Text = read["seri"].ToString();
                yil.Text = read["yil"].ToString();
                renk.Text = read["renk"].ToString();
            }
            baglanti.Close();
        }

        public void satishesapla(Label lbl)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(tutar) from satis", baglanti);
            lbl.Text = "Toplam Tutar=" + komut.ExecuteScalar() + "TL";
            baglanti.Close();
        }
    }
}
