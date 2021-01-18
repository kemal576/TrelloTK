using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TrelloTK
{
    public partial class formCardDetails : Form
    {
        public formCardDetails()
        {
            InitializeComponent();
        }
        
        public void btnKartOnay_Click(object sender, EventArgs e)
        {
            if (txtNotlar.Text == "" || txtProjeNo.Text == "" || txtTeknikUzman.Text == "" || txtIsAciklamasi.Text == "")
                MessageBox.Show("Lütfen tüm bilgileri eksiksiz giriniz.");           
            else
            {
                Card card = Card.cards(); //Card oluşturuldu
                int tecrubeKatki=0 , projeKatki=0, deneyimKatki=0; //Tahmin için değişkenler tanımlandı
                //Card içindeki değişkenlere txt'lerden veriler aktarıldı
                card.Id = lblCardId.Text;
                card.Info = txtIsAciklamasi.Text;
                card.Note = txtNotlar.Text;
                card.tarih = txtTarih.Text;
                card.projeNo = txtProjeNo.Text;
                card.teknikUzman = txtTeknikUzman.Text;
                card.Title = txtCardTitle.Text;
                card.calistinMi = comboCalistinMi.Text;
                card.Kategori = lblKategori.Text;
                if (card.Kategori == "inProgress")
                    card.baslamaTarihi = DateTime.Now.ToString("g");
                card.kacProje = Convert.ToInt32(numKacKart.Value);
                card.tecrubeYil = Convert.ToInt32(numTecrube.Value);

                card.IsTakibi = new List<string>();// İş takibi listesi oluşturuldu

                if (comboCalistinMi.Text == "EVET") //Tahmin için hesaplamalar , yöntemler
                {
                    deneyimKatki = 5; // Daha önce çalıştığı için

                    if (card.kacProje <= 5) // Çalıştığı proje sayısına göre
                        projeKatki = card.kacProje;
                    else
                        projeKatki = 8;

                    if (card.tecrubeYil <= 3) // Tecrübesine göre
                        tecrubeKatki = card.tecrubeYil;
                    else
                        tecrubeKatki = 4;

                    card.tahminiProjeBitim = 20 - (deneyimKatki + projeKatki + tecrubeKatki);
                }
                else
                    card.tahminiProjeBitim = 20;
                //MessageBox.Show(card.tahminiProjeBitim.ToString());

                foreach (var item in lstTakip.Items) //İş takibine yazdırma işlemleri
                {
                    string tmpLine = "";
                    var ls = (ListViewItem)item;
                    for (int i = 0; i < 4; i++)
                    {
                        tmpLine += ls.SubItems[i].Text + "£";
                    }
                    card.IsTakibi.Add(tmpLine);
                }

                if (DataManager.IdKontrol_txt(card.Id)) //Card Idsine göre Id kontrol
                {
                    card.tarih = DateTime.Now.ToString("dd/MM/yyyy HH:mm"); //Anlık tarih alma
                    DataManager.txtWrite(card);
                    MessageBox.Show("YENİ KART KAYDEDİLDİ!");
                }
                else
                {
                    DataManager.DeleteLine(card.Id, card.Kategori); 
                    DataManager.txtWrite(card);
                    MessageBox.Show("KART GÜNCELLENDİ!");
                }

                formHome formHome = new formHome();
                formHome.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            formHome formHome = new formHome();
            formHome.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogDelete = new DialogResult(); //Emin misiniz Sorgusu için dialogResult
            dialogDelete = MessageBox.Show("Kartı silmek istediğinize emin misiniz?", "SİL", MessageBoxButtons.YesNo);
            if (dialogDelete == DialogResult.Yes)
            {
                DataManager.DeleteLine(lblCardId.Text, lblKategori.Text); //O satırın silinmesi ve resetlenmesi
                formHome formHome = new formHome();
                formHome.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Kart silinmedi!");
        }

        private void btnTakipEkle_Click(object sender, EventArgs e)
        {
            if (txtIsTakibiAciklama.Text != "" && txtIsTakibiDurum.Text != "" && txtIsTakibiTarih.Text != "" && txtIsTakibiYapilacakIs.Text != "")
            {
                ListViewItem item = new ListViewItem(); // Yeni liste oluşturulması
                                                        //Liste içine değişkenlerin atanması
                item.Text = txtIsTakibiTarih.Text;
                item.SubItems.Add(txtIsTakibiDurum.Text);
                item.SubItems.Add(txtIsTakibiYapilacakIs.Text);
                item.SubItems.Add(txtIsTakibiAciklama.Text);
                lstTakip.Items.Add(item);
            }
            else
                MessageBox.Show("Eksik bilgi girdiniz!","İŞ TAKİBİ");
            
        }
    }
}
