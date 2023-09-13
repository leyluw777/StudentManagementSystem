using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cities.Queries
{
	public class GetCitiesByCountryRequest : IRequest<GetCitiesByCountryResponse>
	{
		public GetCitiesByCountryRequest(string name)
		{
			Name  = name;
		}

		public string Name { get; set; }
		
	}
}
