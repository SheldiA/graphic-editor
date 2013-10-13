namespace GraphicEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sm_item_create = new System.Windows.Forms.ToolStripMenuItem();
            this.sm_item_open = new System.Windows.Forms.ToolStripMenuItem();
            this.sm_item_save = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.work_panel = new System.Windows.Forms.Panel();
            this.cb_figure = new System.Windows.Forms.ComboBox();
            this.pb_fillellipse = new System.Windows.Forms.PictureBox();
            this.bt_change_color = new System.Windows.Forms.Button();
            this.pb_eraser = new System.Windows.Forms.PictureBox();
            this.pb_ellipse = new System.Windows.Forms.PictureBox();
            this.pb_triangle = new System.Windows.Forms.PictureBox();
            this.pb_rectangle = new System.Windows.Forms.PictureBox();
            this.pb_line = new System.Windows.Forms.PictureBox();
            this.draw_panel = new System.Windows.Forms.Panel();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.save_file = new System.Windows.Forms.SaveFileDialog();
            this.col_dialog = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.work_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_fillellipse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eraser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ellipse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_triangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_rectangle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_line)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Linen;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(786, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sm_item_create,
            this.sm_item_open,
            this.sm_item_save});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.файлToolStripMenuItem.Text = "File";
            // 
            // sm_item_create
            // 
            this.sm_item_create.Name = "sm_item_create";
            this.sm_item_create.Size = new System.Drawing.Size(108, 22);
            this.sm_item_create.Text = "Create";
            this.sm_item_create.Click += new System.EventHandler(this.sm_item_create_Click);
            // 
            // sm_item_open
            // 
            this.sm_item_open.Name = "sm_item_open";
            this.sm_item_open.Size = new System.Drawing.Size(108, 22);
            this.sm_item_open.Text = "Open";
            this.sm_item_open.Click += new System.EventHandler(this.sm_item_oen_Click);
            // 
            // sm_item_save
            // 
            this.sm_item_save.Name = "sm_item_save";
            this.sm_item_save.Size = new System.Drawing.Size(108, 22);
            this.sm_item_save.Text = "Save";
            this.sm_item_save.Click += new System.EventHandler(this.sm_item_save_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.справкаToolStripMenuItem.Text = "Help";
            // 
            // work_panel
            // 
            this.work_panel.BackColor = System.Drawing.Color.PeachPuff;
            this.work_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.work_panel.Controls.Add(this.cb_figure);
            this.work_panel.Controls.Add(this.pb_fillellipse);
            this.work_panel.Controls.Add(this.bt_change_color);
            this.work_panel.Controls.Add(this.pb_eraser);
            this.work_panel.Controls.Add(this.pb_ellipse);
            this.work_panel.Controls.Add(this.pb_triangle);
            this.work_panel.Controls.Add(this.pb_rectangle);
            this.work_panel.Controls.Add(this.pb_line);
            this.work_panel.Location = new System.Drawing.Point(0, 28);
            this.work_panel.Name = "work_panel";
            this.work_panel.Size = new System.Drawing.Size(122, 423);
            this.work_panel.TabIndex = 1;
            // 
            // cb_figure
            // 
            this.cb_figure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_figure.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cb_figure.FormattingEnabled = true;
            this.cb_figure.Location = new System.Drawing.Point(3, 280);
            this.cb_figure.Name = "cb_figure";
            this.cb_figure.Size = new System.Drawing.Size(114, 26);
            this.cb_figure.Sorted = true;
            this.cb_figure.TabIndex = 7;
            // 
            // pb_fillellipse
            // 
            this.pb_fillellipse.Image = global::GraphicEditor.Properties.Resources.ImageFillEllipse;
            this.pb_fillellipse.Location = new System.Drawing.Point(11, 198);
            this.pb_fillellipse.Name = "pb_fillellipse";
            this.pb_fillellipse.Size = new System.Drawing.Size(28, 26);
            this.pb_fillellipse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_fillellipse.TabIndex = 6;
            this.pb_fillellipse.TabStop = false;
            this.pb_fillellipse.Click += new System.EventHandler(this.pb_fillellipse_Click);
            // 
            // bt_change_color
            // 
            this.bt_change_color.Font = new System.Drawing.Font("Mistral", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_change_color.Location = new System.Drawing.Point(13, 333);
            this.bt_change_color.Name = "bt_change_color";
            this.bt_change_color.Size = new System.Drawing.Size(88, 34);
            this.bt_change_color.TabIndex = 5;
            this.bt_change_color.Text = "Change Color";
            this.bt_change_color.UseVisualStyleBackColor = true;
            this.bt_change_color.Click += new System.EventHandler(this.bt_change_color_Click);
            // 
            // pb_eraser
            // 
            this.pb_eraser.Image = global::GraphicEditor.Properties.Resources.eraser;
            this.pb_eraser.Location = new System.Drawing.Point(11, 242);
            this.pb_eraser.Name = "pb_eraser";
            this.pb_eraser.Size = new System.Drawing.Size(28, 26);
            this.pb_eraser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_eraser.TabIndex = 4;
            this.pb_eraser.TabStop = false;
            this.pb_eraser.Click += new System.EventHandler(this.pb_eraser_Click);
            // 
            // pb_ellipse
            // 
            this.pb_ellipse.Image = global::GraphicEditor.Properties.Resources.ImageEllipse;
            this.pb_ellipse.Location = new System.Drawing.Point(11, 154);
            this.pb_ellipse.Name = "pb_ellipse";
            this.pb_ellipse.Size = new System.Drawing.Size(28, 26);
            this.pb_ellipse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_ellipse.TabIndex = 3;
            this.pb_ellipse.TabStop = false;
            this.pb_ellipse.Click += new System.EventHandler(this.pb_ellipse_Click);
            // 
            // pb_triangle
            // 
            this.pb_triangle.Image = global::GraphicEditor.Properties.Resources.ImageTriangle;
            this.pb_triangle.Location = new System.Drawing.Point(11, 107);
            this.pb_triangle.Name = "pb_triangle";
            this.pb_triangle.Size = new System.Drawing.Size(28, 26);
            this.pb_triangle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_triangle.TabIndex = 2;
            this.pb_triangle.TabStop = false;
            this.pb_triangle.Click += new System.EventHandler(this.pb_triangle_Click);
            // 
            // pb_rectangle
            // 
            this.pb_rectangle.BackColor = System.Drawing.Color.Salmon;
            this.pb_rectangle.Image = global::GraphicEditor.Properties.Resources.ImageRectangle;
            this.pb_rectangle.Location = new System.Drawing.Point(11, 65);
            this.pb_rectangle.Name = "pb_rectangle";
            this.pb_rectangle.Size = new System.Drawing.Size(28, 26);
            this.pb_rectangle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_rectangle.TabIndex = 1;
            this.pb_rectangle.TabStop = false;
            this.pb_rectangle.Click += new System.EventHandler(this.pb_rectangle_Click);
            // 
            // pb_line
            // 
            this.pb_line.BackColor = System.Drawing.Color.DarkSalmon;
            this.pb_line.Image = global::GraphicEditor.Properties.Resources.ImageLine;
            this.pb_line.Location = new System.Drawing.Point(11, 22);
            this.pb_line.Name = "pb_line";
            this.pb_line.Size = new System.Drawing.Size(28, 26);
            this.pb_line.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_line.TabIndex = 0;
            this.pb_line.TabStop = false;
            this.pb_line.Click += new System.EventHandler(this.pb_line_Click);
            // 
            // draw_panel
            // 
            this.draw_panel.BackColor = System.Drawing.Color.White;
            this.draw_panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.draw_panel.Location = new System.Drawing.Point(133, 28);
            this.draw_panel.Name = "draw_panel";
            this.draw_panel.Size = new System.Drawing.Size(641, 423);
            this.draw_panel.TabIndex = 2;
            this.draw_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseDown);
            this.draw_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseMove);
            this.draw_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseUp);
            // 
            // open_file
            // 
            this.open_file.FileName = "openFileDialog1";
            this.open_file.Filter = "\"ge files (*.ge)|*.ge|All files (*.*)|*.*\"";
            // 
            // save_file
            // 
            this.save_file.DefaultExt = "ge";
            this.save_file.Filter = "\"ge files (*.ge)|*.ge|All files (*.*)|*.*\"";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(786, 463);
            this.Controls.Add(this.draw_panel);
            this.Controls.Add(this.work_panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Graphic Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.work_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_fillellipse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_eraser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ellipse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_triangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_rectangle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_line)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sm_item_create;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Panel work_panel;
        private System.Windows.Forms.Panel draw_panel;
        private System.Windows.Forms.PictureBox pb_line;
        private System.Windows.Forms.PictureBox pb_rectangle;
        private System.Windows.Forms.ToolStripMenuItem sm_item_open;
        private System.Windows.Forms.ToolStripMenuItem sm_item_save;
        private System.Windows.Forms.OpenFileDialog open_file;
        private System.Windows.Forms.SaveFileDialog save_file;
        private System.Windows.Forms.PictureBox pb_triangle;
        private System.Windows.Forms.PictureBox pb_ellipse;
        private System.Windows.Forms.PictureBox pb_eraser;
        private System.Windows.Forms.Button bt_change_color;
        private System.Windows.Forms.ColorDialog col_dialog;
        private System.Windows.Forms.PictureBox pb_fillellipse;
        private System.Windows.Forms.ComboBox cb_figure;
    }
}

