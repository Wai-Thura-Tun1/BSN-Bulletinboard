using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulletinboard.Front.AppLibrary
{
    /// <summary>
    /// 定数定義クラス（静的クラス）
    /// </summary>
    public class iConstance
    {

        #region システム関連

        /// <summary>
        /// WebAPI認証用：項目名
        /// </summary>
        public const string HTTP_ENDPOINT = "ApiEndpoint";

        /// <summary>
        /// WebAPI認証用：項目名
        /// </summary>
        public const string HTTP_HEADER_APITOKEN = "APIToken";

        /// <summary>
        /// WebAPI認証用：項目名
        /// </summary>
        public const string LOG_MAXDAYCOUNT = "MaxArchiveDayCount";

        /// <summary>
        /// 成功
        /// </summary>
        public const int APIRESULT_SUCCESS = 1;

        /// <summary>
        /// データ無し
        /// </summary>
        public const int APIRESULT_NONEDATA = 0;

        /// <summary>
        /// エラー
        /// </summary>
        public const int APIRESULT_ERROR = -1;


        /// <summary>データステータス：初期値</summary>
        public const int DATASTATUS_NONE = 0;

        /// <summary>データステータス：追加</summary>
        public const int DATASTATUS_ADD = 1;

        /// <summary>データステータス：変更</summary>
        public const int DATASTATUS_UPDATE = 2;

        /// <summary>データステータス：削除</summary>
        public const int DATASTATUS_DELETE = 3;

        #endregion


        #region レイアウト関連

        public const int WINDOW_DEFAULT_WIDTH = 1280;
        public const int WINDOW_DEFAULT_HEIGHT = 780;

        /// <summary>
        /// 入力コントロール用
        /// コントロール高さの規定値
        /// </summary>
        public const int TEXTBOX_HEIGHT = 30;


        /// <summary>
        /// 入力不可項目の背景色
        /// </summary>
        public const string COLOR_READONLY = "#FFD6D6D6";

        #endregion

    }
}
