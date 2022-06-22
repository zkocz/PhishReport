using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GetContacts
{
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			InitializeComponent();

			btnOk.Click += BtnOk_Click;
		}

		/// <summary>
		/// Test if user has right to edit XML with settings (saved in Program Files)
		/// </summary>
		/// <returns></returns>
		private bool TryWriteToConfig()
		{
			try
			{
				string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
				string xmlFile = Path.Combine(dir, "GetContacts.settings.xml");
				string localPath = new Uri(xmlFile).LocalPath;
				var doc = XElement.Load(localPath);

				XElement element = doc.Element("Settings");
				element.SetAttributeValue("id", Guid.NewGuid());
				doc.Save(localPath);

				return true;
			}
			catch
			{
				return false;
			}
		}

		private void frmSettings_Load(object sender, EventArgs e)
		{
			//I have experienced an issue with this check, so for this version I ignore it
			//bool canEdit = TryWriteToConfig();
			bool canEdit = true;
			txtAddreess.ReadOnly = txtConfirmation.ReadOnly = txtSubject.ReadOnly = !canEdit;
			cbDestination.Enabled = btnOk.Enabled = canEdit;

			//list of supported folders to move
			cbDestination.Items.Clear();
			cbDestination.Items.AddRange(new string[] { "Junk Email", "Deleted Items" });

			//get current settings
			Dictionary<string, object> settings = Settings.Get();
			txtAddreess.Text = settings["FwdAddress"].ToString();
			txtSubject.Text = settings["SubjectPrefix"].ToString();
			txtConfirmation.Text = settings["ConfirmationMessage"].ToString();

			txtNoSelected.Text = settings["NoItemSelected"].ToString();
			txtNoSupported.Text = settings["NoSupportedItemSelected"].ToString();
			txtOneNotSent.Text = settings["OneUnsupportedItem"].ToString();
			txtMultipleNotSent.Text = settings["MultipleUnsupportedItems"].ToString();

			//set default ID (junk email) in case of invalid value
			int targetFolderId = 0;
			int.TryParse(settings["TargetFolder"].ToString(), out targetFolderId);
			if (targetFolderId < 0 || targetFolderId > 1)
			{
				targetFolderId = 0;
			}

			cbDestination.SelectedIndex = targetFolderId;
		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			//Application.ProductName returns Outlook, so I have const with product name
			const string APP_NAME = "GetContacts";

			//verify if string match email pattern
			bool isEmail = Regex.IsMatch(txtAddreess.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

			if (!isEmail)
			{
				MessageBox.Show("Invalid email address", APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//save new values
			try
			{
				Settings.Set("FwdAddress", txtAddreess.Text);
				Settings.Set("SubjectPrefix", txtSubject.Text);
				Settings.Set("ConfirmationMessage", txtConfirmation.Text);
				Settings.Set("TargetFolder", cbDestination.SelectedIndex.ToString());
				Settings.Set("NoItemSelected", txtNoSelected.Text);
				Settings.Set("NoSupportedItemSelected", txtNoSupported.Text);
				Settings.Set("OneUnsupportedItem", txtOneNotSent.Text);
				Settings.Set("MultipleUnsupportedItems", txtMultipleNotSent.Text);

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (UnauthorizedAccessException exc)
			{
				MessageBox.Show(exc.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
