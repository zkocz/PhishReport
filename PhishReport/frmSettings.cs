﻿using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PhishReport
{
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			InitializeComponent();
		}

		private void frmSettings_Load(object sender, EventArgs e)
		{
			//list of supported folders to move
			cbDestination.Items.Clear();
			cbDestination.Items.AddRange(new string[] { "Junk Email", "Deleted Items" });

			//get current settings
			Dictionary<string, object> settings = Settings.Get();
			txtAddreess.Text = settings["FwdAddress"].ToString();
			txtSubject.Text = settings["SubjectPrefix"].ToString();
			txtConfirmation.Text = settings["ConfirmationMessage"].ToString();

			//set default ID (junk email) in case of invalid value
			int targetFolderId = 0;
			int.TryParse(settings["TargetFolder"].ToString(), out targetFolderId);
			if (targetFolderId < 0 || targetFolderId > 1)
			{
				targetFolderId = 0;
			}

			cbDestination.SelectedIndex = targetFolderId;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			const string APP_NAME = "PhishReport";
			bool isEmail = Regex.IsMatch(txtAddreess.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

			if(!isEmail)
			{
				MessageBox.Show("Invalid email address", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//save new values
			Settings.Set("FwdAddress", txtAddreess.Text);
			Settings.Set("SubjectPrefix", txtSubject.Text);
			Settings.Set("ConfirmationMessage", txtConfirmation.Text);
			Settings.Set("TargetFolder", cbDestination.SelectedIndex.ToString());

			this.DialogResult = DialogResult.OK;
		}
	}
}
