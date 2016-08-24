using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ImdbWeb.Helpers
{
	public static class HtmlHelpers
	{
		public static IHtmlString PrettyJoin(this HtmlHelper html, IEnumerable<Person> people)
		{
			Func<Person, string> createLink = p => html.ActionLink(p.Name, "Details", "Person", new { id = p.PersonId }, null).ToString();


			int count = 0;
			string res = null;
			foreach (var person in people.Reverse())
			{
				switch (count++)
				{
					case 0:
						res = createLink(person);
						break;

					case 1:
						res = createLink(person) + " og " + res;
						break;

					default:
						res = createLink(person) + ", " + res;
						break;
				}
			}

			return MvcHtmlString.Create(res);
		}
	}
}