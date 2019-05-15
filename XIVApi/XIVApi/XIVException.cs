using System;
using System.Net;

namespace XIVApi.Http
{
    [Serializable]
    public class XIVException : Exception
    {
        public readonly HttpStatusCode HttpStatusCode;

        public XIVException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}