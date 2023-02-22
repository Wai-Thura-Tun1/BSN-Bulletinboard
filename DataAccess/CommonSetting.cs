namespace Bulletinboard.Back.DataAccess
{
    public class CommonSetting
    {
        /// <summary>
        /// Define connection string
        /// </summary>
        public static string BulletinboardConnectString = string.Empty;

        /// <summary>
        /// Define package connnection string
        /// </summary>
        public static string PackageConnectSting = string.Empty;

        /// <summary>
        /// Define log output directory
        /// </summary>
        public static string LogOutputDirectory = string.Empty;

        /// <summary>
        /// Define logger container
        /// </summary>
        public static CommonLibrary.iLog? Log { get; set; }
    }
}