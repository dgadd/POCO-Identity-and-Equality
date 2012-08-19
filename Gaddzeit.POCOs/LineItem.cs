using System;
using Gaddzeit.POCOs;

namespace Gaddzeit.POCOs
{
	public class LineItem
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public int InvoiceNumber { get; set; }

		public Invoice Parent { get; set; }
	}
}

