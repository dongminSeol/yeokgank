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

        #region [2021-08-30] SP 작성 중
        //public List<RegionViewModel> List(string search = "", string orderBy = "", int? pageNumber = 1, int pageSize = 10)
        //{
        //    using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DatabaseConnection")))
        //    {
        //        var para = new DynamicParameters();
        //        para.Add("@orderBy", orderBy);
        //        para.Add("@PageNumber", pageNumber);
        //        para.Add("@PageSize", pageSize);
        //        para.Add("@Search", search);
        //        var data = con.Query<RegionViewModel>("Usp_RegionPagination", para, commandType: CommandType.StoredProcedure).ToList();
        //        return data;
        //    }
        //}
        #endregion

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
    }
}
