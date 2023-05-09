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
    public partial class frmgrafikler : Form
    {
        public frmgrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=1BILGISIZ\\SQLEXPRESS01;Initial Catalog=TblPersonel;Integrated Security=True");

        private void frmgrafikler_Load(object sender, EventArgs e)
        {
            //Sehirler
            baglanti.Open();
            SqlCommand sqlCommand1 = new SqlCommand("Select PerSehir, Count(*) From Tbl_Personel group by PerSehir", baglanti);
            SqlDataReader sqlDataReader = sqlCommand1.ExecuteReader();
            while (sqlDataReader.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(sqlDataReader[0], sqlDataReader[1]);
            }
            baglanti.Close();


            //Maaşlar
            baglanti.Open();
            SqlCommand sqlCommand2 = new SqlCommand("Select PerMeslek, Avg(PerMaas) From Tbl_Personel group by PerMeslek", baglanti);
            SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
            while (sqlDataReader2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(sqlDataReader2[0], sqlDataReader2[1]);
            }
            baglanti.Close();
        }
    }
}
