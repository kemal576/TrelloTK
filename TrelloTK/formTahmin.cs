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
    public partial class formTahmin : Form
    {
        public formTahmin()
        {
            InitializeComponent();
        }   
        private void btnBack_Click(object sender, EventArgs e)
        {
            formHome formHome = new formHome();
            formHome.Show();
            this.Hide();
        }

        private void formTahmin_Load(object sender, EventArgs e)
        {
            List<int> lstData = DataManager.getPredictionData(); //DataManagerden fonksiyonun çağırılması
            lblTopCard.Text = lstData[2].ToString() + " adet";
            lblAktifCard.Text = lstData[3].ToString() + " adet";
            lblKartToplamTahmin.Text = lstData[0].ToString() + "saat";
            lblKartToplamGerceklesen.Text = lstData[1].ToString() + "saat";
            lblBitisTahmin.Text = (lstData[0]-lstData[1]) + " saat";
        }
    }
}
