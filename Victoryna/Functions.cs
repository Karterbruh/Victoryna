using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Victoryna
{
    [Serializable]
    class Functions
    {
        public static string error;     //переменная для вывода ошибок
        

        public static string Check_too_password(string pas1, string pas2)           //Проверка совпадают ли пароли при регистрации
        {
            if (pas2 == "")
            {
                error = text_data.strings[(int)DATA_SET.Confirm_password];
                return error;
            }
            else if (pas1 != pas2)
            {
                error = text_data.strings[(int)DATA_SET.Error_confirm_password];
                return error;
            }
            else
            {
                return null;
            }
        }

        public static string Check_Validation_Login(string str)
        {
            bool done;
            if (str.All(a => Char.IsLetterOrDigit(a)))
            {
                if (str.Length >= 6) done = true;
                else done = false;

            }
            else done = false;

            if (done == false)
            {
                error = text_data.strings[(int)DATA_SET.incorrect_login];

                return error;
            }
            else return null;
        }

        public static string Check_Validation_Password(string str)
        {
            bool done;
            if (str.All(a => Char.IsLetterOrDigit(a)))
            {
                if (str.Length >= 6) done = true;
                else done = false;

            }
            else done = false;

            if (done == false)
            {
                error = text_data.strings[(int)DATA_SET.incorrect_password];

                return error;
            }
            else return null;
        }

        public static string Check_Happy_Birthday()
        {
            System.Windows.Forms.Form Reg = System.Windows.Forms.Application.OpenForms["Registration"];  //Для открытия текущей формы
            DateTime thisTime = DateTime.Today;
            if ((((Registration)Reg).monthCalendar1.SelectionRange.Start.ToString() == Convert.ToString(thisTime)))
            {
                error = text_data.strings[(int)DATA_SET.Error_Happy_Birthday];
                return error;
            }
            else if (Convert.ToDateTime(((Registration)Reg).monthCalendar1.SelectionRange.Start) > Convert.ToDateTime(thisTime))
            {
                error = text_data.strings[(int)DATA_SET.incorrect_Happy_Birthday];
                return error;
            }
            else
            {
                return null;
            }
        }

        public static bool Check_too_login(string last_login)
        {
            for (int i = 0; i < User_data.count; i++)
            {
                if (last_login == User_data.User_list[i].login)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Default_data_after_closing()
        {
            DateTime thisTime = DateTime.Now;     //Чтоб календарь по умолчанию поставить на сегодняшний день
            Forms.registrationForm.textBox1.Text = "";
            Forms.registrationForm.textBox2.Text = "";
            Forms.registrationForm.textBox3.Text = "";
            Forms.registrationForm.label3.Text = "";
            Forms.registrationForm.monthCalendar1.SelectionRange.Start = thisTime;
            Forms.registrationForm.Hide();
        }

        //Засунуть данные в xml
        public static void Serializible_func()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            using (StreamWriter file = new StreamWriter("ThisSystem.xml", false))
            {
                xmlSerializer.Serialize(file, User_data.User_list);
            }
        }

        //Достать данные из файла xml
        public static void Deserializible_func()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            using (StreamReader file = new StreamReader("ThisSystem.xml", false))
            {
                User_data.User_list = (List<User>)xmlSerializer.Deserialize(file);
            }
        }

        public static void Serializible_questions(text_data.question question) //Сохранить вопросы в 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(text_data.question[]));
            using (StreamWriter file = new StreamWriter("questions_lol.xml", false))
            {
                xmlSerializer.Serialize(file, question); 
            }
        }

        public static void Deserializible_questions(text_data.question question)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(text_data.question[]));
            using (StreamReader file = new StreamReader("questions_lol.xml", false))
            {
                question = (text_data.question)xmlSerializer.Deserialize(file);
            }
        }

        // Это должно быть написано текстом!!!!
        // Здесь
        //
        // Читатель не должен догадываться, особенно если в файле 1000+ строк
        //
        //Damn :(
        public static string Registrated()
        {
            Deserializible_func();  //Десерилизировать
            DateTime thisTime = DateTime.Today;
            string login = Forms.registrationForm.textBox1.Text;
            string password = Forms.registrationForm.textBox2.Text;
            string password_two = Forms.registrationForm.textBox3.Text;
            if (!Check_too_login(login))        //Проверка на такой же логин
            {
                //rror = text_data.strings[(int)DATA_SET.login_error_text];

                return Properties.Resources.login_error_text;

                //return error;
            }
            else
            {
                if ((Functions.Check_Validation_Login(login) == null) && (Functions.Check_Validation_Password(password) == null) && (Functions.Check_too_password(password, password_two) == null) && (Functions.Check_Happy_Birthday() == null))     //Если все норм зарегались, т.е. логин и пароль подходят по дресс-коду
                {
                    string wake_up = Forms.registrationForm.monthCalendar1.SelectionRange.Start.ToShortDateString();
                    thisTime = DateTime.Now;
                    string text_for_import_in_the_file = $"Логин: {Forms.registrationForm.textBox1.Text}  Пароль: {Forms.registrationForm.textBox2.Text}  Дата рождения: {wake_up}  Время регистрации: {thisTime}";
                    //button_is_click = true;
                    User_data.User_list.Add(new User { login = Forms.registrationForm.textBox1.Text, password = Forms.registrationForm.textBox2.Text, Date_of_Birthday = wake_up });
                    
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    path = Path.Combine(path, "thissystem.txt");

                    Serializible_func();    //Сериализировать
                    Forms.registrationForm.Hide();
                    return null;
                }
                else
                {
                    return error;
                }
            }
        }

        public static string Join()
        {
            System.Windows.Forms.Form JoinF = System.Windows.Forms.Application.OpenForms["JoinForm"];
            Deserializible_func();
            if ((((JoinForm)JoinF).textBox1.Text == "") && (((JoinForm)JoinF).textBox2.Text == ""))
            {
                error = text_data.strings[(int)DATA_SET.Empty_log_or_password];
                return error;
            }
            else if (Correct_log_and_pass(((JoinForm)JoinF).textBox1.Text, ((JoinForm)JoinF).textBox2.Text) == null)      //Верно ли введен логин и пароль
            {
                User_data.join_login = ((JoinForm)JoinF).textBox1.Text;
                ((JoinForm)JoinF).Hide();
                Forms.vict.Show();

                //User_data.all_points = 0;     //TODO: при входе в новый аккаунт всего должно быть 0 очков, при входе в старый - старое количество
                //User_data.points = 0;
                //User_data.points_Biology = 0;
                //User_data.points_History = 0;
                //User_data.points_Geography = 0;
                //User_data.points_Random = 0;
                return null;
            }
            else
            {
                error = text_data.strings[(int)DATA_SET.incorrect_login_or_password];
                return error;
            }
        }

        public static string Correct_log_and_pass(string login, string password)
        {
            if (User_data.User_list.Count > 0)
            {
                for (int i = 0; i < User_data.User_list.Count; i++)
                {
                    if (login == User_data.User_list[i].login)        //поиск логина
                    {
                        if (password == User_data.User_list[i].password)  //поиск пароля
                        {
                            return null;
                        }
                    }
                }
            }
            else
            {
                error = text_data.strings[(int)DATA_SET.There_are_no_users];
                return error;
            }
            error = text_data.strings[(int)DATA_SET.incorrect_login_or_password];
            return error;
        }

        public static void Draw_table()
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            ((Vict)VictF).dataGridView1.RowCount = 5;
            ((Vict)VictF).dataGridView1.ColumnCount = 3;
            ((Vict)VictF).dataGridView1.Columns[0].HeaderText = "Место";
            ((Vict)VictF).dataGridView1.Columns[0].ReadOnly = true;
            ((Vict)VictF).dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            ((Vict)VictF).dataGridView1.Columns[1].HeaderText = "Логин";
            ((Vict)VictF).dataGridView1.Columns[2].HeaderText = "Правильных ответов";
            ((Vict)VictF).dataGridView1.Columns[0].Width = 50;
            ((Vict)VictF).dataGridView1.Columns[1].Width = 95;
            ((Vict)VictF).dataGridView1.Columns[2].Width = 80;
        }

        public static bool Search_too_login()     //Поиск такого же логина, если пользователь проходит тест ещё раз, то количество верных ответов просто обновилось
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            for (int i = 0; i < User_data.ID; i++)
            {
                if (User_data.join_login == (string)((Vict)VictF).dataGridView1[1, i].Value)
                {
                    User_data.ID = i;
                    return true;
                }

            }
            return false;
        }

        public static void Set_data_table(string login, int amount_scores)       //Внесение данных в таблицу
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            if (User_data.ID > 0) //Т.к. нельзя попасть -1 индекс
            {
                if (Search_too_login()) //Если найден такой-же логин
                {
                    ((Vict)VictF).dataGridView1[1, User_data.ID].Value = login;
                    ((Vict)VictF).dataGridView1[2, User_data.ID].Value = amount_scores;
                    User_data.ID++;
                }
                else
                {
                    ((Vict)VictF).dataGridView1[1, User_data.ID].Value = login;
                    ((Vict)VictF).dataGridView1[2, User_data.ID].Value = amount_scores;
                    User_data.ID++;
                }
            }
            else
            {
                ((Vict)VictF).dataGridView1[1, User_data.ID].Value = login;
                ((Vict)VictF).dataGridView1[2, User_data.ID].Value = amount_scores;
                User_data.ID++;
            }
        }

        public static void Hide_item_main_menu()      //Скрыть элементы интерфейса
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            ((Vict)VictF).comboBox1.Visible = false;
            ((Vict)VictF).button2.Visible = false;
            ((Vict)VictF).label1.Visible = false;
            ((Vict)VictF).label3.Visible = false;
            ((Vict)VictF).label5.Visible = false;
            ((Vict)VictF).dataGridView1.Visible = false;

            ((Vict)VictF).button1.Visible = true;
            ((Vict)VictF).label4.Visible = true;
            ((Vict)VictF).label2.Visible = true;
            ((Vict)VictF).checkBox1.Visible = true;
            ((Vict)VictF).checkBox2.Visible = true;
            ((Vict)VictF).checkBox3.Visible = true;
            ((Vict)VictF).checkBox4.Visible = true;
        }

        public static void Create_question(string question, string answer1, string answer2, string answer3, string answer4)
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            ((Vict)VictF).label2.Text = question;
            ((Vict)VictF).checkBox1.Text = answer1;
            ((Vict)VictF).checkBox2.Text = answer2;
            ((Vict)VictF).checkBox3.Text = answer3;
            ((Vict)VictF).checkBox4.Text = answer4;
        }

        public static void Create_question_arr(int index)   //Создание вопроса (чисто отображение)
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            if (((Vict)VictF).comboBox1.SelectedIndex == 0) //География
            {
                ((Vict)VictF).label2.Text = text_data.Geography_questions[index].queststring;
                ((Vict)VictF).checkBox1.Text = text_data.Geography_questions[index].answers[0];
                ((Vict)VictF).checkBox2.Text = text_data.Geography_questions[index].answers[1];
                ((Vict)VictF).checkBox3.Text = text_data.Geography_questions[index].answers[2];
                ((Vict)VictF).checkBox4.Text = text_data.Geography_questions[index].answers[3];
            }
            else if (((Vict)VictF).comboBox1.SelectedIndex == 1)     //История
            {
                ((Vict)VictF).label2.Text = text_data.History_questions[index].queststring;
                ((Vict)VictF).checkBox1.Text = text_data.History_questions[index].answers[0];
                ((Vict)VictF).checkBox2.Text = text_data.History_questions[index].answers[1];
                ((Vict)VictF).checkBox3.Text = text_data.History_questions[index].answers[2];
                ((Vict)VictF).checkBox4.Text = text_data.History_questions[index].answers[3];
            }
            else if (((Vict)VictF).comboBox1.SelectedIndex == 2)     //Биология
            {
                ((Vict)VictF).label2.Text = text_data.Biology_questions[index].queststring;
                ((Vict)VictF).checkBox1.Text = text_data.Biology_questions[index].answers[0];
                ((Vict)VictF).checkBox2.Text = text_data.Biology_questions[index].answers[1];
                ((Vict)VictF).checkBox3.Text = text_data.Biology_questions[index].answers[2];
                ((Vict)VictF).checkBox4.Text = text_data.Biology_questions[index].answers[3];
            }
        }

        public static CheckBox Selected_checkbox_users()
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            if (((Vict)VictF).checkBox1.Checked)
            {
                return ((Vict)VictF).checkBox1;
            }
            if (((Vict)VictF).checkBox2.Checked)
            {
                return ((Vict)VictF).checkBox2;
            }
            if (((Vict)VictF).checkBox3.Checked)
            {
                return ((Vict)VictF).checkBox3;
            }
            if (((Vict)VictF).checkBox4.Checked)
            {
                return ((Vict)VictF).checkBox4;
            }
            return null;
        }

        public static int Selected_checkbox_users_arr()
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            if (((Vict)VictF).checkBox1.Checked)
            {
                return 1;
            }
            if (((Vict)VictF).checkBox2.Checked)
            {
                return 2;
            }
            if (((Vict)VictF).checkBox3.Checked)
            {
                return 3;
            }
            if (((Vict)VictF).checkBox4.Checked)
            {
                return 4;
            }
            return 0;
        }

        public static string Have_answer_user()     //Проверка того дал ли пользователь ответ?
        {
            if (Selected_checkbox_users() != null)
            {
                return null;
            }
            else
            {
                error = text_data.strings[(int)DATA_SET.Empty_answer];
                return error;
            }
        }

        public static bool Did_you_answer_correctly_one_question(CheckBox checkBox_right, CheckBox checkBox_choose_user)
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            if (checkBox_right == checkBox_choose_user)
            {
                User_data.question++;
                ((Vict)VictF).label4.Text = "Верно";       
                ((Vict)VictF).label4.ForeColor = Color.Green;
                User_data.points++;
                return true;
            }
            else
            {
                ((Vict)VictF).label4.Text = "Неверно";
                ((Vict)VictF).label4.ForeColor = Color.Red;
                User_data.question++;
                return false;
            }
        }       //Верно ли ответил пользователь? (вопрос с одним вариантом ответа

        public static bool Did_you_answer_correctly_some_question(bool checkBox_is_right1, bool checkBox_is_right2, bool checkBox_is_right3, bool checkBox_is_right4) //Если несколько правильных вариантов ответа
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            if ((((Vict)VictF).checkBox1.Checked == checkBox_is_right1) && (((Vict)VictF).checkBox2.Checked == checkBox_is_right2) && (((Vict)VictF).checkBox3.Checked == checkBox_is_right3) && (((Vict)VictF).checkBox4.Checked == checkBox_is_right4))
            {
                User_data.points++;
                User_data.question++;
                ((Vict)VictF).label4.Text = "Верно";
                ((Vict)VictF).label4.ForeColor = Color.Green;
                return true;
            }
            else
            {
                User_data.question++;
                ((Vict)VictF).label4.Text = "Неверно";
                ((Vict)VictF).label4.ForeColor = Color.Red;
                return false;
            }
        }

        public static bool Check_right_or_no(int c, int t)      //Правильно ли ответил пользователь
        {
            text_data.question check = new text_data.question();
            User_data.question++;
            return check.check_answer(Selected_checkbox_users_arr(), t);
        }

        public static void Add_questions()
        {
            System.Windows.Forms.Form Create_q = System.Windows.Forms.Application.OpenForms["Create_questions"];
            if (((Create_questions)Create_q).comboBox1.SelectedIndex == 0)  //География
            {
                List<text_data.question> lst_geography_questions = text_data.Geography_questions.OfType<text_data.question>().ToList();
                lst_geography_questions.Add(new text_data.question { queststring = ((Create_questions)Create_q).textBox1.Text, answers = new string[4] { ((Create_questions)Create_q).textBox2.Text, ((Create_questions)Create_q).textBox3.Text, ((Create_questions)Create_q).textBox4.Text, ((Create_questions)Create_q).textBox5.Text }, right_answer = ((Create_questions)Create_q).comboBox2.SelectedIndex + 1});
                text_data.Geography_questions = lst_geography_questions.ToArray();
            }
            if (((Create_questions)Create_q).comboBox1.SelectedIndex == 1)  //История
            {
                List<text_data.question> lst_history_questions = text_data.History_questions.OfType<text_data.question>().ToList();
                lst_history_questions.Add(new text_data.question { queststring = ((Create_questions)Create_q).textBox1.Text, answers = new string[4] { ((Create_questions)Create_q).textBox2.Text, ((Create_questions)Create_q).textBox3.Text, ((Create_questions)Create_q).textBox4.Text, ((Create_questions)Create_q).textBox5.Text }, right_answer = ((Create_questions)Create_q).comboBox2.SelectedIndex + 1 });
                text_data.History_questions = lst_history_questions.ToArray();
            }
            if (((Create_questions)Create_q).comboBox1.SelectedIndex == 2)  //Биология
            {
                List<text_data.question> lst_biology_questions = text_data.Biology_questions.OfType<text_data.question>().ToList();
                lst_biology_questions.Add(new text_data.question { queststring = ((Create_questions)Create_q).textBox1.Text, answers = new string[4] { ((Create_questions)Create_q).textBox2.Text, ((Create_questions)Create_q).textBox3.Text, ((Create_questions)Create_q).textBox4.Text, ((Create_questions)Create_q).textBox5.Text }, right_answer = ((Create_questions)Create_q).comboBox2.SelectedIndex + 1 });
                text_data.Biology_questions = lst_biology_questions.ToArray();
            }
        }

        public static int Random_Theme_questions()
        {
            Random n = new Random((int)DateTime.Now.Ticks);
            int i = n.Next(0, 3);
            User_data.t = i;
            return User_data.t;
        }   //Рандомайзер случайной темы

        public static int Random_questions()
        {

            while (User_data.counter <= User_data.Random_number.Length)
            {
                User_data.question = User_data.Random_number[User_data.counter];
                return User_data.question;
            }
            return 21;
        }   //Рандомайзер вопроса

        public static void Tests(int t)
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            switch (t)
            {
                case (int)Test.Geography:      //Ответы по географии
                    int last_q = text_data.History_questions.Length;
                    if (User_data.question == 5)
                    {
                        if (Have_answer_user() == null)
                        {
                            Did_you_answer_correctly_some_question(true, false, false, true);
                            Dont_touch_this();
                            ((Vict)VictF).button3.Visible = true;
                        }
                    }
                    else if (User_data.question == 8)
                    {
                        if (Have_answer_user() == null)
                        {
                            Did_you_answer_correctly_some_question(true, true, false, false);
                            Dont_touch_this();
                            ((Vict)VictF).button3.Visible = true;
                        }
                    }
                    else if (last_q == text_data.History_questions.Length)      //Когда последний вопрос
                    {
                        if (Have_answer_user() == null)
                        {
                            Check_right_or_no(last_q, (int)Test.Geography);
                            Dont_touch_this();
                            ((Vict)VictF).button3.Visible = true;
                            if (((Vict)VictF).comboBox1.SelectedIndex == User_data.t)
                            {
                                User_data.all_points -= User_data.points_Geography;   //Вычитаем старое количество правильных ответов 
                                User_data.points_Geography = User_data.points;    //Приравниваем новое количество правильных ответов
                                User_data.all_points += User_data.points_Geography;   //Добавляем количество правильных ответов
                                User_data.User_list.Where(w => w.login == User_data.join_login).ToList().ForEach(s => s.points_Geography = User_data.points_Geography);
                            }
                        }

                    }
                    else
                    {
                        if (Have_answer_user() == null)
                        {
                            Check_right_or_no(User_data.question, t);
                            Dont_touch_this();
                            ((Vict)VictF).button3.Visible = true;
                        }
                    }
                    break;

                case (int)Test.History:  //Ответы по истории
                    Create_question_arr(User_data.question);
                    last_q = text_data.History_questions.Length;
                    if (User_data.question == 3)
                    {
                        if (Have_answer_user() == null)
                        {
                            Did_you_answer_correctly_some_question(true, false, true, true);
                            Dont_touch_this();
                            ((Vict)VictF).button3.Visible = true;
                        }
                    }
                    else if (User_data.question == 9)
                    {
                        if (Have_answer_user() == null)
                        {
                            Did_you_answer_correctly_some_question(true, false, true, true);
                            Dont_touch_this();
                            ((Vict)VictF).button3.Visible = true;
                        }
                    }
                    else if (User_data.question == 17)
                    {
                        if (Have_answer_user() == null)
                        {
                            Did_you_answer_correctly_some_question(true, false, true, false);
                            Dont_touch_this();
                            ((Vict)VictF).button3.Visible = true;
                        }
                    }
                    else if (last_q == text_data.History_questions.Length)      //Когда последний вопрос
                    {
                        if (Have_answer_user() == null)
                        {
                            Check_right_or_no(last_q, (int)Test.History);
                            Dont_touch_this();
                            ((Vict)VictF).button3.Visible = true;
                            if (((Vict)VictF).comboBox1.SelectedIndex == User_data.t)
                            {
                                User_data.all_points -= User_data.points_History;   //Вычитаем старое количество правильных ответов 
                                User_data.points_History = User_data.points;    //Приравниваем новое количество правильных ответов
                                User_data.all_points += User_data.points_History;   //Добавляем количество правильных ответов
                                //User_data.User_list.Where(w => w.login == User_data.join_login).ToList().ForEach(s => s.points_History = User_data.points_History);
                            }
                        }

                    }
                    else
                    {
                        if (Have_answer_user() == null)
                        {
                            Check_right_or_no(User_data.question, t);
                            Dont_touch_this();
                            ((Vict)VictF).button3.Visible = true;
                        }
                    }
                    break;



                    //Тут с несколькими вариантами вопросов нет :) 
                case (int)Test.Biology:      //Ответы по биологии
                    Create_question_arr(User_data.question);
                    last_q = text_data.Biology_questions.Length;    //GOTO: чет странная штука пофиксить надо

                    if (last_q == text_data.History_questions.Length)
                    {
                        Check_right_or_no(last_q, (int)Test.Biology);
                        Dont_touch_this();
                        ((Vict)VictF).button3.Visible = true;
                        if (((Vict)VictF).comboBox1.SelectedIndex == User_data.t)
                        {
                            User_data.all_points -= User_data.points_Biology;   //Вычитаем старое количество правильных ответов 
                            User_data.points_Biology = User_data.points;    //Приравниваем новое количество правильных ответов
                            User_data.all_points += User_data.points_Biology;   //Добавляем количество правильных ответов
                            User_data.User_list.Where(w => w.login == User_data.join_login).ToList().ForEach(s => s.points_Biology = User_data.points_Biology);
                        }
                    }
                    else if (Have_answer_user() == null)        //Иначе просто проверяем правильность ответа
                    {
                        Check_right_or_no(User_data.question, t);
                        Dont_touch_this();
                        ((Vict)VictF).button3.Visible = true;
                    }
                    break;
            }
        }

        public static void Dont_touch_this()
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            ((Vict)VictF).button1.Enabled = false;
            ((Vict)VictF).checkBox1.Enabled = false;
            ((Vict)VictF).checkBox2.Enabled = false;
            ((Vict)VictF).checkBox3.Enabled = false;
            ((Vict)VictF).checkBox4.Enabled = false;
        }   //Чтоб нельзя было нажимать на чек боксы и кнопки

        public static void Start()
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            ((Vict)VictF).Size = new System.Drawing.Size(600, 380);
            User_data.question = 1;
            User_data.points = 0;
            ((Vict)VictF).menuStrip1.Items[0].Enabled = false;
            Hide_item_main_menu();
            switch (((Vict)VictF).comboBox1.SelectedIndex)
            {
                case 0:
                    Create_question_arr(User_data.question);
                    User_data.t = (int)Test.Geography;
                    break;
                case 1:
                    Create_question_arr(User_data.question);
                    User_data.t = (int)Test.History;
                    break;
                case 2:
                    Create_question_arr(User_data.question);
                    User_data.t = (int)Test.Biology;
                    break;
                case 3:     //Рандомные вопросы
                    switch (Random_Theme_questions())
                    {
                        case 0:
                            //text_data.Geography_questions(Random_questions());
                            User_data.t = (int)Test.Geography;
                            User_data.counter++;
                            break;
                        case 1:
                            //text_data.History_questions(Random_questions());
                            User_data.t = (int)Test.History;
                            User_data.counter++;
                            break;
                        case 2:
                            //text_data.Biology_questions(Random_questions());
                            User_data.t = (int)Test.Biology;
                            User_data.counter++;
                            break;
                    }
                    break;
            }
        }

        public static void Next_questions()
        {
            System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];
            //GOTO: кароче как-то надо сделать, что вот последний вопрос уже прошел, надо подвести результаты 
            if ((((User_data.counter == 22) && ((Vict)VictF).comboBox1.SelectedIndex == 3)) ||  ((User_data.question == 22) && (((Vict)VictF).comboBox1.SelectedIndex != 3)))      //Рандом или конкретный тест
            {
                ((Vict)VictF).Size = new System.Drawing.Size(850, 380);
                ((Vict)VictF).comboBox1.Visible = true;
                ((Vict)VictF).button2.Visible = true;
                ((Vict)VictF).label1.Visible = true;
                ((Vict)VictF).label3.Visible = true;
                ((Vict)VictF).label5.Visible = true;
                ((Vict)VictF).dataGridView1.Visible = true;
                ((Vict)VictF).menuStrip1.Items[0].Enabled = true;
                if (((User_data.counter == 21) && (((Vict)VictF).comboBox1.SelectedIndex == 3)))
                {
                    User_data.all_points -= User_data.points_Random;
                    User_data.points_Random = User_data.points;
                    User_data.all_points += User_data.points_Random;
                    //User_data.User_list.Where(w => w.login == User_data.join_login).ToList().ForEach(s => s.points_Random = User_data.points_Random);
                    
                }
                Set_data_table(User_data.join_login, User_data.all_points);
                ((Vict)VictF).dataGridView1.Sort(((Vict)VictF).dataGridView1.Columns[2], ListSortDirection.Descending);
                for (int i = 0; i <= ((Vict)VictF).dataGridView1.RowCount - 1; i++)       //рисует места, с 1 по 5
                {
                    ((Vict)VictF).dataGridView1[0, i].Value = i + 1;
                }

                User_data.question = 1;       //Если пользователь будет проходить ещё раз, то начал с первого вопроса   TODO:
                User_data.counter = 0;
                User_data.points = 0;
                User_data.points_Biology = 0;
                User_data.points_History = 0;
                User_data.points_Geography = 0;
                User_data.points_Random = 0;

                ((Vict)VictF).button1.Visible = false;
                ((Vict)VictF).label4.Visible = false;
                ((Vict)VictF).label2.Visible = false;
                ((Vict)VictF).checkBox1.Visible = false;
                ((Vict)VictF).checkBox2.Visible = false;
                ((Vict)VictF).checkBox3.Visible = false;
                ((Vict)VictF).checkBox4.Visible = false;

            }
            ((Vict)VictF).button3.Visible = false;
            ((Vict)VictF).button1.Enabled = true;
            ((Vict)VictF).checkBox1.Enabled = true;
            ((Vict)VictF).checkBox2.Enabled = true;
            ((Vict)VictF).checkBox3.Enabled = true;
            ((Vict)VictF).checkBox4.Enabled = true;

            ((Vict)VictF).checkBox1.Checked = false;
            ((Vict)VictF).checkBox2.Checked = false;
            ((Vict)VictF).checkBox3.Checked = false;
            ((Vict)VictF).checkBox4.Checked = false;
            ((Vict)VictF).label4.Text = "";

            switch (((Vict)VictF).comboBox1.SelectedIndex)
            {
                case 0:
                    Create_question_arr(User_data.question);
                    break;
                case 1:
                    Create_question_arr(User_data.question);
                    break;
                case 2:
                    Create_question_arr(User_data.question);
                    break;
                case 3:
                    switch (Random_Theme_questions())
                    {
                        case 0:
                            //text_data.Geography_questions(Random_questions());
                            User_data.counter++;
                            break;
                        case 1:
                            //text_data.History_questions(Random_questions());
                            User_data.counter++;
                            break;
                        case 2:
                            //text_data.Biology_questions(Random_questions());
                            User_data.counter++;
                            break;
                    }
                    break;
                    
            }
        }

    }
}
