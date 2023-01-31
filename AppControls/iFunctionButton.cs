using System.Windows;
using System.Windows.Controls;

namespace Bulletinboard.Front.AppControls
{

    /// <summary>
    /// カスタムコントロール：ファンクションボタン
    /// </summary>
    public class iFunctionButton : Button
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public iFunctionButton()
        {
            PropertyMetadata metaData = DefaultStyleKeyProperty.GetMetadata(typeof(iFunctionButton));

            if (metaData.DefaultValue == null)
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(iFunctionButton), new FrameworkPropertyMetadata(typeof(iFunctionButton)));
            }
            else
            {
                string classType = CommonLibrary.iConvert.ToString(metaData.DefaultValue.ToString());

                if (classType.Contains(nameof(iFunctionButton)) == false)
                {
                    DefaultStyleKeyProperty.OverrideMetadata(typeof(iFunctionButton), new FrameworkPropertyMetadata(typeof(iFunctionButton)));
                }
            }

            this.Width = 100;
        }

        //static iFunctionButton()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(iFunctionButton), new FrameworkPropertyMetadata(typeof(iFunctionButton)));
        //}


        #region テンプレート用プロパティ

        public static DependencyProperty FunctionKeyProperty = DependencyProperty.Register("FunctionKey", typeof(string), typeof(iFunctionButton));

        public static DependencyProperty CaptionProperty = DependencyProperty.Register("Caption", typeof(string), typeof(iFunctionButton));

        public string FunctionKey
        {
            get { return (string)GetValue(FunctionKeyProperty); }
            set { SetValue(FunctionKeyProperty, value); }
        }

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        #endregion


    }
}
