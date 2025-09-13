using MongoDbEgitim.Entities;
using MongoDbEgitim.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDbEgitim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        CustomerOperations customerOperations= new CustomerOperations();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var customner = new Customer()
            {
                CustomerName = txtCustomerName.Text,
                CustomerSurname = txtCustomerSurname.Text,
                CustomerBalance = decimal.Parse(txtAccountBalance.Text),
                ShoppingCount = int.Parse(txtShopPrice.Text),
            };
            customerOperations.AddCustomer(customner);
            MessageBox.Show("Ekleme işlemi başarıyla gerçekleşti.","Ekleme!!!",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
