namespace Adilicious.Tests.Integration
{
    using System.IO;

    using IISExpressAutomation;

    public class AdiliciousWebsite
    {
        private IISExpress iis;

        public void Start()
        {
            if (iis != null)
            {
                throw new InvalidDataException("IIS Express is already running");
            }

            iis = new IISExpress(new Parameters
            {
                Path = Path.GetFullPath(@"..\..\..\..\..\src\Adilicious.Web"),
                Port = 1337
            });

        }

        public void Stop()
        {
            iis.Dispose();
            iis = null;
        }
    }
}