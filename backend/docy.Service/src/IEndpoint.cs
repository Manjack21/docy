/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Info
 * Datum: 25.06.2017
 * Zeit: 14:29
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Net;

namespace docy {
	public interface IEndpoint {
		bool IsMatch(HttpListenerRequest Request);
		string GenerateOutput(HttpListenerRequest Request, HttpListenerResponse Response);
		void WriteOutput(HttpListenerRequest Request, HttpListenerResponse Response);		
	}
}