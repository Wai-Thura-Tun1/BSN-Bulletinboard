//using System.Collections.Generic;
//using System.Linq;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Input;
//using System.Reflection;

//namespace Bulletinboard.Front.AppControls
//{
//    /// <summary>
//    /// フォーカス範囲を決定し設定するため、及びその範囲内でフォーカスされた要素を設定するための静的メソッド、添付プロパティ、及びイベントを提供します。
//    /// </summary>
//    public static class iFocusManager
//    {
//        /// <summary>
//        /// 指定のコントロールの次のインデックスを持つコントロールにフォーカスを設定します。
//        /// </summary>
//        /// <param name="reference">基準となるコントロール。</param>
//        /// <param name="scope">フォーカス対象を検索するスコープ。</param>
//        /// <returns>フォーカスの設定に成功した場合は true、失敗した場合は false。</returns>
//        public static bool FocusNext(Control reference, DependencyObject? scope = null)
//        {
//            bool isRevers = (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;
//            if (scope == null)
//            {
//                var grid = iVisualTreeHelper.GetAncestors(reference, "iPALETDataGrid");
//                if (grid != null && grid.Count > 0)
//                {
//                    return false;
//                }
//                else
//                {
//                    scope = iVisualTreeHelper.GetRoot(reference);
//                }
//            }

//            int tabindex = reference.TabIndex;
//            List<Control> controls = iVisualTreeHelper.GetDescendantsFocusable<Control>(scope)
//                .Where(c => IsFocusable(c) && c.TabIndex >= 0 && c.TabIndex <= 100000 || c == reference)
//                .OrderBy(c => c.TabIndex)
//                .ToList();



//            if (controls.Count == 0)
//            {
//                return false;
//            }

//            int index = controls.IndexOf(reference);

//            if (index < 0)
//            {
//                reference = iVisualTreeHelper.GetAncestors<Control>(reference).FirstOrDefault(c => controls.Contains(c));
//                index = controls.IndexOf(reference);
//            }

//            if (index < 0)
//            {
//                if (isRevers)
//                {
//                    var ctrls = controls.Where<Control>(s => s.TabIndex >= tabindex);
//                    if (ctrls.Count<Control>() > 0)
//                    {
//                        reference = ctrls.First<Control>();
//                    }
//                    else
//                    {
//                        reference = controls.First<Control>();
//                    }
//                }
//                else
//                {
//                    var ctrls = controls.Where<Control>(s => s.TabIndex <= tabindex);
//                    if (ctrls.Count<Control>() > 0)
//                    {
//                        reference = ctrls.Last<Control>();
//                    }
//                    else
//                    {
//                        reference = controls.Last<Control>();
//                    }
//                }
//                if (reference == null)
//                {
//                    return false;
//                }
//                index = controls.IndexOf(reference);
//            }
//            else
//            {
//                if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
//                {
//                    index--;

//                    if (index < 0)
//                    {
//                        index = controls.Count - 1;
//                    }
//                }
//                else
//                {
//                    index++;

//                    if (index >= controls.Count)
//                    {
//                        index = 0;
//                    }
//                }
//            }

//            if (controls[index] == reference)
//            {
//                return false;
//            }


//#if SILVERLIGHT
//            return controls[index] is iPALETDataGrid ? ((iPALETDataGrid)controls[index]).Focus() : controls[index].Focus();
//#else
//            Application.Current.Dispatcher.BeginInvoke(new System.Action(() =>
//            {
//                var method = from s in controls[index].GetType().GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.DeclaredOnly)
//                             where iCompare.Equals(s.Name, "Focus") && s.GetParameters().Count<ParameterInfo>() == 0
//                             select s;
//                if (method == null || method.Count<MethodInfo>() == 0)
//                {
//                    controls[index].Focus();
//                    //Keyboard.Focus(controls[index]);
//                }
//                else
//                {
//                    MethodInfo focusMathod = method.FirstOrDefault<MethodInfo>();
//                    focusMathod.Invoke(controls[index], new object[] { });
//                }
//            }));
//            return true;
//#endif
//        }

//        /// <summary>
//        /// 指定されたコントロールがフォーカスを受け取ることが可能かどうかを示す値を取得します。
//        /// </summary>
//        /// <param name="control">フォーカスを取得できるか確認するコントロール。</param>
//        /// <returns>取得できる場合は true、できない場合は false。</returns>
//        public static bool IsFocusable(Control control)
//        {
//            if (control is TextBox)
//            {
//                return control.IsEnabled && control.Visibility == Visibility.Visible && !((TextBox)control).IsReadOnly && control.IsTabStop;
//            }
//#if WPF
//            //if(control is iComboEditor)
//            //{
//            //    iComboEditorTextBox comboText = iVisualTreeHelper.GetDescendants<iComboEditorTextBox>(control, true).First();
//            //    return control.IsEnabled && control.Visibility == Visibility.Visible && comboText.IsTabStop;
//            //}
//#endif
//            else
//            {
//                var isTabStop = control.GetPropertyValue("IsTabStop") as bool?;
//                return control.IsEnabled && control.Visibility == Visibility.Visible && isTabStop.HasValue && isTabStop.Value;
//            }
//        }

//#if !SILVERLIGHT

//        /// <summary>
//        /// 指定したフォーカス範囲内で論理フォーカスを持つ要素を取得します。
//        /// </summary>
//        /// <returns>論理フォーカスを持つ指定したフォーカス範囲内の要素。</returns>
//        public static IInputElement GetFocusedElement()
//        {
//            var element = Application.Current.Dispatcher.Invoke(() =>
//            {
//                var window = from s in Application.Current.Windows.Cast<Window>()
//                             where s.IsActive
//                             select s;
//                if (window != null && window.Count<Window>() > 0)
//                {
//                    return FocusManager.GetFocusedElement(window.FirstOrDefault<Window>());
//                }
//                else
//                {
//                    //return FocusManager.GetFocusedElement(Application.Current.MainWindow);
//                    return null;
//                }
//            });

//            return element;
//        }

//        /// <summary>
//        /// 指定したフォーカス範囲内で論理フォーカスを持つ要素を取得します。
//        /// </summary>
//        /// <param name="control">指定したフォーカス範囲で論理フォーカスを持つ要素。</param>
//        /// <returns>論理フォーカスを持つ指定したフォーカス範囲内の要素。</returns>
//        public static IInputElement GetFocusedElement(FrameworkElement control)
//        {
//            DependencyObject element = iVisualTreeHelper.GetRoot(control);
//            return FocusManager.GetFocusedElement(element);
//        }
//#endif

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="target"></param>
//        /// <param name="delaymillisecond"></param>
//        public static void SetFocusDelay(FrameworkElement target, int delaymillisecond = 200)
//        {
//            var task = new System.Action<int>((time) =>
//            {
//                System.Threading.Thread.Sleep(time);
//                target.Dispatcher.BeginInvoke(
//                    (System.Action)(() =>
//                    {
//                        target.Focus();
//                        Keyboard.Focus(target);
//                    }));
//            });
//            task.BeginInvoke(delaymillisecond, null, null);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="target"></param>
//        /// <param name="action"></param>
//        /// <param name="delaymillisecond"></param>
//        public static void SetFocusActionDelay(FrameworkElement target, System.Action action, int delaymillisecond = 200)
//        {
//            var task = new System.Action<int>((time) =>
//            {
//                System.Threading.Thread.Sleep(time);
//                target.Dispatcher.BeginInvoke(action);
//            });
//            task.BeginInvoke(delaymillisecond, null, null);
//        }
//    }
//}
