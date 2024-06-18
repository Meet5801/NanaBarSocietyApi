namespace NanabarSamaj.API.ViewModels
{
    public class ResponseData
    {
        public bool success { get; set; } = false;
        public string message { get; set; } = "something went wrong, please try again later";
        public Object data { get; set; }
        public int code { get; set; } = 500;
    }
}
