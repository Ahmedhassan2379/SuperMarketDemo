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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G7GOH9P\SQLEXPRESS;Initial Catalog=SuperMarketdb;Integrated Security=True;");
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string checkquery = "select CatId from Category_tbl where CatId="+CatId.Text+"";
                SqlDataAdapter cmd = new SqlDataAdapter(checkquery, con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("This Item Is Existed");
                }
                else
                {
                    con.Open();
                    string query = "insert into Category_tbl values(" + CatId.Text + ",'" + CatName.Text + "','" + CatDes.Text + "')";
                    SqlCommand sqlCommand = new SqlCommand(query, con);
                    sqlCommand.ExecuteNonQuery();
                    con.Close();
                    CatId.Text = "";
                    CatName.Text = "";
                    CatDes.Text = "";
                    DisplayCategories();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void DisplayCategories()
        {
            con.Open();
            string query = "select * from Category_tbl";
            SqlDataAdapter adapter = new SqlDataAdapter(query,con);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            CategoryDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            DisplayCategories();
        }

        private void CategoryDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatId.Text = CategoryDGV.SelectedRows[0].Cells[0].Value.ToString();
            CatName.Text = CategoryDGV.SelectedRows[0].Cells[1].Value.ToString();
            CatDes.Text = CategoryDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatId.Text == "")
                {
                    MessageBox.Show("select category");
                }
                else
                {
                    MessageBox.Show("You Want Delete This Item ?!");
                    con.Open();
                    string query = "delete from Category_tbl where CatId=" + CatId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    CatId.Text = "";
                    CatName.Text = "";
                    CatDes.Text = "";
                    DisplayCategories();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatId.Text == ""||CatName.Text==""||CatDes.Text=="")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    string query = "update Category_tbl set CatName='"+CatName.Text+"',CatDestcription='"+CatDes.Text+"' where CatId="+CatId.Text+"";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    CatId.Text = "";
                    CatName.Text = "";
                    CatDes.Text = "";
                    DisplayCategories();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            form.Show();
            this.Hide();
        }
    }
}
