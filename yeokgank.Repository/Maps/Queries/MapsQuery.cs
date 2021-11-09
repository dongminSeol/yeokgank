using yeokgank.ViewModel.Maps;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace yeokgank.Repository.Maps.Query
{
    public class MapsQuery : IMapsQuery
    {
        private readonly IConfiguration _configuration;

        public MapsQuery(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public List<MapsViewModel> List(string search ="")
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                var para = new DynamicParameters();
                para.Add("@", search);
                var data = con.Query<MapsViewModel>("", para, commandType: CommandType.StoredProcedure).ToList();

                return data;
            }
        }



    }
}
