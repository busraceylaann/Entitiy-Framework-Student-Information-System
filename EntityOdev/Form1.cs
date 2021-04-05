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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbSınavOgrenciEntities db = new DbSınavOgrenciEntities();
        

       
        
       

        //private void txtad_TextChanged(object sender, EventArgs e)
        //{
        //    string aranan = txtad.Text;
        //    var degerler = from s in db.TBLOGRENCİ
        //                   where s.AD.Contains(aranan) //aranan textbox ifadeyi datadaki ifadeye eşşit olan item  içerisindekileri bulur
        //                   select s;
        //    dataGridView1.DataSource = degerler.ToList();

        //}

        private void btnlinq_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                List<TBLOGRENCİ> liste1 = db.TBLOGRENCİ.OrderBy(p => p.AD).ToList();
                dataGridView1.DataSource = liste1;
            }
            if(radioButton2.Checked==true)
            {
                List<TBLOGRENCİ> liste2 = db.TBLOGRENCİ.OrderByDescending(p => p.AD).ToList();
                dataGridView1.DataSource = liste2;
            }
            if(radioButton3.Checked==true)
            {
                List<TBLOGRENCİ> liste3 = db.TBLOGRENCİ.OrderBy(p => p.AD).Take(3).ToList();
                dataGridView1.DataSource = liste3;
            }
        }

        private void btnjoin_Click(object sender, EventArgs e)
        {
            var sorgu = from d1 in db.TBLNOTLAR
                        join d2 in db.TBLOGRENCİ
                        on d1.OGR equals d2.ID
                        join d3 in db.TBLDERSLER
                        on d1.DERS equals d3.DERSID
                        select new
                        {
                            ÖĞRENCİ = d2.AD,
                            SOYAD = d2.SOYAD,
                            DERS =d3.DERSADI,                           
                            SINAV1 = d1.SINAV1,
                            SINAV2=d1.SINAV2,
                            SINAV3=d1.SINAV3,
                            ORTALAMA=d1.ORTALAMA,

                        };
            dataGridView1.DataSource = sorgu.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            derscs ders = new derscs();
            ders.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notlar not = new notlar();
            not.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ogrenci ogrenci = new ogrenci();
            ogrenci.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
