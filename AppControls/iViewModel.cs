using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Bulletinboard.Front.AppControls
{
    public class iViewModel : INotifyPropertyChanged
    {

        public iViewModel()
        {
            this.ErrorList = new ObservableCollection<string>();
        }

        public enum ControlType
        {
            TextBox = 1,
            DataGrid = 2,
        }

        #region イベント定義

        ///// <summary>
        ///// 画面終了通知イベント
        ///// </summary>
        //public event EventHandler<EventArgs> CloseWindow;

        /// <summary>
        /// フォーカス移動通知イベント
        /// </summary>
        public delegate void MoveFocusEventHandler(string propertyName);
        public event MoveFocusEventHandler? MoveFocus;

        public void OnMoveFocus(string propertyName)
        {
            if (MoveFocus != null)
            {
                MoveFocus.Invoke(propertyName);
            }
        }

        /// <summary>
        /// データグリッド用フォーカス移動通知イベント
        /// </summary>
        public delegate void MoveFocusDataGridEventHandler(int rowIndex, int columnIndex);
        public event MoveFocusDataGridEventHandler? MoveFocusDataGrid;

        public void OnMoveFocusDataGrid(int rowIndex, int columnIndex)
        {
            if (MoveFocusDataGrid != null)
            {
                MoveFocusDataGrid.Invoke(rowIndex, columnIndex);
            }
        }

        #endregion

        /// <summary>
        /// ViewModelに紐づけた元フォーム
        /// </summary>
        public iWindow? ParentForm { get; set; }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public ObservableCollection<string> ErrorList { get; set; }

        private int _selectedErrorIndex = 0;
        /// <summary>
        /// システムメッセージ：コンボボックス選択インデックス
        /// </summary>
        public int SelectedErrorIndex
        {
            get
            {
                return _selectedErrorIndex;
            }
            set
            {
                _selectedErrorIndex = value;
                OnPropertyChanged(nameof(SelectedErrorIndex));
            }
        }

        #region 共通コマンド定義

        public iDelegateCommand? WindowLoaded { get; set; }
        public iDelegateCommand? WindowClosed { get; set; }

        public iDelegateCommand? CommandF1 { get; set; }
        public iDelegateCommand? CommandF2 { get; set; }
        public iDelegateCommand? CommandF3 { get; set; }
        public iDelegateCommand? CommandF4 { get; set; }
        public iDelegateCommand? CommandF5 { get; set; }
        public iDelegateCommand? CommandF6 { get; set; }
        public iDelegateCommand? CommandF7 { get; set; }
        public iDelegateCommand? CommandF8 { get; set; }
        public iDelegateCommand? CommandF9 { get; set; }
        public iDelegateCommand? CommandF10 { get; set; }
        public iDelegateCommand? CommandF11 { get; set; }
        public iDelegateCommand? CommandF12 { get; set; }

        #endregion


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
