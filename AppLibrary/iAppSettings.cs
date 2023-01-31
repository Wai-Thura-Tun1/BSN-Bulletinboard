using Bulletinboard.Front.AppLibrary.Model;
namespace Bulletinboard.Front.AppLibrary
{
    /// <summary>
    /// アプリケーション設定情報格納クラス
    /// </summary>
    public class iAppSettings
    {
        private static string _apiEndpoint = string.Empty;
        /// <summary>
        /// WebAPIのエンドポイント(URL)を保持する
        /// </summary>
        public static string ApiEndpoint
        {
            get { return _apiEndpoint; }
            set { _apiEndpoint = value; }
        }

        private static string _apiToken = string.Empty;
        /// <summary>
        /// WebAPIの認証トークン
        /// </summary>
        public static string ApiToken
        {
            get { return _apiToken; }
            set { _apiToken = value; }
        }

        private static User _loginUser = new User();
        /// <summary>
        /// ログインユーザー情報
        /// </summary>
        public static User LoginUser
        {
            get { return _loginUser; }
            set { _loginUser = value; }
        }

        private static CommonLibrary.iLog _log = new CommonLibrary.iLog();

        /// <summary>
        /// ロギングクラス
        /// </summary>
        public static CommonLibrary.iLog Log
        {
            get { return _log; }
            set { _log = value; }
        }

    }
}
