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
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
            kullaniciBLL = new KullaniciBLL();
        }
        KullaniciBLL kullaniciBLL;
        Kullanici kullanici;
        public int kulllaniciID = 0;
        private void btnGiris_Click(object sender, EventArgs e)
        {
            kullanici = new Kullanici();
            kullanici = kullaniciBLL.IsmeGoreGetir(txtKullaniciAdi.Text);
            if (kullanici is not null)
            {

                if (kullanici.Sifre == kullaniciBLL.ComputeSha256Hash(txtSifre.Text))
                {
                    kulllaniciID = kullanici.ID;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linklblAnaSayfa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linklblSifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum sifremiUnuttum = new SifremiUnuttum();
            sifremiUnuttum.ShowDialog();
        }

    }
}
