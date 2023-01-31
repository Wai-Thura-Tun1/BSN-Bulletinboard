using System.Windows;
using System.Windows.Controls;

namespace Bulletinboard.Front.AppControls
{

    /// <summary>
    /// カスタムコントロール：ComboBoxを継承したコントロール
    /// </summary>
    public class iComboBox : ComboBox
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public iComboBox()
        {
            //PropertyMetadata metaData = DefaultStyleKeyProperty.GetMetadata(typeof(iComboBox));

            //if (metaData.DefaultValue == null)
            //{
            //    DefaultStyleKeyProperty.OverrideMetadata(typeof(iComboBox), new FrameworkPropertyMetadata(typeof(iComboBox)));
            //}
            //else
            //{
            //    string classType = Addon.CommonLiblary.iConvert.ToString(metaData.DefaultValue.ToString());

            //    if (classType.Contains(nameof(iComboBox)) == false)
            //    {
            //        DefaultStyleKeyProperty.OverrideMetadata(typeof(iComboBox), new FrameworkPropertyMetadata(typeof(iComboBox)));
            //    }

            //}

            this.Height = AppLibrary.iConstance.TEXTBOX_HEIGHT;
            this.IsEditable = true;

            //this.IsInputMode = false;
        }

        #region プロパティ

        ///// <summary>
        ///// 入力中フラグ（入力中の場合trueを返す）
        ///// </summary>
        //public bool IsInputMode { get; set; }

        ///// <summary>
        ///// IMEをDisabledに設定する場合,trueを指定する
        ///// </summary>
        //public bool ImeDisabled { get; set; }

        #endregion

        ///// <summary>
        ///// フォーカス受取時のイベント
        ///// </summary>
        //protected override void OnGotFocus(RoutedEventArgs e)
        //{
        //    base.OnGotFocus(e);
        //    this.SelectAll();

        //    if (this.ImeDisabled == true)
        //    {
        //        this.SetValue(InputMethod.IsInputMethodEnabledProperty, false);
        //    }
        //    else
        //    {
        //        // IME制御
        //        // 全角入力可能な状態にする
        //        InputScope scope = new InputScope();
        //        InputScopeName scopeName = new InputScopeName();
        //        scopeName.NameValue = InputScopeNameValue.Hiragana;
        //        scope.Names.Add(scopeName);
        //        this.InputScope = scope;
        //    }
        //}

        ///// <summary>
        ///// フォーカスが外れた時のイベント
        ///// </summary>
        //protected override void OnLostFocus(RoutedEventArgs e)
        //{
        //    base.OnLostFocus(e);

        //    if (this.ImeDisabled == true)
        //    {

        //        // 全角の文字列を半角に変換する
        //        Addon.CommonLiblary.iConvert convert = new CommonLiblary.iConvert();
        //        string halfsizeStr = convert.ToHankakuAlphabetSuji(this.Text);

        //        // 貼り付けにより全角の文字列が入力されるケースがあるため半角かチェックする
        //        if (Addon.CommonLiblary.iVerify.IsOnlyAlphaNumeric(halfsizeStr) == true)
        //        {
        //            if (this.Text.Equals(halfsizeStr) == false)
        //            {
        //                // 半角に変換した文字列を設定する
        //                this.Text = halfsizeStr;
        //            }
        //        }
        //        else
        //        {
        //            // IMEがDisabledの状態で全角文字が含まれている場合は空欄にする
        //            this.Text = string.Empty;
        //        }
        //    }
        //}

        ///// <summary>
        ///// キー入力確定時に発生するイベント
        ///// </summary>
        //protected override void OnTextInput(TextCompositionEventArgs e)
        //{
        //    base.OnTextInput(e);
        //    // 入力中のフラグを降ろす
        //    this.IsInputMode = false;
        //}

        ///// <summary>
        ///// テキスト変更イベント
        ///// ※全角入力途中でも発生する
        ///// </summary>
        //protected override void OnTextChanged(TextChangedEventArgs e)
        //{
        //    base.OnTextChanged(e);
        //    // 入力中のフラグを立てる
        //    this.IsInputMode = true;
        //}

    }

}
