/*
 * Erstellt mit SharpDevelop.
 * Benutzer: Info
 * Datum: 25.06.2017
 * Zeit: 15:09
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */

using System;
using System.Net;

namespace docy {
	public class ErrorEndpoint : Endpoint {
		readonly Exception _ex;
		
		public ErrorEndpoint() {
			_ex = new Exception("An error occured!");
		}
		public ErrorEndpoint(Exception ex) {
			_ex = ex;
		}
		
				
		public override bool IsMatch(HttpListenerRequest Request) {
			return true;
		}
		
		public override string GenerateOutput(HttpListenerRequest Request,HttpListenerResponse Response) {			
			return Newtonsoft.Json.JsonConvert.SerializeObject(new {Message = _ex.Message, Type = _ex.GetType().Name, Stacktrace = _ex.StackTrace});					
		}
	}
	
}