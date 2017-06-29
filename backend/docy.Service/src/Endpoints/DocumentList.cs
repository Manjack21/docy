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
	public class DocumentListEndpoint : Endpoint {
		DocumentRepository _repo;
		
		public DocumentListEndpoint(DocumentRepository repo) {
			_repo = repo;
		}
		
		public override string GenerateOutput(HttpListenerRequest Request, HttpListenerResponse Response) {
			return Newtonsoft.Json.JsonConvert.SerializeObject(_repo.ActiveDocuments(), Newtonsoft.Json.Formatting.Indented);
		}
		
		public override bool IsMatch(HttpListenerRequest Request) {
			return System.Text.RegularExpressions.Regex.IsMatch(Request.Url.AbsolutePath, "/DOC$") && Request.HttpMethod == "GET";
		}
	}
}