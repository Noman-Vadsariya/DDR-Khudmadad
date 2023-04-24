using System.Globalization;

namespace DDR_Khudmadad.DTO
{
    public class ApiResponse
    {
        public string Code;
        
        public string Message;

        public object? ResponseData { get; set; }
    }

    public enum ResponseType
    {
        Success,
        NotFound,
        Failure
    } 
}
