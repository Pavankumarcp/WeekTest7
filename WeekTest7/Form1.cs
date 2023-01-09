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
using System.Configuration;

namespace WeekTest7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAddnew_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HRCon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("AddEmployeeByValidating", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeNo",TxtEmployeeNo.Text);
            cmd.Parameters.AddWithValue("@EmployeeName", TxtEmployeeName.Text);
            cmd.Parameters.AddWithValue("@Salary", TxtSalary.Text);
            if(radioButton1.Checked)
            {
                cmd.Parameters.AddWithValue("@EmployeeType",'P');
            }
            cmd.Parameters.AddWithValue("@EmployeeType", 'C');
            
            cmd.Parameters.AddWithValue("@EmployeeType", TxtSalary.Text);
            if(con.State==ConnectionState.Closed)
            {
                con.Open();
            }
            
            
            
            cmd.ExecuteNonQuery();
        }
        public void ResetDetails()
        {
            TxtEmployeeNo.Text = "";
            TxtEmployeeName.Text = "";
            TxtEmployeeName.Text = "";
            TxtSalary.Text = "";
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            
            ResetDetails();


        }
        
    }
}
