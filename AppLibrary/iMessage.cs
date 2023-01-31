using System.Windows;

namespace Bulletinboard.Front.AppLibrary
{
    public class iMessage
    {


        #region "メッセージ定義"

        // =====================================
        //  プレフィックス
        //      Infomation : IMSG_
        //      Question   : QMSG_
        //      Warning    : WMSG_
        //      Error      : EMSG_
        //
        //  メッセージ種類
        //      業務系      : プレフィックスの後に TRAN_ を付ける
        //      システム系   : プレフィックスの後に SYS_ を付ける
        //      例) IMSG_TRAN_XXXX, QMSG_SYS_XXXX
        //
        //  業務固有のメッセージ
        //      TRAN_ の後にAB, DAなどの業務プレフィックスを付ける
        //          受注系    ：WMSG_TRAN_AB_XXXX
        //          EDI連携系 ：WMSG_TRAN_MA_XXXX
        //
        //  XXXXは10飛ばしの連番とする
        //  0010 → 0020 → 0030
        //  ※間に挿入したい場合は"0011"のように指定しても良い
        //
        // =====================================

        // 共通
        public const string MSG_SYS_0010 = "{0}行目：";


        #region Infomation

        public const string IMSG_SYS_0010 = "正常に更新しました。";
        public const string IMSG_SYS_0020 = "対象データを削除しました。";
        public const string IMSG_SYS_0030 = "";
        public const string IMSG_SYS_0040 = "";
        public const string IMSG_SYS_0050 = "";
        public const string IMSG_TRAN_0060 = "User has been added successfully";
        public const string IMSG_TRAN_0070 = "User has been updated successfully";
        public const string IMSG_TRAN_0080 = "User has been deleted successfully";
        public const string IMSG_TRAN_0090 = "Post has been added successfully";
        public const string IMSG_TRAN_0100 = "Post has been updated successfully";
        public const string IMSG_TRAN_0110 = "Post has been deleted successfully";
        public const string IMSG_TRAN_0120 = "Post has been uploaded successfully";
        public const string IMSG_TRAN_0130 = "Post has been downloaded successfully";
        public const string IMSG_TRAN_0140 = "Password has been updated successfully";

        #endregion

        #region Question

        /// <summary>メッセージ内容：画面を終了します。よろしいですか？</summary>
        public const string QMSG_SYS_0010 = "画面を終了します。よろしいですか？";

        /// <summary>メッセージ内容：入力を破棄して画面をクリアしますか？</summary>
        public const string QMSG_SYS_0020 = "入力を破棄して画面をクリアしますか？";

        /// <summary>表示しているデータを削除します。よろしいですか？</summary>
        public const string QMSG_SYS_0030 = "表示しているデータを削除します。よろしいですか？";

        /// <summary>選択された行を削除しますか？</summary>
        public const string QMSG_SYS_0040 = "選択された行を削除しますか？";


        // 区分マスタ用
        public const string QMSG_TRAN_XX_5010 = "区分を追加します。よろしいですか？";
        public const string QMSG_TRAN_XX_5020 = "区分を更新します。よろしいですか？";
        public const string QMSG_TRAN_XX_5030 = "区分を削除します。よろしいですか？";

        // 外部連携フォーマット定義マスタ用
        public const string QMSG_TRAN_XX_2010 = "連携フォーマット定義を追加します。よろしいですか。";
        public const string QMSG_TRAN_XX_2020 = "連携フォーマット定義を更新します。よろしいですか。";
        public const string QMSG_TRAN_XX_2030 = "連携フォーマット定義を削除します。よろしいですか。";

        public const string QMSG_TRAN_USER_3010 = "Are you sure to delete this user ?";
        public const string QMSG_TRAN_POST_3020 = "Are you sure to delete this post ?";
        public const string QMSG_TRAN_POST_3030 = "Are you sure to logout ?";
        #endregion

        #region Warning

        public const string WMSG_SYS_0010 = "ユーザーコードまたはパスワードが入力されていません。";
        public const string WMSG_SYS_0020 = "ユーザーコードまたはパスワードが登録されていません。";
        public const string WMSG_SYS_0030 = "画面にデータが表示されていません。";
        public const string WMSG_SYS_0040 = "担当者を入力してください。";
        public const string WMSG_SYS_0050 = "担当者コードがマスタに登録されていません。";
        public const string WMSG_SYS_0060 = "パスワードを入力してください。";
        public const string WMSG_SYS_0070 = "権限を入力してください。";
        public const string WMSG_SYS_0080 = "権限がマスタに登録されていません。";
        public const string WMSG_SYS_0090 = "対象のデータは削除できません。";
        public const string WMSG_SYS_0100 = "許容できる文字列を超えています。超えた文字列は切り捨てられます。";
        public const string WMSG_SYS_0110 = "編集中に他者がデータを変更しているため更新できません。最新のデータを取得してください。";
        public const string WMSG_SYS_0120 = "明細部が未入力です。";
        public const string WMSG_SYS_0130 = "入力エラーがあります。画面下部のメッセージ欄を確認してください。";
        public const string WMSG_SYS_0140 = "登録されていないデータは削除できません。";
        public const string WMSG_SYS_0150 = "Email or password is not registered";


