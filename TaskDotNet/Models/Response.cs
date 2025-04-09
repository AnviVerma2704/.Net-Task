namespace TaskDotNet.Models
{
    public class Response<Data>
    {
        public bool isSuccess { get; set; }
        public string? message { get; set; }
        public Data? data { get; set; }

        public Response(bool success,string Message,Data dataRecived)
        {
            isSuccess = success;
            message = Message;
            data = dataRecived;
        }
    }
}
