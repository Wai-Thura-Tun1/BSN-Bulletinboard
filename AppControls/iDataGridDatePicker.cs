using System.Windows;
using System.Windows.Controls;

namespace Bulletinboard.Front.AppControls
{

    /// <summary>
    /// 日付コントロール
    /// カスタムコントロール：DataPickerを継承したコントロール
    /// </summary>
    public class iDataGridDatePicker : DatePicker
    {

        public iDataGridDatePicker()
        {
            PropertyMetadata metaData = DefaultStyleKeyProperty.GetMetadata(typeof(iDataGridDatePicker));

            if (metaData.DefaultValue == null)
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(iDataGridDatePicker), new FrameworkPropertyMetadata(typeof(iDataGridDatePicker)));
            }
            else
            {
                string classType = CommonLibrary.iConvert.ToString(metaData.DefaultValue.ToString());

                if (classType.Contains(nameof(iDataGridDatePicker)) == false)
                {
                    DefaultStyleKeyProperty.OverrideMetadata(typeof(iDataGridDatePicker), new FrameworkPropertyMetadata(typeof(iDataGridDatePicker)));
                }
            }

            this.Height = AppLibrary.iConstance.TEXTBOX_HEIGHT;
        }

    }

}
