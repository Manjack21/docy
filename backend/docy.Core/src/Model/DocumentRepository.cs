/*
 * Created by SharpDevelop.
 * User: Info
 * Date: 11.06.2017
 * Time: 19:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace docy {
	// TODO: Implement persist function and XML-Persistor
	// TODO: Override Add method so that every Document gets an unique Id
	public class DocumentRepository : System.Collections.Concurrent.ConcurrentBag<docy.Document> {
		public DocumentRepository()
		{}
		
		public DocumentRepository(IEnumerable<Document> Documents) : base(Documents)
		{}
		
		
		public IEnumerable<Document> ActiveDocuments()
		{
			return this.Where((item) => !item.IsDeleted);
		}
	}
}