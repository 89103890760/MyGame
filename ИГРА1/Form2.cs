using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //---Для чтения и создания файлов
using System.Runtime.Serialization.Formatters.Binary; //---Для чтения и создания файлов

namespace ИГРА1
{
    public partial class Form2 : Form
    {
        //*****Таблица для уровня сложности*********
        DataTable dbLevel;
        DataColumn collNameLevel;
        DataColumn collLevel;
        string pathLevel;
        //***Таблица для смены рубашки ракеты *****
        DataTable dataTblImg;
        DataColumn dataCol;
        DataColumn dataState;
        DataColumn colLocation;
        DataColumn colSize;
        string pathRubashka;
        //***********************************
        public Form2()
        {
            this.ControlBox = false;
            InitializeComponent();
            this.Name = "form2";
            //*****Таблица для уровня сложности*********
            dbLevel = new DataTable();
            collNameLevel = new DataColumn("collNameLevel", typeof(string));
            collLevel = new DataColumn("collLevel", typeof(int));
            pathLevel = "state/levelState"; //---состояние уровня
            //************************************************
            //**********Таблица для смены рубашки ракеты *****
            pathRubashka = "state/rubState";
            //----------------------
            dataTblImg = new DataTable();
            //----------------------
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
            //******************************************
            //***********************************
            this.Load += Form2_Load;
            //***********************************
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            //*****Уровень сложности*****************
            string curDirLevel = Directory.GetCurrentDirectory();
            DirectoryInfo dirLevel = new DirectoryInfo(curDirLevel);
            FileInfo[] filesLevel = dirLevel.GetFiles("levelState", SearchOption.AllDirectories);
            if (filesLevel.Length < 1)
            {
                dbLevel.Columns.Add(collNameLevel);
                dbLevel.Columns.Add(collLevel);
                DataRow row0 = dbLevel.NewRow();
                row0["collNameLevel"] = "Уровень";
                row0["collLevel"] = 1;
                dbLevel.Rows.Add(row0);
                using (FileStream fs = new FileStream(pathLevel, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dbLevel);
                }
                dbLevel.Rows.Clear();
            }
            else
            {
                try
                {
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
                }
                catch (Exception ex)
                {
                    dbLevel.Rows.Clear();
                    dbLevel.Columns.Add(collNameLevel);
                    dbLevel.Columns.Add(collLevel);
                    DataRow row0 = dbLevel.NewRow();
                    row0["collNameLevel"] = "Уровень";
                    row0["collLevel"] = 1;
                    dbLevel.Rows.Add(row0);
                    using (FileStream fs = new FileStream(pathLevel, FileMode.Create))
                    {
                        BinaryFormatter bFormat = new BinaryFormatter();
                        bFormat.Serialize(fs, dbLevel);
                    }
                    ex.ToString();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form != null && form.Name == "form1")
                {
                    if (form.Visible == false)
                    {
                        form.Visible = true;
                    }
                }
            }
            this.Close();
        }
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            button1.KeyDown += new KeyEventHandler(button1_KeyDown);
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                button1.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Visible = true;
            Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
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
                    { 
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(217, 319);
                        dataTblImg.Rows[row][3] = new Size(54, 94);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();

                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
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
                    if (dataTblImg.Rows[row][0].ToString() == "ракета2.png")
                    { 
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(217, 319);
                        dataTblImg.Rows[row][3] = new Size(54, 94);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked)
            {
                //****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "тарелка9.jpg")
                    {
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(205,341);
                        dataTblImg.Rows[row][3] = new Size(81, 72);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //*****************************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox1.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
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
                    if (dataTblImg.Rows[row][0].ToString() == "ракета3.jpg")
                    { 
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(217,319);
                        dataTblImg.Rows[row][3] = new Size(54,94);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
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
                    if (dataTblImg.Rows[row][0].ToString() == "ракета4.jpg")
                    { 
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(220, 304);
                        dataTblImg.Rows[row][3] = new Size(51,109);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                //*****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "ракета5.jpg")
                    { 
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(216,320);
                        dataTblImg.Rows[row][3] = new Size(60,93);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //***********************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox1.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                //*****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "корабль1.jpg")
                    { 
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(214, 323);
                        dataTblImg.Rows[row][3] = new Size(65, 90);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //***********************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox1.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                //*****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "корабль2.jpg")
                    {
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(201, 343);                    
                        dataTblImg.Rows[row][3] = new Size(88, 70);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //***********************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox1.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
               
                //*****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "тарелка1.png")
                    {
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(208, 343);
                        dataTblImg.Rows[row][3] = new Size(77, 70);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox1.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                //*****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "тарелка3.png")
                    {
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(208, 343);
                        dataTblImg.Rows[row][3] = new Size(77, 70);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //*************************************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox1.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {
                //****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "тарелка4.jpg")
                    {
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(208, 343);
                        dataTblImg.Rows[row][3] = new Size(77, 70);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //*****************************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox1.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                //****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "тарелка5.png")
                    {
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(203,355);
                        dataTblImg.Rows[row][3] = new Size(87,58);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //*****************************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox1.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
            {
                //****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "тарелка7.jpg")
                    {
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(203,355);
                        dataTblImg.Rows[row][3] = new Size(87,58);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //*****************************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox1.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
            {
                //****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "тарелка10.jpg")
                    {
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(206, 337);
                        dataTblImg.Rows[row][3] = new Size(83, 76);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //*****************************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox1.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
            }
        }
        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
            {
                //****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "тарелка11.jpg")
                    {
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(206, 337);
                        dataTblImg.Rows[row][3] = new Size(83, 76);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //*****************************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox1.Checked = false;
                checkBox19.Checked = false;
            }
        }
        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
            {
                //****************************************
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
                    if (dataTblImg.Rows[row][0].ToString() == "тарелка12.jpg")
                    {
                        dataTblImg.Rows[row][1] = true;
                        dataTblImg.Rows[row][2] = new Point(201, 348);
                        dataTblImg.Rows[row][3] = new Size(91, 65);
                    }
                    else
                    { dataTblImg.Rows[row][1] = false; }
                }
                using (FileStream fs = new FileStream(pathRubashka, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dataTblImg);
                }
                dataTblImg.Rows.Clear();
                //*****************************************
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
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
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                using (FileStream fs = new FileStream(pathLevel, FileMode.Open))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    dbLevel = (DataTable)bFormat.Deserialize(fs);
                }
                dbLevel.Rows[0][1] = 2;
                using (FileStream fs = new FileStream(pathLevel, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dbLevel);
                }
                dbLevel.Rows.Clear();
                checkBox5.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                using (FileStream fs = new FileStream(pathLevel, FileMode.Open))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    dbLevel = (DataTable)bFormat.Deserialize(fs);
                }
                dbLevel.Rows[0][1] = 3;
                using (FileStream fs = new FileStream(pathLevel, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dbLevel);
                }
                dbLevel.Rows.Clear();
                checkBox6.Checked = false;
                checkBox5.Checked = false;
            }
        }
       
    }

}
