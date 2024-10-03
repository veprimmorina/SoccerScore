using System.Net;
using System.Text;
using zdt_application.Application.Wrappers;

namespace zdt_application.Application.Services.Base
{
    public class BaseService
    {
        protected const string ApiKey = "DHABkUL14VHXnFtA";
        protected const int Timeout = 5000;
        protected const string BaseUrl = "http://api.isportsapi.com/sport/football";

        protected async Task<BaseResponse<string>> MakeHttpRequest(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ReadWriteTimeout = Timeout;
                request.ContentType = "text/html;charset=UTF-8";

                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (Stream myResponseStream = response.GetResponseStream())
                using (StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8))
                {
                    string retString = await myStreamReader.ReadToEndAsync();
                    return BaseResponse<string>.Success(retString);
                }
            }
            catch (Exception ex)
            {
                return BaseResponse<string>.BadRequest(ex.Message);
            }
        }
    }
}