using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Victoryna
{
    [Serializable]
    public partial class JoinForm : Form
    {
        public JoinForm()
        {
            InitializeComponent();
            Random rand = new Random();
            User_data.Random_number = Enumerable.Repeat<int>(0, 21).Select((x, i) => new { i = i, rand = rand.Next(0, 21) }).OrderBy(x => x.rand).Select(x => x.i).ToArray();
        }

        private void button1_Click(object sender, EventArgs e)  //Вход
        {
            if (Functions.Join() != null)
            {
                label3.Text = Functions.error;
                label3.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)      //Регистрация
        {
            Forms.registrationForm = new Registration();        //Если не создавать новый экземпляр, то выдает ошибку, что нелья получить доступ к уничтоженному объекту
            Forms.registrationForm.Show();
        }
    }
}
