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
			Inspector inspector = e.Control.Context as Inspector;
			if (inspector != null)
			{
				MailItem originalMail = inspector.CurrentItem as MailItem;
				Send(originalMail);
			}
			else
			{ 
				Explorer explorer = new Outlook.Application().ActiveExplorer() as Explorer;
				Selection selection = explorer.Selection;

				if(selection.Count == 0)
				{
					MessageBox.Show(Properties.Settings.Default.NoMailSelected);
					return;
				}

				foreach(var selectedItem in selection)
				{
					if(selectedItem is MailItem)
					{
						Send((MailItem)selectedItem);
					}
				}
			}
		}

		void Send(MailItem originalMail)
		{ 
			if (originalMail != null)
			{
				try
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

					MessageBox.Show(Properties.Settings.Default.Thanks);
				}
				catch (System.Exception exc)
				{
					System.Windows.Forms.MessageBox.Show(exc.Message);
				}
			}
		}
	}
}