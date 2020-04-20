namespace Newton_Interpolation
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.function_dataGridView = new System.Windows.Forms.DataGridView();
            this.columnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.interpolateStep_textBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.interpolateInitialX_textBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.interpolateFinalX_textBox = new System.Windows.Forms.ToolStripTextBox();
            this.Interpolate_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.interpolated_dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.step_textBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.initialX_textBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.finalX_textBox = new System.Windows.Forms.ToolStripTextBox();
            this.CreateValueTable_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.function_dataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interpolated_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(849, 485);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseCaptureChanged += new System.EventHandler(this.pictureBox1_MouseCaptureChanged);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter_1);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave_1);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // function_dataGridView
            // 
            this.function_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.function_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnX,
            this.columnY});
            this.function_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.function_dataGridView.Location = new System.Drawing.Point(0, 0);
            this.function_dataGridView.Name = "function_dataGridView";
            this.function_dataGridView.Size = new System.Drawing.Size(240, 217);
            this.function_dataGridView.TabIndex = 3;
            // 
            // columnX
            // 
            this.columnX.Frozen = true;
            this.columnX.HeaderText = "X";
            this.columnX.Name = "columnX";
            // 
            // columnY
            // 
            this.columnY.Frozen = true;
            this.columnY.HeaderText = "Y";
            this.columnY.Name = "columnY";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.interpolateStep_textBox,
            this.toolStripLabel5,
            this.interpolateInitialX_textBox,
            this.toolStripLabel6,
            this.interpolateFinalX_textBox,
            this.Interpolate_Button,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1093, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel4.Text = "Step=";
            // 
            // interpolateStep_textBox
            // 
            this.interpolateStep_textBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.interpolateStep_textBox.Name = "interpolateStep_textBox";
            this.interpolateStep_textBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel5.Text = "Initial x=";
            // 
            // interpolateInitialX_textBox
            // 
            this.interpolateInitialX_textBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.interpolateInitialX_textBox.Name = "interpolateInitialX_textBox";
            this.interpolateInitialX_textBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel6.Text = "Final x=";
            // 
            // interpolateFinalX_textBox
            // 
            this.interpolateFinalX_textBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.interpolateFinalX_textBox.Name = "interpolateFinalX_textBox";
            this.interpolateFinalX_textBox.Size = new System.Drawing.Size(100, 25);
            // 
            // Interpolate_Button
            // 
            this.Interpolate_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Interpolate_Button.Image = ((System.Drawing.Image)(resources.GetObject("Interpolate_Button.Image")));
            this.Interpolate_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Interpolate_Button.Name = "Interpolate_Button";
            this.Interpolate_Button.Size = new System.Drawing.Size(68, 22);
            this.Interpolate_Button.Text = "Interpolate";
            this.Interpolate_Button.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // interpolated_dataGridView
            // 
            this.interpolated_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.interpolated_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.interpolated_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interpolated_dataGridView.Location = new System.Drawing.Point(0, 0);
            this.interpolated_dataGridView.Name = "interpolated_dataGridView";
            this.interpolated_dataGridView.Size = new System.Drawing.Size(240, 264);
            this.interpolated_dataGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "X";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Y";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.function_dataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.interpolated_dataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(240, 485);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 50);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer2.Size = new System.Drawing.Size(1093, 485);
            this.splitContainer2.SplitterDistance = 240;
            this.splitContainer2.TabIndex = 7;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.step_textBox,
            this.toolStripLabel2,
            this.initialX_textBox,
            this.toolStripLabel3,
            this.finalX_textBox,
            this.CreateValueTable_Button,
            this.toolStripSeparator2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1093, 25);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 22);
            this.toolStripLabel1.Text = "Step=";
            // 
            // step_textBox
            // 
            this.step_textBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.step_textBox.Name = "step_textBox";
            this.step_textBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel2.Text = "Initial x=";
            // 
            // initialX_textBox
            // 
            this.initialX_textBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.initialX_textBox.Name = "initialX_textBox";
            this.initialX_textBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel3.Text = "Final x=";
            // 
            // finalX_textBox
            // 
            this.finalX_textBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.finalX_textBox.Name = "finalX_textBox";
            this.finalX_textBox.Size = new System.Drawing.Size(100, 25);
            // 
            // CreateValueTable_Button
            // 
            this.CreateValueTable_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CreateValueTable_Button.Image = ((System.Drawing.Image)(resources.GetObject("CreateValueTable_Button.Image")));
            this.CreateValueTable_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateValueTable_Button.Name = "CreateValueTable_Button";
            this.CreateValueTable_Button.Size = new System.Drawing.Size(105, 22);
            this.CreateValueTable_Button.Text = "Create value table";
            this.CreateValueTable_Button.Click += new System.EventHandler(this.CreateValueTable_Button_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 535);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.function_dataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interpolated_dataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView function_dataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Interpolate_Button;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnY;
        private System.Windows.Forms.DataGridView interpolated_dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox interpolateStep_textBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox interpolateInitialX_textBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripTextBox interpolateFinalX_textBox;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox step_textBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox initialX_textBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox finalX_textBox;
        private System.Windows.Forms.ToolStripButton CreateValueTable_Button;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

