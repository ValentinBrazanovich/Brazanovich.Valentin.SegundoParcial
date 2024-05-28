namespace WinFormVisualizador
{
    partial class FrmVisualizador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richTextBoxLog = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBoxLog
            // 
            richTextBoxLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxLog.BackColor = SystemColors.Info;
            richTextBoxLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxLog.Location = new Point(12, 12);
            richTextBoxLog.Name = "richTextBoxLog";
            richTextBoxLog.ReadOnly = true;
            richTextBoxLog.Size = new Size(776, 426);
            richTextBoxLog.TabIndex = 1;
            richTextBoxLog.Text = "";
            // 
            // FrmVisualizador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBoxLog);
            Name = "FrmVisualizador";
            Text = "Registro de usuarios";
            Load += VisualizadorLogUsuarios_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBoxLog;
    }
}
