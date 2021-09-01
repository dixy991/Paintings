using Slizlba.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slizlba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateDataGridView();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void PopulateDataGridView()
        {
            var slike = GetSLike();
            dataGridView1.DataSource = slike;
        }

        private object GetSLike()
        {
            var uzmi = new OperationSlikeSelect();
            var provera = OperationManager.Insance.executeOperation(uzmi);
            var oc = provera as OperationCollection;
            return oc.Data.Cast<DtoSlike>().ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var unos = new OperationSlikeInsert();
            unos.Slika = new DtoSlike
            {
                Cena = 250,
                Datum = DateTime.Now,
                Naziv = "Tu sam"
            };
            unos.Autori = new int[] { 2, 3 };
            var provera = OperationManager.Insance.executeOperation(unos);
            if (provera.Succeess)
                PopulateDataGridView();
            else
                MessageBox.Show(provera.Message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var izabran = dataGridView1.SelectedRows[0].DataBoundItem as DtoSlike;
            var unos = new OperationSlikeUpdate();
            unos.Slika = new DtoSlike
            {
                Id = izabran.Id,
                Cena = 250,
                Datum = DateTime.Now,
                Naziv = "Promena!"
            };
            var provera = OperationManager.Insance.executeOperation(unos);
            if (provera.Succeess)
                PopulateDataGridView();
            else
                MessageBox.Show(provera.Message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var izabran = dataGridView1.SelectedRows[0].DataBoundItem as DtoSlike;
            var brisanje = new OperationSlikeDelete();
            brisanje.Slika = new DtoSlike
            {
                Id = izabran.Id
            };
            var provera = OperationManager.Insance.executeOperation(brisanje);
            if (provera.Succeess)
                PopulateDataGridView();
            else
                MessageBox.Show(provera.Message);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var izabran = dataGridView1.SelectedRows[0].DataBoundItem as DtoSlike;
            var nadji = new getAutoriOp(izabran.Id);
            var provera = OperationManager.Insance.executeOperation(nadji);
            var oc = provera as OperationCollection;
            dataGridView2.DataSource = oc.Data.Cast<DtoAutor>().ToArray();
        }
    }
}
