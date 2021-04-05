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
    public partial class notlar : Form
    {
        public notlar()
        {
            InitializeComponent();
        }
        DbSınavOgrenciEntities db = new DbSınavOgrenciEntities();
        private void notlistele_Click(object sender, EventArgs e)
        {
            var sorgu = from item in db.TBLNOTLAR select new { item.NOTID, item.TBLOGRENCİ.AD, item.TBLOGRENCİ.SOYAD, item.TBLDERSLER.DERSADI, item.SINAV1, item.SINAV2, item.SINAV3, item.ORTALAMA, item.DURUM };
            dataGridView1.DataSource = sorgu.ToList();
        }

   

        private void btnhesapla_Click(object sender, EventArgs e)
        {
            int toplam1 = Convert.ToInt32(txtsinav1.Text);
            int toplam2 = Convert.ToInt32(txtsinav2.Text);
            int toplam3 = Convert.ToInt32(txtsinav3.Text);
            int ortalama = 0;
            ortalama = (toplam1 + toplam2 + toplam3) / 3;
            txtortalama.Text = ortalama.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {

                string userId11 = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string userId0 = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                string user2Id12 = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                string userId = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                string user2Id = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                string jobId = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;

                txtsinav1.Text = jobId;
                txtsinav2.Text = userId;
                txtsinav3.Text = user2Id;
                comboadsoyad.Text = userId11;
                comboders.Text = user2Id12;
                txtnotid.Text = userId0;




            }
        }
        private void sinavlistele()
        {
            var query = from item in db.TBLNOTLAR
                        select new
                        {
                            item.NOTID,
                            item.TBLOGRENCİ.AD,
                            item.TBLOGRENCİ.SOYAD,
                            item.TBLDERSLER.DERSADI,
                            item.SINAV1,
                            item.SINAV2,
                            item.SINAV3,
                            item.ORTALAMA,
                            item.DURUM

                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void btnsınavkaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLAR n = new TBLNOTLAR();
            
            //var ogrenci = db.TBLOGRENCI.Where(x => x.ID.Equals(cmbadsoyad.SelectedValue)).ToList();
            //label3.Text =Convert.ToString( ogrenci);
            n.OGR = Convert.ToInt16(comboadsoyad.SelectedValue);
            n.DERS = Convert.ToInt16(comboders.SelectedValue);
            n.SINAV1 = Convert.ToInt16(txtsinav1.Text);
            n.SINAV2 = Convert.ToInt16(txtsinav2.Text);
            n.SINAV3 = Convert.ToInt16(txtsinav3.Text);
            n.ORTALAMA = Convert.ToInt16(txtortalama.Text);
            n.DURUM = Convert.ToBoolean(comboBox1.SelectedValue);
            sinavlistele();
            db.TBLNOTLAR.Add(n);
            db.SaveChanges();
            
            MessageBox.Show("Not kaydedildi");
            dataGridView1.DataSource = db.TBLNOTLAR.ToList();
        }

        private void notlar_Load(object sender, EventArgs e)
        {
            sinavlistele();
            var listeogrenci = db.TBLOGRENCİ.Select(x => new
            {
                x.ID,
                AD = x.AD + " " + x.SOYAD
            }).ToList();
            comboadsoyad.DataSource = listeogrenci;
            comboadsoyad.DisplayMember = "AD";
            comboadsoyad.ValueMember = "ID";

            var listeders = db.TBLDERSLER.ToList();
            comboders.DataSource = listeders;
            comboders.DisplayMember = "DERSAD";
            comboders.ValueMember = "DERSID";
        }

        private void btnsınavguncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtnotid.Text);
            var n = db.TBLNOTLAR.Find(id);
            n.SINAV1 = Convert.ToInt16(txtsinav1.Text);
            n.SINAV2 = Convert.ToInt16(txtsinav2.Text);
            n.SINAV3 = Convert.ToInt16(txtsinav3.Text);
            n.ORTALAMA = Convert.ToInt16(txtortalama.Text);
            n.DURUM = Convert.ToBoolean(comboBox1.SelectedValue);
            db.SaveChanges();
            sinavlistele();
            MessageBox.Show("Not güncellendi");
            dataGridView1.DataSource = db.TBLNOTLAR.ToList();

        }
    }
}
