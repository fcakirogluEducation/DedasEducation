namespace DedasApp.API.Models
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
    }
}