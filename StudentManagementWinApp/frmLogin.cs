using BusinessObject.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementWinApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Role", typeof(string));
            table.Columns.Add("Name", typeof(string));
            using var contex = new studentmanagementContext();
            foreach (var item in contex.Accounts.ToList())
            {
                table.Rows.Add(item.UserId, item.Role, item.Name);
            }
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account acc = new Account
            {
                UserId = "123",
                Name = "quyen",
                Role = "11",
            };
            try
            {
                using var contex = new studentmanagementContext();
                contex.Accounts.Add(acc);
                contex.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
