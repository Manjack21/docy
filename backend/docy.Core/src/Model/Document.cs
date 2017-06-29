/*
 * Created by SharpDevelop.
 * User: Info
 * Date: 11.06.2017
 * Time: 19:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
namespace docy {
	public class Document {
		public Document(){
			this.Id = 0;
			this.Createdate = System.DateTime.MinValue;
			this.From = string.Empty;
			this.IsDeleted = false;
			this.Name = string.Empty;
			this.Path = string.Empty;
			this.Tags = new string[] {};
			this.To = string.Empty;
		}
		
		public Int32 Id { get; set; }
		public string Name { get; set; }
		public DateTime Createdate { get; set; }
		public string From { get; set; }
		public bool IsDeleted { get; set; }
		public string To { get; set; }
		public string Path { get; set; }
		public string[] Tags { get; set; }
	}
}