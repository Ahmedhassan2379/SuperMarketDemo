using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketDemo
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=SW-A-HASSAN;Initial Catalog=SuperMarketdb;Integrated Security=True;");
        private void button2_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void FillCategoryDropDown()
        {
            conn.Open();
            string query = "select CatName from Category_tbl";
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(reader);
            ProductCat.ValueMember = "CatName";
            ProductCat.DataSource = dt;
            conn.Close();
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            FillCategoryDropDown();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SellerForm s = new SellerForm();
            s.Show();
            this.Hide();
        }
    }
}
