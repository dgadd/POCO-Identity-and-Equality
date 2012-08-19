using System;
using System.Collections.Generic;

namespace Gaddzeit.POCOs
{
	public class Invoice
	{
		public int Id { get; set; }
		public DateTime InvoiceDate { get; set; }
		private IDictionary<int, LineItem> _lineItems;

		public Invoice() 
		{
			_lineItems = new Dictionary<int, LineItem>();
		}

		public override bool Equals (object obj)
		{
			var other = (Invoice)obj;
			if (other == null) return false;
			return this.Id.Equals(other.Id);
		}

		public override int GetHashCode ()
		{
			return this.Id.GetHashCode();
		}

		public IEnumerable<KeyValuePair<int, LineItem>> LineItems()
		{
			return _lineItems;
		}

		public void AddLineItem(LineItem lineItem)
		{
			lineItem.Parent = this;
			LineItem nullChecker = null;
			_lineItems.TryGetValue(lineItem.Id, out nullChecker);
			if(nullChecker == null)
				_lineItems.Add(lineItem.Id, lineItem);
		}

		public void AddLineItemAlternateCreatedByMaintenanceTeamAccidentallySixMonthsLater(LineItem lineItem)
		{
			lineItem.Parent = this;
			LineItem nullChecker = null;
			_lineItems.TryGetValue(lineItem.InvoiceNumber, out nullChecker);
			if(nullChecker == null)
				_lineItems.Add(lineItem.InvoiceNumber, lineItem);
		}
	}


}

