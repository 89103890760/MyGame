using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO; //---Для чтения и создания файлов
using System.Runtime.Serialization.Formatters.Binary; //---Для чтения и создания файлов
//----------------------------------
using ИГРА1.dsTimeGameTableAdapters;
//----------------------------------
namespace ИГРА1
{
    public partial class Form3 : Form
    {
        Bitmap kameta;
        Bitmap kameta2;
        Graphics g;
        Graphics g2;
        Random rnd;
        Random rnd2;
        Rectangle rct;
        Rectangle rct2;
        int dx;
        int dx2;
        Form5 form5 = new Form5();
        Form4 form4 = new Form4();
        //-------------------------
        public  int level { get; set; } // уровень игры
        string pathLevel; //---путь к двоичному файлу данных уровня сложности
        DataTable dbLevel; //---таблица данных уровня сложности
        //---Время игры-----------------------
        DataTable dtGameTime;  //---Врея игры
        string pathGame; //---Путь сохранения двоичного файла состояния
        //-------------------------
        public Form3()
        {
            {
                InitializeComponent();
                //--------------------------------
                dtGameTime = new DataTable();  //---Врея игры
                pathGame = "state/GameTime";   //---Путь сохранения двоичного файла состояния
                //--------------------------------
                form5.Name = "form5";
                form4.Name = "form4";
                this.ControlBox = false;  //---Скрыть отображения кнопок формы
                dbLevel = new DataTable();
                pathLevel = "state/levelState"; //---состояние уровня
                kameta = new System.Drawing.Bitmap(Image.FromFile("картинки/камета.jpg"), 35, 80);
                kameta2 = new System.Drawing.Bitmap(Image.FromFile("картинки/камета2.jpg"), 50, 100);
                using (FileStream fs = new FileStream(pathLevel, FileMode.Open))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    dbLevel = (DataTable)bFormat.Deserialize(fs);
                }
                level = (int)dbLevel.Rows[0][1];
                using (FileStream fs = new FileStream(pathLevel, FileMode.Create))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(fs, dbLevel);
                }
                dbLevel.Rows.Clear();
            }
            kameta.MakeTransparent();
            kameta2.MakeTransparent();
            g = this.CreateGraphics();
            g2 = this.CreateGraphics();
            rnd = new Random();
            rnd2 = new Random();
            rct.X = +10;
            rct.Y = this.Size.Height / 50 + rnd.Next(50);
            rct.Width = kameta.Width;
            rct.Height = kameta.Height;
            rct2.X = +400;
            rct2.Y = this.Size.Height / 50 + rnd2.Next(50);
            rct2.Width = kameta2.Width;
            rct2.Height = kameta2.Height;
            dx = 2;
            dx2 = 2;
            if (level == 1)
            {
                timer2.Interval = 20;
                timer2.Enabled = true;
            }
            if(level==2)
            {
                timer2.Interval = 20;
                timer2.Enabled = true;
                timer3.Interval = 20;
                timer3.Enabled = true;
            }
            if (level == 3)
            {
                timer2.Interval = 10;
                timer2.Enabled = true;
                timer3.Interval = 10;
                timer3.Enabled = true;
            }
        }
        public PictureBox pictureBox_Rubashka(PictureBox pb)
        {
            pictureBox2.Image = pb.Image;
            pictureBox2.Width = pb.Width;
            pictureBox2.Height = pb.Height;
            pictureBox2.Location = pb.Location;
            return pictureBox2;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try 
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form != null && form.Name == "form4")
                    {
                        if (label1.Text != "")
                        {
                            using (FileStream fs = new FileStream(pathGame, FileMode.Open))
                            {
                                BinaryFormatter bFormat = new BinaryFormatter();
                                dtGameTime = (DataTable)bFormat.Deserialize(fs);
                            }
                            DataRow rowDt = dtGameTime.NewRow();
                            rowDt["Игра"] = "Игра";
                            rowDt["Время"] = label1.Text;
                            dtGameTime.Rows.Add(rowDt);
                            using (FileStream fs = new FileStream(pathGame, FileMode.Create))
                            {
                                BinaryFormatter bFormat = new BinaryFormatter();
                                bFormat.Serialize(fs, dtGameTime);
                            }
                        }
                        form.Visible = true;
                        Close();
                    }
                    else
                    {
                        form4.Name = "form4";
                        for (int i = 0; i < form4.Controls.Count; i++)
                        {
                            if (form4.Controls[i].Name == "label2")
                            {
                                form4.Controls[i].Text = label1.Text;
                                if (label1.Text != "")
                                {
                                    using (FileStream fs = new FileStream(pathGame, FileMode.Open))
                                    {
                                        BinaryFormatter bFormat = new BinaryFormatter();
                                        dtGameTime = (DataTable)bFormat.Deserialize(fs);
                                    }
                                    DataRow rowDt = dtGameTime.NewRow();
                                    rowDt["Игра"] = "Игра";
                                    rowDt["Время"] = label1.Text;
                                    dtGameTime.Rows.Add(rowDt);
                                    using (FileStream fs = new FileStream(pathGame, FileMode.Create))
                                    {
                                        BinaryFormatter bFormat = new BinaryFormatter();
                                        bFormat.Serialize(fs, dtGameTime);
                                    }
                                }
                            }
                           
                        }
                        form4.Show();
                        Close();
                    }
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }   
        }
        DateTime date1 = new DateTime(0, 0);
        private void timer1_Tick(object sender, EventArgs e)
        {
            date1 = date1.AddSeconds(0.1);
            label1.Text = string.Format(date1.ToString("mm:ss"));
            timer1.Start();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (level==1)
            {
                timer1.Enabled = true;
                timer1.Start();
                timer2.Enabled = true;
                timer2.Start();
                button3.Enabled = true;
                button4.Enabled = true;
            }
           if(level==2)
            {
                timer1.Enabled = true;
                timer1.Start();
                timer2.Enabled = true;
                timer2.Start();
                timer3.Enabled = true;
                timer3.Start();
                button3.Enabled = true;
                button4.Enabled = true;
            }
            if (level == 3)
            {
                timer1.Enabled = true;
                timer1.Start();
                timer2.Enabled = true;
                timer2.Start();
                timer3.Enabled = true;
                timer3.Start();
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }
        private void StopBtn_Click(object sender, EventArgs e)
        {
            if(level==1)
            {
                timer2.Stop();
                timer2.Enabled = false;
                timer1.Stop();
                timer1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
           if(level==2)
            {
                timer2.Stop();
                timer2.Enabled = false;
                timer3.Stop();
                timer3.Enabled = false;
                timer1.Stop();
                timer1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            if (level == 3)
            {
                timer2.Stop();
                timer2.Enabled = false;
                timer3.Stop();
                timer3.Enabled = false;
                timer1.Stop();
                timer1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(pictureBox2.Location.X - 10, pictureBox2.Location.Y);
            if (pictureBox2.Left <= 0)
            {
                pictureBox2.Location = new Point(0, pictureBox2.Location.Y);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(pictureBox2.Location.X + 10, pictureBox2.Location.Y);
            if (pictureBox2.Right >= 430)
            {
                pictureBox2.Location = new Point(430, pictureBox2.Location.Y);
            }
        }
        private void StopBtn_KeyDown(object sender, KeyEventArgs e)
        {
            StopBtn.KeyDown += new KeyEventHandler(StopBtn_KeyDown);
            if (e.KeyCode == Keys.Space)
            {
                StopBtn.PerformClick();
            }
        }
        private void button5_KeyDown(object sender, KeyEventArgs e)
        {
            button5.KeyDown += new KeyEventHandler(button5_KeyDown);
            if (e.KeyCode == Keys.Enter)
            {
                button5.PerformClick();
            }
        }
        private void StartBtn_KeyDown(object sender, KeyEventArgs e)
        {
            StartBtn.KeyDown += new KeyEventHandler(StartBtn_KeyDown);
            if (e.KeyCode == Keys.Space)
            {
                StartBtn.PerformClick();
            }
        }
        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            button3.KeyDown += new KeyEventHandler(button3_KeyDown);
            if (e.KeyCode == Keys.A)
            {
                button3.PerformClick();
            }
        }
        private void button4_KeyDown(object sender, KeyEventArgs e)
        {
            button4.KeyDown += new KeyEventHandler(button4_KeyDown);
            if (e.KeyCode == Keys.D)
            {
                button4.PerformClick();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.A))
            {
                button3.PerformClick();
            }
            else if (keyData == (Keys.D))
            {
                button4.PerformClick();
            }
            if (keyData == (Keys.E))
            {
                StopBtn.PerformClick();
            }
            else if (keyData == (Keys.Q))
            {
                StartBtn.PerformClick();
            }
            if (keyData == (Keys.Enter))
            {
                button5.PerformClick();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                if (level == 1)
                { timer2.Stop(); }
            }
            Rectangle rkameta = new Rectangle(rct.X, rct.Y, rct.Width, rct.Height);
            g.DrawImage(BackgroundImage, rkameta, rkameta, GraphicsUnit.Pixel);
            if (rct.Y < this.ClientRectangle.Width)

                rct.Y += dx;
            else
            {
                rct.X = this.Size.Height / 8 + rnd.Next(350);
                rct.Y = -40;
                dx = 5 + rnd.Next(3);
            }
            g.DrawImage(kameta, rct.X, rct.Y);
            PictureBox p2 = new PictureBox();
            p2.Image = kameta;
            Rectangle r1 = p2.DisplayRectangle;
            Rectangle rraketa = pictureBox2.DisplayRectangle;
            rraketa.Location = pictureBox2.Location;
            //----------------------------------------------------
            if (rraketa.IntersectsWith(rkameta))
            {
                try
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form != null && form.Name == "form5")
                        {
                            if (form.Visible == false)
                            {
                                for (int i = 0; i < form5.Controls.Count; i++)
                                {
                                    if (form5.Controls[i].Name == "label1")
                                    {
                                        form5.Controls[i].Text = label1.Text;

                                        //************************************
                                        using (FileStream fs = new FileStream(pathGame, FileMode.Open))
                                        {
                                            BinaryFormatter bFormat = new BinaryFormatter();
                                            dtGameTime = (DataTable)bFormat.Deserialize(fs);
                                        }
                                        DataRow rowDt = dtGameTime.NewRow();
                                        rowDt["NameCol"] = "Игра";
                                        rowDt["Time"] = label1.Text;
                                        dtGameTime.Rows.Add(rowDt);
                                        using (FileStream fs = new FileStream(pathGame, FileMode.Create))
                                        {
                                            BinaryFormatter bFormat = new BinaryFormatter();
                                            bFormat.Serialize(fs, dtGameTime);
                                        }
                                        //************************************
                                        form.Visible = true;
                                        Close();
                                    }
                                }
                            }
                        }
                        else
                        {
                            form5.Name = "form5";
                            for (int i = 0; i < form5.Controls.Count; i++)
                            {
                                if (form5.Controls[i].Name == "label3")
                                {
                                    form5.Controls[i].Text = label1.Text;
                                    //************************************
                                    using (FileStream fs = new FileStream(pathGame, FileMode.Open))
                                    {
                                        BinaryFormatter bFormat = new BinaryFormatter();
                                        dtGameTime = (DataTable)bFormat.Deserialize(fs);
                                    }
                                    DataRow rowDt = dtGameTime.NewRow();
                                    rowDt["Игра"] = "Игра";
                                    rowDt["Время"] = label1.Text;
                                    dtGameTime.Rows.Add(rowDt);
                                    using (FileStream fs = new FileStream(pathGame, FileMode.Create))
                                    {
                                        BinaryFormatter bFormat = new BinaryFormatter();
                                        bFormat.Serialize(fs, dtGameTime);
                                    }
                                    //************************************
                                    form5.Show();
                                    Close();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                if (level == 1)
                {
                    timer2.Stop();
                    timer3.Stop();
                }
                if (level==2)
                {
                    timer2.Stop();
                    timer3.Stop();
                }
                if (level == 3)
                {
                    timer2.Stop();
                    timer3.Stop();
                }
            }
            Rectangle rkameta2 = new Rectangle(rct2.X, rct2.Y, rct2.Width, rct2.Height);
            g2.DrawImage(BackgroundImage, rkameta2, rkameta2, GraphicsUnit.Pixel);
            if (rct2.Y < this.ClientRectangle.Width)
                rct2.Y += dx2;
            else
            {
                rct2.X = this.Size.Height / 8 + rnd.Next(350);
                rct2.Y = -40;
                dx2 = 5 + rnd.Next(3);
            }
            g2.DrawImage(kameta2, rct2.X, rct2.Y);
            PictureBox p3 = new PictureBox();
            p3.Image = kameta2;
            Rectangle r2 = p3.DisplayRectangle;
            Rectangle rraketa = pictureBox2.DisplayRectangle;
            rraketa.Location = pictureBox2.Location;
            if (rraketa.IntersectsWith(rkameta2))
            {
                try
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form != null && form.Name == "form5")
                        {
                            if (form.Visible == false)
                            {
                                for (int i = 0; i < form5.Controls.Count; i++)
                                {
                                    if (form5.Controls[i].Name == "label3")
                                    {
                                        form5.Controls[i].Text = label1.Text;
                                        //************************************
                                        using (FileStream fs = new FileStream(pathGame, FileMode.Open))
                                        {
                                            BinaryFormatter bFormat = new BinaryFormatter();
                                            dtGameTime = (DataTable)bFormat.Deserialize(fs);
                                        }
                                        DataRow rowDt = dtGameTime.NewRow();
                                        rowDt["Игра"] = "Игра";
                                        rowDt["Время"] = label1.Text;
                                        dtGameTime.Rows.Add(rowDt);
                                        using (FileStream fs = new FileStream(pathGame, FileMode.Create))
                                        {
                                            BinaryFormatter bFormat = new BinaryFormatter();
                                            bFormat.Serialize(fs, dtGameTime);
                                        }
                                        //************************************
                                    }
                                }
                                form.Visible = true;
                                Close();
                            }
                        }
                        else
                        {
                            form5.Name = "form5";
                            for (int i = 0; i < form5.Controls.Count; i++)
                            {
                                if (form5.Controls[i].Name == "label3")
                                {
                                    form5.Controls[i].Text = label1.Text;
                                    //************************************
                                    using (FileStream fs = new FileStream(pathGame, FileMode.Open))
                                    {
                                        BinaryFormatter bFormat = new BinaryFormatter();
                                        dtGameTime = (DataTable)bFormat.Deserialize(fs);
                                    }
                                    DataRow rowDt = dtGameTime.NewRow();
                                    rowDt["Игра"] = "Игра";
                                    rowDt["Время"] = label1.Text;
                                    dtGameTime.Rows.Add(rowDt);
                                    using (FileStream fs = new FileStream(pathGame, FileMode.Create))
                                    {
                                        BinaryFormatter bFormat = new BinaryFormatter();
                                        bFormat.Serialize(fs, dtGameTime);
                                    }
                                    //************************************
                                }
                            }
                            form5.Show();
                            Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
        }
    }
}
