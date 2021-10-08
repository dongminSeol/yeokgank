using yeokgank.ViewModel.Maps;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using yeokgank.ViewModel.Apartment;
using yeokgank.ViewModel.Paging;
using System;

namespace yeokgank.Repository.Apartment.Query
{
    public class ApartmentQuery : IApartmentQuery
    {
        private readonly IConfiguration _configuration;

        public ApartmentQuery(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ApartmentTradeViewModel Trade(string search = "", int? page = 1, int pagesize = 10)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                try
                {
                    var param = new DynamicParameters();
                    param.Add("@PageNumber", page);
                    param.Add("@PageSize", pagesize);
                    param.Add("@Search", search);
                    var trade = con.Query<ApartmentTradeModel>("", param, commandType: CommandType.StoredProcedure).ToList();

                    return new ApartmentTradeViewModel
                    {
                        ApartmentTrade = trade,
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = (int)page,
                            ItemsPerPage = (int)pagesize,
                            TotalItems = param.Get<int>("TotalCnt")
                        }
                    };

                }
                catch(Exception e)
                {
                    throw;
                }


            }
        }


    }
}
