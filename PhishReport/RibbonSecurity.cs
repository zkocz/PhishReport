using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
			var m = e.Control.Context as Inspector;
			var mailitem = m.CurrentItem as MailItem;
			if (mailitem != null)
			{
				try
				{
					string PropName = "http://schemas.microsoft.com/mapi/proptag/0x007D001E";
					var oPA = mailitem.PropertyAccessor;
					string header = oPA.GetProperty(PropName);

					MailItem tosend = (MailItem)Globals.ThisAddIn.Application.CreateItem(OlItemType.olMailItem);
					tosend.Attachments.Add(mailitem);
					tosend.To = "marge.simpson@lab.local";
					tosend.Subject = "Suspected mail";
					tosend.Body = header;
					tosend.Save();
					tosend.Send();

					Outlook.MAPIFolder inBox = (Outlook.MAPIFolder)this.Application.
		  ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderJunk);
					//Microsoft.Office.Interop.Outlook.Folder inbox = Application.ActiveExplorer().Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);


				}
				catch (System.Exception exc)
				{
					Console.WriteLine("Exception caught: {0}", exc.Message);
				}

				MessageBox.Show("Diky za nahlaseni");
			}
		}
	}
}