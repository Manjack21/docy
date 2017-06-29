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
using System.Linq;

namespace docy {
	public class DocumentDetailEndpoint : Endpoint {
		DocumentRepository _repo;
		
		public DocumentDetailEndpoint(DocumentRepository repo) {
			_repo = repo;
		}
		
		public override string GenerateOutput(HttpListenerRequest Request, HttpListenerResponse Response) {
			Int32 Id = Int32.Parse(Request.Url.AbsolutePath.Split('/').Last());
			
			Document doc = _repo.ActiveDocuments().FirstOrDefault((item) => item.Id == Id);
			if (doc == null) { doc = new Document(); }
			
			return Newtonsoft.Json.JsonConvert.SerializeObject(doc, Newtonsoft.Json.Formatting.Indented);
		}
		
		public override bool IsMatch(HttpListenerRequest Request) {
			return System.Text.RegularExpressions.Regex.IsMatch(Request.Url.AbsolutePath, "/DOC/\\d+$") && Request.HttpMethod == "GET";
		}
	}
}