using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Victoryna
{
    public partial class Create_questions : Form
    {
        public Create_questions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Functions.Add_questions();
            if (comboBox1.SelectedIndex == 0)
            {
                Functions.Deserializible_questions(text_data.Geography_questions[text_data.Geography_questions.Length - 1]);
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Functions.Deserializible_questions(text_data.History_questions[text_data.History_questions.Length - 1]);
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Functions.Deserializible_questions(text_data.Biology_questions[text_data.Biology_questions.Length - 1]);
            }
        }
    }
}
