using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace Victoryna
{
    [Serializable]
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)      
        {
            if (Functions.Registrated() != null)    //Если какая-то ошибка, то
            {
                label3.Text = Functions.Registrated();
                label3.ForeColor = Color.Red;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.UseSystemPasswordChar = false;
                this.pictureBox2.Image = Image.FromFile("open.png");   //Работает быстрее и лучше, чем this.pictureBox2.Load("filename.jpg");
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                textBox2.UseSystemPasswordChar = true;
                this.pictureBox2.Image = Image.FromFile("close.png");
            }
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel)
            {
                Functions.Default_data_after_closing();
            }
        }
    }
}
