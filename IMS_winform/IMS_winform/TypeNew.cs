using IMS_winform.Repositories;
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

namespace IMS_winform
{
    public partial class TypeNew : Form
    {
        public TypeNew()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            Models.Type type = new Models.Type();
            type.Name = textBoxName.Text;
            type.Description = textBoxDes.Text;

            TypeRepository typeRepo = new TypeRepository();
            typeRepo.Create(type);

            MessageBox.Show("Success!");
        }

    }
}
