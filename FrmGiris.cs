using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace VeritabanıPersonel
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=1BILGISIZ\\SQLEXPRESS01;Initial Catalog=TblPersonel;Integrated Security=True");

        private void FrmGiris_Load(object sender, EventArgs e)
        {
          
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand command = new SqlCommand("Select * From Tbl_Yönetici where KullaniciAdi=@p1 and Sifre=@p2  ", baglanti);
            command.Parameters.AddWithValue("@p1", txtad.Text);
            command.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader reader = command.ExecuteReader(); 
            if (reader.Read()) { 
            Form1 frm= new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı yada Şifre Hatalı !");
            }

            baglanti.Close();
        }
    }
}
