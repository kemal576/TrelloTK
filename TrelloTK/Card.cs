using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrelloTK
{
     public class Card //SINGLETON OLARAK TASARLANDI
    {
        private static Card Cards;
        private Card()
        {
            
        }

        public static Card cards() 
        {
            if (Cards == null) //O nesneden yoksa yenisini oluştur varsa kendisini döndür
                Cards = new Card();
            else
            { //Döndürmeden önce içini sıfırla
                Cards.Id = null;
                Cards.gecenSure = null;
                Cards.Info = null;
                Cards.IsTakibi = null;
                Cards.Kategori = null;
                Cards.Note = null;
                Cards.projeNo = null;
                Cards.tahminiProjeBitim = 0;
                Cards.calistinMi = null;
                Cards.kacProje = 0;
                Cards.tecrubeYil = 0;
                Cards.baslamaTarihi = null;
                Cards.tarih = null;
                Cards.teknikUzman = null;
                Cards.Title = null;              
            }
            return Cards;
        }

        public string Id { get; set; }//KART NO
        public string Kategori { get; set; } //KART KATEGORİ
        public string Title { get; set; }//KART BAŞLIK
        public string Info { get; set; }//İŞ AÇIKLAMASI
        public string Note { get; set; }//VARSA KART NOT
        public string teknikUzman { get; set; } //Teknik Uzman
        public string tarih { get; set; } //Tarih
        public string projeNo { get; set; }//Proje No
        public string baslamaTarihi { get; set; }//KART ÇALIŞMASINA BAŞLANILAN TARİH
        public string gecenSure { get; set; }//GEÇEN SÜRE
        public string calistinMi { get; set; }
        public int tecrubeYil { get; set; }
        public int kacProje { get; set; }
        public int tahminiProjeBitim { get; set; }
        public List<string> IsTakibi { get; set; }

        public static string CategoryCheck(TextBox card)//Kart kategorisi değiştirmeye yarıyor.
        {
            if (card.Location.X > 40 && card.Location.X < 290)
                return "todo";
            else if (card.Location.X > 348 && card.Location.X < 593)
                return "inProgress";
            else if (card.Location.X > 641 && card.Location.X < 886)
                return "completed";
            
           // return null;
            return "todo";
        }


    }
}
