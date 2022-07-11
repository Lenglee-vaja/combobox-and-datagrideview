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

namespace Homeworklab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ACER\Documents\LabHw.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillstudentid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select stid From tbstudent", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("stid", typeof(string));
            dt.Load(rdr);
            cbid.ValueMember = "stid";
            cbid.DataSource = dt;
            con.Close();
        }
        private void fillstudentname()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select stname From tbstudent", con);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("stname", typeof(string));
            dt2.Load(rd);
            cbname.ValueMember = "stname";
            cbname.DataSource = dt2;
            con.Close();
        }
        private void fillstudentclass()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select stclass From tbstudent", con);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Columns.Add("stclass", typeof(string));
            dt3.Load(rd);
            cbclass.ValueMember = "stclass";
            cbclass.DataSource = dt3;
            con.Close();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from tbfees";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dgfees.DataSource = ds.Tables[0];
            con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            fillstudentid();
            fillstudentname();
            fillstudentclass();
            populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*tbnum.Text = dgfees.SelectedRows[0].Cells[0].Value.ToString();
            cbgender.SelectedItem = dgfees.SelectedRows[0].Cells[4].Value.ToString();
            tbmon.Text = dgfees.SelectedRows[0].Cells[6].Value.ToString();
            
            StdPhone.Text = StdDGV.SelectedRows[0].Cells[4].Value.ToString();
            FeesTb.Text = StdDGV.SelectedRows[0].Cells[6].Value.ToString();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
             try
             {
                 if (tbnum.Text == "" || tbmon.Text == "" )
                 {
                     MessageBox.Show("Missing Information");
                 }
                 else
                 {
                     con.Open();
                     SqlCommand cmd = new SqlCommand("insert into tbfees values('" + tbnum.Text + "','" + cbid.SelectedValue.ToString() + "','" + cbname.SelectedValue.ToString() + "','" + cbclass.SelectedValue.ToString() + "','" + cbgender.SelectedItem.ToString() + "','" + cbyear.SelectedItem.ToString() + "','" + tbmon.Text + "')", con);
                     cmd.ExecuteNonQuery();
                     MessageBox.Show("Fees Successfully Added");
                     con.Close();
                     populate();
                 }
             }
             catch
             {
                 MessageBox.Show("Something Went Wrong");
             }
            /*dgfees.Rows.Add(tbnum.Text, cbid.SelectedValue.ToString(), cbname.SelectedValue.ToString(), cbclass.SelectedValue.ToString(), cbgender.SelectedItem.ToString(), cbyear.SelectedItem.ToString(), tbmon.Text);*/
        }
    }
}
