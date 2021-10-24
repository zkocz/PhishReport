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

		}

		private void btnReport_Click(object sender, RibbonControlEventArgs e)
		{
			//Application.ProductName returns "Outlook"
			const string APP_NAME = "PhishReport";
			bool supported = false;
			Inspector inspector = e.Control.Context as Inspector;
			if (inspector != null)
			{
				MailItem originalMail = inspector.CurrentItem as MailItem;
				try
				{
					Send(originalMail);
					supported = true;
				}
				catch (System.Exception exc)
				{
					MessageBox.Show(exc.Message);
				}
			}
			else
			{
				Explorer explorer = new Outlook.Application().ActiveExplorer() as Explorer;
				Selection selection = explorer.Selection;

				if (selection.Count == 0)
				{
					string s = Properties.Settings.Default.NoMailSelected;
					MessageBox.Show(s, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				foreach (var selectedItem in selection)
				{
					if (selectedItem is MailItem)
					{
						try
						{
							Send((MailItem)selectedItem);
							supported = true;
						}
						catch (System.Exception exc)
						{
							string s = exc.Message;
							MessageBox.Show(s, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}

			if (!supported)
			{
				string s = Properties.Settings.Default.NoSupportedMailSelected;
				MessageBox.Show(s, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			else
			{
				string s = Properties.Settings.Default.Thanks;
				MessageBox.Show(s, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		void Send(MailItem originalMail)
		{
			if (originalMail != null)
			{
				string propName = "http://schemas.microsoft.com/mapi/proptag/0x007D001E";
				var propAccessor = originalMail.PropertyAccessor;
				string header = propAccessor.GetProperty(propName);

				MailItem fwMail = (MailItem)Globals.ThisAddIn.Application.CreateItem(OlItemType.olMailItem);
				fwMail.To = Properties.Settings.Default.FwdAddress;
				fwMail.Subject = string.Format("{0}: {1}", Properties.Settings.Default.Subject, originalMail.Subject);
				fwMail.Body = header;
				fwMail.Attachments.Add(originalMail);
				fwMail.Save();
				fwMail.Send();

				OlDefaultFolders targetFolder = OlDefaultFolders.olFolderInbox;

				int targetFolderId = (int)Properties.Settings.Default.TargetFolder;
				switch (targetFolderId)
				{
					case 1:
						targetFolder = OlDefaultFolders.olFolderJunk;
						break;
					case 2:
						targetFolder = OlDefaultFolders.olFolderDeletedItems;
						break;
					default:
						targetFolderId = 0;
						break;
				}

				if (targetFolderId > 0)
				{
					originalMail.Close(OlInspectorClose.olDiscard);
					Outlook.Application a = new Outlook.Application();
					MAPIFolder target = a.ActiveExplorer().Session.GetDefaultFolder(targetFolder);
					originalMail.Move(target);
				}
			}
		}
	}
}