using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Bulletinboard.Front.AppControls
{

    /// <summary>
    /// カスタムコントロール：DataGridを継承したコントロール
    /// </summary>
    public class iDataGrid : DataGrid
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public iDataGrid()
        {

            // DataGrid上でユーザーによる変更を不可とする
            this.AutoGenerateColumns = false;
            this.FontSize = 14;
            this.FontFamily = new FontFamily("メイリオ");
            this.CanUserAddRows = false;
            this.CanUserDeleteRows = false;
            this.CanUserSortColumns = false;
            this.CanUserResizeRows = false;
            this.CanUserReorderColumns = false;
            this.SelectionMode = DataGridSelectionMode.Single;
            this.SelectionUnit = DataGridSelectionUnit.Cell;
            this.RowHeaderWidth = 20;

            this.GridLinesVisibility = DataGridGridLinesVisibility.All;
            this.HeadersVisibility = DataGridHeadersVisibility.All;
            this.RowBackground = new BrushConverter().ConvertFrom("#FFFFFFFF") as SolidColorBrush;
            this.AlternatingRowBackground = new BrushConverter().ConvertFrom("#FFEBF7EC") as SolidColorBrush;
            this.HorizontalGridLinesBrush = new BrushConverter().ConvertFrom("#9E9E9E") as SolidColorBrush;
            this.VerticalGridLinesBrush = new BrushConverter().ConvertFrom("#9E9E9E") as SolidColorBrush;
            this.EnableRowVirtualization = true;
            this.EnableColumnVirtualization = true;


            // ColumnのStyleを設定する
            Style columnHeaderStyle = new Style();
            columnHeaderStyle.Setters.Add(new Setter(HorizontalAlignmentProperty, HorizontalAlignment.Stretch));
            columnHeaderStyle.Setters.Add(new Setter(VerticalAlignmentProperty, VerticalAlignment.Stretch));
            columnHeaderStyle.Setters.Add(new Setter(HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            columnHeaderStyle.Setters.Add(new Setter(VerticalContentAlignmentProperty, VerticalAlignment.Center));
            this.ColumnHeaderStyle = columnHeaderStyle;


            // CellのStyleを設定する
            Style cellStyle = new Style(typeof(DataGridCell));
            cellStyle.Setters.Add(new Setter(PaddingProperty, new Thickness(0, 0, 0, 0)));
            cellStyle.Setters.Add(new Setter(IsTabStopProperty, false));

            var trigger = new Trigger();
            trigger.Property = DataGridCell.IsSelectedProperty;
            trigger.Value = true;
            trigger.Setters.Add(new Setter(TextBox.BackgroundProperty, new SolidColorBrush(Colors.Transparent)));
            trigger.Setters.Add(new Setter(TextBox.ForegroundProperty, new SolidColorBrush(Colors.Black)));
            cellStyle.Triggers.Add(trigger);

            this.CellStyle = cellStyle;

        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
            }
            else
            {
                base.OnPreviewKeyDown(e);
            }
        }

    }

}
