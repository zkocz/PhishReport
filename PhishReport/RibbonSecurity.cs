using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PhishReport
{
	public partial class RibbonSecurity
	{
		private void RibbonSecurity_Load(object sender, RibbonUIEventArgs e)
		{
			sbtnReport.ScreenTip = Properties.Settings.Default.Hint;
		}

		/// <summary>
		/// Click on main button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void sbtnReport_Click(object sender, RibbonControlEventArgs e)
		{
			//Application.ProductName returns "Outlook"
			const string APP_NAME = "PhishReport";

			//if any mail was successfully sent, display confirmation message
			bool sent = false;
			
			Inspector inspector = e.Control.Context as Inspector;
			if (inspector != null)	//item is open
			{
				try
				{
					Send(inspector.CurrentItem);
					sent = true;
				}
				catch (System.Exception exc)
				{
					MessageBox.Show(exc.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else //get selected items in list of emails in current folder
			{
				Explorer explorer = new Outlook.Application().ActiveExplorer() as Explorer;
				Selection selection = explorer.Selection;

				if (selection.Count == 0)
				{
					string s = Properties.Settings.Default.NoMailSelected;
					MessageBox.Show(s, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					foreach (var selectedItem in selection)
					{
						try
						{
							Send(selectedItem as MailItem);
							sent = true;
						}
						catch (System.Exception exc)
						{
							MessageBox.Show(exc.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				}
			}
			if(sent)
			{
				Dictionary<string, object> settings = Settings.Get();
				string s = settings["ConfirmationMessage"].ToString();
				MessageBox.Show(s, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// Cretaes a new email and sends the original email as attachment. Current email is moved to folder specified in Settings
		/// </summary>
		/// <param name="originalMail"></param>
		void Send(MailItem originalMail)
		{
			if (originalMail != null)
			{
				Dictionary<string, object> settings = Settings.Get();
				
				//create new email
				string propName = "http://schemas.microsoft.com/mapi/proptag/0x007D001E";
				var propAccessor = originalMail.PropertyAccessor;
				string header = propAccessor.GetProperty(propName);

				MailItem fwMail = (MailItem)Globals.ThisAddIn.Application.CreateItem(OlItemType.olMailItem);
				fwMail.To = settings["FwdAddress"].ToString();
				fwMail.Subject = string.Format("{0}{1}", settings["SubjectPrefix"].ToString(), originalMail.Subject);
				fwMail.Body = header;
				fwMail.Attachments.Add(originalMail);
				fwMail.Save();
				fwMail.Send();

				//get folder to move to
				OlDefaultFolders targetFolder = OlDefaultFolders.olFolderInbox;
				string strTF = settings["TargetFolder"].ToString();
				int targetFolderId = Convert.ToInt32(settings["TargetFolder"].ToString());
				switch (targetFolderId)
				{
					case 1:
						targetFolder = OlDefaultFolders.olFolderDeletedItems;
						break;
					default:
						targetFolder = OlDefaultFolders.olFolderJunk;
						break;
				}

				originalMail.Close(OlInspectorClose.olDiscard);
				MAPIFolder target = new Outlook.Application().ActiveExplorer().Session.GetDefaultFolder(targetFolder);
				originalMail.Move(target);
			}
		}

		/// <summary>
		/// Displays "About" information
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAbout_Click(object sender, RibbonControlEventArgs e)
		{
			frmAbout f = new frmAbout();
			f.ShowDialog();
		}

		//Displays Form for settings
		private void btnSettings_Click(object sender, RibbonControlEventArgs e)
		{
			frmSettings f = new frmSettings();
			f.ShowDialog();
		}
	}
}