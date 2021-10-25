using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;

namespace PhishReportCustomAction
{
	public class CustomActions
	{
		[CustomAction]
		public static ActionResult ValidateEmail(Session session)
		{
			session.Log("Begin CustomAction1");

			string email = session["FWD_ADDRESS"];
			return ActionResult.Failure;
			//return ActionResult.Success;
		}
	}
}
