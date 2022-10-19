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

namespace Stock_Manager_GUI
{
    public partial class product_managment : Form
    {

        public void getproduct()
        {
            string str = @"data source=DESKTOP-DTLL7GR\SQLEXPRESS; initial catalog = productmanagment ; integrated security= true";
            SqlConnection sql = new SqlConnection(str);

            //   MessageBox.Show("connected successfully");

            string query = "select * from product";
            SqlCommand com = new SqlCommand(query, sql);
            DataTable dt = new DataTable();
            sql.Open();
            SqlDataReader sdr = com.ExecuteReader();
            dt.Load(sdr);
            com.ExecuteNonQuery();

            sql.Close();
            dataGridView1.DataSource = dt;






        }

        public product_managment()
        {
            InitializeComponent();
        }

        private void product_managment_Load(object sender, EventArgs e)
        {
            getproduct();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = @"data source=DESKTOP-DTLL7GR\SQLEXPRESS ; initial catalog = productmanagment  ; integrated security= true";
            SqlConnection sql= new SqlConnection(str);
            sql.Open();
            MessageBox.Show("connected successfully");

            string query = "insert into product values('" + txt_pid.Text + "','" + txt_name.Text + "','" + txt_price.Text + "','" + txt_disc.Text + "', '" + txt_catid.Text + "')";
         
            SqlCommand com = new SqlCommand(query, sql);
            com.ExecuteNonQuery();

            sql.Close();
            

            getproduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = @"data source=DESKTOP-DTLL7GR\SQLEXPRESS ; initial catalog = productmanagment ; integrated security= true";
            SqlConnection sql= new SqlConnection(str);
            sql.Open();


            string query = "update product set name='" + txt_name.Text + "' , price='" + txt_price.Text + "',discription='" + txt_disc.Text + "' ,catagoryid='" + txt_catid.Text + "' where id='" + txt_pid.Text + "'";
            SqlCommand com = new SqlCommand(query, sql);

            com.ExecuteNonQuery();

            sql.Close();
    


            getproduct();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = @"data source=DESKTOP-DTLL7GR\SQLEXPRESS ; initial catalog = productmanagment; integrated security= true";
            SqlConnection sql = new SqlConnection(str);
            sql.Open();

            string query = "delete  from product where id='" + txt_pid + "'";
            SqlCommand com = new SqlCommand(query, sql);
            com.ExecuteNonQuery();

            sql.Close();


            getproduct();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = @"data source=DESKTOP-DTLL7GR\SQLEXPRESS ; initial catalog = productmanagment; integrated security= true";
            SqlConnection sql = new SqlConnection(str);
            sql.Open();


            string query = "select*  from product where id='" + txt_pid + "'";
            SqlCommand com = new SqlCommand(query, sql);
            com.ExecuteNonQuery();

            sql.Close();


            getproduct();

        }
    }
}
