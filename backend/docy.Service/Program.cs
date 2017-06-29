/*
 * Created by SharpDevelop.
 * User: Info
 * Date: 24.06.2017
 * Time: 08:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace docy.Service
{
	class Program
	{
		public static void Main(string[] args)
		{						
			Console.WriteLine("Startup docy Service on " + DateTime.Now.ToString());
			
			DocumentRepository repo = new DocumentRepository();			
			repo.Add(new Document {Name = "Doc1", Createdate = new DateTime(2017, 2, 1)});
			
			HttpServerConfiguration config = new HttpServerConfiguration();
			config.Prefixes = new string[] {"http://*:8080/"};
			config.Endpoints = new IEndpoint[] {new DocumentListEndpoint(repo),
											    new DocumentAddEndpoint(repo),
											    new DocumentDetailEndpoint(repo),
											    new DocumentDeleteEndpoint(repo)};
			
			HttpServer server = new HttpServer(config);
			server.Start();
			
			Console.WriteLine("Press any key to stop the server . . . ");
			Console.ReadKey(true);
			server.Stop();
		}
		
		
	}
}