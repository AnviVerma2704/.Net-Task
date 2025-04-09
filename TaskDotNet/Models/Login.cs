namespace TaskDotNet.Models
{
    public class Login<Token>
    {
        public bool isSuccess { get; set; }
        public string? message { get; set; }
        public Token? Data { get; set; }

        public Login(bool success, string Message, Token dataRecived)
        {
            isSuccess = success;
            message = Message;
            Data = dataRecived;
        }
    }
}
