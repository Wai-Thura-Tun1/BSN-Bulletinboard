using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bulletinboard.Front.AppControls
{

    /// <summary>
    /// カスタムコントロール：TextBoxを継承したコントロール
    /// </summary>
    public class iNumericTextBox : TextBox
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public iNumericTextBox()
        {
            PropertyMetadata metaData = DefaultStyleKeyProperty.GetMetadata(typeof(iNumericTextBox));

            if (metaData.DefaultValue == null)
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(iNumericTextBox), new FrameworkPropertyMetadata(typeof(iNumericTextBox)));
            }
            else
            {
                string classType = CommonLibrary.iConvert.ToString(metaData.DefaultValue.ToString());

                if (classType.Contains(nameof(iNumericTextBox)) == false)
                {
                    DefaultStyleKeyProperty.OverrideMetadata(typeof(iNumericTextBox), new FrameworkPropertyMetadata(typeof(iNumericTextBox)));
                }

            }

            convert = new CommonLibrary.iConvert();

            this.SetValue(InputMethod.IsInputMethodEnabledProperty, false);
            InputScope scope = new InputScope();
            InputScopeName scopeName = new InputScopeName();
            scopeName.NameValue = InputScopeNameValue.Number;
            scope.Names.Add(scopeName);
            this.InputScope = scope;

            this.TextAlignment = TextAlignment.Right;
            this.VerticalContentAlignment = VerticalAlignment.Center;
            this.MaxValue = DEFAULT_MAX_VALUE;
            this.MinValue = DEFAULT_MIN_VALUE;
            this.Height = AppLibrary.iConstance.TEXTBOX_HEIGHT;

        }

        //static iNumericTextBox()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(iNumericTextBox), new FrameworkPropertyMetadata(typeof(iNumericTextBox)));
        //    //IsInputMode = false;
        //}

        private const decimal DEFAULT_MAX_VALUE = 999999999999.99M;
        private const decimal DEFAULT_MIN_VALUE = 0M;

        private CommonLibrary.iConvert convert;

        #region プロパティ

        private int precision;
        /// <summary>
        /// 【ReadOnly】小数部の桁数(精度)　※最大値から取得
        /// </summary>
        public int Precision
        {
            get { return precision; }
        }

        private decimal max;
        /// <summary>
        /// 最大値
        /// 既定値は[ 999,999,999,999 ]です
        /// </summary>
        public decimal MaxValue
        {
            get { return max; }
            set
            {
                max = value;
                // 小数点以下の桁数を取得
                precision = CommonLibrary.iFraction.GetPrecision(value);
            }
        }

        /// <summary>
        /// 最小値
        /// 既定値は[ 0 ]です
        /// </summary>
        public decimal MinValue { get; set; }

        /// <summary>
        /// null許容
        /// </summary>
        public bool Nullable { get; set; }

        #endregion

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {

            if (e.Text == ".")
            {
                // 小数を認めない場合、. は受け付けない
                if (this.precision == 0)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.Text == " ")
            {
                // 半角スペースは受け付けない
                e.Handled = true;
                return;
            }

            string checkValue;


            if (string.IsNullOrEmpty(this.SelectedText) == false)
            {
                // テキストを全選択しているかチェックする
                if (this.Text.Equals(this.SelectedText) == true)
                {
                    // 全選択している場合は入力した文字のみで判定を行う
                    checkValue = e.Text;
                }
                else
                {
                    // 選択部を入力文字に置き換えて判定を行う
                    checkValue = this.Text.Substring(0, this.CaretIndex) + e.Text + this.Text.Substring(this.CaretIndex + this.SelectedText.Length);
                }
            }
            else
            {
                // 選択中のテキストが無ければキャレット部に入力文字を挿入する
                checkValue = this.Text.Insert(this.CaretIndex, e.Text);
            }

            if (this.MinValue < 0)
            {
                if (checkValue == "-")
                {
                    return;
                }
            }

            // 入力結果が数値か判定する
            if (CommonLibrary.iVerify.IsNumeric(checkValue) == false)
            {
                // 数値以外の場合、後続のイベント処理を行わない制御を行う
                e.Handled = true;
                return;
            }

            decimal inputValue = CommonLibrary.iConvert.ToDecimal(checkValue);

            // 小数点以下の桁数をチェックし、超える場合は受け付けない
            if (this.Precision < CommonLibrary.iFraction.GetPrecision(inputValue))
            {
                e.Handled = true;
                return;
            }

            // MaxValueを超えないかチェックする
            if (this.MaxValue < inputValue)
            {
                e.Handled = true;
                return;
            }

            // MinValueを下回らないかチェックする
            if (inputValue < this.MinValue)
            {
                e.Handled = true;
                return;
            }

            base.OnPreviewTextInput(e);
        }

        // 入力内容が確定したタイミングで発生するイベント
        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            base.OnTextInput(e);
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
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

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            // 貼り付けられた文字列が全角の場合を考慮
            string tempStr = convert.ToHankakuAll(this.Text);

            if (CommonLibrary.iVerify.IsNumeric(tempStr) == false)
            {
                this.Text = string.Empty;
            }

        }


    }

}
