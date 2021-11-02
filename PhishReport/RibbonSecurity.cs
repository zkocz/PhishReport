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
					sent = Send(inspector.CurrentItem);
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
							sent = Send(selectedItem as MailItem);
						}
						catch (System.Exception exc)
						{
							MessageBox.Show(exc.Message, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				}
			}

			Dictionary<string, object> settings = Settings.Get();
			if (sent)
			{
				string s = settings["ConfirmationMessage"].ToString();
				MessageBox.Show(s, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				string s = settings["ConfirmationMessage"].ToString();
				MessageBox.Show(string.Format("{0} (Some items was not send)", s), APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// Cretaes a new email and sends the original email as attachment. Current email is moved to folder specified in Settings
		/// </summary>
		/// <param name="originalMail"></param>
		private bool Send(object originalMail)
		{
			Dictionary<string, object> settings = Settings.Get();
			string subject = string.Empty;
			PropertyAccessor propAccessor = null;


			if (originalMail is Outlook.MailItem)
			{
				propAccessor = ((MailItem)originalMail).PropertyAccessor;
				subject = ((MailItem)originalMail).Subject;
			}
			else if (originalMail is Outlook.ContactItem)
			{
				propAccessor = ((ContactItem)originalMail).PropertyAccessor;
				subject = ((ContactItem)originalMail).Subject;
			}
			else if (originalMail is Outlook.AppointmentItem)
			{
				propAccessor = ((AppointmentItem)originalMail).PropertyAccessor;
				subject = ((AppointmentItem)originalMail).Subject;
			}
			else if (originalMail is Outlook.TaskItem)
			{
				propAccessor = ((TaskItem)originalMail).PropertyAccessor;
				subject = ((TaskItem)originalMail).Subject;
			}
			else if (originalMail is Outlook.MeetingItem)
			{
				propAccessor = ((MeetingItem)originalMail).PropertyAccessor;
				subject = ((MeetingItem)originalMail).Subject;
			}

			else if (originalMail is Outlook.ReportItem)
			{
				propAccessor = ((ReportItem)originalMail).PropertyAccessor;
				subject = ((ReportItem)originalMail).Subject;
			}
			else if (originalMail is Outlook.DistListItem)
			{
				propAccessor = ((DistListItem)originalMail).PropertyAccessor;
				subject = ((DistListItem)originalMail).Subject;
			}

			else if (originalMail is Outlook.JournalItem)
			{
				propAccessor = ((JournalItem)originalMail).PropertyAccessor;
				subject = ((JournalItem)originalMail).Subject;
			}
			else if (originalMail is Outlook.MobileItem)
			{
				propAccessor = ((MobileItem)originalMail).PropertyAccessor;
				subject = ((MobileItem)originalMail).Subject;
			}
			else if (originalMail is Outlook.NoteItem)
			{
				propAccessor = ((NoteItem)originalMail).PropertyAccessor;
				subject = ((NoteItem)originalMail).Subject;
			}
			else if (originalMail is Outlook.PostItem)
			{
				propAccessor = ((PostItem)originalMail).PropertyAccessor;
				subject = ((PostItem)originalMail).Subject;
			}
			else
			{
				return false;
			}

			//create new email
			string propName = "http://schemas.microsoft.com/mapi/proptag/0x007D001E";

			string header = propAccessor.GetProperty(propName);

			MailItem fwMail = (MailItem)Globals.ThisAddIn.Application.CreateItem(OlItemType.olMailItem);
			fwMail.To = settings["FwdAddress"].ToString();
			fwMail.Subject = string.Format("{0}{1}", settings["SubjectPrefix"].ToString(), subject);
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

			//originalMail.Close(OlInspectorClose.olDiscard);
			MAPIFolder target = new Outlook.Application().ActiveExplorer().Session.GetDefaultFolder(targetFolder);
			//originalMail.Move(target);


			if (originalMail is Outlook.MailItem)
			{
				((MailItem)originalMail).Close(OlInspectorClose.olDiscard);
				((MailItem)originalMail).Move(target);
			}
			else if (originalMail is Outlook.ContactItem)
			{
				((ContactItem)originalMail).Close(OlInspectorClose.olDiscard);
				((ContactItem)originalMail).Move(target);
			}
			else if (originalMail is Outlook.AppointmentItem)
			{
				((AppointmentItem)originalMail).Close(OlInspectorClose.olDiscard);
				((AppointmentItem)originalMail).Move(target);
			}
			else if (originalMail is Outlook.TaskItem)
			{
				((TaskItem)originalMail).Close(OlInspectorClose.olDiscard);
				((TaskItem)originalMail).Move(target);
			}
			else if (originalMail is Outlook.MeetingItem)
			{
				((MeetingItem)originalMail).Close(OlInspectorClose.olDiscard);
				((MeetingItem)originalMail).Move(target);
			}

			else if (originalMail is Outlook.ReportItem)
			{
				((ReportItem)originalMail).Close(OlInspectorClose.olDiscard);
				((ReportItem)originalMail).Move(target);
			}
			else if (originalMail is Outlook.DistListItem)
			{
				((DistListItem)originalMail).Close(OlInspectorClose.olDiscard);
				((DistListItem)originalMail).Move(target);
			}

			else if (originalMail is Outlook.JournalItem)
			{
				((JournalItem)originalMail).Close(OlInspectorClose.olDiscard);
				((JournalItem)originalMail).Move(target);
			}
			else if (originalMail is Outlook.MobileItem)
			{
				((MobileItem)originalMail).Close(OlInspectorClose.olDiscard);
				((MobileItem)originalMail).Move(target);
			}
			else if (originalMail is Outlook.NoteItem)
			{
				((NoteItem)originalMail).Close(OlInspectorClose.olDiscard);
				((NoteItem)originalMail).Move(target);
			}
			else if (originalMail is Outlook.PostItem)
			{
				((PostItem)originalMail).Close(OlInspectorClose.olDiscard);
				((PostItem)originalMail).Move(target);
			}
			return true;
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