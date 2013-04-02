namespace PingdomMaintenanceWindowApp
{
    using System;

    using RestSharp;

    public class PingdomAuthenticator : IAuthenticator
    {
        private readonly string _username;
        private readonly string _password;

        public PingdomAuthenticator(string username, string password)
        {
          this._password = password;
          this._username = username;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (client.BaseUrl.IndexOf("https://", System.StringComparison.Ordinal) > 0)
            {
                var host = client.BaseUrl;
                host.Replace("https://", string.Format(""));
                client.BaseUrl = string.Format("");
            } else
            {
                client.BaseUrl = string.Format("");
            }
           
        }
    }
}
