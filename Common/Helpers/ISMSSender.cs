namespace Phantom.API.Common.Helpers
{
    public interface ISMSSender
    {
        void DoSendMessageToOneValidNumber(string number, string text);
    }
}
