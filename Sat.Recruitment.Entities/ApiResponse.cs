using System.Net;

namespace Sat.Recruitment.Entities
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }
}
