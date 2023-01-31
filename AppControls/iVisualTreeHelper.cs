//using System.Collections.Generic;
//using System.Linq;
//using System.Windows;
////using System.Windows.Input;
//using System.Windows.Media;

//namespace Bulletinboard.Front.AppControls
//{
//    /// <summary>
//    /// ビジュアルツリーのノード関連の共通タスクを実行するためのユーティリティメソッドを提供します。
//    /// </summary>
//    public static class iVisualTreeHelper
//    {
//        /// <summary>
//        /// ビジュアルツリーにおけるオブジェクトの親オブジェクトを返します。
//        /// </summary>
//        /// <param name="reference">親オブジェクトを探す元オブジェクト。</param>
//        /// <returns>親オブジェクト。</returns>
//        public static DependencyObject GetParent(DependencyObject reference)
//        {
//            return VisualTreeHelper.GetParent(reference);
//        }

//        /// <summary>
//        /// ビジュアルツリーにおけるオブジェクトのルートオブジェクトを返します。
//        /// </summary>
//        /// <param name="reference">ルートオブジェクトを探す元オブジェクト。</param>
//        /// <returns>ルートオブジェクト。</returns>
//        public static DependencyObject GetRoot(DependencyObject reference)
//        {
//#if SILVERLIGHT
//            DependencyObject retval = VisualTreeHelper.GetRoot(reference);
//            if(retval == null)
//            {
//                System.Func<DependencyObject, DependencyObject> func = null;
//                func = (obj) =>
//                {
//                    DependencyObject tmp = VisualTreeHelper.GetParent(obj);
//                    return tmp == null || obj is iPALET.Library.Windows.Controls.iViewControl ? obj : func(tmp);
//                };
//                retval = func.Invoke(reference);
//            }
//            return retval;
//#else
//            DependencyObject tmp = reference;
//            DependencyObject root = tmp;

//            while ((tmp = VisualTreeHelper.GetParent(tmp)) != null)
//            {
//                root = tmp;
//            }

//            return root;
//#endif
//        }

//        /// <summary>
//        /// 指定の型の子要素のリストを取得します。
//        /// </summary>
//        /// <typeparam name="T">取得する要素の型。</typeparam>
//        /// <param name="reference">基準となる要素。</param>
//        /// <returns>指定の型の要素のリスト。</returns>
//        public static List<T> GetChildren<T>(DependencyObject reference)
//            where T : DependencyObject
//        {
//            List<T> list = new List<T>();
//            int count = VisualTreeHelper.GetChildrenCount(reference);

//            for (int i = 0; i < count; i++)
//            {
//                DependencyObject child = VisualTreeHelper.GetChild(reference, i);

//                if (child is T)
//                {
//                    list.Add((T)child);
//                }
//            }

//            return list;
//        }

//        /// <summary>
//        /// 先祖を辿って指定の型の要素のリストを取得します。
//        /// </summary>
//        /// <typeparam name="T">取得する要素の型。</typeparam>
//        /// <param name="reference">基準となる要素。</param>
//        /// <returns>指定の型の要素のリスト。</returns>
//        public static List<T> GetAncestors<T>(DependencyObject reference)
//            where T : DependencyObject
//        {
//            List<T> list = new List<T>();

//            while (reference != null)
//            {
//                reference = VisualTreeHelper.GetParent(reference) as FrameworkElement;

//                if (reference != null && reference is T)
//                {
//                    list.Add((T)reference);
//                }
//            }

//            return list;
//        }

//        /// <summary>
//        /// 先祖を辿って指定の型の要素のリストを取得します。
//        /// </summary>
//        /// <param name="reference">基準となる要素。</param>
//        /// <param name="classname"></param>
//        /// <returns>指定の型の要素のリスト。</returns>
//        public static List<DependencyObject> GetAncestors(DependencyObject reference, string classname)
//        {
//            List<DependencyObject> list = new List<DependencyObject>();

//            while (reference != null)
//            {
//                reference = VisualTreeHelper.GetParent(reference) as FrameworkElement;

//                if (reference != null && reference is DependencyObject && reference.GetType().Name.Contains(classname))
//                {
//                    list.Add((DependencyObject)reference);
//                }
//            }

//            return list;
//        }

