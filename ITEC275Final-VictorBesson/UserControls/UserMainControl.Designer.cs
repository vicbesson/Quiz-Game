namespace ITEC275Final_VictorBesson.UserControls
{
    partial class UserMainControl
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnMyQuizzes = new System.Windows.Forms.FlowLayoutPanel();
            this.pnPublicQuizzes = new System.Windows.Forms.FlowLayoutPanel();
            this.pnInvitedQuizzes = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(241)))), ((int)(((byte)(119)))));
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(569, 16);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(117, 38);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create Quiz";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(241)))), ((int)(((byte)(119)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(708, 16);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(117, 38);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnMyQuizzes
            // 
            this.pnMyQuizzes.AutoScroll = true;
            this.pnMyQuizzes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnMyQuizzes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnMyQuizzes.Location = new System.Drawing.Point(19, 91);
            this.pnMyQuizzes.Name = "pnMyQuizzes";
            this.pnMyQuizzes.Size = new System.Drawing.Size(256, 460);
            this.pnMyQuizzes.TabIndex = 5;
            this.pnMyQuizzes.WrapContents = false;
            // 
            // pnPublicQuizzes
            // 
            this.pnPublicQuizzes.AutoScroll = true;
            this.pnPublicQuizzes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnPublicQuizzes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnPublicQuizzes.Location = new System.Drawing.Point(294, 91);
            this.pnPublicQuizzes.Name = "pnPublicQuizzes";
            this.pnPublicQuizzes.Size = new System.Drawing.Size(256, 460);
            this.pnPublicQuizzes.TabIndex = 6;
            this.pnPublicQuizzes.WrapContents = false;
            // 
            // pnInvitedQuizzes
            // 
            this.pnInvitedQuizzes.AutoScroll = true;
            this.pnInvitedQuizzes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnInvitedQuizzes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnInvitedQuizzes.Location = new System.Drawing.Point(569, 91);
            this.pnInvitedQuizzes.Margin = new System.Windows.Forms.Padding(0);
            this.pnInvitedQuizzes.Name = "pnInvitedQuizzes";
            this.pnInvitedQuizzes.Size = new System.Drawing.Size(256, 460);
            this.pnInvitedQuizzes.TabIndex = 7;
            this.pnInvitedQuizzes.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "My Quizzes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(367, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Public Quizzes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(660, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Invited To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(84, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(310, 29);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(241)))), ((int)(((byte)(119)))));
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.Enabled = false;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(424, 17);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(117, 37);
            this.btnRun.TabIndex = 13;
            this.btnRun.Text = "Run Quiz";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // UserMainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(56)))));
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnInvitedQuizzes);
            this.Controls.Add(this.pnPublicQuizzes);
            this.Controls.Add(this.pnMyQuizzes);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCreate);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserMainControl";
            this.Size = new System.Drawing.Size(847, 582);
            this.Load += new System.EventHandler(this.UserMainControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.FlowLayoutPanel pnMyQuizzes;
        private System.Windows.Forms.FlowLayoutPanel pnPublicQuizzes;
        private System.Windows.Forms.FlowLayoutPanel pnInvitedQuizzes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        public System.Windows.Forms.Button btnRun;
    }
}
