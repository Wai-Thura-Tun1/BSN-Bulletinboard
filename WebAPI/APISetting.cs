namespace Bulletinboard.Back.WebAPI
{
    public class APISetting
    {
        /// <summary>
        /// Define key_connectstr
        /// </summary>
        public const string KEY_CONNECTSTR = "ConnectionString";

        /// <summary>
        /// Define key_connectstr_package
        /// </summary>
        public const string KEY_CONNECTSTR_PACKAGE = "PackageConnectionString";

        /// <summary>
        /// Define key_apitoken
        /// </summary>
        public const string KEY_APITOKEN = "APIToken";

        /// <summary>
        /// Define key_logdirectory
        /// </summary>
        public const string KEY_LOGDIRECTORY = "LogDirectory";

        /// <summary>
        /// Define configuration
        /// </summary>
        public static IConfiguration? Configuration { get; set; }
    }
}
