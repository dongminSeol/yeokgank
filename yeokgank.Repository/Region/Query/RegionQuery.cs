using yeokgank.ViewModel.Maps;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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

        public List<RegionViewModel> List(string search = "", int? pageNumber = 1, int pageSize = 10)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                var param = new DynamicParameters();

                param.Add("@PageNumber", pageNumber);
                param.Add("@PageSize", pageSize);
                param.Add("@TotalCnt", DbType.Int32, direction: ParameterDirection.Output);

                var data = con.Query<RegionViewModel>("SP_Read_RegionCode", param, commandType: CommandType.StoredProcedure).ToList();

                return data;
            }
        }

        #region [2021-08-30] 수정 중
        public List<RegionViewModel> List(string search = "", string orderBy = "", int? pageNumber = 1, int pageSize = 10)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
            {
                var data = con.Query<RegionViewModel>(@"SELECT  AD_H_NM								    AS Address
	                                                           ,Latitude                                AS Lat
	                                                           ,Longitude                               AS Lng
	                                                           ,(AD_H_CD + AD_M_CD + AD_S_CD + AD_T_CD) AS RegionCode
                                                         FROM  T_RegionCode 
                                                         Where [State]='Y' 
                                                         And   [AD_M_CD] = '000' Or (AD_H_CD='36' And AD_M_CD='110' And AD_S_CD='000') ").ToList();
                return data;
            }
        }
        #endregion
    }
}
