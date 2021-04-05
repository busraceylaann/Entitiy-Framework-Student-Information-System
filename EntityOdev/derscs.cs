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

namespace EntityOdev
{
    public partial class derscs : Form
    {
        public derscs()
        {
            InitializeComponent();
        }
        DbSınavOgrenciEntities db = new DbSınavOgrenciEntities();
        private void btnekle_Click(object sender, EventArgs e)
        {
            TBLDERSLER d = new TBLDERSLER();
            d.DERSADI = txtdersad.Text;
            db.TBLDERSLER.Add(d);
            db.SaveChanges();
            MessageBox.Show("Ders Listeye Eklenmiştir");
            txtdersad.Text = "";
            txtdersıd.Text = "";
            dataGridView1.DataSource = db.TBLDERSLER.ToList();
        }

        private void btndersil_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtdersıd.Text);
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            MessageBox.Show("Ders Silindi");
            txtdersad.Text = "";
            txtdersıd.Text = "";
            dataGridView1.DataSource = db.TBLDERSLER.ToList();
        }

        private void btndersguncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtdersıd.Text);
            var x = db.TBLDERSLER.Find(id);
            x.DERSADI = txtdersad.Text;


            db.SaveChanges();
            MessageBox.Show("Ders Bilgileri Başarıyla Güncellendi");
            txtdersad.Text = "";
            txtdersıd.Text = "";
            dataGridView1.DataSource = db.TBLDERSLER.ToList();
        }

        private void btnderslistele_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-9FQMCJ0\SQLEXPRESS;Initial Catalog=DbSınavOgrenci;Integrated Security=True");
            SqlCommand komut = new SqlCommand("Select *From tbldersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {


                string userId = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string jobId = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;

                txtdersıd.Text = jobId;
                txtdersad.Text = userId;
               




            }
        }
    }
}
