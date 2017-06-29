/*
 * Created by SharpDevelop.
 * User: Info
 * Date: 24.06.2017
 * Time: 08:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml.Serialization;

namespace docy.Service
{
	/// <summary>
	/// Description of HttpServerConfiguration.
	/// </summary>
	public class HttpServerConfiguration
	{
		public HttpServerConfiguration()
		{
			this.Prefixes = new string[] {""};
			this.MaxNumberOfThreads = 10;
			this.Endpoints = new IEndpoint[] {};
		}
		
		public string[] Prefixes {get; set;}
		public Int32 MaxNumberOfThreads {get; set;}
		public IEndpoint[] Endpoints {get; set;}
		
		/// <summary>
		/// Static method for loading configuration data from a xml-file
		/// </summary>
		/// <param name="path">path to the xml-file</param>
		/// <returns></returns>
		public static HttpServerConfiguration LoadFromFile(string path) 
		{
			XmlSerializer Serializer = new XmlSerializer(typeof(HttpServerConfiguration));
			
			string XmlMarkup = System.IO.File.ReadAllText(path);
			return (HttpServerConfiguration)Serializer.Deserialize(new System.IO.StringReader(XmlMarkup));
		}
		
		/// <summary>
		/// Method for serializing this configurationobject to a xml-file
		/// </summary>
		/// <param name="path">path to the xml-file</param>
		/// <returns></returns>
		public void SaveToFile(string path) 
		{
			XmlSerializer Serializer = new XmlSerializer(typeof(HttpServerConfiguration));
			
			Serializer.Serialize(new System.IO.StreamWriter(path, false, System.Text.Encoding.UTF8), this);			
		}
		
		
	}
}
