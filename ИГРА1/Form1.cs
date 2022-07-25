using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO; //---Для чтения и создания файлов
using System.Runtime.Serialization.Formatters.Binary; //---Для чтения и создания файлов

namespace ИГРА1
{
    public partial class Form1 : Form
    {
        //***Рубашка*************************
        DataTable dataTblImg = new DataTable();
        DataColumn dataCol;
        DataColumn dataState;
        DataColumn colLocation;
        DataColumn colSize;
        string pathRubashka;
        //***********************************
        //***таблица данных для сохранения времени игры***
        DataTable dtGameTime;  //---Врея игры;
        DataColumn idTime;  //---Идентифткатор;
        DataColumn NameCol; //---Наименование сохранения
        DataColumn Time; //---Время игры
        string pathGame; //---Путь сохранения двоичного файла состояния
        String result; 
        //************************************************
        public Form1()
        {
            this.ControlBox = false;
            InitializeComponent();
            result = null;
            this.VisibleChanged += VisibleUpdate;
            this.Name = "form1";
            //***Рубашка*******************
            dataCol = new DataColumn("Rubashka", typeof(string));
            dataCol.AllowDBNull = false;
            dataCol.MaxLength = 128;
            //----------------------
            dataState = new DataColumn("State", typeof(bool));
            dataState.AllowDBNull = false;
            //----------------------
            colLocation = new DataColumn("colLocation", typeof(Point));
            colSize = new DataColumn("colSize", typeof(Size));
            //-----------------------
            dataTblImg.Columns.Add(dataCol);
            dataTblImg.Columns.Add(dataState);
            dataTblImg.Columns.Add(colLocation);
            dataTblImg.Columns.Add(colSize);
            pathRubashka = "state/rubState";  //---Путь к папке двоичного файла для сохранения состояния рубашки ракеты
            //********************************
            //***таблица данных для сохранения времени игры***
            dtGameTime = new DataTable("GameTime"); //---Врея игры;
            idTime = new DataColumn("ИД", typeof(int));  //---Идентифткатор - тип данных int;
            idTime.AllowDBNull = false; //---Не допускать нулевые(поле должно быть заполнено) значения
            idTime.AutoIncrement = true; //---Разрешить автоматическое заполнение поля
            idTime.AutoIncrementSeed = 0; //---Начальное значение для автоматического заполнения поля
            idTime.AutoIncrementStep = 1; //---Шаг приращения в автоматическом заполняемом поле
            NameCol = new DataColumn("Игра", typeof(string)); //---Наименование сохранения - тип данных string
            NameCol.MaxLength = 128; //---Максимальная длина строкового поля
            NameCol.AllowDBNull = false; // Не допускать нулевые(поле должно быть заполнено) значения
            Time = new DataColumn("Время", typeof(string)); //---Время игры - тип данных TimeSpan
            Time.MaxLength = 10;
            Time.AllowDBNull = false;
            pathGame = "state/GameTime"; //---Путь сохранения двоичного файла состояния 
            //---Вставить столбцы--------------
            dtGameTime.Columns.Add(idTime);
            dtGameTime.Columns.Add(NameCol);
            dtGameTime.Columns.Add(Time);
            //*********************************
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //********Рубашка************************
            string curDir = Directory.GetCurrentDirectory(); //---Строка для записи пути запуска программы
            DirectoryInfo dir = new DirectoryInfo(curDir); //---Записать в строку curDir путь запуска (директории) программы
            //---Найти в указанной дериктории во всех каталогах и подкаталогах указанный файл по пути pathRubashka
            FileInfo[] files = dir.GetFiles(pathRubashka, SearchOption.AllDirectories); 
            if (files.Length > 0) //---Если файл есть ничего не предпринимать.
            { }
            if (files.Length < 1)   //--- Если файла нет, то заполнить таблицу данных нужными строками и сериализовать(создать двоичный файл из dataTblImg)
            {
                //--- Строки ---------------------------
                DataRow row0 = dataTblImg.NewRow();
                row0["Rubashka"] = "ракета1.jpg";
                row0["State"] = true;
                row0["colLocation"] = new Point(217, 319);
                row0["colSize"] = new Size(54, 94);
                dataTblImg.Rows.Add(row0);
                DataRow row1 = dataTblImg.NewRow();
                row1["Rubashka"] = "ракета2.png";
                row1["State"] = false;
                row1["colLocation"] = new Point(217, 319);
                row1["colSize"] = new Size(54, 94);
                dataTblImg.Rows.Add(row1);
                DataRow row2 = dataTblImg.NewRow();
                row2["Rubashka"] = "ракета3.jpg";
                row2["State"] = false;
                row2["colLocation"] = new Point(217, 319);
                row2["colSize"] = new Size(54, 94);
                dataTblImg.Rows.Add(row2);
                DataRow row3 = dataTblImg.NewRow();
                row3["Rubashka"] = "ракета4.jpg";
                row3["State"] = false;
                row3["colLocation"] = new Point(220, 304);
                row3["colSize"] = new Size(51, 109);
                dataTblImg.Rows.Add(row3);
                DataRow row4 = dataTblImg.NewRow();
                row4["Rubashka"] = "ракета5.jpg";
                row4["State"] = false;
                row4["colLocation"] = new Point(216, 320);
                row4["colSize"] = new Size(60, 93);
                dataTblImg.Rows.Add(row4);
                DataRow row5 = dataTblImg.NewRow();
                row5["Rubashka"] = "корабль1.jpg";
                row5["State"] = false;
                row5["colLocation"] = new Point(214, 323);
                row5["colSize"] = new Size(65, 90);
                dataTblImg.Rows.Add(row5);
                DataRow row6 = dataTblImg.NewRow();
                row6["Rubashka"] = "корабль2.jpg";
                row6["State"] = false;
                row6["colLocation"] = new Point(201, 343);
                row6["colSize"] = new Size(88, 70);
                dataTblImg.Rows.Add(row6);
                DataRow row7 = dataTblImg.NewRow();
                row7["Rubashka"] = "тарелка1.png";
                row7["State"] = false;
                row7["colLocation"] = new Point(208, 343);
                row7["colSize"] = new Size(77, 70);
                dataTblImg.Rows.Add(row7);
                DataRow row8 = dataTblImg.NewRow();
                row8["Rubashka"] = "тарелка3.png";
                row8["State"] = false;
                row8["colLocation"] = new Point(208, 343);
                row8["colSize"] = new Size(77, 70);
                dataTblImg.Rows.Add(row8);
                DataRow row9 = dataTblImg.NewRow();
                row9["Rubashka"] = "тарелка4.jpg";
                row9["State"] = false;
                row9["colLocation"] = new Point(208, 343);
                row9["colSize"] = new Size(77, 70);
                dataTblImg.Rows.Add(row9);
                DataRow row10 = dataTblImg.NewRow();
                row10["Rubashka"] = "тарелка5.png";
                row10["State"] = false;
                row10["colLocation"] = new Point(203, 355);
                row10["colSize"] = new Size(87, 58);
                dataTblImg.Rows.Add(row10);
                DataRow row11 = dataTblImg.NewRow();
                row11["Rubashka"] = "тарелка7.jpg";
                row11["State"] = false;
                row11["colLocation"] = new Point(203, 355);
                row11["colSize"] = new Size(87, 58);
                dataTblImg.Rows.Add(row11);
                DataRow row12 = dataTblImg.NewRow();
                row12["Rubashka"] = "тарелка9.jpg";
                row12["State"] = false;
                row12["colLocation"] = new Point(205, 341);
                row12["colSize"] = new Size(81, 72);
                dataTblImg.Rows.Add(row12);
                DataRow row13 = dataTblImg.NewRow();
                row13["Rubashka"] = "тарелка10.jpg";
                row13["State"] = false;
                row13["colLocation"] = new Point(206, 337);
                row13["colSize"] = new Size(83, 76);
                dataTblImg.Rows.Add(row13);
                DataRow row14 = dataTblImg.NewRow();
                row14["Rubashka"] = "тарелка11.jpg";
                row14["State"] = false;
                row14["colLocation"] = new Point(206, 337);
                row14["colSize"] = new Size(83, 76);
                dataTblImg.Rows.Add(row14);
                DataRow row15 = dataTblImg.NewRow();
                row15["Rubashka"] = "тарелка12.jpg";
                row15["State"] = false;
                row15["colLocation"] = new Point(201, 348);
                row15["colSize"] = new Size(91, 65);
                dataTblImg.Rows.Add(row15);
                //---создать двоичный файл из dataTblImg по указаному пути pathRubashka
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
            }
            //******Время игры****************
            string curDirTimeGame = Directory.GetCurrentDirectory(); //---Строка для записи пути запуска программы
            DirectoryInfo dirTimeGame = new DirectoryInfo(curDirTimeGame); //---Записать в строку curDirTimeGame путь запуска (директории) программы
            //---Найти в указанной дериктории во всех каталогах и подкаталогах указанный файл
            FileInfo[] filesTimeGame = dir.GetFiles(pathGame, SearchOption.AllDirectories);
            if (filesTimeGame.Length > 0)
            {
                using (FileStream fs = new FileStream(pathGame, FileMode.Open))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    dtGameTime = (DataTable)bFormat.Deserialize(fs);
                }
                DateTime dt = new DateTime(0, 0);
                for (int row = 0; row < dtGameTime.Rows.Count; row++)
                {
                    dt = Convert.ToDateTime(dtGameTime.Rows[row][2]);
                    for (int rowEQ = 0; rowEQ < dtGameTime.Rows.Count; rowEQ++)
                    {
                        if (dt > Convert.ToDateTime(dtGameTime.Rows[rowEQ][2]))
                        {
                            dt = Convert.ToDateTime(dtGameTime.Rows[rowEQ][2]);
                            result = dtGameTime.Rows[rowEQ][2].ToString();
                        }
                    }
                }
                if (dtGameTime.Rows.Count == 0)
                {
                    label3.Text = "Результатов нет.";
                }
                else
                {
                    label3.Text = result;
                }
                dtGameTime.Rows.Clear();
            }
            if (filesTimeGame.Length < 1)
            {
                //--using - все методы выполняются только в этом блоуке.
                //---По окончании выполнения все объекты удаляются из оперативной памяти.
                //---Все потоки для чтения и записи закрываются.
                using (FileStream fs = new FileStream(pathGame, FileMode.Create)) 
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dtGameTime);
                }
            }
            //********************************
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string pathLevel = "state/levelState";
            DataTable dbLevel = new DataTable();
            using (FileStream fs = new FileStream(pathLevel, FileMode.Open))
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                dbLevel = (DataTable)bFormat.Deserialize(fs);
            }
            dbLevel.Rows[0][1] = 1;
            using (FileStream fs = new FileStream(pathLevel, FileMode.Create))
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                bFormat.Serialize(fs, dbLevel);
            }
            dbLevel.Rows.Clear();
            //****************************************************
            string pathRubashka = "state/rubState";
            //-----------------------------
            dataTblImg.Clear();
            using (FileStream fs = new FileStream(pathRubashka, FileMode.Open))
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                dataTblImg = (DataTable)bFormat.Deserialize(fs);
            }
            for (int row = 0; row < dataTblImg.Rows.Count; row++)
            {
                if (dataTblImg.Rows[row][0].ToString() == "ракета1.jpg")
                { dataTblImg.Rows[row][1] = true; }
                else
                { dataTblImg.Rows[row][1] = false; }
            }
            using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                bFormat.Serialize(fs, dataTblImg);
            }
            dataTblImg.Rows.Clear();
            //****************************************************
            Close();
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Form3 form3 = new Form3();
            //--------------------------
            //***Рубашка*******************
            string pathRubashka = "state/rubState";
            //-----------------------------
            dataTblImg.Clear();
            using (FileStream fs = new FileStream(pathRubashka, FileMode.Open))
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                dataTblImg = (DataTable)bFormat.Deserialize(fs);
            }
            for (int row = 0; row < dataTblImg.Rows.Count; row++)
            {
                if ((bool)dataTblImg.Rows[row][1] == true)
                {
                    PictureBox pb = new PictureBox();
                    string kart = string.Format("картинки/{0}", dataTblImg.Rows[row][0]);
                    pb.Image = new Bitmap(Image.FromFile(string.Format(kart)));
                    pb.Location = (Point)dataTblImg.Rows[row][2];
                    pb.Size = (Size)dataTblImg.Rows[row][3];
                    form3.pictureBox_Rubashka(pb);
                }
               
            }
            //*************************************************************************
          
                form3.Name = "form3";
            form3.Visible = true;
            this.Visible = false;
        }
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            button1.KeyDown += new KeyEventHandler(button1_KeyDown);
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
            
        }
        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            button3.KeyDown += new KeyEventHandler(button3_KeyDown);
            if (e.KeyCode == Keys.Escape)
            {
                button3.PerformClick();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                button1.PerformClick();
            }
            else if (keyData == (Keys.Escape))
            {
                button3.PerformClick();
            }
            else if (keyData == (Keys.Tab))
            {
                button2.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Name = "form2";
            form2.Visible = true;
            Visible = false;
        }
        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            button1.KeyDown += new KeyEventHandler(button2_KeyDown);
            if (e.KeyCode == Keys.Tab)
            {
                button2.PerformClick();
            }
        }
        private void VisibleUpdate(object EventHandler, EventArgs e)
        {
            using (FileStream fs = new FileStream(pathGame, FileMode.Open))
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                dtGameTime = (DataTable)bFormat.Deserialize(fs);
            }
            DateTime dt = new DateTime(0, 0);
            for (int row = 0; row < dtGameTime.Rows.Count; row++)
            {
                dt = Convert.ToDateTime(dtGameTime.Rows[row][2]);
                for (int rowEQ = 0; rowEQ < dtGameTime.Rows.Count; rowEQ++)
                {
                    if (dt < Convert.ToDateTime(dtGameTime.Rows[rowEQ][2]))
                    {
                        dt = Convert.ToDateTime(dtGameTime.Rows[rowEQ][2]);
                        result = dtGameTime.Rows[rowEQ][2].ToString();
                    } 
                }
            }
            if (dtGameTime.Rows.Count == 0)
            {
                label3.Text = "Результатов нет.";
            }
            else 
            {
                label3.Text = result;
            }
            dtGameTime.Rows.Clear();
        }
    }
}
