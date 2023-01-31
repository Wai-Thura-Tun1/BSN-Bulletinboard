using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bulletinboard.Front.AppControls
{

    /// <summary>
    /// 日付コントロール
    /// カスタムコントロール：DataPickerを継承したコントロール
    /// </summary>
    public class iDatePicker : DatePicker
    {

        public iDatePicker()
        {
            PropertyMetadata metaData = DefaultStyleKeyProperty.GetMetadata(typeof(iDatePicker));

            if (metaData.DefaultValue == null)
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(iDatePicker), new FrameworkPropertyMetadata(typeof(iDatePicker)));
            }
            else
            {
                string classType = CommonLibrary.iConvert.ToString(metaData.DefaultValue.ToString());

                if (classType.Contains(nameof(iDatePicker)) == false)
                {
                    DefaultStyleKeyProperty.OverrideMetadata(typeof(iDatePicker), new FrameworkPropertyMetadata(typeof(iDatePicker)));
                }
            }

            this.Height = AppLibrary.iConstance.TEXTBOX_HEIGHT;
            this.SelectedDateFormat = DatePickerFormat.Short;

        }


        protected override void OnPreviewLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnPreviewLostKeyboardFocus(e);

            if (string.IsNullOrEmpty(this.Text) == false)
            {
                this.Text = CommonLibrary.iConvert.ToDateFormat(this.Text);
            }
        }

    }

}
