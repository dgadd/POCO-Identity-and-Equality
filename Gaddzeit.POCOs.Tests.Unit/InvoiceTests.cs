using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;
using Gaddzeit.POCOs;

namespace Gaddzeit.POCOs.Tests.Unit
{
	[TestFixture()]
	public class InvoiceTests
	{
		[Test()]
		public void Equality_Is_Maintained_By_POCO_Internally ()
		{
			var sut1 = new Invoice {  Id = 1234, InvoiceDate = DateTime.Today };
			var sut2 = new Invoice {  Id = 1234, InvoiceDate = DateTime.Today.AddDays(-1) };
			Assert.AreEqual(sut1, sut2, "Equality should be based on Id only.");
		}

		[Test()]
		public void LineItems_Is_Dictionary_Encapsulated_As_IEnumerable()
		{
			var sut = new Invoice { Id = 1 };
			Assert.IsInstanceOf(typeof(IEnumerable<KeyValuePair<int,LineItem>>), sut.LineItems());
		}

		[Test()]
		public void AddLineItem_Checks_Identity_and_Equality_Based_On_Id_Property() 
		{
			var lineItem1 = new LineItem { Id = 35, Description = "Shirt" };
			var lineItem2 = new LineItem { Id = 35, Description = "Shirt" };

			var sut = new Invoice { Id = 1 };
			Assert.AreEqual(0, sut.LineItems().Count());
			sut.AddLineItem(lineItem1);
			sut.AddLineItem(lineItem2);			
			Assert.AreEqual(1, sut.LineItems().Count(), "LineItems should only increment for unique Id");
		}

		[Test()]
		public void Junior_Dev_Accidentally_Changes_Identity_And_Equality_In_Second_Method() 
		{
			var lineItem1 = new LineItem { Id = 35, Description = "Shirt", InvoiceNumber=10001 };
			var lineItem2 = new LineItem { Id = 35, Description = "Shirt", InvoiceNumber=10002 };

			var sut = new Invoice { Id = 1 };
			Assert.AreEqual(0, sut.LineItems().Count());
			sut.AddLineItemAlternateCreatedByMaintenanceTeamAccidentallySixMonthsLater(lineItem1);
			sut.AddLineItemAlternateCreatedByMaintenanceTeamAccidentallySixMonthsLater(lineItem2);
			Assert.AreEqual(1, sut.LineItems().Count(), "LineItems should only increment for unique Id");
		}


	}
}

