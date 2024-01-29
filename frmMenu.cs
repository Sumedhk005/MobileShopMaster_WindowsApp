using System;
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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void loginMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginMaster login = new LoginMaster();
            login.MdiParent = this;
            login.Show();
        }

        private void productMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPackingMaster product = new frmPackingMaster();
            product.MdiParent = this;
            product.Show();
        }

        private void companyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompanyMaster company = new frmCompanyMaster();
            company.MdiParent = this;
            company.Show();
        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerMaster customer = new frmCustomerMaster();   
            customer.MdiParent = this;
            customer.Show();
        }
    }
}
