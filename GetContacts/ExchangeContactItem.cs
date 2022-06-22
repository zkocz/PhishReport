using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace GetContacts
{
	public class ExchangeContactItem
	{
      public string FirstName = string.Empty;
      public string LastName = string.Empty;
      public string DisplayName = string.Empty;
      public string Company = string.Empty;
      public string Department = string.Empty;
      public string Title = string.Empty;
      public string L = string.Empty;
      public string TelephoneNumber = string.Empty;
      public string Mobile = string.Empty;
      public string Mail = string.Empty;
      public string Description = string.Empty;
      public string PrimaryTelephoneNumber = string.Empty;
      public string MailingAddressStreet = string.Empty;
      public string MailingAddressCity = string.Empty;
      public string MailingAddressState = string.Empty;

      public ExchangeContactItem()
		{
         Outlook.ContactItem newContact = (Outlook.ContactItem)Globals.ThisAddIn.Application.CreateItem(Outlook.OlItemType.olContactItem);

         newContact.;
      }

      public void Save()
		{
         Outlook.ContactItem newContact = (Outlook.ContactItem)Globals.ThisAddIn.Application.CreateItem(Outlook.OlItemType.olContactItem);

         newContact.FirstName = FirstName;
         newContact.LastName = LastName;
         newContact.DisplayName = DisplayName;
         newContact.Company = Company;
         newContact.Department = Department;
         newContact.Title = Title;
         newContact.L = L;
         newContact..TelephoneNumber = TelephoneNumber;
         newContact.Mobile = Mobile;
         newContact.Mail = Mail;
         newContact.Description = Description;
         newContact.PrimaryTelephoneNumber = PrimaryTelephoneNumber;
         newContact.MailingAddressStreet = MailingAddressStreet;
         newContact.MailingAddressCity = MailingAddressCity;
         newContact.MailingAddressState = MailingAddressState;

         newContact.Save();
         newContact.Display(true);
      }
	}
}
