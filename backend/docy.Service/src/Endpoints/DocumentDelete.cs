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
	public class DocumentDeleteEndpoint : Endpoint {
		DocumentRepository _repo;
		
		public DocumentDeleteEndpoint(DocumentRepository repo) {
			_repo = repo;
		}
		
		public override string GenerateOutput(HttpListenerRequest Request, HttpListenerResponse Response) {	
			string Id = Request.Url.AbsolutePath.Split('/').Last();
			
			Document doc = _repo.FirstOrDefault((item) => item.Id == Convert.ToInt32(Id));
			if (doc == null) { return "Document not found. No document removed."; };
			
			doc.IsDeleted = true;
			
			return "Document removed - " + _repo.Count;
		}
		
		public override bool IsMatch(HttpListenerRequest Request) {
			return System.Text.RegularExpressions.Regex.IsMatch(Request.Url.AbsolutePath, "/DOC/\\d+$") && Request.HttpMethod == "DELETE";
		}
	}
}