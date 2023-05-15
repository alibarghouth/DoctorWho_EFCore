using System.Net;

namespace DoctorWho.Exceptions
{
    public class DoctorWhoException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