//        /// <summary>
//        /// 子孫を辿って指定の型の要素のリストを取得します。
//        /// </summary>
//        /// <typeparam name="T">取得する要素の型。</typeparam>
//        /// <param name="reference">基準となる要素。</param>
//        /// <param name="stop">指定の型の要素が見つかったときにその子孫に対してさらに検索を行うどうかを示す値。</param>
//        /// <param name="hasChildTabIndex">子要素にもTabIndexを付与するかどうかを示す値。</param>
//        /// <param name="isReverse"></param>
//        /// <returns>指定の型の要素のリスト。</returns>
//        public static List<T> GetDescendants<T>(DependencyObject reference, bool stop = false, bool hasChildTabIndex = false, bool isReverse = false)
//         where T : DependencyObject
//        {
//            List<T> list = new List<T>();

//            GetDescendants<T>(reference, list, stop, hasChildTabIndex, isReverse);

//            return list;
//        }

//        /// <summary>
//        /// 子孫を辿って指定の型の要素のリストを取得します。
//        /// </summary>
//        /// <remarks>
//        /// 再帰処理的に子要素を辿るためのメソッドです。
//        /// </remarks>
//        /// <typeparam name="T">取得する要素の型。</typeparam>
//        /// <param name="reference">基準となる要素。</param>
//        /// <param name="list">取得した要素を格納するリスト。</param>
//        /// <param name="stop">指定の型の要素が見つかったときにその子孫に対してさらに検索を行うどうかを示す値。</param>
//        /// <param name="hasChildTabIndex">子要素にもTabIndexを付与するかどうかを示す値。</param>
//        /// <param name="isReverse"></param>
//        /// <param name="parentTabIndex">親のTabIndex。</param>
//        private static void GetDescendants<T>(DependencyObject reference, List<T> list, bool stop = false, bool hasChildTabIndex = false, bool isReverse = false, int parentTabIndex = int.MaxValue)
//            where T : DependencyObject
//        {
//            if (reference == null)
//            {
//                return;
//            }

//            int childrenCount = VisualTreeHelper.GetChildrenCount(reference);

//            int tabIndex = parentTabIndex;

//            if (hasChildTabIndex)
//            {
//                if (reference.GetType().GetProperty("TabIndex") != null)
//                {
//                    tabIndex = (int)reference.GetPropertyValue("TabIndex");
//                }
//            }

//            for (int i = 0; i < childrenCount; i++)
//            {
//                FrameworkElement? child = VisualTreeHelper.GetChild(reference, i) as FrameworkElement;

//                if (child == null)
//                {
//                    continue;
//                }

//                T? c = child as T;
//                int tmpTabIndex = tabIndex;
//                if (c != null)
//                {
//                    if (hasChildTabIndex)
//                    {
//                        if (c.GetType().GetProperty("TabIndex") != null)
//                        {
//                            tmpTabIndex = (int)c.GetValue("TabIndex");
//                            if (tabIndex != -1 && (tmpTabIndex == int.MaxValue || tmpTabIndex < 0))
//                            {
//                                c.SetPropertyValue("TabIndex", tabIndex);
//                            }
//                            else
//                            {
//                                tmpTabIndex = tabIndex;
//                            }
//                        }
//                    }
//                }

//                if (isReverse)　//逆順なら子は親の前にAdd
//                {
//                    GetDescendants<T>(child, list, stop, hasChildTabIndex, isReverse, tmpTabIndex);
//                }

//                if (c != null)
//                {
//                    list.Add(c);

//                    if (stop)
//                    {
//                        continue;
//                    }
//                }

//                if (!isReverse)　//正順なら子は親の次にAdd
//                {
//                    GetDescendants<T>(child, list, stop, hasChildTabIndex, isReverse, tmpTabIndex);
//                }
//            }
//        }

//        /// <summary>
//        /// 子孫を辿って指定の型の要素のリストを取得します。(親要素が使用不可・不可視の場合、子要素を取得しない)
//        /// </summary>
//        /// <typeparam name="T">取得する要素の型。</typeparam>
//        /// <param name="reference">基準となる要素。</param>
//        /// <param name="stop">指定の型の要素が見つかったときにその子孫に対してさらに検索を行うどうかを示す値。</param>
//        /// <param name="hasChildTabIndex">子要素にもTabIndexを付与するかどうかを示す値。</param>
//        /// <param name="isReverse"></param>
//        /// <returns>指定の型の要素のリスト。</returns>
//        public static List<T> GetDescendantsFocusable<T>(DependencyObject reference, bool stop = false, bool hasChildTabIndex = false, bool isReverse = false)
//         where T : DependencyObject
//        {
//            List<T> list = new List<T>();

//            GetDescendantsFocusable<T>(reference, list, stop, hasChildTabIndex, isReverse);

//            return list;
//        }

