/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Info
 * Datum: 25.06.2017
 * Zeit: 19:15
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */



using System;
using System.Net;

namespace docy {
	public class DocumentAddEndpoint : Endpoint {
		DocumentRepository _repo;
		
		public DocumentAddEndpoint(DocumentRepository repo) {
			_repo = repo;
		}
		
		public override string GenerateOutput(HttpListenerRequest Request, HttpListenerResponse Response) {		
			System.IO.StreamReader reader = new System.IO.StreamReader(Request.InputStream);
			
			Document daten = Newtonsoft.Json.JsonConvert.DeserializeObject<Document>(reader.ReadToEnd());
			
			_repo.Add(daten);
			
			return "Document added - " + _repo.Count;
		}
		
		public override bool IsMatch(HttpListenerRequest Request) {
			return System.Text.RegularExpressions.Regex.IsMatch(Request.Url.AbsolutePath, "/DOC$") && Request.HttpMethod == "POST";
		}
	}
}