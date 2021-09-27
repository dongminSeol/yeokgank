using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using yeokgank.ViewModel.Paging;
using yeokgank.ViewModel.Region;

namespace yeokgank.Repository.Region.Query
{
    public class RegionQuery : IRegionQuery
    {
        private readonly IConfiguration _configuration;

        public RegionQuery(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public RegionViewModel List(string ad_h_cd, string ad_m_cd ,string ad_s_cd, string ad_t_cd , int? page = 1, int? pagesize = 10)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
                {
                    var param = new DynamicParameters();

                    param.Add("@AD_H_CD", ad_h_cd);
                    param.Add("@AD_M_CD", ad_m_cd);
                    param.Add("@AD_S_CD", ad_s_cd);
                    param.Add("@AD_T_CD", ad_t_cd);
                    param.Add("@PageNumber", page);
                    param.Add("@PageSize", pagesize);
                    param.Add("@TotalCnt", DbType.Int32, direction: ParameterDirection.Output);

                    var region = con.Query<RegionModel>("SP_Read_RegionCode", param, commandType: CommandType.StoredProcedure).ToList();


                    return new RegionViewModel
                    {
                        Region = region,
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = (int)page,
                            ItemsPerPage = (int)pagesize,
                            TotalItems = param.Get<int>("TotalCnt")
                        }
                    };
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
