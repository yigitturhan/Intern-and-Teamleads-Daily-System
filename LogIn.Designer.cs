namespace DemoProject
{
    partial class LogIn
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.tbxPasswordSI = new System.Windows.Forms.TextBox();
            this.lblPasswordSI = new System.Windows.Forms.Label();
            this.tbxEmailSI = new System.Windows.Forms.TextBox();
            this.lblEmailSI = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgwChoose = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserNameSU = new System.Windows.Forms.Label();
            this.tbxUserNameSU = new System.Windows.Forms.TextBox();
            this.cbxTeamLead = new System.Windows.Forms.CheckBox();
            this.cbxIntern = new System.Windows.Forms.CheckBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.tbxPasswordSU = new System.Windows.Forms.TextBox();
            this.lblPasswordSU = new System.Windows.Forms.Label();
            this.tbxEmailSU = new System.Windows.Forms.TextBox();
            this.lblEmailSU = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwChoose)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSignIn);
            this.groupBox1.Controls.Add(this.tbxPasswordSI);
            this.groupBox1.Controls.Add(this.lblPasswordSI);
            this.groupBox1.Controls.Add(this.tbxEmailSI);
            this.groupBox1.Controls.Add(this.lblEmailSI);
            this.groupBox1.Location = new System.Drawing.Point(55, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 309);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sign In";
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(67, 269);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(127, 23);
            this.btnSignIn.TabIndex = 4;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // tbxPasswordSI
            // 
            this.tbxPasswordSI.Location = new System.Drawing.Point(17, 195);
            this.tbxPasswordSI.Name = "tbxPasswordSI";
            this.tbxPasswordSI.Size = new System.Drawing.Size(233, 20);
            this.tbxPasswordSI.TabIndex = 3;
            // 
            // lblPasswordSI
            // 
            this.lblPasswordSI.AutoSize = true;
            this.lblPasswordSI.Location = new System.Drawing.Point(14, 159);
            this.lblPasswordSI.Name = "lblPasswordSI";
            this.lblPasswordSI.Size = new System.Drawing.Size(53, 13);
            this.lblPasswordSI.TabIndex = 2;
            this.lblPasswordSI.Text = "Password";
            // 
            // tbxEmailSI
            // 
            this.tbxEmailSI.Location = new System.Drawing.Point(17, 77);
            this.tbxEmailSI.Name = "tbxEmailSI";
            this.tbxEmailSI.Size = new System.Drawing.Size(233, 20);
            this.tbxEmailSI.TabIndex = 1;
            // 
            // lblEmailSI
            // 
            this.lblEmailSI.AutoSize = true;
            this.lblEmailSI.Location = new System.Drawing.Point(14, 51);
            this.lblEmailSI.Name = "lblEmailSI";
            this.lblEmailSI.Size = new System.Drawing.Size(32, 13);
            this.lblEmailSI.TabIndex = 0;
            this.lblEmailSI.Text = "Email";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgwChoose);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblUserNameSU);
            this.groupBox2.Controls.Add(this.tbxUserNameSU);
            this.groupBox2.Controls.Add(this.cbxTeamLead);
            this.groupBox2.Controls.Add(this.cbxIntern);
            this.groupBox2.Controls.Add(this.btnSignUp);
            this.groupBox2.Controls.Add(this.tbxPasswordSU);
            this.groupBox2.Controls.Add(this.lblPasswordSU);
            this.groupBox2.Controls.Add(this.tbxEmailSU);
            this.groupBox2.Controls.Add(this.lblEmailSU);
            this.groupBox2.Location = new System.Drawing.Point(432, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(705, 309);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sign Up";
            // 
            // dgwChoose
            // 
            this.dgwChoose.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwChoose.Location = new System.Drawing.Point(344, 51);
            this.dgwChoose.Name = "dgwChoose";
            this.dgwChoose.Size = new System.Drawing.Size(335, 198);
            this.dgwChoose.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Select Your Teamlead (Only for interns)";
            // 
            // lblUserNameSU
            // 
            this.lblUserNameSU.AutoSize = true;
            this.lblUserNameSU.Location = new System.Drawing.Point(17, 168);
            this.lblUserNameSU.Name = "lblUserNameSU";
            this.lblUserNameSU.Size = new System.Drawing.Size(60, 13);
            this.lblUserNameSU.TabIndex = 11;
            this.lblUserNameSU.Text = "User Name";
            // 
            // tbxUserNameSU
            // 
            this.tbxUserNameSU.Location = new System.Drawing.Point(6, 184);
            this.tbxUserNameSU.Name = "tbxUserNameSU";
            this.tbxUserNameSU.Size = new System.Drawing.Size(246, 20);
            this.tbxUserNameSU.TabIndex = 10;
            // 
            // cbxTeamLead
            // 
            this.cbxTeamLead.AutoSize = true;
            this.cbxTeamLead.Location = new System.Drawing.Point(121, 232);
            this.cbxTeamLead.Name = "cbxTeamLead";
            this.cbxTeamLead.Size = new System.Drawing.Size(80, 17);
            this.cbxTeamLead.TabIndex = 9;
            this.cbxTeamLead.Text = "Team Lead";
            this.cbxTeamLead.UseVisualStyleBackColor = true;
            this.cbxTeamLead.CheckedChanged += new System.EventHandler(this.cbxTeamLead_CheckedChanged);
            // 
            // cbxIntern
            // 
            this.cbxIntern.AutoSize = true;
            this.cbxIntern.Location = new System.Drawing.Point(24, 232);
            this.cbxIntern.Name = "cbxIntern";
            this.cbxIntern.Size = new System.Drawing.Size(53, 17);
            this.cbxIntern.TabIndex = 8;
            this.cbxIntern.Text = "Intern";
            this.cbxIntern.UseVisualStyleBackColor = true;
            this.cbxIntern.CheckedChanged += new System.EventHandler(this.cbxIntern_CheckedChanged);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(274, 269);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(127, 23);
            this.btnSignUp.TabIndex = 5;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // tbxPasswordSU
            // 
            this.tbxPasswordSU.Location = new System.Drawing.Point(6, 118);
            this.tbxPasswordSU.Name = "tbxPasswordSU";
            this.tbxPasswordSU.Size = new System.Drawing.Size(246, 20);
            this.tbxPasswordSU.TabIndex = 7;
            // 
            // lblPasswordSU
            // 
            this.lblPasswordSU.AutoSize = true;
            this.lblPasswordSU.Location = new System.Drawing.Point(17, 102);
            this.lblPasswordSU.Name = "lblPasswordSU";
            this.lblPasswordSU.Size = new System.Drawing.Size(159, 13);
            this.lblPasswordSU.TabIndex = 6;
            this.lblPasswordSU.Text = "Password (At least 4 characters)";
            // 
            // tbxEmailSU
            // 
            this.tbxEmailSU.Location = new System.Drawing.Point(6, 48);
            this.tbxEmailSU.Name = "tbxEmailSU";
            this.tbxEmailSU.Size = new System.Drawing.Size(246, 20);
            this.tbxEmailSU.TabIndex = 5;
            // 
            // lblEmailSU
            // 
            this.lblEmailSU.AutoSize = true;
            this.lblEmailSU.Location = new System.Drawing.Point(17, 30);
            this.lblEmailSU.Name = "lblEmailSU";
            this.lblEmailSU.Size = new System.Drawing.Size(32, 13);
            this.lblEmailSU.TabIndex = 4;
            this.lblEmailSU.Text = "Email";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 433);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Sign In / Sign Up";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwChoose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.TextBox tbxPasswordSI;
        private System.Windows.Forms.Label lblPasswordSI;
        private System.Windows.Forms.TextBox tbxEmailSI;
        private System.Windows.Forms.Label lblEmailSI;
        private System.Windows.Forms.CheckBox cbxTeamLead;
        private System.Windows.Forms.CheckBox cbxIntern;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.TextBox tbxPasswordSU;
        private System.Windows.Forms.Label lblPasswordSU;
        private System.Windows.Forms.TextBox tbxEmailSU;
        private System.Windows.Forms.Label lblEmailSU;
        private System.Windows.Forms.Label lblUserNameSU;
        private System.Windows.Forms.TextBox tbxUserNameSU;
        private System.Windows.Forms.DataGridView dgwChoose;
        private System.Windows.Forms.Label label1;
    }
}