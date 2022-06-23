
namespace PhishReport
{
	partial class frmSettings
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
			this.txtAddreess = new System.Windows.Forms.TextBox();
			this.txtConfirmation = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSubject = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.label5 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtNoSelected = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtMultipleNotSent = new System.Windows.Forms.TextBox();
			this.txtOneNotSent = new System.Windows.Forms.TextBox();
			this.txtNoSupported = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbDestination = new System.Windows.Forms.ComboBox();
			this.tabControl1.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtAddreess
			// 
			this.txtAddreess.Location = new System.Drawing.Point(226, 19);
			this.txtAddreess.Name = "txtAddreess";
			this.txtAddreess.Size = new System.Drawing.Size(241, 20);
			this.txtAddreess.TabIndex = 0;
			// 
			// txtConfirmation
			// 
			this.txtConfirmation.Location = new System.Drawing.Point(226, 108);
			this.txtConfirmation.Name = "txtConfirmation";
			this.txtConfirmation.Size = new System.Drawing.Size(241, 20);
			this.txtConfirmation.TabIndex = 2;
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(424, 464);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(59, 464);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Forward to:";
			// 
			// txtSubject
			// 
			this.txtSubject.Location = new System.Drawing.Point(226, 64);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(241, 20);
			this.txtSubject.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Subject prefix";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 111);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Confirmation message";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabGeneral);
			this.tabControl1.Location = new System.Drawing.Point(28, 26);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(512, 415);
			this.tabControl1.TabIndex = 7;
			// 
			// tabGeneral
			// 
			this.tabGeneral.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tabGeneral.Controls.Add(this.label5);
			this.tabGeneral.Controls.Add(this.label8);
			this.tabGeneral.Controls.Add(this.label6);
			this.tabGeneral.Controls.Add(this.txtNoSelected);
			this.tabGeneral.Controls.Add(this.label7);
			this.tabGeneral.Controls.Add(this.txtMultipleNotSent);
			this.tabGeneral.Controls.Add(this.txtOneNotSent);
			this.tabGeneral.Controls.Add(this.txtNoSupported);
			this.tabGeneral.Controls.Add(this.label4);
			this.tabGeneral.Controls.Add(this.cbDestination);
			this.tabGeneral.Controls.Add(this.label1);
			this.tabGeneral.Controls.Add(this.label3);
			this.tabGeneral.Controls.Add(this.txtAddreess);
			this.tabGeneral.Controls.Add(this.label2);
			this.tabGeneral.Controls.Add(this.txtConfirmation);
			this.tabGeneral.Controls.Add(this.txtSubject);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(504, 389);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "General";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 210);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(144, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "\"No item selected\" message:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(24, 340);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(166, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "\"Multiple items not sent\" message";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(24, 295);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(145, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "\"One item not sent\" message";
			// 
			// txtNoSelected
			// 
			this.txtNoSelected.Location = new System.Drawing.Point(226, 203);
			this.txtNoSelected.Name = "txtNoSelected";
			this.txtNoSelected.Size = new System.Drawing.Size(241, 20);
			this.txtNoSelected.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(24, 251);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(191, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "\"No supported item selected\" message";
			// 
			// txtMultipleNotSent
			// 
			this.txtMultipleNotSent.Location = new System.Drawing.Point(226, 337);
			this.txtMultipleNotSent.Name = "txtMultipleNotSent";
			this.txtMultipleNotSent.Size = new System.Drawing.Size(241, 20);
			this.txtMultipleNotSent.TabIndex = 11;
			// 
			// txtOneNotSent
			// 
			this.txtOneNotSent.Location = new System.Drawing.Point(226, 292);
			this.txtOneNotSent.Name = "txtOneNotSent";
			this.txtOneNotSent.Size = new System.Drawing.Size(241, 20);
			this.txtOneNotSent.TabIndex = 11;
			// 
			// txtNoSupported
			// 
			this.txtNoSupported.Location = new System.Drawing.Point(226, 248);
			this.txtNoSupported.Name = "txtNoSupported";
			this.txtNoSupported.Size = new System.Drawing.Size(241, 20);
			this.txtNoSupported.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 155);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Destination folder";
			// 
			// cbDestination
			// 
			this.cbDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDestination.FormattingEnabled = true;
			this.cbDestination.Location = new System.Drawing.Point(226, 152);
			this.cbDestination.Name = "cbDestination";
			this.cbDestination.Size = new System.Drawing.Size(121, 21);
			this.cbDestination.TabIndex = 3;
			// 
			// frmSettings
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(564, 521);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSettings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.frmSettings_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabGeneral.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox txtAddreess;
		private System.Windows.Forms.TextBox txtConfirmation;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSubject;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbDestination;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtNoSelected;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtMultipleNotSent;
		private System.Windows.Forms.TextBox txtOneNotSent;
		private System.Windows.Forms.TextBox txtNoSupported;
	}
}