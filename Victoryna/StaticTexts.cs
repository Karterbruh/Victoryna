using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Victoryna
{
    enum DATA_SET
    {
        text1,
        text2,
        login_error_text,
        incorrect_login,
        Confirm_password,
        Error_confirm_password,
        incorrect_password,
        Error_Happy_Birthday,
        incorrect_Happy_Birthday,
        There_are_no_users,
        incorrect_login_or_password,
        Empty_log_or_password,
        Empty_answer,
        Right,
        Wrong,
        helloworld,
        max
    };

    static class text_data
    {

        public static string[] strings = new string[(int)DATA_SET.max]{
            "",
            "",
            "Такой логин уже существует",
            "Логин должен содержать только буквы и цифры, без пробелов и более 6 символов",
            "Подтвердите пароль.",
            "Пароли не совпадают. Попробуйте ещё раз.",
            "Пароль должен содержать только буквы и цифры, без пробелов и более 6 символов",
            "Укажите дату рождения",
            "Неверная дата рождения, дата рождения должна быть до сегодняшнего дня",
            "Не зарегестрирован ни один пользователь",
            "Неверный логин или пароль",
            "Введите логин и пароль",
            "Выберите вариант(ы) ответа(ов)",
            "Верно",
            "Неверно",
            "zomg"
        };

        /*
        static void load_external_array(string path) {
            try
            {
                StreamReader sr = new StreamReader(path);
                int i = 0;
                while (!sr.EndOfStream)
                {
                    strings[i++] = sr.ReadLine();
                }
            }
            catch
            {
                Console.WriteLine("lol error %)");
            }
        }
        */

        public class question {
            public string queststring;
            public string[] answers;
            public int right_answer;
            public int[] right_answers;


            public bool check_answer(int checked_, int t)  //Функция проверки правильности ответа t - тема
            {
                System.Windows.Forms.Form VictF = System.Windows.Forms.Application.OpenForms["Vict"];

                switch (t)
                {
                    case (int)Test.Geography:
                        if (checked_ == Geography_questions[User_data.question - 1].right_answer)
                        {
                            User_data.all_points++;
                            ((Vict)VictF).label4.Text = "Верно";    //Чисто для дебаггинга
                            return true;
                        }
                        else
                        {
                            ((Vict)VictF).label4.Text = "Неверно";
                            return false;
                        }
                    case (int)Test.History:
                        if (checked_ == History_questions[User_data.question - 1].right_answer)
                        {
                            User_data.all_points++;
                            ((Vict)VictF).label4.Text = "Верно";    //Чисто для дебаггинга
                            return true;
                        }
                        else
                        {
                            ((Vict)VictF).label4.Text = "Неверно";
                            return false;
                        }
                    case (int)Test.Biology:
                        if (checked_ == Biology_questions[User_data.question - 1].right_answer)
                        {
                            User_data.all_points++;
                            ((Vict)VictF).label4.Text = "Верно";    //Чисто для дебаггинга
                            return true;
                        }
                        else
                        {
                            ((Vict)VictF).label4.Text = "Неверно";
                            return false;
                        }
                    default:
                        return false;

                }

                
            }
        }

        //GOTO: нужно сделать разные разделы вопросов, т.е. для истории, географии, биологии. >> также доделать сериализацию (функции сделаны).

        public static question[] History_questions = new question[]
        {
            new question{queststring = "Кто был лидером большевиков?",answers = new string[4] { "Ленин", "Петр I", "Сталин", "Путин"}, right_answer = 1},
            new question{queststring = "Антипартийная группа Маленкова, Кагановича, Молотова и примкнувшего к ним Шепилова — так называли тех, кто в 1957 г. попытался сместить Хрущева. А кем был Шепилов?", answers = new string[4] { "Министром иностранных дел", "Министром сельского хозяйства", "Министром легкой промышленности", "Министром финансов" }, right_answer = 1},
            new question{queststring = "Какой корабль в 1900 г. спустил на воду лично Николай II?", answers = new string[4] { "Броненосец «Потемкин»", "Крейсер «Аврора»", "Крейсер «Варяг»", "Фрегат «Паллада»" }, right_answer = 2 },
            new question{queststring = "Какие страны входят в состав НАТО в настоящее время? (несколько вариантов ответа)",answers = new string[4] { "Эстония", "Россия", "Литва", "США"}, right_answers = new int[3] {1,3,4} },
            new question{queststring = "В каком году главами государств СНГ было подписано Соглашение о создании Межгосударственного экологического совета стран СНГ?",answers = new string[4] { "1993", "1992", "1995", "1991"}, right_answer = 2 },
            new question{queststring = "Какое из государств СНГ первым подписало с Европейским Союзом Соглашение о партнёрстве и сотрудничестве?",answers = new string[4] { "Украина", "Казахстан", "Узбекистан", "Россия"}, right_answer = 4 },
            new question{queststring = "Какие события произошли в один и тот же год?",answers = new string[4] { "Падение Византийской империи и окончание Столетней войны", "Восстание Уота Тайлера и Гильома Каля", "Образование государства у франков и арабов", "Битва на Косовом поле и сражение при Креси"}, right_answer = 1 },
            new question{queststring = "\"Душой ислама\" называют ...",answers = new string[4] { "Тасфир", "Коран", "Суфизм", "Рукопись \"Рашахот айн алхайат\""}, right_answer = 1 },
            new question{queststring = "Какое государство в 1929 г. производило 44% промышленной продукции так называемого капиталистического мира?",answers = new string[4] { "Япония", "Германия", "США", "Великобритания"}, right_answer = 3},
            new question{queststring = "Какие государства, являлись доминионами Великобритании после первой мировой войны? (Несколько вариантов ответа)",answers = new string[4] { "Нигерия", "Австралия", "Канада", "Индия"},right_answers = new int[2] {1,3} },
            new question{queststring = "В каком году в результате подписания советско-японской декларации было оформлено формальное прекращение состояния войны между бывшим СССР и Японией?",answers = new string[4] { "1956", "1945", "1991", "1958"}, right_answer = 1 },
            new question{queststring = "Кем были построены первые каменные храмы на Руси?",answers = new string[4] { "Итальянскими зодчими", "Аристотелем Фиорованти", "Византийскими архитекторами", "Знаменитым русским строителем Федором Конем"}, right_answer = 3 },
            new question{queststring = "В какой период истории в живописи распространяется направление, получившее название \"гиперреализм\"?",answers = new string[4] { "В конце XIX в.", "В 20-е годы XIX в.", "В 50-е годы XX в.", "В 60-е годы XX в."}, right_answer = 4 },
            new question{queststring = "Определите страну - первый британский доминион?",answers = new string[4] { "Индия", "США", "Австралия", "Канада"}, right_answer = 4 },
            new question{queststring = "В истории России \"золотым веком\" дворяне называли период правления ...",answers = new string[4] { "Александра I", "Екатерины II", "Петра I", "Павла"}, right_answer = 2 },
            new question{queststring = "Что по сути дела привело к созданию в 20-х годах XX в. унитарного сверхцентрализованного Советского государства?",answers = new string[4] { "Решение о введении новой экономической политики", "Договор об образовании СССР", "решение о коллективизации сельского хозяйства", "решение об индустриализации промышленности"}, right_answer = 2 },
            new question{queststring = "Сколько республик подписали в 1991 г. в Алма-Ате протокол соглашения об образовании СНГ?",answers = new string[4] { "13", "15", "9", "10"}, right_answer = 3 },
            new question{queststring = "Каковы основные цели и методы борьбы анархо-синдикалистов? (несколько вариантов ответа)",answers = new string[4] { "Уничтожение государства", "Борьба за проведение частичных реформ", "Провозглашение курса на достижение единства рабочего класса", "Создание общественного самоуправления"}, right_answers = new int[2] {1,3} },
            new question{queststring = "В каком году были установлены дипломатические отношения между США и СССР?",answers = new string[4] { "1928", "1933", "1929", "1930"}, right_answer = 2 },
            new question{queststring = "Что позволило небольшому отряду казаков Ермака разбить превосходящие силы сибирского хана Кучума?",answers = new string[4] { "Наличие огнестрельного оружия", "Тактика боя, окружение войск Кучума резервным отрядом", "Внезапность нападения на войска Кучума", "Прибытие на помощь Ермаку дополнительных сил, бегство войск Кучума"}, right_answer = 1 },
            new question{queststring = "Какой город не входил в состав России в XVII в.?",answers = new string[4] { "Гурьев", "Киев", "Якутск", "Минск"}, right_answer = 4 },
        };

        public static question[] Biology_questions = new question[]
        {
            new question{queststring = "К какой группе тканей относят костную и хрящевую ткани?",answers = new string[4] {"Мышечной", "Эпителиальной", "Соеденительной", "Механической"}, right_answer = 3},
            new question{queststring = "Центральная опора растения, соединяющая подземные и наземные органы:",answers = new string[4] {"Стебель", "Пробка", "Междоузлия", "Проводящие сосуды"}, right_answer = 1},
            new question{queststring = "Жидкая часть крови, состоящая из воды и белков:",answers = new string[4] {"Цитоплазма", "Плазма", "Жидкость", "Кариоплазма"}, right_answer = 2},
            new question{queststring = "Сколько у человека ребер?",answers = new string[4] {"12", "16", "24", "36"}, right_answer = 3},
            new question{queststring = "Сколько хромосом у человека?",answers = new string[4] {"46", "47:)", "52", "3"}, right_answer = 1},
            new question{queststring = "Минимальным  уровнем организации жизни, на котором проявляется такое свойство живых систем, как способность к обмену веществ, энергии, информации, является:",answers = new string[4] {"Биосферный", "Клеточный", "Организменный", "Молекулярный"}, right_answer = 2},
            new question{queststring = "Высшим уровнем организации жизни является:",answers = new string[4] {"Биосферный", "Биогеоценотический", "Популярно-видовой", "Организменный"}, right_answer = 1},
            new question{queststring = "Любая клетка способна к",answers = new string[4] {"Мейозу", "Проведению нервного импульса", "Сокращению", "Обмену веществ"}, right_answer = 4},
            new question{queststring = "Хлоропласты есть в клетках:",answers = new string[4] {"Корня капусты", "Гриба-трутовика", "Листа красного перца", "Почек собаки"}, right_answer = 3},
            new question{queststring = "В клетке возбудителя чумы нет:",answers = new string[4] {"Рибосом", "Цитоплазмы", "Мембраны", "Ядра"}, right_answer = 4},
            new question{queststring = "Среда, в которой перевариваются белки пищи в желудке, является:",answers = new string[4] {"Нейтральной", "Щелочной", "Слабощелочной", "Кислой"}, right_answer = 4},
            new question{queststring = "Железо входит в состав:",answers = new string[4] {"АТФ", "РНК", "Гемоглобина", "Хлорофила"}, right_answer = 3},
            new question{queststring = "Дж. Уотсон и Ф. Крик создали",answers = new string[4] {"Клеточную теорию", "Законы наследственности", "Модель РНК", "Теорию мутагенеза"}, right_answer = 3},
            new question{queststring = "С полным превращением развивается:",answers = new string[4] {"Саранча", "Стрекоза", "Пчела", "Кузнечик"}, right_answer = 3},
            new question{queststring = "Заболевание ВИЧ связано с нарушением:",answers = new string[4] {"Сердечно-сосудистой системы", "Имунной системы", "Опорно-двигательной системы", "Пищеварительной системы"}, right_answer = 2},
            new question{queststring = "Долгое время учёные не могли определить функцию этих клеток. При их открытии лейкоциты были приняты за посторонние организму существа, паразитирующие в нём. Их называют «клетками пожирателями». Эти клетки были открыты И.И. Мечниковым. О каких клетках идёт речь?",answers = new string[4] {"Фагоциты", "Лимфоциты", "Эритроциты", "Фагоциты"}, right_answer = 1},
            new question{queststring = "Функции данного органа в теле человека можно сравнить с работой фильтра. Они убирают из организма вредные продукты распада.",answers = new string[4] {"Печень", "Почки", "Мочевой пузырь", "Желудок"}, right_answer = 2},
            new question{queststring = "Очень заразное вирусное заболевание, характеризующееся обильной сыпью, нередко оставляющей после себя рубцы.",answers = new string[4] {"Туберкулез", "ОРЗ", "Оспа", "Грипп"}, right_answer = 3},
            new question{queststring = "Какая из ниже перечисленных функций не характерна для крови?",answers = new string[4] {"Опорная", "Защитная", "Транспортная", "Соеденительная"}, right_answer = 1},
            new question{queststring = "Какой витамин получает человек от солнца?",answers = new string[4] {"А", "B", "C", "D"}, right_answer = 4},
            new question{queststring = "Как называется смещение соприкасающихся в полости сустава костей?",answers = new string[4] {"Вывих", "Ушиб", "Перелом", "Растяжение"}, right_answer = 1}
        };

        public static question[] Geography_questions = new question[]
        {
            new question{queststring = "Количество жителей в Москве",answers = new string[4] {"1 млн", "5 млн", "10 млн", "12 млн"}, right_answer = 4},
            new question{queststring = "В какой стране находится город Цинциннати?",answers = new string[4] {"Италия", "Испания", "США", "Канада"}, right_answer = 3},
            new question{queststring = "Какая пустыня расположена в южном полушарии?",answers = new string[4] {"Сахара", "Атакама", "Кара-Кум", "Гоби"}, right_answer = 2},
            new question{queststring = "Какой остров самый большой в мире?",answers = new string[4] {"Мадагаскар", "Бали", "Новая Гвинея", "Гренландия"}, right_answer = 4},
            new question{queststring = "Какая из этих стран имеет выход к Каспийскому морю?",answers = new string[4] {"Таджикистан", "Туркменистан", "Узбекистан", "Афганистан"}, right_answer = 2},
            new question{queststring = "Выберите два самых больших города мира",answers = new string[4] {"Шанхай", "Токио", "Мумбаи", "Пекин"}, right_answer = 1}, //1.4
            new question{queststring = "На территории какого современного государства находятся развалины древнего города Карфаген?",answers = new string[4] {"Сирия", "Египет", "Тунис", "Иордания"}, right_answer = 3},
            new question{queststring = "Какое из этих озер находится в Европе?",answers = new string[4] {"Виктория", "Балатон", "Байкал", "Онтарио"}, right_answer = 2},
            new question{queststring = "С какими странами Франция не имеет общей границы?",answers = new string[4] {"Нидерланды", "Португалия", "Германия", "Италия"}, right_answer = 1},   //1,2
            new question{queststring = "В какой стране находится Стоунхедж?",answers = new string[4] {"Шотландия", "Англия", "Ирландия", "Уэльс"}, right_answer = 2},
            new question{queststring = "Как называется единственная река, вытекающая из озера Байкал?",answers = new string[4] {"Обь", "Ангара", "Енисей", "Амур"}, right_answer = 2},
            new question{queststring = "Чему равна географическая широта на экваторе?",answers = new string[4] {"30°", "60°", "90°", "0°"}, right_answer = 4},
            new question{queststring = "Какая река считается самой полноводной в мире?",answers = new string[4] {"Амазонка", "Нил", "Ганг", "Волга"}, right_answer = 1},
            new question{queststring = "Какая железная дорога считается самой длинной?",answers = new string[4] {"Новый шёлковый путь", "Транссибирская магистраль", "Пекин – Гуанчжоу", "Чикаго – Лос-Анджелес"}, right_answer = 2},
            new question{queststring = "У какого государства нет столицы?",answers = new string[4] {"Ватикан", "Науру", "Лапландия", "Марокко"}, right_answer = 2},
            new question{queststring = "Самая высокая гора Европы?",answers = new string[4] {"Эверест", "Джомолунгма", "Касио", "Монблан"}, right_answer = 4},
            new question{queststring = "Между какими островами расстояние 4 км, а разница во времени 12 часов?",answers = new string[4] {"Острова Диомида", "Азорские острова", "Острова Таити", "Железные острова"}, right_answer = 1},
            new question{queststring = "Самое тёплое море?",answers = new string[4] {"Красное море", "Чёрное море", "Тиморское море", "Московское море"}, right_answer = 1},
            new question{queststring = "«Это карликовое государство с населением около 1 тыс. человек имеет свое правительство, свой банк, гвардию, законы, валюту и монарха. Сфера деятельности этого государства – весь мир».",answers = new string[4] {"Андрора", "Лихтенштейн", "Монако", "Ватикан"}, right_answer = 4},
            new question{queststring = "В стране самая большая продолжительность жизни и самая низкая детская смертность в Европе. Важнейшими природными богатствами этой страны являются лес и железная руда. В столице этого государства вручают Нобелевскую премию",answers = new string[4] {"Норвегия", "Швеция", "Швейцария", "Финляндия"}, right_answer = 2},
            new question{queststring = "В этой стране насчитывается около 7 млн иммигрантов. Они призваны восполнить «брешь» в недостатке рабочих рук, необходимых на трудоемких и малооплачиваемых производствах. В основном это турки (курды), боснийцы, сербы, хорваты, греки, евреи и представители других южноевропейских народов. О какой стране идет речь?",answers = new string[4] {"ФРГ", "Швейцария", "Австрия", "Великобритания"}, right_answer = 1}
        };

        public static void Geography_questionss(int c)
        {

        }

        public static void Biology_questionss(int c)
        {

        }

    }


}
