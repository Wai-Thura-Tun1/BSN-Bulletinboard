using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
//using MahApps.Metro.Controls;
using Bulletinboard.Front.AppLibrary;

namespace Bulletinboard.Front.AppControls
{
    /// <summary>
    /// Windowの基本クラス
    /// </summary>
    /// <remarks>
    /// ファンクションキーのイベント制御などフォーム共通の処理を実装する
    /// </remarks>
    public class iWindow : Window
    {

        #region イベント定義

        public event EventHandler? OnKeyUpF1;
        public event EventHandler? OnKeyUpF2;
        public event EventHandler? OnKeyUpF3;
        public event EventHandler? OnKeyUpF4;
        public event EventHandler? OnKeyUpF5;
        public event EventHandler? OnKeyUpF6;
        public event EventHandler? OnKeyUpF7;
        public event EventHandler? OnKeyUpF8;
        public event EventHandler? OnKeyUpF9;
        public event EventHandler? OnKeyUpF10;
        public event EventHandler? OnKeyUpF11;
        public event EventHandler? OnKeyUpF12;

        #endregion

        public iWindow()
        {
            // Windowのデフォルト値を設定する
            this.FontFamily = new FontFamily("メイリオ");
            this.FontSize = 14;
            this.Background = new BrushConverter().ConvertFrom("#FFFFF5E0") as SolidColorBrush;

            this.Height = iConstance.WINDOW_DEFAULT_HEIGHT;
            this.Width = iConstance.WINDOW_DEFAULT_WIDTH;
            this.IsDisplayClosingMessage = true;

        }

        #region プロパティ

        /// <summary>
        /// 画面終了時の確認メッセージ表示フラグ
        /// 規定値：true
        /// </summary>
        public bool IsDisplayClosingMessage { get; set; }

        #endregion

        #region 公開メソッド

        /// <summary>
        /// 全角文字の入力が確定しているか判定する
        /// </summary>
        /// <return>
        /// 入力中の場合trueを返す
        /// </return>
        public bool IsInputMode()
        {
            try
            {
                // 現在キーボード操作可能なコントロールを取得する
                IInputElement focusedControl = Keyboard.FocusedElement;

                // テキストボックスの場合
                if (focusedControl is iTextBox)
                {
                    iTextBox ctrl = (iTextBox)focusedControl;
                    return ctrl.IsInputMode;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// F1キー, F1ボタン押下時のコマンド処理
        /// 画面終了の確認メッセージを表示し、Yesの場合画面を終了する
        /// </summary>
        public void CommandF1()
        {
            this.Close();
        }

        /// <summary>
        /// F6キー, F6ボタン押下時のコマンド処理
        /// フォーカス位置を１つ前に戻す
        /// </summary>
        public void CommandF6()
        {
            //Keyboard.PrimaryDevice.Modifiers = ModifierKeys.Shift;
            KeyEventArgs keyEventTab = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Tab);
            keyEventTab.RoutedEvent = Keyboard.PreviewKeyDownEvent;

            InputManager.Current.ProcessInput(keyEventTab);
        }

        #endregion

        /// <summary>
        /// Windows終了時のイベント処理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {

            if (this.IsDisplayClosingMessage)
            {
                MessageBoxResult result;

                // 画面終了前に
                result = iMessage.ShowQuestion(iMessage.MT_0010, iMessage.QMSG_SYS_0010, MessageBoxResult.No);

                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnClosing(e);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if (this.IsInputMode() == true)
                {
                    // 入力中はフォーカス移動しない
                    return;
                }

                FrameworkElement? element = (FocusManager.GetFocusedElement(this) as FrameworkElement);

                if (element != null)
                {

                    // MoveFocusではDataGridにフォーカス移動した際にTabキー押下時と動作が異なるためTabキーを強制的に押したことにする
                    KeyEventArgs keyEventTab = new KeyEventArgs(e.KeyboardDevice, e.InputSource, e.Timestamp, Key.Tab);
                    keyEventTab.RoutedEvent = Keyboard.PreviewKeyDownEvent;

                    InputManager.Current.ProcessInput(keyEventTab);

                    //if (element is DataGridCell)
                    //{
                    //    //var inputElement = element as IInputElement;
                    //    //element.get

                    //    //if (inputElement != null)
                    //    //{
                    //    //    inputElement.Focus();
                    //    //}
                    //}
                    //else
                    //{
                    //    element.MoveFocus(new TraversalRequest(direction));
                    //}
                    //element.MoveFocus(new TraversalRequest(direction));

                }

                e.Handled = true;

                // if (iFocusManager.FocusNext((Control)e.OriginalSource, this))
                // {
                //     // フォーカス成功時、以降のイベント処理は行わない制御を行う
                //     e.Handled = true;
                // }
            }
            else
            {
                base.OnPreviewKeyDown(e);
            }
        }


        /// <summary>
        /// KeyDown イベントが発生する前に呼び出されます。
        /// </summary>
        /// <param name="e">イベントデータ。</param>
        protected override void OnKeyUp(KeyEventArgs e)
        {

            if (this.IsInputMode())
            {
                // 全角文字の入力中はファンクションキーイベントを起こさないよう制御する
                return;
            }

            switch (e.Key)
            {

                case Key.F1:
                    if (OnKeyUpF1 != null)
                    {
                        OnKeyUpF1(this, e);
                    }
                    break;

                case Key.F2:
                    if (OnKeyUpF2 != null)
                    {
                        OnKeyUpF2(this, e);
                    }
                    break;

                case Key.F3:
                    if (OnKeyUpF3 != null)
                    {
                        OnKeyUpF3(this, e);
                    }
                    break;

                case Key.F4:
                    if (OnKeyUpF4 != null)
                    {
                        OnKeyUpF4(this, e);
                    }
                    break;

                case Key.F5:
                    if (OnKeyUpF5 != null)
                    {
                        OnKeyUpF5(this, e);
                    }
                    break;

                case Key.F6:
                    if (OnKeyUpF6 != null)
                    {
                        OnKeyUpF6(this, e);
                    }
                    break;

                case Key.F7:
                    if (OnKeyUpF7 != null)
                    {
                        OnKeyUpF7(this, e);
                    }
                    break;

                case Key.F8:
                    if (OnKeyUpF8 != null)
                    {
                        OnKeyUpF8(this, e);
                    }
                    break;

                case Key.F9:
                    if (OnKeyUpF9 != null)
                    {
                        OnKeyUpF9(this, e);
                    }
                    break;

                case Key.F11:
                    if (OnKeyUpF11 != null)
                    {
                        OnKeyUpF11(this, e);
                    }
                    break;

                case Key.F12:
                    if (OnKeyUpF12 != null)
                    {
                        OnKeyUpF12(this, e);
                    }
                    break;
            }


            switch (e.SystemKey)
            {
                case Key.F10:
                    if (OnKeyUpF10 != null)
                    {
                        OnKeyUpF10(this, e);
                    }
                    break;
            }

            base.OnKeyUp(e);

        }

    }
}

