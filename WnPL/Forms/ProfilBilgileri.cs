﻿using BLL.BLL.Models;
using Entities.Enums;
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
    public partial class ProfilBilgileri : Form
    {
        public ProfilBilgileri(int kullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = kullaniciID;
            kullaniciBLL = new KullaniciBLL();
        }

        KullaniciBLL kullaniciBLL;
        Kullanici kullanici;
        int kullaniciID;

        private void ProfilBilgileri_Load(object sender, EventArgs e)
        {
            kullanici = new Kullanici();
            kullanici = kullaniciBLL.IDGoreGetir(kullaniciID);
            txtAd.Text = kullanici.Ad;
            txtSoyad.Text = kullanici.Soyad;
            if (kullanici.Cinsiyet == Cinsiyet.Kadin)
            {
                txtCinsiyet.Text = Cinsiyet.Kadin.ToString();
            }
            else
            {
                txtCinsiyet.Text = Cinsiyet.Erkek.ToString();
            }
            txtYas.Text = (DateTime.Now.Year - kullanici.DogumTarihi.Year).ToString();
            txtBoy.Text = kullanici.Boy.ToString();
            txtKilo.Text = kullanici.Kilo.ToString();
            txtAktiviteSeviyesi.Text = kullaniciBLL.BilgiVer(kullaniciID);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            BilgiGuncelleme bilgiGuncelleme = new BilgiGuncelleme(kullaniciID);
            bilgiGuncelleme.ShowDialog();
            this.Close();
        }

        private void groupBoxBilgilerim_Enter(object sender, EventArgs e)
        {

        }
    }
}