        // 区分マスタ用
        public const string WMSG_TRAN_XX_5010 = "区分コードを入力してください。";
        public const string WMSG_TRAN_XX_5020 = "区分名を入力してください。";
        public const string WMSG_TRAN_XX_5030 = "区分値を入力してください。";
        public const string WMSG_TRAN_XX_5040 = "区分値［{0}］が重複しています。";
        public const string WMSG_TRAN_XX_5050 = "明細行に変更不可の区分が存在するため、区分を削除できません。";
        public const string WMSG_TRAN_XX_5060 = "変更不可の明細行は削除できません。";
        public const string WMSG_TRAN_XX_5070 = "区分名称を入力してください。";

        // 外部連携フォーマット定義マスタ用
        public const string WMSG_TRAN_MX_2010 = "定義コードを入力してください。";
        public const string WMSG_TRAN_MX_2020 = "フォーマット定義名を入力してください。";
        public const string WMSG_TRAN_MX_2030 = "フォーマット区分を入力してください。";
        public const string WMSG_TRAN_MX_2040 = "項目名を入力してください。";
        public const string WMSG_TRAN_MX_2050 = "項目名［{0}］が重複しています。";
        public const string WMSG_TRAN_MX_2060 = "対象の定義情報が見つかりません。";
        public const string WMSG_TRAN_MX_2070 = "明細行を選択してください。";
        public const string WMSG_TRAN_MX_2080 = "明細部に行を追加してください。";

        // Validation Message For Bulletinboard
        public const string WMSG_TRAN_U_2090 = "Please enter first-name";
        public const string WMSG_TRAN_U_2100 = "Please enter last-name";
        public const string WMSG_TRAN_U_2110 = "Please enter email";
        public const string WMSG_TRAN_U_2120 = "Please enter password";
        public const string WMSG_TRAN_U_2130 = "Please enter confirm password";
        public const string WMSG_TRAN_U_2140 = "Please enter phone";
        public const string WMSG_TRAN_U_2150 = "Please enter date of birth";
        public const string WMSG_TRAN_U_2160 = "Please enter address";
        public const string WMSG_TRAN_U_2170 = "Passwords do not match";
        public const string WMSG_TRAN_P_2180 = "Please enter title";
        public const string WMSG_TRAN_P_2190 = "Please enter description";
        public const string WMSG_TRAN_U_2200 = "Please enter old password";
        public const string WMSG_TRAN_U_2210 = "Please enter new password";
        public const string WMSG_TRAN_U_2220 = "Please enter confirm password";
        public const string WMSG_TRAN_U_2230 = "New password and confirm password must be same";
        public const string WMSG_TRAN_U_2240 = "Try with another email!";
        #endregion

        #region Error

        public const string EMSG_SYS_0010 = "申し訳ございません。システム内部でエラーが発生しております。\n"
                                          + "システム管理者へ状況などお伝えください。";
        public const string EMSG_SYS_0020 = "申し訳ございません。データ取得時にサーバーでエラーが発生しております。\n"
                                          + "システム管理者へ状況などお伝えください。";
        public const string EMSG_SYS_0030 = "申し訳ございません。データ更新時にサーバーでエラーが発生しております。\n"
                                          + "システム管理者へ状況などお伝えください。";
        public const string EMSG_SYS_0040 = "申し訳ございません。データ削除時にサーバーでエラーが発生しております。\n"
                                          + "システム管理者へ状況などお伝えください。";
        public const string EMSG_SYS_0050 = "";
        public const string EMSG_SYS_0060 = "";
        public const string EMSG_SYS_0070 = "";
        public const string EMSG_SYS_0080 = "";
        public const string EMSG_SYS_0090 = "";
        public const string EMSG_SYS_0100 = "";
        public const string EMSG_TRAN_0110 = "Saving user data failed";
        public const string EMSG_TRAN_0120 = "Updating user data failed";
        public const string EMSG_TRAN_0130 = "Deleting user data failed";
        public const string EMSG_TRAN_0140 = "Saving post data failed";
        public const string EMSG_TRAN_0150 = "Updating post data failed";
        public const string EMSG_TRAN_0160 = "Deleting post data failed";
        public const string EMSG_TRAN_0170 = "Uploading post data failed";
        public const string EMSG_TRAN_0180 = "Downloading post data failed";
        public const string EMSG_TRAN_0190 = "Updating password failed or old password is wrong!";
        #endregion

        #endregion


        #region メッセージタイトル定義

        // =====================================
        //  プレフィックス
        //      MT_
        //      （メッセージタイトル）
        //
        //  プレフィックス後
        //      XXXX
        //      10飛ばしの連番
        //      ※間に挿入したい場合は"0011"のように指定しても良い
        //
        //  例
        //  MT_0010, MT_0020, MT_0030
        //
        // =====================================

