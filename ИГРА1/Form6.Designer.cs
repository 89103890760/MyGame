
namespace ИГРА1
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timeGameBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsTimeGameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsTimeGame = new ИГРА1.dsTimeGame();
            this.timeGameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeGameTableAdapter = new ИГРА1.dsTimeGameTableAdapters.TimeGameTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeGameBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTimeGameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTimeGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeGameBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.WindowText;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(310, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 58);
            this.button1.TabIndex = 7;
            this.button1.Text = "Вернуться в настройки";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Просмотр результатов";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(12, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(246, 413);
            this.dataGridView1.TabIndex = 9;
            // 
            // timeGameBindingSource1
            // 
            this.timeGameBindingSource1.DataMember = "TimeGame";
            this.timeGameBindingSource1.DataSource = this.dsTimeGameBindingSource;
            // 
            // dsTimeGameBindingSource
            // 
            this.dsTimeGameBindingSource.DataSource = this.dsTimeGame;
            this.dsTimeGameBindingSource.Position = 0;
            // 
            // dsTimeGame
            // 
            this.dsTimeGame.DataSetName = "dsTimeGame";
            this.dsTimeGame.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timeGameBindingSource
            // 
            this.timeGameBindingSource.DataMember = "TimeGame";
            this.timeGameBindingSource.DataSource = this.dsTimeGameBindingSource;
            // 
            // timeGameTableAdapter
            // 
            this.timeGameTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.WindowText;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(310, 327);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 58);
            this.button2.TabIndex = 14;
            this.button2.Text = "Удалить все результаты";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form6";
            this.Text = "Кометный дождь";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeGameBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTimeGameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsTimeGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeGameBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource dsTimeGameBindingSource;
        private dsTimeGame dsTimeGame;
        private System.Windows.Forms.BindingSource timeGameBindingSource;
        private dsTimeGameTableAdapters.TimeGameTableAdapter timeGameTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource timeGameBindingSource1;
    }
}