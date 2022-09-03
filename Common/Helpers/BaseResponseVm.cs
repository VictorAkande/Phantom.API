namespace Phantom.API.Common.Helpers
{
    public class BaseResponseVm<T>
    {
        public string code { get; set; }
        public bool Successful { get; set; }
        public string Message { get; set; }

        public T data { get; set; } = default(T);


    }
}
