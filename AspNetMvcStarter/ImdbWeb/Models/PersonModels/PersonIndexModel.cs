using System.Linq;
using MovieDAL;
using System.Collections.Generic;

namespace ImdbWeb.Model.PersonModels
{
	public class PersonIndexModel
	{
		public IEnumerable<Person> Movies { get; internal set; }
		public string Title { get; internal set; }
	}
}