using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cities.Queries
{
	public  class GetCitiesByCountryResponse
	{
		public List<City> Cities { get; set; }
	}
}
