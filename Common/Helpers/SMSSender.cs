using AfricasTalkingCS;
using Microsoft.Extensions.Logging;
using NLog;

namespace Phantom.API.Common.Helpers
{
    public class SMSSender:ISMSSender
    {
        private static string apikey;
        private static string username;
        private static Logger nLogger = LogManager.GetCurrentClassLogger();
        public SMSSender(IConfiguration configuration)
        {
            _configuration = configuration;
            apikey = _configuration.GetSection("Apikey").Value;
            username = _configuration.GetSection("Username").Value;
        }

        AfricasTalkingGateway gateway = new AfricasTalkingGateway(username, apikey);
        private readonly IConfiguration _configuration;

        /// <summary>
        /// this method sends Messages
        /// </summary>
        /// <param name="number"> must be in international format e.g +2347045678909</param>
        /// <param name="text"> must not be more than 50 characters</param>
        public void DoSendMessageToOneValidNumber(string number, string text)
        {

            try
            {
                dynamic res = gateway.SendMessage(number, text);
                //Console.WriteLine(res);

            }
            catch (AfricasTalkingGatewayException exception)
            {
                //Console.WriteLine(exception);
            }
        }
    }
}
