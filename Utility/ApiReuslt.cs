using System.Collections.Generic;
using System.Net;

namespace Utility
{
    public class ApiReuslt<T>
        where T : class
    {
        public ApiReuslt(string massage, HttpStatusCode httpStatusCode, List<string> erorr, T date)
        {
            Massage = massage;
            HttpStatusCode = httpStatusCode;
            Erorr = erorr;
            Date = date;
        }

        public string Massage { get; set; }
        public List<string> Erorr { get; set; } = new List<string>();
        public HttpStatusCode HttpStatusCode { get; set; }
        public T Date { get; set; }
    }
}
