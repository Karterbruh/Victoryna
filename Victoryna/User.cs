using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victoryna
{
    [Serializable]
    enum Test
    {
        Geography,
        History,
        Biology,
        Random_questions
    }

    public struct User
    {
        public string login;
        public string password;
        public string Date_of_Birthday;
        public int points_History;
        public int points_Biology;
        public int points_Geography;
        public int points_Random;
    }

    public static class User_data
    {
        public static int count { get { return User_list.Count; } }

        public static List<User> User_list = new List<User>();
        public static string join_login;
        public static int ID = 0;
        public static int counter = 0;
        public static int t;    //Выбранная тема
        public static int[] Random_number = new int[21];
        public static int question = 1;
        public static int all_points = 0;
        public static int points_History = 0;
        public static int points_Biology = 0;
        public static int points_Geography = 0;
        public static int points_Random = 0;
        public static int points = 0;
    }

    public static class Forms
    {
        public static Registration registrationForm = new Registration();
        public static Vict vict = new Vict();
    }
}
