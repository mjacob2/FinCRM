using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCRM.DataAccess.CQRS.Queries
{
	internal class QueryPaginationParameters
	{
		private const int MaxSize = 100;
		private int DefaultSize = 20;

		public int Page { get; set; }
		public int Size
		{
			get
			{
				return DefaultSize;
			}
			set
			{
				if (value < 0)
				{
					value = 0;
				}
				DefaultSize = Math.Min(MaxSize, value);
			}
		}
	}
}
