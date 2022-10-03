namespace Phantom.API.Common.Helpers
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public Task<BaseResponseVm<T>> CustomErroMessage(string msg, string code)
        {
            try
            {
                var res = new BaseResponseVm<T>()
                {
                    code = code,
                    Successful = false,
                    Message = msg,


                };

                return Task.FromResult(res);
            }
            catch (System.Exception)
            {

                return Task.FromResult(new BaseResponseVm<T>());
            }
        }



        public Task<BaseResponseVm<T>> InternalServerError()
        {

            try
            {
                var res = new BaseResponseVm<T>()
                {
                    code = "500",
                    Successful = false,


                };

                return Task.FromResult(res);
            }
            catch (System.Exception)
            {

                return Task.FromResult(new BaseResponseVm<T>());
            }
        }

        public Task<BaseResponseVm<T>> SuccessMessage(string? code, object data)
        {
            try
            {
                var res = new BaseResponseVm<T>()
                {
                    code = code ?? "200",
                    Message = "Success",
                    Successful = true,
                    data = (T)data

                };

                return Task.FromResult(res);

            }
            catch (System.Exception)
            {
                //loging
                return Task.FromResult(new BaseResponseVm<T>());

            }
        }
    }
}
