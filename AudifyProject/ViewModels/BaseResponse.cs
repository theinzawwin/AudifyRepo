using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class BaseResponse<T>
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public BaseResponse() { }
        public BaseResponse(T data)
        {
            Result = true;
            ErrorMessage = string.Empty;
            StatusCode = 200;
            Data = data;

        }
    }
}
