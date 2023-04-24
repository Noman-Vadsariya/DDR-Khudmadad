using System.Globalization;

namespace Khudmadad_Backend.Models
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
