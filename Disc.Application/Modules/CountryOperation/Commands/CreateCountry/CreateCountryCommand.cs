﻿using MediatR;
using Disc.Domain.Entities;

namespace Disc.Application.CountryOperations.Commands.CreateCountry
{
    public class CreateCountryCommand : IRequest<Country>
    {
        public Country Country { get; set; }

        public CreateCountryCommand(Country country)
        {
            Country = country;
        }
    }
}
