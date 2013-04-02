namespace PingdomMaintenanceWindowApp
{
    using System;
    using System.Configuration;
    using System.Text;

    using RestSharp;

    public class PingdomMaintenanceWindow
    {
        private string AppKey
        {
            get
            {
                return ConfigurationManager.AppSettings["app-key"];
            }
        }

        private string Username
        {
            get
            {
                return ConfigurationManager.AppSettings["authorization.username"];
            }
        }

        private string Password
        {
            get
            {
                return ConfigurationManager.AppSettings["authorization.password"];
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
        }

        private const string Host = "https://api.pingdom.com:443";

        private const string Resource = "/api/2.0/checks";

        private readonly RestClient client;

        private readonly RestRequest request;

        private string message;

        public PingdomMaintenanceWindow()
        {
            client = new RestClient(Host);
            client.AddDefaultHeader("Accept","*/*");
            client.AddDefaultHeader("Accept-Encoding", "gzip,deflate,sdch");
            client.AddDefaultHeader("App-Key", AppKey);
            client.Authenticator = new HttpBasicAuthenticator(Username, Password);

            request = new RestRequest(Resource, Method.PUT);
        }

        public void Start()
        {
            PauseChecks(true);
        }

        public void Stop()
        {
            PauseChecks(false);
        }

        private void PauseChecks(bool is_paused)
        {
            request.AddParameter("paused", is_paused);

            var response = client.Execute(request);

            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                message = response.Content;
            }
            else
            {
                message = response.ErrorMessage;

                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }
            }
        }
    }
}
