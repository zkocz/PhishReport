using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace PhishReport
{
	public class Settings
	{
		public Settings()
		{

		}

		public static void Set(string name, string value)
		{
			string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
			string xmlFile = Path.Combine(dir, "phishreport.settings.xml");
			string localPath = new Uri(xmlFile).LocalPath;
			var doc = XElement.Load(localPath);

			XElement element = doc.Element("Settings").Element(name);
			element.Value = value;
			doc.Save(localPath);
		}

		public static Dictionary<string, object> Get()
		{
			Dictionary<string, object> data = new Dictionary<string, object>();
			string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
			string xmlFile = Path.Combine(dir, "phishreport.settings.xml");
			XDocument doc = XDocument.Load(xmlFile);

			foreach (XElement element in doc.Element("PhishReport").Element("Settings").Elements())
			{
				string name = element.Name.LocalName;
				string value = element.Value;
				data.Add(name, value);
			}
			return data;
		}
	}
}
