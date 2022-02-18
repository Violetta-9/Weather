using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Contracts.Exseption
{
    public class NotFoundCityExseption:Exception
    {
        public NotFoundCityExseption(string cityName):base($"{cityName} was not found")
        {

        }
    }
}
