using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace Bulletinboard.Front.AppControls
{

    /// <summary>
    /// カスタムコントロール：TextBoxを継承したコントロール
    /// </summary>
    /// <remarks>
    /// ImeDisabledの設定により、全角入力可、不可を切り替えることが可能です。
    /// </remarks>
    public class iTextBox : TextBox
    {

        public enum ImeModeKbn
        {
            /// <summary>制御無し（初期値）</summary>
            All = 1,
            /// <summary>半角英数字のみ許容</summary>
            AlphaNumeric = 2,
            /// <summary>半角英数字及び半角ｶﾅを許容</summary>
            Hankaku = 3,
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public iTextBox()
        {
            PropertyMetadata metaData = DefaultStyleKeyProperty.GetMetadata(typeof(iTextBox));

            if (metaData.DefaultValue == null)
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(iTextBox), new FrameworkPropertyMetadata(typeof(iTextBox)));
            }
            else
            {
                string classType = CommonLibrary.iConvert.ToString(metaData.DefaultValue.ToString());

                if (classType.Contains(nameof(iTextBox)) == false)
                {
                    DefaultStyleKeyProperty.OverrideMetadata(typeof(iTextBox), new FrameworkPropertyMetadata(typeof(iTextBox)));
                }

            }

            this.IsInputMode = false;
            this.Height = AppLibrary.iConstance.TEXTBOX_HEIGHT;

            // 全角入力の対応
            TextCompositionManager.AddPreviewTextInputHandler(this, DecideTextInput);
            TextCompositionManager.AddPreviewTextInputStartHandler(this, StartTextInput);

        }

        /// <summary>
        /// 入力開始時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartTextInput(object sender, TextCompositionEventArgs e)
        {
            // 入力中のフラグを立てる
            this.IsInputMode = true;
        }

        /// <summary>
        /// 入力確定時の処理
        /// 全角の場合、日本語入力を確定したときのみ発生する
        /// 半角の場合、入力の都度発生する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecideTextInput(object sender, TextCompositionEventArgs e)
        {
            this.IsInputMode = false;
        }



        #region イベント定義

        /// <summary>
        /// テキスト変更イベント
        /// フォーカスが離れたときに発生する
        /// </summary>
        public event EventHandler? OnTextUpdated;

        #endregion

        #region プロパティ

        /// <summary>
        /// 入力中フラグ（入力中の場合trueを返す）
        /// </summary>
        public bool IsInputMode { get; set; }

        private ImeModeKbn _imeMode = ImeModeKbn.All;
        /// <summary>
        /// IMEを設定する
        /// 初期値は全角許容
        /// </summary>
        public ImeModeKbn ImeMode
        {
            get { return _imeMode; }
            set
            {
                _imeMode = value;

                // IME制御
                InputScope scope = new InputScope();
                InputScopeName scopeName = new InputScopeName();

                switch (_imeMode)
                {
                    case ImeModeKbn.All:
                        // 全角入力可能な状態にする
                        scopeName.NameValue = InputScopeNameValue.Hiragana;
                        scope.Names.Add(scopeName);
                        this.InputScope = scope;
                        break;

                    case ImeModeKbn.AlphaNumeric:
                        // IMEをDisabledにする
                        this.SetValue(InputMethod.IsInputMethodEnabledProperty, false);
                        break;

                    case ImeModeKbn.Hankaku:
                        // 全角入力可能な状態にする
                        scopeName.NameValue = InputScopeNameValue.KatakanaHalfWidth;
                        scope.Names.Add(scopeName);
                        this.InputScope = scope;
                        break;
                }

            }
        }

        /// <summary>
        /// 最大バイト数
        /// </summary>
        public int MaxStringByte { get; set; }

        #endregion

        #region 変数

        /// <summary>
        /// フォーカスを受け取ったときのテキスト
        /// </summary>
        private string beforeText = string.Empty;

        #endregion


        /// <summary>
        /// フォーカス受取時のイベント
        /// </summary>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            this.beforeText = this.Text;

            this.SelectAll();
        }

        /// <summary>
        /// マウスボタン押下時のイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDown(e);

            if (this.IsFocused)
            {
                return;
            }
            else
            {
                e.Handled = true;
                this.Focus();
            }
        }


        /// <summary>
        /// フォーカスが外れた時のイベント
        /// </summary>
        protected override void OnLostFocus(RoutedEventArgs e)
        {

            CommonLibrary.iConvert convert = new CommonLibrary.iConvert();
            string halfsizeStr = String.Empty;

            switch (this.ImeMode)
            {
                case ImeModeKbn.AlphaNumeric:
                    // 半角英数のみ許容

                    // 全角の文字列を半角に変換する
                    halfsizeStr = convert.ToHankakuAlphabetSuji(this.Text);

                    // 貼り付けにより全角の文字列が入力されるケースがあるため半角かチェックする
                    if (CommonLibrary.iVerify.IsOnlyAlphaNumeric(halfsizeStr) == true)
                    {
                        if (this.Text.Equals(halfsizeStr) == false)
                        {
                            // 半角に変換した文字列を設定する
                            this.Text = halfsizeStr;
                        }
                    }
                    else
                    {
                        // IMEがDisabledの状態で全角文字が含まれている場合は空欄にする
                        this.Text = string.Empty;
                    }

                    break;

                case ImeModeKbn.Hankaku:
                    // 半角英数、半角ｶﾅを許容

                    // 全角の文字列を半角に変換する
                    halfsizeStr = convert.ToHankakuAll(this.Text);

                    // 貼り付けにより全角の文字列が入力されるケースがあるため半角かチェックする
                    if (CommonLibrary.iVerify.IsOnlyHankakuMoji(halfsizeStr) == true)
                    {
                        if (this.Text.Equals(halfsizeStr) == false)
                        {
                            // 半角に変換した文字列を設定する
                            this.Text = halfsizeStr;
                        }
                    }
                    else
                    {
                        // IMEがDisabledの状態で全角文字が含まれている場合は空欄にする
                        this.Text = string.Empty;
                    }

                    break;
            }

            if (string.IsNullOrEmpty(this.Text) == false)
            {
                if (0 < this.MaxStringByte)
                {
                    Encoding sjis = Encoding.GetEncoding("Shift_JIS");
                    // 入力されたバイト数をチェックする
                    byte[] byteArray = sjis.GetBytes(this.Text);

                    if (this.MaxStringByte < byteArray.Length)
                    {
                        this.Text = sjis.GetString(byteArray, 0, this.MaxStringByte);
                        AppLibrary.iMessage.ShowWarning(AppLibrary.iMessage.MT_0030, AppLibrary.iMessage.WMSG_SYS_0100);
                    }
                }
            }

            if (this.beforeText != this.Text)
            {
                // テキストが変わったときのみイベントを発生させる
                if (this.OnTextUpdated != null)
                {
                    OnTextUpdated(this, new EventArgs());
                }
            }

            base.OnLostFocus(e);
        }

    }

}
