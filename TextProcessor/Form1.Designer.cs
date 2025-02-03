namespace TextProcessor
{
    partial class MainForm
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnProcessText = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnClearFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 39);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(340, 306);
            this.txtInput.TabIndex = 0;
            // 
            // txtResult
            // 
            this.txtResult.AcceptsReturn = true;
            this.txtResult.AcceptsTab = true;
            this.txtResult.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.txtResult.Location = new System.Drawing.Point(448, 39);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(340, 306);
            this.txtResult.TabIndex = 1;
            // 
            // btnProcessText
            // 
            this.btnProcessText.Location = new System.Drawing.Point(10, 385);
            this.btnProcessText.Name = "btnProcessText";
            this.btnProcessText.Size = new System.Drawing.Size(111, 35);
            this.btnProcessText.TabIndex = 2;
            this.btnProcessText.Text = "Выполнить преобразование";
            this.btnProcessText.UseVisualStyleBackColor = true;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(127, 385);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(111, 35);
            this.btnSelectFolder.TabIndex = 3;
            this.btnSelectFolder.Text = "Выбрать папку";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            // 
            // btnClearFolder
            // 
            this.btnClearFolder.Location = new System.Drawing.Point(244, 385);
            this.btnClearFolder.Name = "btnClearFolder";
            this.btnClearFolder.Size = new System.Drawing.Size(111, 35);
            this.btnClearFolder.TabIndex = 4;
            this.btnClearFolder.Text = "Очистить папку";
            this.btnClearFolder.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClearFolder);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnProcessText);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtInput);
            this.Name = "MainForm";
            this.Text = "Text Processor Test Task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnProcessText;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnClearFolder;
    }
}

