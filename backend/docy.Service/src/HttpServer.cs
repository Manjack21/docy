/*
 * Created by SharpDevelop.
 * User: Info
 * Date: 24.06.2017
 * Time: 08:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace docy.Service
{
	/// <summary>
	/// Description of HttpServer.
	/// </summary>
	public class HttpServer
	{
		private readonly HttpListener _HttpListener;
		private readonly HttpServerConfiguration _config;
		private List<IAsyncResult> _contexts;
		private System.Threading.Tasks.Task _contextStarter;
			
		public HttpServer(HttpServerConfiguration config)
		{
			this.isStopRequested = false;
			_config = config;
			_contexts = new List<IAsyncResult>(_config.MaxNumberOfThreads);
			_HttpListener = new System.Net.HttpListener();
				
			foreach (string prefix in config.Prefixes) {
				_HttpListener.Prefixes.Add( prefix);				
			}		
			
		}
		
		public bool isStopRequested { get; set; }
		
		public void Start() {
			
			if (!_HttpListener.IsListening) {
				_HttpListener.Start();	
			}
			
			_contextStarter = System.Threading.Tasks.Task.Run( () => {
																while (!this.isStopRequested) {
																	_contexts.RemoveAll((item) => item.IsCompleted);
																	
																	if (_contexts.Count < _config.MaxNumberOfThreads) {
																		Console.WriteLine(string.Format("currently {0} of {1} threads runnning. Let's start another one.", 
																		                                _contexts.Count, _config.MaxNumberOfThreads));
																		_contexts.Add( _HttpListener.BeginGetContext(new AsyncCallback(this.ListenerCallback), _HttpListener));
																	}
																}
			                                                  });
		}
		
		public void Stop() {
			this.isStopRequested = true;
			_contextStarter.Wait();
		}
		
		private void ListenerCallback(IAsyncResult result) {
			HttpListener listener = (HttpListener) result.AsyncState;
		    // Call EndGetContext to complete the asynchronous operation.
		    HttpListenerContext context = listener.EndGetContext(result);
		    HttpListenerRequest request = context.Request;
		    // Obtain a response object.
		    HttpListenerResponse response = context.Response;
		    
		    IEndpoint ep = _config.Endpoints.FirstOrDefault((item) => item.IsMatch(request));
		    if (ep == null) { ep = new ErrorEndpoint(new System.Net.WebException("Der Endpunkt konnte nicht gefunden werden")); }
		    
		    // Construct a response
		    ep.WriteOutput(request, response);
		}
		
		
	}
}
