using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ef
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        ProductDal productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        public void LoadProducts()
        {
            dgw1.DataSource = productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            productDal.Add(new Product
            {
                Name = txtAddName.Text,
                UnitPrice = Convert.ToDecimal(txtAddUnitPrice.Text),
                StockAmount = Convert.ToInt32(txtAddStockAmount.Text),
            });
            LoadProducts();
            MessageBox.Show("Added!");
        }

        private void dgw1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUpdateName.Text = dgw1.CurrentRow.Cells[1].Value.ToString();
            txtUpdateUnitPrice.Text = dgw1.CurrentRow.Cells[2].Value.ToString();
            txtUpdateStockAmount.Text = dgw1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgw1.CurrentRow.Cells[0].Value),
                Name = txtUpdateName.Text,
                UnitPrice = Convert.ToDecimal(txtUpdateUnitPrice.Text),
                StockAmount = Convert.ToInt32(txtUpdateStockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("Updated");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgw1.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Deleted!");
        }
    }
}
