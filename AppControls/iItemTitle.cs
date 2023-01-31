using System.Windows;
using System.Windows.Controls;

namespace Bulletinboard.Front.AppControls
{

    /// <summary>
    /// 項目タイトル用コントロール
    /// カスタムコントロール：TextBlockを継承したコントロール
    /// </summary>
    public class iItemTitile : TextBlock
    {
        public iItemTitile()
        {
            this.TextAlignment = TextAlignment.Right;
            this.VerticalAlignment = VerticalAlignment.Center;
            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.Padding = new Thickness(4,0,4,0);
            this.Width = 80;
        }
    }

}
