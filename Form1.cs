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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=1BILGISIZ\\SQLEXPRESS01;Initial Catalog=TblPersonel;Integrated Security=True"); 
       
        private void Form1_Load(object sender, EventArgs e)
        {
        
          

        }


        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Select * from Tbl_Personel", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataTable dt = new DataTable(); 

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd, PerSoyad, PerSehir, PerMaas, PerMeslek, PerDurum) values (@p1, @p2, @p3, @p4 , @p5, @p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtperad.Text);
            komut.Parameters.AddWithValue("@p2", txtpersoyad.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Eklendi...");

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";

            }
        }

        void Temizle()
        {
            txtid.Text = "";
            txtperad.Text = "";
            txtpersoyad.Text = "";
            txtmeslek.Text = "";
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked= false;
            txtperad.Focus();
        }


        private void BtnTEmizle_Click(object sender, EventArgs e)
        {
            Temizle();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            int seçilen = dataGridView1.SelectedCells[0].RowIndex;
           
            txtid.Text = dataGridView1.Rows[seçilen].Cells[0].Value.ToString();
            txtperad.Text= dataGridView1.Rows[seçilen].Cells[1].Value.ToString();
            txtpersoyad.Text= dataGridView1.Rows[seçilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[seçilen].Cells[3].Value.ToString(); 
            maskedTextBox1.Text = dataGridView1.Rows[seçilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[seçilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[seçilen].Cells[6].Value.ToString();


        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;

            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel where Perid=@k1 ", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Silindi...");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand güncellecommand = new SqlCommand("Update Tbl_Personel Set Perad=@a1, PerSoyad=@a2, PerSehir=@a3, PerMaas=@a4, PerDurum=@a5, PerMeslek=@a6   Where Perid=@a7 ", baglanti);
            güncellecommand.Parameters.AddWithValue("@a1" , txtperad.Text);
            güncellecommand.Parameters.AddWithValue("@a2", txtpersoyad.Text);
            güncellecommand.Parameters.AddWithValue("@a3", comboBox1.Text);
            güncellecommand.Parameters.AddWithValue("@a4", maskedTextBox1.Text);
            güncellecommand.Parameters.AddWithValue("@a5", label8.Text);
            güncellecommand.Parameters.AddWithValue("@a6", txtmeslek.Text);
            güncellecommand.Parameters.AddWithValue("@a7", txtid.Text);
            güncellecommand.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kayıt Güncellendi...");


        }

        private void Btnİstatiktik_Click(object sender, EventArgs e)
        {
            frmİstatistik frmİstatistik = new frmİstatistik();
            frmİstatistik.Show();

        }

        private void BtnGrafik_Click(object sender, EventArgs e)
        {
            frmgrafikler frmgrafikler = new frmgrafikler(); 
            frmgrafikler.Show();
        }
    }
}