        /// <summary>タイトル：画面終了</summary>
        public const string MT_0010 = "画面終了";

        /// <summary>タイトル：システムエラー</summary>
        public const string MT_0020 = "システムエラー";

        /// <summary>タイトル：文字数超過</summary>
        public const string MT_0030 = "文字数超過";

        /// <summary>タイトル：ログインエラー</summary>
        public const string MT_0040 = "ログインエラー";

        /// <summary>タイトル：入力エラー</summary>
        public const string MT_0050 = "入力エラー";

        /// <summary>タイトル：画面クリア</summary>
        public const string MT_0060 = "画面クリア";

        /// <summary>タイトル：データ取得エラー</summary>
        public const string MT_0070 = "データ取得エラー";

        /// <summary>タイトル：削除前確認</summary>
        public const string MT_0080 = "削除前確認";

        /// <summary>タイトル：更新エラー</summary>
        public const string MT_0090 = "更新エラー";

        /// <summary>タイトル：削除エラー</summary>
        public const string MT_0100 = "削除エラー";

        /// <summary>タイトル：更新成功</summary>
        public const string MT_0110 = "更新成功";

        /// <summary>タイトル：削除成功</summary>
        public const string MT_0120 = "削除成功";

        /// <summary>タイトル：更新前確認</summary>
        public const string MT_0130 = "更新前確認";

        public const string MT_0140 = "System Error";

        public const string MT_0150 = "Login Error";

        public const string MT_0160 = "Create User";

        public const string MT_0170 = "Edit User";

        public const string MT_0180 = "Delete User";

        public const string MT_0190 = "Create Post";

        public const string MT_0200 = "Edit Post";

        public const string MT_0210 = "Delete Post";

        public const string MT_0220 = "Upload Post";

        public const string MT_0230 = "Download Post";

        public const string MT_0240 = "Change Password";

        public const string MT_0250 = "Logout";

        #endregion


        /// <summary>
        /// 情報を伝えるメッセージを表示する
        /// </summary>
        /// <param name="title">メッセージウィンドウのタイトル（定数プレフィックス MT）※特殊な場合。直値 可</param>
        /// <param name="message">メッセージ内容（定数プレフィックス IMSG）</param>
        /// <return>
        /// メッセージダイアログの結果を返却（ OKのみ ）
        /// </return>
        public static MessageBoxResult ShowInfomation(string title, string message)
        {
            return MessageBox.Show(message, title, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        /// <summary>
        /// ユーザーに問い合わせるメッセージを表示する
        /// </summary>
        /// <param name="title">メッセージウィンドウのタイトル（定数プレフィックス MT）※特殊な場合。直値 可</param>
        /// <param name="message">メッセージ内容（定数プレフィックス QMSG）</param>
        /// <param name="defaultResult">初期フォーカス位置の指定（Yesボタン / Noボタン）</param>
        /// <return>
        /// メッセージダイアログの結果を返却（Yes / No）
        /// </return>
        public static MessageBoxResult ShowQuestion(string title, string message, MessageBoxResult defaultResult)
        {
            return MessageBox.Show(message, title, System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question, defaultResult);
        }

        /// <summary>
        /// アイコンが警告アイコンの状態で、ユーザーに問い合わせるメッセージを表示する
        /// </summary>
        /// <param name="title">メッセージウィンドウのタイトル（定数プレフィックス MT）※特殊な場合。直値 可</param>
        /// <param name="message">メッセージ内容（定数プレフィックス WMSG）</param>
        /// <param name="defaultResult">初期フォーカス位置の指定（Yesボタン / Noボタン）</param>
        /// <return>
        /// メッセージダイアログの結果を返却（Yes / No）
        /// </return>
        public static MessageBoxResult ShowWarningQuestion(string title, string message, MessageBoxResult defaultResult)
        {
            return MessageBox.Show(message, title, System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Warning, defaultResult);
        }

        /// <summary>
        /// 警告メッセージを表示する
        /// </summary>
        /// <param name="title">メッセージウィンドウのタイトル（定数プレフィックス MT）※特殊な場合。直値 可</param>
        /// <param name="message">メッセージ内容（定数プレフィックス WMSG）</param>
        /// <return>
        /// メッセージダイアログの結果を返却（ OKのみ ）
        /// </return>
        public static MessageBoxResult ShowWarning(string title, string message)
        {
            return MessageBox.Show(message, title, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
        }

        /// <summary>
        /// エラーメッセージを表示する
        /// </summary>
        /// <param name="title">メッセージウィンドウのタイトル（定数プレフィックス MT）※特殊な場合。直値 可</param>
        /// <param name="message">メッセージ内容（定数プレフィックス EMSG）</param>
        /// <return>
        /// メッセージダイアログの結果を返却（ OKのみ ）
        /// </return>
        public static MessageBoxResult ShowError(string title, string message)
        {
            return MessageBox.Show(message, title, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }

    }
}
