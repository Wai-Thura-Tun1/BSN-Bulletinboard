using System;
using System.Windows.Input;

namespace Bulletinboard.Front.AppControls
{

    /// <summary>
    /// Viewからバインディングするコマンドクラス
    /// </summary>
    public class iDelegateCommand : ICommand
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public iDelegateCommand(System.Action<object?> exec, System.Func<bool> canExec)
        {
            this.execute = exec;
            this.canExecute = canExec;
        }

        /// <summary>
        /// 実行処理を指定する
        /// </summary>
        System.Action<object?> execute;

        /// <summary>
        /// 実行不可の条件式を指定する
        /// 無条件の場合はnullを設定する
        /// </summary>
        System.Func<bool> canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute();
        }

        public void Execute(object? parameter)
        {
            if (execute != null)
            {
                execute.Invoke(parameter);
            }
        }

        // INotifyPropertyChangedのインタフェースを実装する場合下記コードが必要
        // public event PropertyChangedEventHandler? PropertyChanged;  
        // private void OnPropertyChanged(string propertyName)  
        // {  
        //     if (PropertyChanged != null)  
        //     {  
        //         PropertyChanged(this, new PropertyChangedEventArgs(propertyName));  
        //     }  
        // }  
    }
}