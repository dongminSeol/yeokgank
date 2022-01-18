using System.ComponentModel;

namespace yeokgank.DataScheduler.Http
{
    public enum HttpDestination
    {
        [Description("http://openapi.molit.go.kr")] TradeEndPoint,
        [Description("http://apis.data.go.kr")] SigunguAptInfoEndPoint,
    }
}
