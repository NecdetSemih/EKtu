namespace Web.Models
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
    }
}
