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
    public class ApartmentQueries : IApartmentQueries
    {
        private readonly IConfiguration _configuration;

        public ApartmentQueries(IConfiguration configuration)
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
                    param.Add("@AD_H_CD", ad_h_cd ?? "11" );
                    param.Add("@AD_M_CD", ad_m_cd ?? "000");
                    param.Add("@STARTDATE", startdate ?? DateTime.Now.AddDays(-7).ToString("yyyyMMdd"));
                    param.Add("@ENDDATE", enddate ?? DateTime.Now.AddDays(-1).ToString("yyyyMMdd"));
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
