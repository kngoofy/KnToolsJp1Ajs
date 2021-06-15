
namespace KnToolsJp1AjsForms
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkBoxAzNavel = new System.Windows.Forms.CheckBox();
            this.checkBoxfBase = new System.Windows.Forms.CheckBox();
            this.checkBoxDerico = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxAzNavel
            // 
            this.checkBoxAzNavel.AutoSize = true;
            this.checkBoxAzNavel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxAzNavel.Location = new System.Drawing.Point(70, 64);
            this.checkBoxAzNavel.Name = "checkBoxAzNavel";
            this.checkBoxAzNavel.Size = new System.Drawing.Size(116, 28);
            this.checkBoxAzNavel.TabIndex = 0;
            this.checkBoxAzNavel.Text = "AzNavel";
            this.checkBoxAzNavel.UseVisualStyleBackColor = true;
            // 
            // checkBoxfBase
            // 
            this.checkBoxfBase.AutoSize = true;
            this.checkBoxfBase.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxfBase.Location = new System.Drawing.Point(70, 106);
            this.checkBoxfBase.Name = "checkBoxfBase";
            this.checkBoxfBase.Size = new System.Drawing.Size(92, 28);
            this.checkBoxfBase.TabIndex = 1;
            this.checkBoxfBase.Text = "fBase";
            this.checkBoxfBase.UseVisualStyleBackColor = true;
            // 
            // checkBoxDerico
            // 
            this.checkBoxDerico.AutoSize = true;
            this.checkBoxDerico.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBoxDerico.Location = new System.Drawing.Point(70, 152);
            this.checkBoxDerico.Name = "checkBoxDerico";
            this.checkBoxDerico.Size = new System.Drawing.Size(101, 28);
            this.checkBoxDerico.TabIndex = 2;
            this.checkBoxDerico.Text = "Derico";
            this.checkBoxDerico.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(18, 233);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1033, 31);
            this.textBox1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Button1);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(20, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 200);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FromDcMon";
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Button1.Location = new System.Drawing.Point(298, 50);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(126, 55);
            this.Button1.TabIndex = 5;
            this.Button1.Text = "Create";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(655, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 163);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 305);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBoxDerico);
            this.Controls.Add(this.checkBoxfBase);
            this.Controls.Add(this.checkBoxAzNavel);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAzNavel;
        private System.Windows.Forms.CheckBox checkBoxfBase;
        private System.Windows.Forms.CheckBox checkBoxDerico;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

