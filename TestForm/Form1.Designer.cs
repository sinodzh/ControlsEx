namespace TestForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxEx1 = new ControlsEx.TextBoxEx();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxEx2 = new ControlsEx.TextBoxEx();
            this.SuspendLayout();
            // 
            // textBoxEx1
            // 
            this.textBoxEx1.EditValueType = ControlsEx.TextBoxEx.ValueType.String;
            this.textBoxEx1.Location = new System.Drawing.Point(61, 43);
            this.textBoxEx1.MaxNum = 2147483647;
            this.textBoxEx1.MinNum = -2147483648;
            this.textBoxEx1.Name = "textBoxEx1";
            this.textBoxEx1.Size = new System.Drawing.Size(130, 21);
            this.textBoxEx1.TabIndex = 0;
            this.textBoxEx1.EditValueChanging += new ControlsEx.TextBoxEx.ChangingEventHandler(this.textBoxEx1_EditValueChanging);
            this.textBoxEx1.TextChanged += new System.EventHandler(this.textBoxEx1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Click";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxEx2
            // 
            this.textBoxEx2.EditValueType = ControlsEx.TextBoxEx.ValueType.Number;
            this.textBoxEx2.Location = new System.Drawing.Point(61, 73);
            this.textBoxEx2.MaxNum = 200;
            this.textBoxEx2.MinNum = -200;
            this.textBoxEx2.Name = "textBoxEx2";
            this.textBoxEx2.Size = new System.Drawing.Size(130, 21);
            this.textBoxEx2.TabIndex = 2;
            this.textBoxEx2.Text = "0";
            this.textBoxEx2.EditValueChanging += new ControlsEx.TextBoxEx.ChangingEventHandler(this.textBoxEx2_EditValueChanging);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBoxEx2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxEx1);
            this.Name = "Form1";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlsEx.TextBoxEx textBoxEx1;
        private System.Windows.Forms.Button button1;
        private ControlsEx.TextBoxEx textBoxEx2;
    }
}

