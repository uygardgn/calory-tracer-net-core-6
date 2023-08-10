using BLL.BLL.Models;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPL.Forms
{
    public partial class OgunYonetimi : Form
    {
        public OgunYonetimi(int kullaniciID, MainForm mainForm)
        {
            InitializeComponent();
            ogunBLL = new OgunBLL();
            kategoriBLL = new KategoriBLL();
            yiyecekBLL = new YiyecekBLL();
            yiyecekDetayBLL = new YiyecekDetayBLL();
            ogun = new Ogun();
            yiyecekler = new List<Yiyecek>();
            gunlukRapor = new GunlukRapor();
            tuketimGecmisi = new TuketimGecmisi();
            kullaniciBLL = new KullaniciBLL();
            gunlukRaporBLL = new GunlukRaporBLL();
            yiyecekOgunBLL = new YiyecekOgunBLL();
            ogunDetayBLL = new OgunDetayBLL();
            kullaniciOgunBLL = new KullaniciOgunBLL();
            besinDegeriBLL = new BesinDegeriBLL();
            this.kullaniciID = kullaniciID;
            this.mainForm = mainForm;
            //Cboxlara double Click Yapıldıgında aktif olacak            
        }
        OgunBLL ogunBLL;
        KategoriBLL kategoriBLL;
        YiyecekBLL yiyecekBLL;
        YiyecekDetayBLL yiyecekDetayBLL;
        Ogun ogun;
        List<Yiyecek> yiyecekler;
        YiyecekDetay yiyecekDetay = new YiyecekDetay();
        GunlukRapor gunlukRapor;
        TuketimGecmisi tuketimGecmisi;
        KullaniciBLL kullaniciBLL;
        GunlukRaporBLL gunlukRaporBLL;
        YiyecekOgunBLL yiyecekOgunBLL;
        OgunDetayBLL ogunDetayBLL;
        KullaniciOgunBLL kullaniciOgunBLL;
        BesinDegeriBLL besinDegeriBLL;
        BesinDegeri besinDegeri;
        Yiyecek yiyecek;
        YiyecekOgun yiyecekOgun;
        OgunDetay ogunDetay;
        KullaniciOgun kullaniciOgun;
        Kullanici kullanici;
        int kullaniciID;
        MainForm mainForm;



        string resimUzantisi;
        private void OgunYonetimi_Load(object sender, EventArgs e)
        {

            cboxOgun.DisplayMember = "OgunAd";
            cboxOgun.ValueMember = "ID";
            cboxOgun.DataSource = ogunBLL.Listele();

            cboxKategori.DisplayMember = "KategoriAd";
            cboxKategori.ValueMember = "ID";
            cboxKategori.DataSource = kategoriBLL.Listele();

            cboxYemekDetay.DisplayMember = "Icerik";
            cboxYemekDetay.ValueMember = "ID";
            cboxYemekDetay.DataSource = yiyecekDetayBLL.Listele();

            lboxYemekler.DataSource = yiyecekBLL.ButunYemekleriGetir();
            lboxYemekler.DisplayMember = "YiyecekAd";
            lboxYemekler.ValueMember = "ID";

            //Cboxlara double Click Yapıldıgında aktif olacak 
            cboxYemekDetay.Enabled = false;
            btnYeniYemekDetayEkle.Enabled = false;
            btnYemegiEkle.Enabled = false;
        }

        private void btnYemekResmiSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif"; openFileDialog.Title = "Resim Seç"; if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string resimYolu = openFileDialog.FileName;
                pboxYemekResmi.Image = Image.FromFile(resimYolu);
                resimUzantisi = resimYolu;
            }
        }

        private void btnYeniYemekDetayEkle_Click(object sender, EventArgs e)
        {

            DetayEkleme detayEkleme = new DetayEkleme((int)lboxYemekler.SelectedValue);
            detayEkleme.ShowDialog();
        }

        private void btnYeniYemekEkle_Click(object sender, EventArgs e)
        {
            YemekEkleme yemekEkleme = new YemekEkleme();
            yemekEkleme.ShowDialog();
        }



        private void btnOgunEkle_Click(object sender, EventArgs e)
        {
            //ogun = new Ogun();
            //ogun.OgunAd = txtOgunEkleme.Text;
            //if (ogunBLL.Ekle(ogun))
            //{
            //    MessageBox.Show("Öğün Ekleme Başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtOgunEkleme.Visible = false;
            //    btnOgunEkle.Visible = false;
            //    cboxOgun.DisplayMember = "OgunAd";
            //    cboxOgun.ValueMember = "ID";
            //    cboxOgun.DataSource = ogunBLL.Listele();
            //}
            //else
            //{
            //    MessageBox.Show("Öğün Ekleme Esnasında Bir Problem Oluştu. Lütfen Daha Sonra Tekrar Deneyiniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cboxKategori.SelectedIndex != -1)
            {
                lboxYemekler.DisplayMember = "YiyecekAd";
                lboxYemekler.ValueMember = "ID";
                lboxYemekler.DataSource = yiyecekBLL.Filtrele((int)cboxKategori.SelectedValue);

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    yiyecekler = yiyecekBLL.KarakterAl(textBox1.Text, (int)cboxKategori.SelectedValue);
                    lboxYemekler.DisplayMember = "YiyecekAd";
                    lboxYemekler.ValueMember = "ID";
                    lboxYemekler.DataSource = yiyecekler;
                }
            }
            else
            {
                yiyecekler = yiyecekBLL.KarakterAl(textBox1.Text);
                lboxYemekler.DisplayMember = "YiyecekAd";
                lboxYemekler.ValueMember = "ID";
                lboxYemekler.DataSource = yiyecekler;
            }
        }

        private void cboxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            lboxYemekler.DisplayMember = "YiyecekAd";
            lboxYemekler.ValueMember = "ID";
            lboxYemekler.DataSource = yiyecekBLL.Filtrele((int)cboxKategori.SelectedValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnTümYemekler_Click(object sender, EventArgs e)
        {
            lboxYemekler.DisplayMember = "YiyecekAd";
            lboxYemekler.ValueMember = "ID";
            lboxYemekler.DataSource = yiyecekBLL.ButunYemekleriGetir();
        }

        private void lboxYemekler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lboxYemekler_DoubleClick(object sender, EventArgs e)
        {
            cboxYemekDetay.Enabled = true;
            if ((int)lboxYemekler.SelectedValue > 0)
            {
                Yiyecek yiyecek = new Yiyecek();
                yiyecek = yiyecekBLL.IdGetir((int)lboxYemekler.SelectedValue);
                lblYemekAdi.Text = yiyecek.YiyecekAd;
                List<YiyecekDetay> yiyecekDetaylar = new List<YiyecekDetay>();
                yiyecekDetaylar = yiyecekDetayBLL.YiyecekDetayGetir(yiyecek.ID);
                //pboxYemekResmi.Image = Image.FromFile(yiyecekDetay.ResimYolu);          //DIKKAT ET
                btnYeniYemekDetayEkle.Enabled = true;
                if (yiyecekDetaylar[0].Icerik is not null)
                {
                    cboxYemekDetay.DisplayMember = "Icerik";
                    cboxYemekDetay.ValueMember = "ID";
                    cboxYemekDetay.DataSource = yiyecekDetaylar;

                    if (cboxYemekDetay.SelectedIndex > -1 && cboxYemekDetay.SelectedIndex <= cboxYemekDetay.Items.Count - 1 && !string.IsNullOrEmpty(yiyecekDetaylar[0].Icerik))
                    {
                        cboxYemekDetay.Text = yiyecekDetaylar[0].Icerik.ToString();
                        //cboxYemekDetay.ValueMember = "ID";
                        btnYemegiEkle.Enabled = true;

                    }
                }
                else
                {
                    btnYemegiEkle.Enabled = false;
                }
            }
        }

        private void cboxYemekDetay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        private void nupdownGramaj_ValueChanged(object sender, EventArgs e)
        {
            Hesapla();
        }

        public void Hesapla()
        {
            int abc = (int)cboxYemekDetay.SelectedValue;

            yiyecekDetay = yiyecekDetayBLL.YiyecekDetayDöndür(abc);
            double degerkatsayısı = (double)nupdownGramaj.Value / 100;

            lblKalori.Text = (yiyecekDetay.Kalori100gr * degerkatsayısı).ToString();
            lblKarbonhidrat.Text = (yiyecekDetay.Karbonhidrat100gr * degerkatsayısı).ToString();
            lblProtein.Text = (yiyecekDetay.Protein100gr * degerkatsayısı).ToString();
            lblYag.Text = (yiyecekDetay.Yag100gr * degerkatsayısı).ToString();
        }

        private void btnYemegiEkle_Click(object sender, EventArgs e)
        {
            bool gunlukVeriEklendi = false;
            //Kullanici kullanici = new Kullanici();

            yiyecekOgun = new();
            yiyecek = new();
            ogunDetay = new();
            kullaniciOgun = new();

            yiyecekOgun.OgunID = (int)cboxOgun.SelectedValue;
            yiyecekOgun.YiyecekID = (int)lboxYemekler.SelectedValue;
            bool eklendiMı = yiyecekOgunBLL.Ekle(yiyecekOgun);

            ogunDetay.OgunID = (int)cboxOgun.SelectedValue;
            bool eklendiMı2 = ogunDetayBLL.Ekle(ogunDetay);

            kullaniciOgun.OgunID = (int)cboxOgun.SelectedValue;
            kullaniciOgun.KullaniciID = kullaniciID;
            bool eklendiMı3 = kullaniciOgunBLL.Ekle(kullaniciOgun);

            besinDegeri = new();
            int abc = besinDegeri.ID;
            besinDegeri.PorsiyonGramaji = (double)nupdownGramaj.Value;
            besinDegeri.Kalori = Convert.ToDouble(lblKalori.Text);
            besinDegeri.Protein = Convert.ToDouble(lblProtein.Text);
            besinDegeri.Karbonhidrat = Convert.ToDouble(lblKarbonhidrat.Text);
            besinDegeri.Yag = Convert.ToDouble(lblYag.Text);
            besinDegeri.YiyecekOgunID = yiyecekOgun.ID;
            //besinDegeri.YiyecekID = (int)lboxYemekler.SelectedValue;
            bool eklendiMı4 = besinDegeriBLL.Ekle(besinDegeri);

            if (eklendiMı4)
            {
                kullanici = kullaniciBLL.IDGoreGetir(kullaniciID);
                gunlukRapor.KullaniciID = kullaniciID;
                gunlukRapor.KaloriIhtiyaci = kullanici.KaloriIhtiyacı;
                gunlukRapor.TuketilenKalori = Convert.ToDouble(lblKalori.Text);
                gunlukRapor.Protein = Convert.ToDouble(lblProtein.Text);
                gunlukRapor.Karbonhidrat = Convert.ToDouble(lblKarbonhidrat.Text);
                gunlukRapor.Yag = Convert.ToDouble(lblYag.Text);
                gunlukVeriEklendi = gunlukRaporBLL.Ekle(gunlukRapor);

                tuketimGecmisi = new TuketimGecmisi();
                tuketimGecmisi.KullaniciID = kullaniciID;
                tuketimGecmisi.KategoriID = (int)cboxKategori.SelectedValue;
                tuketimGecmisi.OgunID = (int)cboxOgun.SelectedValue;
                tuketimGecmisi.YiyecekID = (int)lboxYemekler.SelectedValue;
                tuketimGecmisi.BesinDegeriID = besinDegeri.ID;
                TuketimGecmisiBLL tuketimGecmisiBLL = new TuketimGecmisiBLL();
                bool eklendiMi = tuketimGecmisiBLL.Ekle(tuketimGecmisi);
                if (eklendiMi && eklendiMı && eklendiMı2 && eklendiMı3 && eklendiMı4)
                {
                    MessageBox.Show("Ekleme İşlemi Başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bir Hata Meydana Geldi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }
        private void lnkAnaSayfa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AnaEkran anaEkran = new AnaEkran(kullaniciID, mainForm);
            anaEkran.MdiParent = mainForm;
            anaEkran.Dock = DockStyle.Fill;
            this.Width = anaEkran.Width + 20;
            this.Height = anaEkran.Height + 90;
            anaEkran.Show();
            this.Close();
        }

        private void cboxOgun_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}