//        /// <summary>
//        /// 子孫を辿って指定の型の要素のリストを取得します。(親要素が使用不可・不可視の場合、子要素を取得しない)
//        /// </summary>
//        /// <remarks>
//        /// 再帰処理的に子要素を辿るためのメソッドです。
//        /// </remarks>
//        /// <typeparam name="T">取得する要素の型。</typeparam>
//        /// <param name="reference">基準となる要素。</param>
//        /// <param name="list">取得した要素を格納するリスト。</param>
//        /// <param name="stop">指定の型の要素が見つかったときにその子孫に対してさらに検索を行うどうかを示す値。</param>
//        /// <param name="hasChildTabIndex">子要素にもTabIndexを付与するかどうかを示す値。</param>
//        /// <param name="isReverse"></param>
//        /// <param name="parentTabIndex">親のTabIndex。</param>
//        private static void GetDescendantsFocusable<T>(DependencyObject reference, List<T> list, bool stop = false, bool hasChildTabIndex = false, bool isReverse = false, int parentTabIndex = int.MaxValue)
//            where T : DependencyObject
//        {
//            if (reference == null)
//            {
//                return;
//            }

//            int childrenCount = VisualTreeHelper.GetChildrenCount(reference);

//            int tabIndex = parentTabIndex;

//            if (hasChildTabIndex)
//            {
//                if (reference.GetType().GetProperty("TabIndex") != null)
//                {
//                    tabIndex = (int)reference.GetPropertyValue("TabIndex");
//                }
//            }

//            if (childrenCount > 0)
//            {
//                object obj = reference.GetPropertyValue("IsEnabled");
//                if (obj != null && !(bool)obj)
//                {
//                    return;
//                }

//                object obj2 = reference.GetPropertyValue("Visibility");

//                if (obj2 != null && (Visibility)obj2 != Visibility.Visible)
//                {
//                    return;
//                }
//            }

//            for (int i = 0; i < childrenCount; i++)
//            {
//                FrameworkElement child = VisualTreeHelper.GetChild(reference, i) as FrameworkElement;

//                if (child == null)
//                {
//                    continue;
//                }

//                T c = child as T;
//                int tmpTabIndex = tabIndex;
//                if (c != null)
//                {
//                    if (hasChildTabIndex)
//                    {
//                        if (c.GetType().GetProperty("TabIndex") != null)
//                        {
//                            tmpTabIndex = (int)c.GetPropertyValue("TabIndex");
//                            if (tabIndex != -1 && (tmpTabIndex == int.MaxValue || tmpTabIndex < 0))
//                            {
//                                c.SetPropertyValue("TabIndex", tabIndex);
//                            }
//                            else
//                            {
//                                tmpTabIndex = tabIndex;
//                            }
//                        }
//                    }
//                }

//                if (isReverse)　//逆順なら子は親の前にAdd
//                {
//                    GetDescendantsFocusable<T>(child, list, stop, hasChildTabIndex, isReverse, tmpTabIndex);
//                }

//                if (c != null)
//                {
//                    list.Add(c);

//                    if (stop)
//                    {
//                        continue;
//                    }
//                }

//                if (!isReverse)　//正順なら子は親の次にAdd
//                {
//                    GetDescendantsFocusable<T>(child, list, stop, hasChildTabIndex, isReverse, tmpTabIndex);
//                }
//            }
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        public class ElementItem<T>
//        {
//            /// <summary>
//            /// 
//            /// </summary>
//            public int Level { get; set; }
//            /// <summary>
//            /// 
//            /// </summary>
//            public T Element { get; set; }
//        }

//#if SILVERLIGHT
//        /// <summary>
//        /// 指定された座標にある指定の型の要素を取得します。
//        /// </summary>
//        /// <typeparam name="T">取得する要素の型。</typeparam>
//        /// <param name="baseElement">基準となる要素。</param>
//        /// <param name="offset">指定の座標。</param>
//        /// <returns>指定の型の要素のリスト。</returns>
//        public static List<T> GetElements<T>(FrameworkElement baseElement, Point offset = default(Point))
//            where T : FrameworkElement
//        {
//            if (baseElement.ActualWidth == 0 || baseElement.ActualHeight == 0)
//            {
//                return new List<T>();
//            }

//            if (offset == default(Point))
//            {
//                offset = new Point(2, 2);
//            }

//            List<T> elements;

//            try
//            {
//                GeneralTransform transform = baseElement.TransformToVisual(null);
//                Point point = transform.Transform(offset);

//                elements = VisualTreeHelper.FindElementsInHostCoordinates(point, Application.Current.RootVisual).Where(x => x is T).Select(x => x as T).ToList();
//            }
//            catch
//            {
//                elements = new List<T>();
//            }

//            return elements;
//        }
//#endif
//    }
//}
