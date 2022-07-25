using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИГРА1
{
    public partial class Form4 : Form
    {
        private void Form4_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
        public Form4()
        {
            this.ControlBox = false;
            InitializeComponent();
            this.Name = "form4";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Form form in Application.OpenForms)
            {
                if(form !=null && form.Name=="form1")
                {
                    if (form.Visible == false)
                    {
                        form.Visible = true;
                    }
                }
            }
            Close();
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
    }
}
