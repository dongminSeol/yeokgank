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
        public ApartmentTradeViewModel TradeMonth(string ad_h_cd, string ad_m_cd, string startdate, string enddate)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                try
                {
                    var param = new DynamicParameters();
                    param.Add("@AD_H_CD", ad_h_cd);
                    param.Add("@AD_M_CD", ad_m_cd);
                    param.Add("@STARTDATE", startdate);
                    param.Add("@ENDDATE", enddate);
                    var trade = con.Query<ApartmentTradeModel>("SP_ReadTradeMonth", param, commandType: CommandType.StoredProcedure).ToList();

                    return new ApartmentTradeViewModel
                    {
                        ApartmentTrade = trade
                    };

                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }


    }
}
