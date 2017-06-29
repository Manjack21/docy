/*
 * Created by SharpDevelop.
 * User: Info
 * Date: 11.06.2017
 * Time: 18:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace docy.UnitTest
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	[TestFixture]
	public class functionsUnitTest
	{
		
		[Test]
		public void testfunction_string_nothing() {
			Assert.AreEqual("OK", "OK");
		}
	}
}