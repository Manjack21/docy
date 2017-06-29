/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Info
 * Datum: 25.06.2017
 * Zeit: 20:20
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Net;

namespace docy {
	public abstract class Endpoint : IEndpoint {
		public abstract bool IsMatch(HttpListenerRequest Request);		
		public abstract string GenerateOutput(HttpListenerRequest Request, HttpListenerResponse Response);
		
		public void WriteOutput(HttpListenerRequest Request, HttpListenerResponse Response) {
			using (var writer = new System.IO.StreamWriter(Response.OutputStream)) {
				writer.Write(GenerateOutput(Request, Response));
			}
		}
		
	}
}