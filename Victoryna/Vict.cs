using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victoryna
{
    [Serializable]
    public partial class Vict : Form
    {
        public Vict()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)      //Ответить
        {
            Functions.Tests(User_data.t);
        }

        private void button2_Click(object sender, EventArgs e)      //Начать
        {
            Functions.Start();
            Functions.Draw_table();
        }

        private void button3_Click(object sender, EventArgs e)      //Следующий вопрос
        {
            Functions.Next_questions();
        }

        private void тёмнаяToolStripMenuItem_Click(object sender, EventArgs e)      //Темная тема
        {   
            Forms.vict.BackColor = Color.Black;
            Forms.vict.comboBox1.BackColor = Color.DarkGray;
            Forms.vict.button1.BackColor = Color.DarkGray;
            Forms.vict.button2.BackColor = Color.DarkGray;
            Forms.vict.button3.BackColor = Color.DarkGray;
            Forms.vict.checkBox1.ForeColor = Color.WhiteSmoke;
            Forms.vict.checkBox2.ForeColor = Color.WhiteSmoke;
            Forms.vict.checkBox3.ForeColor = Color.WhiteSmoke;
            Forms.vict.checkBox4.ForeColor = Color.WhiteSmoke;
            Forms.vict.label1.ForeColor = Color.WhiteSmoke;
            Forms.vict.label2.ForeColor = Color.WhiteSmoke;
            Forms.vict.label3.ForeColor = Color.WhiteSmoke;
            Forms.vict.label4.ForeColor = Color.WhiteSmoke;
            Forms.vict.label5.ForeColor = Color.WhiteSmoke;
            Forms.vict.Show();
        }

        private void светлаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.vict.BackColor = Color.White;
            Forms.vict.comboBox1.BackColor = Color.White;
            Forms.vict.button1.BackColor = Color.White;
            Forms.vict.button2.BackColor = Color.White;
            Forms.vict.button3.BackColor = Color.White;
            Forms.vict.checkBox1.ForeColor = Color.White;
            Forms.vict.checkBox2.ForeColor = Color.White;
            Forms.vict.checkBox3.ForeColor = Color.White;
            Forms.vict.checkBox4.ForeColor = Color.White;
            Forms.vict.label1.ForeColor = Color.White;
            Forms.vict.label2.ForeColor = Color.White;
            Forms.vict.label3.ForeColor = Color.White;
            Forms.vict.label4.ForeColor = Color.White;
            Forms.vict.label5.ForeColor = Color.White;
            Forms.vict.Show();
        }

        public void выйтиИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["JoinForm"];  //Для открытия текущей формы
            ((JoinForm)f).textBox1.Text = null;        //Чтобы когда мы вышли из аккаунта поля были пустыми
            ((JoinForm)f).textBox2.Text = null;
            Forms.vict.Hide();
            f.Show();
        }

        private void Vict_Activated(object sender, EventArgs e)
        {
            label6.Text = $"Добро пожаловать {User_data.join_login}";
        }

        private void добавитьВопросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Create_questions create_Questions = new Create_questions();
            create_Questions.Show();
            Functions.Serializible_questions(text_data.History_questions[text_data.History_questions.Length - 1]);
            Functions.Serializible_questions(text_data.Geography_questions[text_data.Geography_questions.Length - 1]);
            Functions.Serializible_questions(text_data.Biology_questions[text_data.Biology_questions.Length - 1]);
        }

        private void Vict_Load(object sender, EventArgs e)
        {
            
        }
    }
}
