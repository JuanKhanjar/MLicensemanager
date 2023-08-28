namespace MLicensemanager.BlazorUI.HttpServices
{
    public interface IWebApiExecuter
    {
        Task<T?> InvokeGet<T>(string relativUrl);
        Task<string> InvokeUpdate(string relativeUrl, string data);
    }
}