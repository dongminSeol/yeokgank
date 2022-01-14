using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using yeokgank.ViewModel.Maps;

namespace yeokgank.Repository.Maps.Query
{
    public interface IMapsQueries
    {
        List<MapsViewModel> List(string search ="");

    }
}
