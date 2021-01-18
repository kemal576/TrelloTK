using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrelloTK
{
    public partial class formHome : Form
    {
        public formHome()
        {
            InitializeComponent();
        }


        private void formHome_Load(object sender, EventArgs e)
        {
            //Form Load olduğunda dataManager classından LoadCards methodu çağrıltıp listenin içerisi txtden okunarak dolduruluyor.
            cardsYapılacaklar = DataManager.LoadCards("todo");
            cardsYapılıyor = DataManager.LoadCards("inProgress");
            cardsTamamlandı = DataManager.LoadCards("completed");

            // Form Load olduğunda txtden okuma yapıp kartların listelenmesi sağlanan methodun çağrılması
            kartListele(cardsYapılacaklar, btnKartEkle, 53, Color.CadetBlue, 340, 655, btnKartEkleYapılıyor, btnKartEkle, btnKartEkleTamamlandı, Color.Coral, Color.YellowGreen);
            kartListele(cardsYapılıyor, btnKartEkleYapılıyor, 372, Color.Coral, 221, 655, btnKartEkle, btnKartEkleYapılıyor, btnKartEkleTamamlandı, Color.CadetBlue, Color.YellowGreen);
            kartListele(cardsTamamlandı, btnKartEkleTamamlandı, 669, Color.YellowGreen, 515, 221, btnKartEkleYapılıyor, btnKartEkleTamamlandı, btnKartEkle, Color.Coral, Color.CadetBlue);
        }

        // Kartlarımızın tutulacağı diziler tanımlandı.
        List<TextBox> cardsYapılacaklar = new List<TextBox>();
        List<TextBox> cardsYapılıyor = new List<TextBox>();
        List<TextBox> cardsTamamlandı = new List<TextBox>();


        public void kartListele(List<TextBox> list, Button btn, int locationX, Color color, int deger1, int deger2, Button kartEkle1, Button kartEkle2, Button kartEkle3, Color colors, Color colors2)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Multiline = true; // Çok satırlı bir textbox'a döndürüldü.
                list[i].TextAlign = HorizontalAlignment.Center; //Yazı ortalandı.
                list[i].Size = new Size(195, 34); //Kartın boyutu belirlendi
                list[i].BackColor = color; //Kartın arka plan rengi belirlendi
                list[i].ForeColor = Color.White; //Kartın yazı rengi belirlendi
                list[i].Font = new Font("Arial", 10); //Kartın yazı tipi ve boyutu belirlendi
                list[i].Location = new Point(locationX, 76); //Kartın lokasyonu belirlendi

                if (i == 0)
                    list[i].Location = new Point(locationX, 76); //İlk kartın konumu
                else
                    list[i].Location = new Point(locationX, btn.Location.Y - 1); //Sonraki kartların dinamik konumu
                if (i == 0)
                    btn.Location = new Point(locationX, 116); //Butonun ilk konumu
                else
                    btn.Location = new Point(locationX, btn.Location.Y + 40); //Butonun sonraki dinamik konumları

                list[i].DoubleClick += new EventHandler(kartDetay); //Kartın dbClick özelliğine kartDetay Methodu eklendi.
                list[i].LocationChanged += new EventHandler((sender, e) => dragDrop(sender, e, list, deger1, i, deger2, kartEkle1, kartEkle2, kartEkle3, colors, colors2)); //LocationChanged özelliğine dragDrop methodu atandı.
                list[i].TextChanged += new EventHandler(textLength);//TextChanged özelliğine textLength methodu atandı.
                ControlExtension.Draggable(list[i], true); // Kartların hareketlendirilmesi sağlandı.
                list[i].MouseUp += new MouseEventHandler(DataManager.ChangeCategory); //Kartın MouseUp özelliğine ChangeCategory methodu atandı.
                list[i].MouseUp += new MouseEventHandler(btnYenile_Click); //Kart taşınınca ekranın resetlenmesi sağlandı
                list[i].KeyPress += new KeyPressEventHandler(textBox9_KeyPress); //Entera Tıklanınca kartın detayının açılması sağlandı
                this.Controls.Add(list[i]); //Eventler atandı
            }
        }
        private void kartDetay(object sender, EventArgs e)
        {
            TextBox card = (TextBox)sender;

            formCardDetails formCard = new formCardDetails();

            formCard.lblCardId.Text = card.Name; //Card'ın ID'sine card'ın name'i atandı.
            formCard.txtCardTitle.Text = card.Text; //Card'ın title'ına card'ın text'i atandı.
            formCard.lblKategori.Text = Card.CategoryCheck(card); // Kart kategorisi belirlendi.

            Card cardDetay = DataManager.txtRead(card.Name, Card.CategoryCheck(card)); //txtden okuma yapıldı

            //Form içindeki textboxlara card sınıfından bilgiler aktarıldı
            formCard.txtProjeNo.Text = cardDetay.projeNo;
            formCard.txtTeknikUzman.Text = cardDetay.teknikUzman;
            formCard.txtTarih.Text = cardDetay.tarih;
            formCard.txtTahminiSure.Text = cardDetay.tahminiProjeBitim.ToString();

            if (cardDetay.baslamaTarihi != null && cardDetay.baslamaTarihi != "" && Card.CategoryCheck(card) == "inProgress")//Card tarihin null kontrolü yapıldı
            {
                DateTime dateTime = DateTime.Parse(cardDetay.baslamaTarihi);
                cardDetay.gecenSure = Math.Round((DateTime.Now - dateTime).TotalHours).ToString();
                if (Convert.ToInt32(cardDetay.gecenSure) > cardDetay.tahminiProjeBitim) //Geçen süre anlık tarihe göre sınırlandırıldı
                    cardDetay.gecenSure = cardDetay.tahminiProjeBitim.ToString();
            }
            //Kalan bilgiler textboxlara aktarıldı
            formCard.txtGerceklesenSure.Text = cardDetay.gecenSure;
            formCard.txtIsAciklamasi.Text = cardDetay.Info;
            formCard.txtNotlar.Text = cardDetay.Note;
            formCard.comboCalistinMi.Text = cardDetay.calistinMi;
            formCard.numTecrube.Value = cardDetay.tecrubeYil;
            formCard.numKacKart.Value = cardDetay.kacProje;


            if (cardDetay.IsTakibi != null) //İş takibi değerlerinin null kontrolü yapıldı
            {
                foreach (var takip in cardDetay.IsTakibi)
                {
                    string[] tmp = takip.Split('£');
                    if (tmp.Length >= 4)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = tmp[0]; item.SubItems.Add(tmp[1]);
                        item.SubItems.Add(tmp[2]); item.SubItems.Add(tmp[3]);
                        formCard.lstTakip.Items.Add(item);
                    }

                }
            }
            formCard.Show();
            this.Hide();
        }

        private void textLength(object sender, System.EventArgs e)
        {//Text uzunluğu belli bir sınırı geçince kartın boyutunun büyümesi sağlandı
            TextBox txt = (TextBox)sender;
            if (txt.Text.Length >= 30)
                txt.Size = new Size(195, 45);
            else if (txt.Text.Length < 30)
                txt.Size = new Size(195, 34);
        }
        private void dragDrop(object sender, System.EventArgs e, List<TextBox> dizi, int deger1, int i, int deger2, Button kartEkle1, Button kartEkle2, Button kartEkle3, Color colors, Color colors2)
        {//Kartın sürükle bırak methodu

            for (i = 0; i < dizi.Count; i++)
            {
                if (dizi[i].Location.X == deger1)
                {
                    dizi[i].BackColor = colors;
                    kartEkle1.Location = new Point(kartEkle1.Location.X, kartEkle1.Location.Y + 40);
                    kartEkle2.Location = new Point(kartEkle2.Location.X, kartEkle2.Location.Y - 40);
                }
                else if (dizi[i].Location.X == deger2)
                {
                    kartEkle2.Location = new Point(kartEkle2.Location.X, kartEkle2.Location.Y - 40);
                    dizi[i].BackColor = colors2;
                    kartEkle3.Location = new Point(btnKartEkleTamamlandı.Location.X, btnKartEkleTamamlandı.Location.Y + 40);
                }
            }
        }
        public void kartEkle(List<TextBox> dizi, Button btn, int adet, int locationX, Color color, int deger1, int deger2, Button kartEkle1, Button kartEkle2, Button kartEkle3, Color colors, Color colors2)
        {
            dizi.Add(new TextBox()); //Listeye yeni textbox eklendi

            dizi[adet].Multiline = true; // Çok satırlı bir textbox'a döndürüldü.
            dizi[adet].TextAlign = HorizontalAlignment.Center; //Yazı ortalandı.
            dizi[adet].Size = new Size(195, 34); //Kartın boyutu belirlendi
            dizi[adet].BackColor = color; //Kartın arka plan rengi belirlendi
            dizi[adet].ForeColor = Color.White; //Kartın yazı rengi belirlendi
            dizi[adet].Font = new Font("Arial", 10); //Kartın fontu ve font boyutu değiştirildi.

            //İlk oluşturulduysa ayrı birden fazlaysa ayrı şekilde kart lokasyonları belirlendi
            if (adet == 0)
                dizi[adet].Location = new Point(locationX, 76);
            else
                dizi[adet].Location = new Point(locationX, btn.Location.Y - 1); //dizi[adet-1].Location.Y+50
            if (adet == 0)
                btn.Location = new Point(locationX, 116);
            else
                btn.Location = new Point(locationX, btn.Location.Y + 40);

            Random rnd = new Random();
            string Id;
            do
            {
                Id = rnd.Next(1000, 9999).ToString(); //Karta random bir ıd atandı
            }
            while (!IdKontrol_Array(Id));

            dizi[adet].Name = Id; //Kartın name'ine random olan ıd atandı
            dizi[adet].Text = "Bu karta bir görev giriniz!"; //Geçici kart title'ı atandı
            dizi[adet].DoubleClick += new EventHandler(kartDetay); //Kartın dbClick özelliğine kartDetay Methodu eklendi.
            dizi[adet].LocationChanged += new EventHandler((sender, e) => dragDrop(sender, e, dizi, deger1, adet, deger2, kartEkle1, kartEkle2, kartEkle3, colors, colors2)); //LocationChanged özelliğine dragDrop methodu atandı.
            dizi[adet].TextChanged += new EventHandler(textLength);//TextChanged özelliğine textLength methodu atandı.
            ControlExtension.Draggable(dizi[adet], true); // Kartların hareketlendirilmesi sağlandı.
            dizi[adet].MouseUp += new MouseEventHandler(DataManager.ChangeCategory); //Kartın MouseUp özelliğine ChangeCategory methodu atandı.
            this.Controls.Add(dizi[adet]);
            adet++;
        }

        private bool IdKontrol_Array(string Id) //Id kontrolu yapılan method Kontroller ile aynı id'nin iki kere atanması engellendi
        {
            // YAPILIYOR KISMINDAKİ KARTLAR TARANDI
            for (int i = 0; i < cardsYapılıyor.Count; i++)
            {
                if (cardsYapılıyor[i] != null)
                {
                    if (cardsYapılıyor[i].Name == Id)
                        return false;
                }
            }
            // YAPILACAKLAR KISMINDAKİ KARTLAR TARANDI
            for (int i = 0; i < cardsYapılacaklar.Count; i++)
            {
                if (cardsYapılacaklar[i] != null)
                {
                    if (cardsYapılacaklar[i].Name == Id)
                        return false;
                }
            }
            // TAMAMLANDI KISMINDAKİ KARTLAR TARANDI
            for (int i = 0; i < cardsTamamlandı.Count; i++)
            {
                if (cardsTamamlandı[i] != null)
                {
                    if (cardsTamamlandı[i].Name == Id)
                        return false;
                }
            }
            return true;
        }

        private void btnKartEkle_Click(object sender, EventArgs e)
        {
            kartEkle(cardsYapılacaklar, btnKartEkle, cardsYapılacaklar.Count, 53, Color.CadetBlue, 340, 655, btnKartEkleYapılıyor, btnKartEkle, btnKartEkleTamamlandı, Color.Coral, Color.YellowGreen);
        }

        private void btnTahmin_Click(object sender, EventArgs e)
        {//Tahmin form'una geçiş
            formTahmin formTahmin = new formTahmin();
            formTahmin.Show();
            this.Hide();
        }

        private void btnKartEkleYapılıyor_Click(object sender, EventArgs e)
        {
            kartEkle(cardsYapılıyor, btnKartEkleYapılıyor, cardsYapılıyor.Count, 372, Color.Coral, 221, 655, btnKartEkle, btnKartEkleYapılıyor, btnKartEkleTamamlandı, Color.CadetBlue, Color.YellowGreen);
        }

        private void btnKartEkleTamamlandı_Click(object sender, EventArgs e)
        {
            kartEkle(cardsTamamlandı, btnKartEkleTamamlandı, cardsTamamlandı.Count, 669, Color.YellowGreen, 515, 221, btnKartEkleYapılıyor, btnKartEkleTamamlandı, btnKartEkle, Color.Coral, Color.CadetBlue);
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            formHome form = new formHome();
            form.Show();
            this.Hide();
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {//Entera basılınca kartDetay fonksiyonu çağırıldı karta giriş sağlandı.
            if (e.KeyChar == (char)Keys.Enter)
            {
                ((TextBox)sender).Parent.Hide();
                kartDetay(sender, e);
                
            }
                
        }
    }
}
