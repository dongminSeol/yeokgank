using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace yeokgank.DataScheduler.Http
{

    public class HttpConnecter 
    {

        private const string PARAMETER_TYPE = "application/json";

        private readonly RestClient restClient;

        public HttpConnecter(string requestUri)
        {
            restClient = new RestClient(requestUri);
        }

        private void SetHeader(ref RestRequest request, string headerKey, string headerValue)
        {
            request.AddHeader(headerKey, headerValue);
        }

        public string Get()
        {
            try
            {
                RestRequest request = new RestRequest(Method.GET);
                var response = restClient.Execute(request);
                var code = response.StatusCode;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpException("Http request error.")
                    {
                        HttpCode = response.StatusCode
                    };
                }
                else
                {
                    return response.Content;
                }

            }
            catch (HttpException e)
            {
                if (e.HttpCode == HttpStatusCode.RequestTimeout)
                {
                }

                //Log("HttpStatusCode :: " + e.HttpCode + " Message :: " + e.Message.ToString());
                return null;
            }
        }

        public string Get(string endPoint)
        {
            try
            {
                RestRequest request = new RestRequest(endPoint, Method.GET);
                //SetHeader(ref request, restClient.BuildUri(request).AbsolutePath);
                var response = restClient.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK) throw new HttpException("Http request error.") { HttpCode = response.StatusCode };
                return response.Content;
            }
            catch (HttpException e)
            {
                if (e.HttpCode == HttpStatusCode.RequestTimeout)
                {
                }
                //Log(" HttpCode :: " + e.HttpCode + " :: " + e.ToString(), "FailLog", logPath);
                return null;
            }
        }

        public string Post(string endPoint, object requestParameters)
        {
            try
            {

                var parameterSerialized = JsonConvert.SerializeObject(requestParameters);

                RestRequest request = new RestRequest(endPoint, Method.POST);

                //SetHeader(ref request, parameterSerialized);

                request.AddParameter(PARAMETER_TYPE, parameterSerialized, ParameterType.RequestBody);
                var response = restClient.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK) throw new HttpException("Http request error.") { HttpCode = response.StatusCode };
                return response.Content;
            }
            catch (HttpException e)
            {
                if (e.HttpCode == HttpStatusCode.RequestTimeout)
                {
                }

                //Log(" HttpCode :: " + e.HttpCode + " :: " + e.ToString(), "FailLog", logPath);

                return null;
            }
        }

        public string Put(string endPoint, object requestParameters)
        {
            try
            {
                var parameterSerialized = JsonConvert.SerializeObject(requestParameters);
                RestRequest request = new RestRequest(endPoint, Method.PUT);
                var dataForHash = restClient.BuildUri(request).AbsolutePath + parameterSerialized;
                //SetHeader(ref request, dataForHash);
                request.AddParameter(PARAMETER_TYPE, parameterSerialized, ParameterType.RequestBody);
                var response = restClient.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK) throw new HttpException("Http request error.") { HttpCode = response.StatusCode };
                return response.Content;
            }
            catch (HttpException e)
            {
                if (e.HttpCode == HttpStatusCode.RequestTimeout)
                {

                }
                return null;
            }
        }

        public string Delete(string endPoint)
        {
            try
            {
                RestRequest request = new RestRequest(endPoint, Method.DELETE);
                //SetHeader(ref request, restClient.BuildUri(request).AbsolutePath);
                var response = restClient.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK) throw new HttpException("Http request error.") { HttpCode = response.StatusCode };
                return response.Content;
            }
            catch (HttpException e)
            {
                if (e.HttpCode == HttpStatusCode.RequestTimeout)
                {
                }
                return null;
            }
        }

    }

}
