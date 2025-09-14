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

        private void txtAccountBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Customer> customers = customerOperations.GetAllCustomer();
            dataGridView1.DataSource= customers;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerId.Text;
            customerOperations.DeleteCustomer(customerId);
            MessageBox.Show("Müşteri Başarıyla Silindi.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            var updateCustomer = new Customer()
            {
                CustomerName= txtCustomerName.Text,
                CustomerSurname= txtCustomerSurname.Text,
                CustomerBalance = decimal.Parse(txtAccountBalance.Text),
                ShoppingCount = int.Parse(txtShopPrice.Text),
                CustomerId = id
            };
            customerOperations.UpdateCustomer(updateCustomer);
            MessageBox.Show("Müşteri Başarıyla Güncellendi");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            string id = txtCustomerId.Text;
            Customer customers = customerOperations.GetCustomerById(id);
            dataGridView1.DataSource = new List<Customer> { customers};
        }
    }
}
