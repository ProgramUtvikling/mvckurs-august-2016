using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Helpers
{
	public static class HtmlHelpers
	{
		public static string PrettyJoin(this HtmlHelper html, IEnumerable<Person> people)
		{
			int count = 0;
			string res = null;
			foreach (var person in people.Reverse())
			{
				switch (count++)
				{
					case 0:
						res = person.Name;
						break;

					case 1:
						res = person.Name + " og " + res;
						break;

					default:
						res = person.Name + ", " + res;
						break;
				}
			}

			return res;
		}
	}
}