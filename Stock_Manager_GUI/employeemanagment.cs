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
using System.Text.RegularExpressions;

namespace Stock_Manager_GUI
{
    public partial class employeemanagment : Form
    {

        public void getemployeerecord()
        {
            string str = @"data source=BESU\SQLEXPRESS ; initial catalog = managingemployee ; integrated security= true";
            SqlConnection sqlcon = new SqlConnection(str);

            //   MessageBox.Show("connected successfully");

            string query = "select * from employeeinfo";
            SqlCommand com = new SqlCommand(query, sqlcon);
            DataTable dt = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = com.ExecuteReader();
            dt.Load(sdr);
            com.ExecuteNonQuery();

            sqlcon.Close();
            dataGridView1.DataSource = dt;






        }
        
        public void validate()
        {
            Regex reg1 = new Regex(@"^[a-z] {2}[1-9] {2}$");
            Regex reg2 = new Regex(@"^[A-Z] {1}[a-z] {3,8}$");
            Regex reg3 = new Regex(@"^[m|m]ale|[f|F]emale$");
            Regex reg4 = new Regex(@"^[a-z]{3}[A-Z]{2}[@|#|$]{1}");
           
                
            if (!reg1.IsMatch(txt_empid.Text))
            {
                errorProvider1.SetError(txt_empid, "invalid employee id");
            }

           
            if (!reg2.IsMatch(txt_fname.Text))
            {
                errorProvider1.SetError(txt_fname, "invalid firstname");
            }


            if (!reg2.IsMatch(txt_lname.Text))
            {
                errorProvider1.SetError(txt_lname, "invalid last name");
            }


            if (!reg1.IsMatch(txt_rid.Text))
            {
                errorProvider1.SetError(txt_rid, "invalid rollid");
            }

            if (!reg4.IsMatch(txt_password.Text))
            {
                errorProvider1.SetError(txt_password, "invalid password");
            }

        }
        public employeemanagment()
        {
            InitializeComponent();
        }

        private void employeemanagment_Load(object sender, EventArgs e)
        {
            getemployeerecord();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string str = @"data source=BESU\SQLEXPRESS ; initial catalog = managingemployee  ; integrated security= true";
            SqlConnection sqlcon = new SqlConnection(str);
            sqlcon.Open();
            MessageBox.Show("connected successfully");

            string query = "insert into employeeinfo values('" + txt_empid.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_gender.Text + "', '" + txt_rid.Text + "', '" + txt_password.Text + "')";
           // validate();
            SqlCommand com = new SqlCommand(query, sqlcon);
            com.ExecuteNonQuery();

            sqlcon.Close();
            validate();
           
           
            getemployeerecord();
           
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string str = @"data source=BESU\SQLEXPRESS ; initial catalog = managingemployee ; integrated security= true";
            SqlConnection sqlcon = new SqlConnection(str);
            sqlcon.Open();


            string query = "update employeeinfo set rollid='" + txt_rid.Text + "' , firstname='" + txt_fname.Text + "',lastname='" + txt_lname.Text + "' ,gender='" + txt_gender.Text + "', password='" + txt_password.Text + "' where id='" + txt_empid.Text + "'";
            SqlCommand com = new SqlCommand(query, sqlcon);

            com.ExecuteNonQuery();

            sqlcon.Close();
            validate();
           

            getemployeerecord();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string str = @"data source=BESU\SQLEXPRESS ; initial catalog = managingemployee ; integrated security= true";
            SqlConnection sqlcon = new SqlConnection(str);
            sqlcon.Open();

            string query = "delete  from employeeinfo where id='" + txt_empid + "'";
            SqlCommand com = new SqlCommand(query, sqlcon);
            com.ExecuteNonQuery();

            sqlcon.Close();

           
            getemployeerecord();

        }
        /*
        private void btn_search_Click(object sender, EventArgs e)
        {

        }
*/
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_empid.Text = "";
            txt_fname.Text = "";
            txt_lname.Text = "";
            txt_fname.Text = "";
            txt_gender.Text = "";
            txt_rid.Text = "";
            txt_password.Text = "";
        }
    }
}
