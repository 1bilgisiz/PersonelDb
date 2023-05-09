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
    public partial class frmİstatistik : Form
    {
        public frmİstatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=1BILGISIZ\\SQLEXPRESS01;Initial Catalog=TblPersonel;Integrated Security=True");
       
        private void frmİstatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();    


            SqlCommand sqlCommand = new SqlCommand("Select Count(*) From Tbl_Personel",baglanti);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                personelbl.Text = reader[0].ToString();

            }
            baglanti.Close();

            //Evli PErsonel SAyısı

            baglanti.Open();

            SqlCommand evlicommand = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader sqlDataReader = evlicommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                evlitbl.Text = sqlDataReader[0].ToString();
            }

            baglanti.Close();


            //Bekar Personel Sayısı
            baglanti.Open();

            SqlCommand bekarcommand = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader sqlDataReader2 = bekarcommand.ExecuteReader();
            while (sqlDataReader2.Read())
            {
                bekarlbl.Text = sqlDataReader2[0].ToString();
            }

            baglanti.Close();


            //Şehir Sayısı
            baglanti.Open();

            SqlCommand sehircommand = new SqlCommand("Select Count(distinct(PerSehir))  From Tbl_Personel ", baglanti);
            SqlDataReader sqlDataReader3 = sehircommand.ExecuteReader();
            while (sqlDataReader3.Read())
            {
                sehirlbl.Text = sqlDataReader3[0].ToString();
            }

            baglanti.Close();


            //Toplam Maaş
            baglanti.Open();

            SqlCommand maascommand = new SqlCommand("Select Sum(PerMaas) From Tbl_Personel ", baglanti);
            SqlDataReader sqlDataReader4 = maascommand.ExecuteReader();
            while (sqlDataReader4.Read())
            {
                toplamlbl.Text = sqlDataReader4[0].ToString();
            }
            baglanti.Close();


            baglanti.Open();

            SqlCommand maascommand2 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel ", baglanti);
            SqlDataReader sqlDataReader5 = maascommand2.ExecuteReader();
            while (sqlDataReader5.Read())
            {
                ortalamalbl.Text = sqlDataReader5[0].ToString();
            }
            baglanti.Close();


        }
    }
}
