namespace ITEC275Final_VictorBesson.UserControls.MiniControls
{
    partial class CreateQuizAnswerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.cbAnswer = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMessage.Location = new System.Drawing.Point(26, 25);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 18);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.Click += new System.EventHandler(this.CreateQuizAnswerControl_Click);
            // 
            // cbAnswer
            // 
            this.cbAnswer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbAnswer.AutoSize = true;
            this.cbAnswer.Location = new System.Drawing.Point(560, 25);
            this.cbAnswer.Name = "cbAnswer";
            this.cbAnswer.Size = new System.Drawing.Size(15, 14);
            this.cbAnswer.TabIndex = 2;
            this.cbAnswer.UseVisualStyleBackColor = true;
            this.cbAnswer.CheckedChanged += new System.EventHandler(this.cbAnswer_CheckedChanged);
            // 
            // CreateQuizAnswerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cbAnswer);
            this.Controls.Add(this.lblMessage);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CreateQuizAnswerControl";
            this.Size = new System.Drawing.Size(597, 65);
            this.Click += new System.EventHandler(this.CreateQuizAnswerControl_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.CheckBox cbAnswer;
    }
}
