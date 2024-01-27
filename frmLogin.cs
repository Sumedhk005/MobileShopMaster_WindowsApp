using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileShopMaster
{
    public partial class frmLogin : Form
    {
        public static SqlConnection Con;
        public SqlCommand cmd;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           ConnectToDatabase();
        }
        private void ConnectToDatabase()
        {
            try
            {
                Con = new SqlConnection("Data Source=SUMEDH-PC\\SQLEXPRESS2012;Initial Catalog=MobileShopMaster;User ID=sa;Password=9342101179 ; timeout=30");
                Con.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("can not connect DataBase" + e.Message);
                System.Windows.Forms.MessageBox.Show("Can not connected To database please set .ini Files!!!" + e.Message, "e-CosmoHealth", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                //System.Windows.Forms.Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, user_password;

            username=txtusername.Text;
            user_password=txtpassword.Text;

            try
            {
                String querry = "SELECT * FROM Login WHERE Username = '" + txtusername.Text + "' AND Password = '" + txtpassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry,Con);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtusername.Text;
                    user_password = txtpassword.Text;
                    
                    frmMenu menu = new frmMenu();
                    menu.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtusername.Clear();
                    txtpassword.Clear();

                    txtusername.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            { 
              Con.Close();
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*txtpassword.Focus();*/
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtusername.Text == "")
                    {
                        MessageBox.Show("Please Enter Username");
                    }
                    else
                    {
                        txtpassword.Focus();
                    }
                }
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtpassword.Text == "")
                {
                    MessageBox.Show("Please Enter Password");
                }
                else
                {
                    btnsave.Focus();
                }
            }
        }
    }
}
