using System.Text.Json.Serialization;

namespace EKtu.Application.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}
