using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

namespace yeokgank.DataScheduler.Services
{
    public class Apartment
    {
        public Apartment() 
        {
            Settings = new ApartmentSettings();
        }

        public ApartmentSettings Settings { get; set; }

        public void GetTrade()
        {
            try
            {
                var regcode = GetRegionalCode();

                int diffMonth = Settings.DiffMonth;
                int rows = Settings.Rows;
                int pageno = Settings.PageNo;
                string servicekey = Settings.ServiceKey;


                for (int month = diffMonth; month < 1; month++)
                {
                    foreach (var r in regcode)
                    {
                        var url = EndPoint((r.AD_H_CD + r.AD_M_CD), servicekey, month, pageno, rows);
                        var tradeData = Request<TradeData>(url);

                        if (tradeData != null)
                        {
                            if (tradeData.response.body.totalCount == 0 || tradeData.response.body.items == null)
                            {
                                Console.WriteLine($"{r.AD_H_NM + r.AD_M_NM} {DateTime.Now.AddMonths(month).ToString("yyyy-MM")} 거래 정보 없음.");
                            }
                            else
                            {
                                AddTradeData(tradeData, (r.AD_H_NM + r.AD_M_NM));
                            }
                        }

                    }
                    /// 공공데이터 API 문제로 0.01초 간격을 두고 호출
                    Thread.Sleep(10);
                }
            }
            catch(Exception e)
            {
                
                Console.WriteLine(e.Message);
                throw;
            }
         
        }
        private bool AddTradeData(TradeData tradeData,string regionalName)
        {
            try
            {
                using (var context = new ConsoleAppDbContext())
                {
                    foreach (var i in tradeData.response.body.items.item)
                    {
                        Console.WriteLine($"{regionalName} {i.월.Trim()}월{i.일.Trim()}일 {i.층.Trim()}층  {i.아파트.Trim()} {i.거래금액.Trim()} 전용{i.전용면적}");
                        context.ApartmentTrade.Add(new ApartmentTrade
                        {
                            TradeCode = (i.년 ?? "").Trim() + (i.월 ?? "").Trim() + (i.일 ?? "").Trim() + (i.층 ?? "").Trim()+"-"+(i.일련번호 ?? "00000-0000").Trim(),
                            ApartmentName = (i.아파트 ?? "").Trim(),
                            DealAmount = (i.거래금액 ?? "").Trim().Replace(",", ""),
                            BuildYear = (i.건축년도 ?? "").Trim(),
                            DealYear = (i.년 ?? "").Trim(),
                            RoadName = (i.도로명 ?? "").Trim(),
                            RoadName_Bonbun = (i.도로명건물본번호코드 ?? "").Trim(),
                            RoadName_Bubun = (i.도로명건물부번호코드 ?? "").Trim(),
                            RoadName_SigunguCode = (i.도로명시군구코드 ?? "").Trim(),
                            RoadName_Seq = (i.도로명일련번호코드 ?? "").Trim(),
                            RoadName_BasementCode = (i.도로명지상지하코드 ?? "0").Trim(),
                            RoadName_Code = (i.도로명코드 ?? "").Trim(),
                            Dong = (i.법정동 ?? "").Trim(),
                            Bonbun = (i.법정동본번코드 ?? "").Trim(),
                            Bubun = (i.법정동부번코드 ?? "").Trim(),
                            SigunguCode = (i.법정동시군구코드 ?? "").Trim(),
                            EubmyundongCode = (i.법정동읍면동코드 ?? "").Trim(),
                            LandCode = (i.법정동지번코드 ?? "").Trim(),
                            DealMonth = (i.월 ?? "").Trim(),
                            DealDay = (i.일 ?? "").Trim(),
                            ManageCode = (i.일련번호 ?? "00000-0000").Trim(),
                            AreaforExclusiveUse = (i.전용면적 ?? "").Trim(),
                            Jibun = (i.지번 ?? "").Trim(),
                            RegionalCode = (i.지역코드 ?? "").Trim(),
                            Floor = (i.층 ?? "").Trim(),
                            CancelDeal_Type = (i.해제여부 ?? "").Trim(),
                            CancelDeal_Day = (i.해제사유발생일 ?? "").Trim(),
                            State = "N",
                            RegDate = DateTime.Now.ToString("yyyyMMddHHmmss")
                        });
                    }
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetFullMessage());
                return false;
            }
     
        }

        private List<RegionCode> GetRegionalCode(int code = 11)
        {
            try
            {
                using (var context = new ConsoleAppDbContext())
                {
                    var region = (from  r in context.RegionCode
                                  where r.State == "Y" 
                                  &&    r.AD_H_CD == code.ToString() 
                                  &&    r.AD_M_CD != "000"
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
        private T Request<T>(string url)
        {
            try
            {
                var http = new HttpConnecter(url);
                var content = http.Get<T>();


                if (content == null)
                {
                    throw new Exception("Process Error. [GetTrade]");

                }

                return content;


            }
            catch (Exception e)
            {
                Console.WriteLine($"Process Error. {e.Message} [GetTrade]");
                return default(T);
            }

        }
        private string EndPoint(string regionalcode, string servicekey, int months = 0, int pageno = 1, int rows = 10)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTradeDev?", HttpDestination.TradeEndPoint.GetDescription());
            sb.AppendFormat("ServiceKey={0}&", servicekey);
            sb.AppendFormat("pageNo={0}&", pageno);
            sb.AppendFormat("numOfRows={0}&", rows);
            sb.AppendFormat("LAWD_CD={0}&", regionalcode);
            sb.AppendFormat("DEAL_YMD={0}", DateTime.Now.AddMonths(months).ToString("yyyyMM"));

            return sb.ToString();
        }



    }
}
