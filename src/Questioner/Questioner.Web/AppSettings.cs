namespace Questioner.Web
{
    public class AppSettings
    {
        private string questionerWebApiUrl;

        public string QuestionerWebApiUrl
        {
            get => questionerWebApiUrl; 
            set => questionerWebApiUrl = value.EndsWith("/") ? value : value + "/"; 
        }
}
}
