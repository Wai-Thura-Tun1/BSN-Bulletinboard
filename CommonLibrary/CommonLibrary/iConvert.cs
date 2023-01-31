using System;
using System.Linq;
using System.Collections.Generic;

namespace Bulletinboard.CommonLibrary
{
    public class iConvert
    {
        public iConvert()
        {
            this.JapaneseList = new List<iCharacter>();
            this.AlphabetSujiKigoList = new List<iCharacter>();
            this.CreateCharacterConvertList();
        }

        #region 型変換処理

        /// <summary>
        /// 文字列をint型に変換する
        /// </summary>
        /// <param name="value">型変換したい文字列</param>
        /// <returns>数値に変換できない場合 nullを返す</returns>
        public static int? ToIntNullable(string value)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return null;
            }

            int result;

            return int.TryParse(value, out result) ? result : null;
        }

        /// <summary>
        /// 文字列をint型に変換する
        /// </summary>
        /// <param name="value">型変換したい文字列</param>
        /// <returns>数値に変換できない場合 0を返す</returns>
        public static int ToInt(string value)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return 0;
            }

            int result;

            return int.TryParse(value, out result) ? result : 0;
        }

        /// <summary>
        /// 文字列をint型に変換する
        /// </summary>
        /// <param name="value">型変換したい文字列</param>
        /// <returns>数値に変換できない場合 0を返す</returns>
        public static int ToInt(object? value)
        {
            if (value == null)
            {
                return 0;
            }

            int result;

            return int.TryParse(value.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 文字列をdecimal型に変換する
        /// </summary>
        /// <param name="value">型変換したい文字列</param>
        /// <returns>数値に変換できない場合 nullを返す</returns>
        public static decimal? ToDecimalNullable(string value)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return null;
            }

            decimal result;

            return decimal.TryParse(value, out result) ? result : null;
        }

        /// <summary>
        /// 文字列をdecimal型に変換する
        /// </summary>
        /// <param name="value">型変換したい文字列</param>
        /// <returns>数値に変換できない場合 nullを返す</returns>
        public static decimal? ToDecimalNullable(object? value)
        {
            if (value == null)
            {
                return null;
            }

            decimal result;

            return decimal.TryParse(value.ToString(), out result) ? result : null;
        }

        /// <summary>
        /// オブジェクトをdecimal型に変換する
        /// </summary>
        /// <param name="value">型変換したい文字列</param>
        /// <returns>数値に変換できない場合 0を返す</returns>
        public static decimal ToDecimal(object? value)
        {
            if (value == null)
            {
                return 0M;
            }

            decimal result;

            return decimal.TryParse(value.ToString(), out result) ? result : 0M;
        }

        /// <summary>
        /// null許容型decimalをdecimal型に変換する
        /// </summary>
        /// <param name="value">型変換したい文字列</param>
        /// <returns>数値に変換できない場合 0を返す</returns>
        public static decimal ToDecimal(decimal? value)
        {
            if (value == null)
            {
                return 0M;
            }

            return value.Value;
        }

        /// <summary>
        /// 文字列をdecimal型に変換する
        /// </summary>
        /// <param name="value">型変換したい文字列</param>
        /// <returns>数値に変換できない場合 0を返す</returns>
        public static decimal ToDecimal(string value)
        {
            if (string.IsNullOrEmpty(value) == true)
            {
                return 0M;
            }

            decimal result;

            return decimal.TryParse(value, out result) ? result : 0M;
        }

        /// <summary>
        /// 文字列に変換し、前方と後方のスペースを取り除いた文字列に変換する
        /// </summary>
        /// <param name="value">型変換したい文字列</param>
        /// <returns>文字列に変換できない場合 string.Emptyを返す</returns>
        public static string ToStringTrim(object? value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            try
            {
                string? retStr = Convert.ToString(value);
                return (retStr == null) ? string.Empty : retStr.Trim();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 文字列に変換する
        /// </summary>
        /// <param name="value">型変換したい文字列</param>
        /// <returns>文字列に変換できない場合 string.Emptyを返す</returns>
        public static string ToString(object? value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            try
            {
                string? retStr = Convert.ToString(value);
                return (retStr == null) ? string.Empty : retStr;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        #endregion


        #region 日付変換

        const string FMT_YYYYMMDD = "yyyy/MM/dd";

        /// <summary>
        /// 「YYYY/MM/DD」の形式の日付文字列を返す
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDateFormat(object? value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            try
            {
                DateTime result;
                string retDateString = string.Empty;
                if (DateTime.TryParse(Convert.ToString(value), out result) == true)
                {
                    retDateString = result.ToString(FMT_YYYYMMDD);
                }

                // システムで利用可能な日付範囲を超えている場合は空文字を返す
                if (result < iVerify.SYSTEM_MINDATE.AddDays(1))
                {
                    retDateString = string.Empty;
                }

                return retDateString;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 「YYYY/MM/DD」の形式の日付文字列を返す
        /// 日付に変換できない場合は「0001/01/01」を返す
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object? value)
        {
            if (value == null)
            {
                return DateTime.MinValue;
            }

            try
            {
                DateTime result;

                if (DateTime.TryParse(Convert.ToString(value), out result) == true)
                {
                    return result;
                }
                else
                {
                    return DateTime.MinValue;
                }

            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// 「YYYY/MM/DD」の形式の日付文字列を返す
        /// 日付に変換できない場合は「0001/01/01」を返す
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNullable(object? value)
        {
            if (value == null)
            {
                return DateTime.MinValue;
            }

            try
            {
                DateTime result;

                if (DateTime.TryParse(Convert.ToString(value), out result) == true)
                {
                    return result;
                }
                else
                {
                    return DateTime.MinValue;
                }

            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        ///// <summary>
        ///// 「YYYY/MM/DD」の形式の日付文字列を返す
        ///// NULLの場合は「空文字」を返す
        ///// </summary>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public static string ToDateTimeNullable(object? value)
        //{
        //    if (value == null)
        //    {
        //        return string.Empty;
        //    }

        //    try
        //    {
        //        DateTime result;

        //        if (DateTime.TryParse(Convert.ToString(value), out result) == true)
        //        {
        //            return result.ToString("yyyy/MM/dd");
        //        }
        //        else
        //        {
        //            return string.Empty;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        return string.Empty;
        //    }
        //}

        #endregion


        #region 半角/全角 変換処理

        private List<iCharacter> JapaneseList { get; set; }
        private List<iCharacter> AlphabetSujiKigoList { get; set; }

        /// <summary>
        /// 文字変換用の全角と半角を定義する
        /// </summary>
        private void CreateCharacterConvertList()
        {

            // 数字
            this.AlphabetSujiKigoList.Add(new iCharacter("０", "0"));
            this.AlphabetSujiKigoList.Add(new iCharacter("１", "1"));
            this.AlphabetSujiKigoList.Add(new iCharacter("２", "2"));
            this.AlphabetSujiKigoList.Add(new iCharacter("３", "3"));
            this.AlphabetSujiKigoList.Add(new iCharacter("４", "4"));
            this.AlphabetSujiKigoList.Add(new iCharacter("５", "5"));
            this.AlphabetSujiKigoList.Add(new iCharacter("６", "6"));
            this.AlphabetSujiKigoList.Add(new iCharacter("７", "7"));
            this.AlphabetSujiKigoList.Add(new iCharacter("８", "8"));
            this.AlphabetSujiKigoList.Add(new iCharacter("９", "9"));

            //  大文字
            this.AlphabetSujiKigoList.Add(new iCharacter("Ａ", "A"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｂ", "B"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｃ", "C"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｄ", "D"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｅ", "E"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｆ", "F"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｇ", "G"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｈ", "H"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｉ", "I"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｊ", "J"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｋ", "K"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｌ", "L"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｍ", "M"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｎ", "N"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｏ", "O"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｐ", "P"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｑ", "Q"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｒ", "R"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｓ", "S"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｔ", "T"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｕ", "U"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｖ", "V"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｗ", "W"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｘ", "X"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｙ", "Y"));
            this.AlphabetSujiKigoList.Add(new iCharacter("Ｚ", "Z"));


            //  小文字
            this.AlphabetSujiKigoList.Add(new iCharacter("ａ", "a"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｂ", "b"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｃ", "c"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｄ", "d"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｅ", "e"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｆ", "f"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｇ", "g"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｈ", "h"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｉ", "i"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｊ", "j"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｋ", "k"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｌ", "l"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｍ", "m"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｎ", "n"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｏ", "o"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｐ", "p"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｑ", "q"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｒ", "r"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｓ", "s"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｔ", "t"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｕ", "u"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｖ", "v"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｗ", "w"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｘ", "x"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｙ", "y"));
            this.AlphabetSujiKigoList.Add(new iCharacter("ｚ", "z"));

            // 記号
            this.AlphabetSujiKigoList.Add(new iCharacter("　", " "));
            this.AlphabetSujiKigoList.Add(new iCharacter("ー", "ｰ"));
            this.AlphabetSujiKigoList.Add(new iCharacter("＠", "@"));
            this.AlphabetSujiKigoList.Add(new iCharacter("；", ";"));
            this.AlphabetSujiKigoList.Add(new iCharacter("：", ":"));
            this.AlphabetSujiKigoList.Add(new iCharacter("、", "､"));
            this.AlphabetSujiKigoList.Add(new iCharacter("，", ","));
            this.AlphabetSujiKigoList.Add(new iCharacter("．", "."));
            this.AlphabetSujiKigoList.Add(new iCharacter("（", "("));
            this.AlphabetSujiKigoList.Add(new iCharacter("）", ")"));
            this.AlphabetSujiKigoList.Add(new iCharacter("＊", "*"));
            this.AlphabetSujiKigoList.Add(new iCharacter("＋", "+"));
            this.AlphabetSujiKigoList.Add(new iCharacter("－", "-"));
            this.AlphabetSujiKigoList.Add(new iCharacter("・", "･"));
            this.AlphabetSujiKigoList.Add(new iCharacter("／", "/"));
            this.AlphabetSujiKigoList.Add(new iCharacter("’", "'"));
            this.AlphabetSujiKigoList.Add(new iCharacter("￥", @"\"));
            this.AlphabetSujiKigoList.Add(new iCharacter("！", "!"));
            this.AlphabetSujiKigoList.Add(new iCharacter("？", "?"));
            this.AlphabetSujiKigoList.Add(new iCharacter("＝", "="));
            this.AlphabetSujiKigoList.Add(new iCharacter("＃", "#"));
            this.AlphabetSujiKigoList.Add(new iCharacter("％", "%"));
            this.AlphabetSujiKigoList.Add(new iCharacter("＆", "&"));
            this.AlphabetSujiKigoList.Add(new iCharacter("＜", "<"));
            this.AlphabetSujiKigoList.Add(new iCharacter("＞", ">"));
            this.AlphabetSujiKigoList.Add(new iCharacter("。", "｡"));
            this.AlphabetSujiKigoList.Add(new iCharacter("「", "｢"));
            this.AlphabetSujiKigoList.Add(new iCharacter("」", "｣"));
            this.AlphabetSujiKigoList.Add(new iCharacter("［", "["));
            this.AlphabetSujiKigoList.Add(new iCharacter("］", "]"));
            this.AlphabetSujiKigoList.Add(new iCharacter("｛", "{"));
            this.AlphabetSujiKigoList.Add(new iCharacter("｝", "}"));
            this.AlphabetSujiKigoList.Add(new iCharacter("＾", "^"));
            this.AlphabetSujiKigoList.Add(new iCharacter("｜", "|"));
            this.AlphabetSujiKigoList.Add(new iCharacter("～", "~"));

            // カタカナ
            this.JapaneseList.Add(new iCharacter("ア", "ｱ"));
            this.JapaneseList.Add(new iCharacter("イ", "ｲ"));
            this.JapaneseList.Add(new iCharacter("ウ", "ｳ"));
            this.JapaneseList.Add(new iCharacter("エ", "ｴ"));
            this.JapaneseList.Add(new iCharacter("オ", "ｵ"));
            this.JapaneseList.Add(new iCharacter("カ", "ｶ"));
            this.JapaneseList.Add(new iCharacter("キ", "ｷ"));
            this.JapaneseList.Add(new iCharacter("ク", "ｸ"));
            this.JapaneseList.Add(new iCharacter("ケ", "ｹ"));
            this.JapaneseList.Add(new iCharacter("コ", "ｺ"));
            this.JapaneseList.Add(new iCharacter("サ", "ｻ"));
            this.JapaneseList.Add(new iCharacter("シ", "ｼ"));
            this.JapaneseList.Add(new iCharacter("ス", "ｽ"));
            this.JapaneseList.Add(new iCharacter("セ", "ｾ"));
            this.JapaneseList.Add(new iCharacter("ソ", "ｿ"));
            this.JapaneseList.Add(new iCharacter("タ", "ﾀ"));
            this.JapaneseList.Add(new iCharacter("チ", "ﾁ"));
            this.JapaneseList.Add(new iCharacter("ツ", "ﾂ"));
            this.JapaneseList.Add(new iCharacter("テ", "ﾃ"));
            this.JapaneseList.Add(new iCharacter("ト", "ﾄ"));
            this.JapaneseList.Add(new iCharacter("ナ", "ﾅ"));
            this.JapaneseList.Add(new iCharacter("ニ", "ﾆ"));
            this.JapaneseList.Add(new iCharacter("ヌ", "ﾇ"));
            this.JapaneseList.Add(new iCharacter("ネ", "ﾈ"));
            this.JapaneseList.Add(new iCharacter("ノ", "ﾉ"));
            this.JapaneseList.Add(new iCharacter("ハ", "ﾊ"));
            this.JapaneseList.Add(new iCharacter("ヒ", "ﾋ"));
            this.JapaneseList.Add(new iCharacter("フ", "ﾌ"));
            this.JapaneseList.Add(new iCharacter("ヘ", "ﾍ"));
            this.JapaneseList.Add(new iCharacter("ホ", "ﾎ"));
            this.JapaneseList.Add(new iCharacter("マ", "ﾏ"));
            this.JapaneseList.Add(new iCharacter("ミ", "ﾐ"));
            this.JapaneseList.Add(new iCharacter("ム", "ﾑ"));
            this.JapaneseList.Add(new iCharacter("メ", "ﾒ"));
            this.JapaneseList.Add(new iCharacter("モ", "ﾓ"));
            this.JapaneseList.Add(new iCharacter("ヤ", "ﾔ"));
            this.JapaneseList.Add(new iCharacter("ユ", "ﾕ"));
            this.JapaneseList.Add(new iCharacter("ヨ", "ﾖ"));
            this.JapaneseList.Add(new iCharacter("ラ", "ﾗ"));
            this.JapaneseList.Add(new iCharacter("リ", "ﾘ"));
            this.JapaneseList.Add(new iCharacter("ル", "ﾙ"));
            this.JapaneseList.Add(new iCharacter("レ", "ﾚ"));
            this.JapaneseList.Add(new iCharacter("ロ", "ﾛ"));
            this.JapaneseList.Add(new iCharacter("ワ", "ﾜ"));
            this.JapaneseList.Add(new iCharacter("ヲ", "ｦ"));
            this.JapaneseList.Add(new iCharacter("ン", "ﾝ"));
            this.JapaneseList.Add(new iCharacter("ヴ", "ｳﾞ"));
            this.JapaneseList.Add(new iCharacter("ガ", "ｶﾞ"));
            this.JapaneseList.Add(new iCharacter("ギ", "ｷﾞ"));
            this.JapaneseList.Add(new iCharacter("グ", "ｸﾞ"));
            this.JapaneseList.Add(new iCharacter("ゲ", "ｹﾞ"));
            this.JapaneseList.Add(new iCharacter("ゴ", "ｺﾞ"));
            this.JapaneseList.Add(new iCharacter("ザ", "ｻﾞ"));
            this.JapaneseList.Add(new iCharacter("ジ", "ｼﾞ"));
            this.JapaneseList.Add(new iCharacter("ズ", "ｽﾞ"));
            this.JapaneseList.Add(new iCharacter("ゼ", "ｾﾞ"));
            this.JapaneseList.Add(new iCharacter("ゾ", "ｿﾞ"));
            this.JapaneseList.Add(new iCharacter("ダ", "ﾀﾞ"));
            this.JapaneseList.Add(new iCharacter("ヂ", "ﾁﾞ"));
            this.JapaneseList.Add(new iCharacter("ヅ", "ﾂﾞ"));
            this.JapaneseList.Add(new iCharacter("デ", "ﾃﾞ"));
            this.JapaneseList.Add(new iCharacter("ド", "ﾄﾞ"));
            this.JapaneseList.Add(new iCharacter("バ", "ﾊﾞ"));
            this.JapaneseList.Add(new iCharacter("ビ", "ﾋﾞ"));
            this.JapaneseList.Add(new iCharacter("ブ", "ﾌﾞ"));
            this.JapaneseList.Add(new iCharacter("ベ", "ﾍﾞ"));
            this.JapaneseList.Add(new iCharacter("ボ", "ﾎﾞ"));
            this.JapaneseList.Add(new iCharacter("パ", "ﾊﾟ"));
            this.JapaneseList.Add(new iCharacter("ピ", "ﾋﾟ"));
            this.JapaneseList.Add(new iCharacter("プ", "ﾌﾟ"));
            this.JapaneseList.Add(new iCharacter("ペ", "ﾍﾟ"));
            this.JapaneseList.Add(new iCharacter("ポ", "ﾎﾟ"));
            this.JapaneseList.Add(new iCharacter("ャ", "ｬ"));
            this.JapaneseList.Add(new iCharacter("ュ", "ｭ"));
            this.JapaneseList.Add(new iCharacter("ョ", "ｮ"));
            this.JapaneseList.Add(new iCharacter("ァ", "ｧ"));
            this.JapaneseList.Add(new iCharacter("ィ", "ｨ"));
            this.JapaneseList.Add(new iCharacter("ゥ", "ｩ"));
            this.JapaneseList.Add(new iCharacter("ェ", "ｪ"));
            this.JapaneseList.Add(new iCharacter("ォ", "ｫ"));

        }


        #region "全角を半角に変換する"

        /// <summary>
        /// 全角文字列を半角文字列に変換する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToHankakuAll(string value)
        {
            if ((value == null) || (value == ""))
            {
                return "";
            }

            string ret = "";

            foreach (char moji in value)
            {

                var alphasujiQuery = from obj in this.AlphabetSujiKigoList
                                     where obj.Zenkaku == moji.ToString()
                                     select obj.Hankaku;

                if (alphasujiQuery.Any() == true)
                {
                    ret += alphasujiQuery.First().ToString();
                }
                else
                {
                    var japanQuery = from obj in this.JapaneseList
                                     where obj.Zenkaku == moji.ToString()
                                     select obj.Hankaku;

                    if (japanQuery.Any() == true)
                    {
                        ret += japanQuery.First().ToString();
                    }
                    else
                    {
                        ret += moji.ToString();
                    }
                }

            }

            return ret;
        }

        /// <summary>
        /// 全角のアルファベット、数字、記号を半角に変換する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToHankakuAlphabetSuji(string value)
        {

            if ((value == null) || (value == ""))
            {
                return "";
            }

            string ret = "";

            foreach (char moji in value)
            {

                var alphasujiQuery = from obj in this.AlphabetSujiKigoList
                                     where obj.Zenkaku == moji.ToString()
                                     select obj.Hankaku;

                if (alphasujiQuery.Any() == true)
                {
                    ret += alphasujiQuery.First().ToString();
                }
                else
                {
                    ret += moji.ToString();
                }

            }

            return ret;
        }


        /// <summary>
        /// 全角のカタカナを半角に変換する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToHankakuKatakana(string value)
        {
            if ((value == null) || (value == ""))
            {
                return "";
            }

            string ret = "";

            foreach (char moji in value)
            {

                var japanQuery = from obj in this.JapaneseList
                                 where obj.Zenkaku == moji.ToString()
                                 select obj.Hankaku;

                if (japanQuery.Any() == true)
                {
                    ret += japanQuery.First().ToString();
                }
                else
                {
                    ret += moji.ToString();
                }

            }

            return ret;
        }

        #endregion


        #region "半角を全角に変換する"

        /// <summary>
        /// 半角文字列を全角文字列に変換する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToZenkakuAll(string value)
        {
            if ((value == null) || (value == ""))
            {
                return "";
            }

            string ret = "";

            string searchMoji = "";

            foreach (char moji in value)
            {

                if (moji == 'ﾞ' || moji == 'ﾟ')
                {
                    searchMoji += moji.ToString();
                }
                else
                {

                    if (searchMoji != "")
                    {
                        // 前回ループの文字列で検索する
                        var query = from obj in this.AlphabetSujiKigoList
                                    where obj.Hankaku == searchMoji
                                    select obj.Zenkaku;

                        if (query.Any() == true)
                        {
                            ret += query.First().ToString();
                        }
                        else
                        {
                            // 前回ループの文字列で検索する
                            var japanQuery = from obj in this.JapaneseList
                                             where obj.Hankaku == searchMoji
                                             select obj.Zenkaku;

                            if (japanQuery.Any() == true)
                            {
                                ret += japanQuery.First().ToString();
                            }
                            else
                            {
                                ret += searchMoji;
                            }

                        }
                    }

                    searchMoji = moji.ToString();

                }

            }

            // 最終文字で検索する
            var lastAlphabetQuery = from obj in this.AlphabetSujiKigoList
                                    where obj.Hankaku == searchMoji
                                    select obj.Zenkaku;

            if (lastAlphabetQuery.Any() == true)
            {
                ret += lastAlphabetQuery.First().ToString();
            }
            else
            {
                // 前回ループの文字列で検索する
                var japanQuery = from obj in this.JapaneseList
                                 where obj.Hankaku == searchMoji
                                 select obj.Zenkaku;

                if (japanQuery.Any() == true)
                {
                    ret += japanQuery.First().ToString();
                }
                else
                {
                    ret += searchMoji;
                }
            }


            return ret;
        }


        /// <summary>
        /// 半角のアルファベット、数字、記号を全角に変換する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToZenkakuAlphabetSujiKigo(string value)
        {
            if ((value == null) || (value == ""))
            {
                return "";
            }

            string ret = "";

            string searchMoji = "";

            foreach (char moji in value)
            {

                if (moji == 'ﾞ' || moji == 'ﾟ')
                {
                    searchMoji += moji.ToString();
                }
                else
                {

                    if (searchMoji != "")
                    {
                        // 前回ループの文字列で検索する
                        var query = from obj in this.AlphabetSujiKigoList
                                    where obj.Hankaku == searchMoji
                                    select obj.Zenkaku;

                        if (query.Any() == true)
                        {
                            ret += query.First().ToString();
                        }
                        else
                        {
                            ret += searchMoji;
                        }
                    }

                    searchMoji = moji.ToString();

                }

            }

            // 最終文字で検索する
            var lastQuery = from obj in this.AlphabetSujiKigoList
                            where obj.Hankaku == searchMoji
                            select obj.Zenkaku;

            if (lastQuery.Any() == true)
            {
                ret += lastQuery.First().ToString();
            }
            else
            {
                ret += searchMoji;
            }


            return ret;
        }


        /// <summary>
        /// 半角のカタカナを全角に変換する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToZenkakuKatakana(string value)
        {
            if ((value == null) || (value == ""))
            {
                return "";
            }

            string ret = "";

            string searchMoji = "";

            foreach (char moji in value)
            {

                if (moji == 'ﾞ' || moji == 'ﾟ')
                {
                    searchMoji += moji.ToString();
                }
                else
                {

                    if (searchMoji != "")
                    {
                        // 前回ループの文字列で検索する
                        var query = from obj in this.JapaneseList
                                    where obj.Hankaku == searchMoji
                                    select obj.Zenkaku;

                        if (query.Any() == true)
                        {
                            ret += query.First().ToString();
                        }
                        else
                        {
                            ret += searchMoji;
                        }
                    }

                    searchMoji = moji.ToString();

                }

            }

            // 最終文字で検索する
            var lastQuery = from obj in this.JapaneseList
                            where obj.Hankaku == searchMoji
                            select obj.Zenkaku;

            if (lastQuery.Any() == true)
            {
                ret += lastQuery.First().ToString();
            }
            else
            {
                ret += searchMoji;
            }


            return ret;
        }

        #endregion

        #endregion


        #region クラスのデータを移す

        /// <summary>
        /// プロパティ名が同じデータをコピーする
        /// 元データを対象データに設定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="motoData">元データのインスタンス</param>
        /// <param name="targetData">更新先のインスタンス</param>
        public static void CopyClassProperty<T>(T motoData, T targetData)
        {

            if (targetData != null)
            {
                foreach (var classItem in targetData.GetType().GetProperties())
                {

                    var motoProperty = motoData.GetType().GetProperty(classItem.Name);

                    if (motoProperty != null)
                    {
                        classItem.SetValue(targetData, motoProperty.GetValue(motoData));
                    }

                    //classItem.SetValue(null, motoProperty.GetValue());
                    //var property = targetData.GetType().GetProperty(classItem.Name);
                    //if (property != null)
                    //{
                    //}
                }
            }

        }

        #endregion

    }
}