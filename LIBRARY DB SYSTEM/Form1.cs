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

namespace LIBRARY_DB_SYSTEM
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-168VT5JN\\SQLEXPRESS;Initial Catalog=\"LIBRARY DB\";Integrated Security=True");
        //private const string connectionString = "Data Source=LAPTOP-168VT5JN\\SQLEXPRESS;Initial Catalog=\"LIBRARY DB\";Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lIBRARY_DBDataSet.Table_bookdb' table. You can move, or remove it, as needed.
            this.table_bookdbTableAdapter.Fill(this.lIBRARY_DBDataSet.Table_bookdb);
         
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Table bookdb] (id,name,title,auther,ISBN,[sh book]) values ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox4.Text+"','"+textBox3.Text+"','"+textBox5.Text+"','"+textBox6.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            display_data();
            MessageBox.Show("succesully inserted!");
        }

        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Table bookdb]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataapd = new SqlDataAdapter(cmd);
            dataapd.Fill(dta);
            dataGridView1.DataSource = dta;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "delete from [Table bookdb] where name = '" + textBox2.Text + "'";
            //cmd.CommandText = "delete from [Table bookdb] where id = '" + textBox1.Text + "' AND name = '" + textBox2.Text + "' AND title = '" + textBox4.Text + "' AND auther = '" + textBox3.Text + "' AND ISBN = '" + textBox5.Text + "' AND sh book = '" + textBox6.Text + "'";
            cmd.CommandText = "delete from [Table bookdb] where id = @id AND name = @name AND title = @title AND auther = @author AND ISBN = @isbn AND [sh book] = @shBook";
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@title", textBox4.Text);
            cmd.Parameters.AddWithValue("@author", textBox3.Text);
            cmd.Parameters.AddWithValue("@isbn", textBox5.Text);
            cmd.Parameters.AddWithValue("@shBook", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            display_data();
            MessageBox.Show("succesully deleted!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Table bookdb] set name = '" + textBox2.Text + "' where name = '"+textBox2.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            display_data();
            MessageBox.Show("succesully updated!");
        }
    }
}
