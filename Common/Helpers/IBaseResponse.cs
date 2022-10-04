namespace Phantom.API.Common.Helpers
{

    public interface IBaseResponse<T>
    {
        Task<BaseResponseVm<T>> SuccessMessage(string code, object data);
        Task<BaseResponseVm<T>> InternalServerError();
        Task<BaseResponseVm<T>> CustomErroMessage(string msg, string code);
        Task<BaseResponseVm<T>> Success(string msg);
    }

}
