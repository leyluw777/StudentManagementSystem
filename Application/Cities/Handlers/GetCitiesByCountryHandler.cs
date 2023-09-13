using Application.Cities.Queries;
using Application.Common.Interfaces;
using Application.Courses.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cities.Handlers
{
	public class GetCitiesByCountryHandler : IRequestHandler<GetCitiesByCountryRequest, GetCitiesByCountryResponse>
	{

		private readonly IApplicationDbContext _appDbContext;
		private readonly IMapper _mapper;

		public GetCitiesByCountryHandler(IApplicationDbContext appDbContext, IMapper mapper)
		{
			_appDbContext = appDbContext;
			_mapper = mapper;
		}

		public async  Task<GetCitiesByCountryResponse> Handle(GetCitiesByCountryRequest request, CancellationToken cancellationToken)
		{
			List<SMSDomain.Entities.City> cities = new List<SMSDomain.Entities.City>();
			var groupCities = await _appDbContext.Cities.Where(x => x.CountryId == _appDbContext.Countries.FirstOrDefault(y => y.Name == request.Name).Id).ToListAsync();
			foreach (var city in groupCities)
			{
			
				cities.Add(city);
			}

			return new GetCitiesByCountryResponse()
			{
				Cities = cities,
			};

			throw new NotImplementedException();
		}
	}
}
