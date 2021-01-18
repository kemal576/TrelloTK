using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrelloTK
{
    public class DataManager
    {
        public static void txtWrite(Card card) //Yolu belirterek txt içine yazılması sağlanıyor.
        {
            string a = "&";
            string filePath = card.Kategori + ".txt";
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            string tmp = "";
            foreach (var tkp in card.IsTakibi)
                tmp += tkp + "$";

            sw.WriteLine(card.Id + a + card.Title + a + card.Info + a + card.Note + a + card.projeNo + a
                        + card.teknikUzman + a + card.tarih + a + card.baslamaTarihi + a + card.gecenSure+a+card.calistinMi+a+card.kacProje+a+card.tecrubeYil+a+card.tahminiProjeBitim.ToString()+a+tmp);
            

            sw.Close();
        }
        public static Card txtRead(string cardId, string kategori)
        { //Ayrıştırma işlemleri yapılıp txt içinden okunması sağlanıyor
            Card card = Card.cards();
            string filePath = kategori + ".txt";
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] lineData = line.Split('&');
                if (lineData[0] == cardId)
                {
                    //Her bölme için ayrı bilgi denk geliyor
                    card.Id = lineData[0];
                    card.Title = lineData[1];
                    card.Info = lineData[2];
                    card.Note = lineData[3];
                    card.projeNo = lineData[4];
                    card.teknikUzman = lineData[5];
                    card.tarih = lineData[6];
                    card.baslamaTarihi = lineData[7];
                    card.gecenSure = lineData[8];
                    card.calistinMi = lineData[9];
                    card.kacProje = Convert.ToInt32(lineData[10]);
                    card.tecrubeYil = Convert.ToInt32(lineData[11]);
                    card.tahminiProjeBitim = Convert.ToInt32(lineData[12]);
                    card.IsTakibi = new List<string>();
                    if (lineData.Length >= 13)
                    {
                        string[] logData = lineData[13].Split('$');
                        foreach (var log in logData)
                            card.IsTakibi.Add(log);
                    }                                     
                }
            }
            return card;
        }
        public static List<int> getPredictionData()//Proje bitim tahmin hesaplama methodu
        {
            int verilen = 0, gecen = 0, topCard = 0, progressCard = 0;
            string[] txtPath = { "todo.txt", "inProgress.txt" };
            foreach (var path in txtPath)
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    string[] lineData = line.Split('&');
                    if (lineData.Length >= 7)
                    {
                        if (lineData[7] != "")
                        {
                            DateTime dateTime = DateTime.Parse(lineData[7]);
                            var saatFarki = Convert.ToInt32(Math.Round((DateTime.Now - dateTime).TotalHours));
                                if (saatFarki > Convert.ToInt32(lineData[12]))
                                    saatFarki = Convert.ToInt32(lineData[12]);
                                if (path == "inProgress.txt")
                                { 
                                    progressCard++;   
                                    gecen += saatFarki;
                                }
                                    
                        }
                        verilen += Convert.ToInt32(lineData[12]);
                        topCard++;
                    }
                    
                }
            }
            return new List<int>() { verilen, gecen, topCard, progressCard};
        }

        public static string BaslamaTarihi(string kategori)
        {
            if (kategori == "inProgress")
                return DateTime.Now.ToString("g");
            else
                return "";
        }



        public static void DeleteLine(string Id, string kategori)
        { //Txtnin içine gidip o satırın silinmesini sağlıyor
            string filePath = kategori + ".txt";
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineData = lines[i].Split('&');
                if (lineData[0] == Id)
                {
                    lines[i] = "";
                }
            }
            File.WriteAllLines(filePath, lines);
        }
        public static List<TextBox> LoadCards(string kategori)
        { //Txtnin içine gidip okuma yapıp cardların Load olmasını sağlıyor
            string filePath = kategori + ".txt";
            string[] lines = File.ReadAllLines(filePath);
            List<TextBox> cards = new List<TextBox>();
            foreach (var line in lines) 
            {
                string[] lineData = line.Split('&');
                if (lineData[0].Length == 4)
                {
                    TextBox card = new TextBox();
                    card.Name = lineData[0];
                    card.Text = lineData[1];
                    cards.Add(card);
                }
                else
                    continue;
            }
            return cards;
        }
        public static bool IdKontrol_txt(string Id)
        { //Kategoriler içine gidip ıd kontrolünü sağlıyor
            string[] kategoriler = { "todo", "inProgress", "completed" };
            foreach (var kategori in kategoriler)
            {
                string filePath = kategori + ".txt";
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] lineData = line.Split('&');
                    if (lineData[0] == Id && lineData != null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static void ChangeCategory(object sender, System.EventArgs e)
        { //Konum değişikliklerine bağlı olarak kategori değişimini sağlıyor
            TextBox txt = (TextBox)sender;
            string kategori = Card.CategoryCheck(txt);
            string Id = txt.Name;
            string[] kategoriler = { "todo", "inProgress", "completed" };

            string filePath = kategori + ".txt";           
            string[] lines = File.ReadAllLines(filePath);
            bool tmp = false;
            foreach (var line in lines)
            {
                string[] lineData = line.Split('&');
                if (lineData[0] == Id && lineData != null)
                {
                    tmp = true;
                    break;
                }
            }
            if (!tmp)
            {
                foreach (var k in kategoriler)
                {
                    if (k != kategori)
                    {
                        string filePathh = k + ".txt";
                        string[] liness = File.ReadAllLines(filePathh);
                        foreach (var l in liness)
                        {
                            string[] lData = l.Split('&');
                            if (lData[0] == Id && lData != null)
                            {
                                Card cardTmp = txtRead(Id, k);
                                cardTmp.Kategori = kategori;
                                cardTmp.baslamaTarihi = DataManager.BaslamaTarihi(kategori);
                                DataManager.DeleteLine(Id, k);
                                txtWrite(cardTmp);
                                break;
                            }
                        }
                    }
                }
            }            
        }
    }
}
