using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Bulletinboard.CommonLibrary
{
    /// <summary> 検証・確認用クラス </summary>
    public class iVerify
    {
        public iVerify()
        {
        }

        public static DateTime SYSTEM_MINDATE = new DateTime(1900, 1, 1);

        /// <summary>
        /// 指定された文字列が数値かチェックする
        /// チェックする前に半角に変換してチェックを行う
        /// </summary>
        public static bool IsNumeric(string value)
        {
            iConvert convert = new iConvert();
            bool result = false;

            try
            {
                decimal temp;
                string checkValue = convert.ToHankakuAll(value);
                result = decimal.TryParse(checkValue, out temp);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 指定した文字列が全て半角英数字（記号含む）かチェックする
        /// ※１文字でも全角文字が含まれている場合はfalseを返す
        /// </summary>
        public static bool IsOnlyAlphaNumeric(string target)
        {
            if (string.IsNullOrEmpty(target) == true)
            {
                return true;
            }

            return Regex.IsMatch(target, @"^[a-zA-Z0-9!-/:-@¥[-`{-~]*$");
        }

        /// <summary>
        /// 指定した文字列が全て半角文字かチェックする
        /// ※１文字でも全角文字が含まれている場合はfalseを返す
        /// </summary>
        public static bool IsOnlyHankakuMoji(string target)
        {
            if (string.IsNullOrEmpty(target) == true)
            {
                return true;
            }

            // 文字数を取得
            int countMoji = target.Length;

            // Shift-JISに変換したバイト数を取得する
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Encoding sjis = Encoding.GetEncoding("Shift_JIS");

            int byteSuu = sjis.GetByteCount(target);

            // 文字数とバイト数が同じ場合は半角文字のみ
            return countMoji == byteSuu;
        }

        /// <summary>
        /// 編集中のデータが誰かに変更されたかチェックする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldData"></param>
        /// <param name="newData"></param>
        /// <returns></returns>
        public static bool IsOtherUpdated<T>(T oldData, T newData)
        {

            if (oldData == null || newData == null)
            {
                return false;
            }

            foreach (var item in oldData.GetType().GetProperties())
            {

                if (item.PropertyType.Name.Contains("List") == false)
                {
                    object? oldValue = item.GetValue(oldData, null);
                    object? newValue = item.GetValue(newData, null);

                    if (oldValue != null && newValue != null)
                    {
                        if (oldValue.Equals(newValue) == false)
                        {
                            return true;
                        }
                    }
                }

            }

            return false;
        }


    }
}