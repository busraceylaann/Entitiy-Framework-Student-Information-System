using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityOdev
{
    public partial class ogrenci : Form
    {
        public ogrenci()
        {
            InitializeComponent();
        }
        DbSınavOgrenciEntities db = new DbSınavOgrenciEntities();
        private void btnkaydet_Click(object sender, EventArgs e)
        {

            TBLOGRENCİ t = new TBLOGRENCİ();
            t.AD = txtad.Text;
            t.SOYAD = txtsoyad.Text;
            db.TBLOGRENCİ.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Listeye Eklenmiştir");
            dataGridView1.DataSource = db.TBLOGRENCİ.ToList();
        }

        private void btnogrencilistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLOGRENCİ.ToList();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(txtogrenciıd.Text);
            var ogr = db.TBLOGRENCİ.Find(id);
            db.TBLOGRENCİ.Remove(ogr);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Silindi");
            txtad.Text = "";
            txtsoyad.Text = "";
            txtogrenciıd.Text = "";
            dataGridView1.DataSource = db.TBLOGRENCİ.ToList();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtogrenciıd.Text);
            var x = db.TBLOGRENCİ.Find(id);
            x.AD = txtad.Text;
            x.SOYAD = txtsoyad.Text;

            db.SaveChanges();
            MessageBox.Show("Öğrenci Bilgileri Başarıyla Güncellendi");
            txtad.Text = "";
            txtsoyad.Text = "";
            txtogrenciıd.Text = "";
            dataGridView1.DataSource = db.TBLOGRENCİ.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {


                string userId = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string user2Id = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string jobId = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;

                txtogrenciıd.Text = jobId;
                txtad.Text = userId;
                txtsoyad.Text = user2Id;




            }
        }
    }
}
