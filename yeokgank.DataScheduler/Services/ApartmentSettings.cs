using System;
using System.Collections.Generic;
using System.Text;

namespace yeokgank.DataScheduler.Services
{
    public class ApartmentSettings
    {
        /// <summary>
        /// 인증키 (URL Encode)
        /// </summary>
        public string ServiceKey { get; set; }
        /// <summary>
        /// 페이지번호
        /// </summary>
        public int PageNo { get; set; }
        /// <summary>
        /// 한 페이지 결과 수
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// 지역코드
        /// </summary>
        public string LAWD_CD { get; set; }
        /// <summary>
        /// 계약월 (시작)
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// 계약월 (종료)
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// 계약 월 (수집 조회 기간)
        /// </summary>
        public int DiffMonth => 12 * (DateTime.ParseExact(StartDate, "yyyyMM", null).Year - DateTime.ParseExact(EndDate, "yyyyMM", null).Year) + 
                                     (DateTime.ParseExact(StartDate, "yyyyMM", null).Month - DateTime.ParseExact(EndDate, "yyyyMM", null).Month);
    }
}
