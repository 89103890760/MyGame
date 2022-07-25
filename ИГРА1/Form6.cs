using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ИГРА1.dsTimeGameTableAdapters;
using System.IO; //---Для чтения и создания файлов
using System.Runtime.Serialization.Formatters.Binary; //---Для чтения и создания файлов



namespace ИГРА1
{
    public partial class Form6 : Form
    {
        //---Время игры-----------------------
        DataTable dtGameTime;  //---Врея игры;
        string pathGame; //---Путь сохранения двоичного файла состояния
        //-------------------------
        public Form6()
        {
            this.ControlBox = false;
            InitializeComponent();
            //--------------------------------
            dtGameTime = new DataTable();  //---Врея игры
            pathGame = "state/GameTime";   //---Путь сохранения двоичного файла состояния
            //--------------------------------
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int colFr = 0;
            foreach (Form fr in Application.OpenForms) //---Найти все открытые формы
            {
                if (fr != null && fr.Name == "form2")
                {
                    colFr = colFr + 1;
                    if (fr.Visible == false)
                    {
                        fr.Visible = true;
                    }
                }
            }
            if (colFr == 0)
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
            Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            //************************************
            //---Прочитать из двоичного файла и загрузить в dtGameTime
            using (FileStream fs = new FileStream(pathGame, FileMode.Open))
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                dtGameTime = (DataTable)bFormat.Deserialize(fs);
            }
            //---Присвоить номер игры ------------
            for(int row=0;row< dtGameTime.Rows.Count;row++)
            {
                dtGameTime.Rows[row][1] = dtGameTime.Rows[row][1] + " " + dtGameTime.Rows[row][0].ToString();
            }
            //------------------------------------
            dataGridView1.DataSource = dtGameTime; //---Загрузить из dtGameTime
            //---Размеры столбцов -----------------
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[0].Visible = false; //---Скрыть столбец идентификатора
            dataGridView1.Columns[1].Width = 100;
            //------------------------------------
            //************************************
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (FileStream fs = new FileStream(pathGame, FileMode.Open))
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                dtGameTime = (DataTable)bFormat.Deserialize(fs);
            }
            //---Изменить на понятное имя столбца и присвоить номер игры--------
            for (int row = 0; row < dtGameTime.Rows.Count; row++)
            {
                dtGameTime.Rows[row][1] = dtGameTime.Rows[row][1] + " " + dtGameTime.Rows[row][0].ToString();
            }
            dtGameTime.Rows.Clear();
            dataGridView1.DataSource = dtGameTime;
            using (FileStream fs = new FileStream(pathGame, FileMode.Create))
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                bFormat.Serialize(fs, dtGameTime);
            }
        }
    }
}
