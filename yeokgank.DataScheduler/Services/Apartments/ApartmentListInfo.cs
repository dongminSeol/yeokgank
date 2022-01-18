using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using yeokgank.DataScheduler.Data;
using yeokgank.DataScheduler.Extensions;
using yeokgank.DataScheduler.Http;
using yeokgank.DataScheduler.Model;
using yeokgank.Entities.Apartment;
using yeokgank.Entities.Region;

namespace yeokgank.DataScheduler.Services.Apartments
{
    public class ApartmentListInfo : OpenData<ApartmentListData>
    {
        public ApartmentListInfo(Settings settings)
        {
            Settings = settings;
        }
        public override bool Add(ApartmentListData data)
        {
            try
            {
                using (var context = new ConsoleAppDbContext())
                {
                    foreach (var i in data.response.body.items.item)
                    {
                        Console.WriteLine($"{i.as1} {i.as2} {i.as3} {i.kaptName} {i.kaptCode}");
                        context.ApartmentList.Add(new ApartmentList
                        {
                            KaptCode = i.kaptCode,
                            KaptName = i.kaptName,
                            BjdCode = i.bjdCode,
                            RegDate = DateTime.Now.ToString("yyyyMMddHHmmss")
                        });
                        ResultCount++;
                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                //ErrorInfo.Add(data);
                Console.WriteLine(e.GetFullMessage());
                return false;
            }
        }

        public override bool Delete()
        {
            throw new NotImplementedException();
        }

        public override void ErrorLog()
        {
            throw new NotImplementedException();
        }

        public override bool Execute()
        {
            var sigunguCode = this.GetSigunguCode();

            try
            {
                foreach (var s in sigunguCode)
                {
                    var url = GetEndPoint(Settings.ServiceKey
                                          , (s.AD_H_CD + s.AD_M_CD)
                                          , Settings.PageNo
                                          , Settings.Rows);
                    var http = new HttpConnecter(url);
                    var sigunguAptData = http.Get<ApartmentListData>();

                    if (sigunguAptData != null)
                    {
                        if (sigunguAptData.response.body.items == null || sigunguAptData.response.body.totalCount == 0)
                        {
                            Console.WriteLine($"{s.AD_H_NM + s.AD_M_NM} 아파트 정보 없음.");
                        }
                        else
                        {
                            this.Add(sigunguAptData);
                        }
                    }
                    /// 공공데이터 API 문제로 0.01초 간격을 두고 호출
                    Thread.Sleep(10);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetFullMessage());
                throw;
            }

            return true;
        }

        public override void Read()
        {
            throw new NotImplementedException();
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 시군구 코드 
        /// </summary>
        private IEnumerable<RegionCode> GetSigunguCode()
        {
            try
            {
                using (var context = new ConsoleAppDbContext())
                {
                    var region = (from r in context.RegionCode
                                  where r.State == "Y"
                                  && r.AD_M_CD != "000"
                                  && r.AD_S_CD == "000"
                                  group r by new
                                  {
                                      r.AD_H_CD
                                     ,r.AD_M_CD
                                     ,r.AD_H_NM
                                     ,r.AD_M_NM
                                  } into g
                                  select new RegionCode()
                                  {
                                      AD_H_CD = g.Key.AD_H_CD
                                    ,AD_M_CD = g.Key.AD_M_CD
                                    ,AD_H_NM = g.Key.AD_H_NM
                                    ,AD_M_NM = g.Key.AD_M_NM
                                  }).ToList();
                    return region;
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }
        private string GetEndPoint(string servicekey, string sigungucode, int pageno = 1, int rows = 10)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}/1613000/AptListService1/getSigunguAptList?", HttpDestination.SigunguAptInfoEndPoint.GetDescription());
            sb.AppendFormat("ServiceKey={0}&", servicekey);
            sb.AppendFormat("sigunguCode={0}&", sigungucode);
            sb.AppendFormat("pageNo={0}&", pageno);
            sb.AppendFormat("numOfRows={0}&", rows);
            return sb.ToString();
        }
    }
}

