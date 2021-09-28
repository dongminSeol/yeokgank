using System.ComponentModel.DataAnnotations;

namespace yeokgank.DataScheduler.HttpResponse
{
    public class Response<T>
    {
        public T ResultData { get; set; }
    }
}
