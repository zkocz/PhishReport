using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace GetContacts
{
	public class Settings
	{
		public Settings()
		{

		}

		/// <summary>
		/// Saves settings to XML file
		/// </summary>
		/// <param name="name">Setting name</param>
		/// <param name="value">Setting value</param>
		public static void Set(string name, string value)
		{
			string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
			string xmlFile = Path.Combine(dir, "GetContacts.settings.xml");
			string localPath = new Uri(xmlFile).LocalPath;
			var doc = XElement.Load(localPath);

			XElement element = doc.Element("Settings").Element(name);
			element.Value = value;
			doc.Save(localPath);
		}

		/// <summary>
		/// Gets all settings
		/// </summary>
		/// <returns>Dictionary of settings</returns>
		public static Dictionary<string, object> Get()
		{
			Dictionary<string, object> data = new Dictionary<string, object>();
			string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
			string xmlFile = Path.Combine(dir, "GetContacts.settings.xml");
			XDocument doc = XDocument.Load(xmlFile);

			foreach (XElement element in doc.Element("GetContacts").Element("Settings").Elements())
			{
				string name = element.Name.LocalName;
				string value = element.Value;
				data.Add(name, value);
			}
			return data;
		}
	}
}
