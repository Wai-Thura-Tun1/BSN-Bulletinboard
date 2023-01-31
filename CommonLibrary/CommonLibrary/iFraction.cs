using System;

namespace Bulletinboard.CommonLibrary
{
    /// <summary> 端数処理クラス </summary>
    public class iFraction
    {
        public iFraction()
        {
        }

        /// <summary>
        /// 小数点以下の桁数を取得する
        /// </summary>
        public static int GetPrecision(decimal value)
        {
            int index = value.ToString().IndexOf('.');

            if (index < 0)
            {
                // . が無い場合は小数桁無し
                return 0;
            }

            return value.ToString().Substring(index + 1).Length;
        }

        /// <summary>
        /// 切上げ処理
        /// </summary>
        /// <param name="value">切上げ対象の数値</param>
        /// <param name="position">切上げ位置　1=小数第一位未満を切上げ  2=小数第二位未満を切上げ  -1=一の位を切上げ</param>
        /// <returns>切上げ処理した数値を返す</returns>
        public static decimal RoundUp(decimal value, int position)
        {
            decimal retValue = 0;

            decimal sign = 1;

            // 絶対値で端数処理を行う
            if (value < 0)
            {
                sign = -1;
                value = Math.Abs(value);
            }

            decimal pos = iConvert.ToDecimal(Math.Pow(10, position).ToString());

            if (0 <= position)
            {
                // 小数未満を切り上げる
                // 例）1 を指定した場合、小数第一位切上げ とする
                retValue = Math.Ceiling(value * pos) / pos;
            }
            else
            {
                // positionが負の場合は切上げの位置を位が大きい方に動かす
                // 例）-1 の場合は一の位を切り上げる
                retValue = Math.Ceiling(value / pos) * pos;
            }

            return retValue * sign;
        }

        /// <summary>
        /// 切捨て処理
        /// </summary>
        /// <param name="value">切捨て対象の数値</param>
        /// <param name="position">切捨て位置　1=小数第一位未満を切捨て  2=小数第二位未満を切捨て  -1=一の位を切捨て</param>
        /// <returns>切捨て処理した数値を返す</returns>
        public static decimal RoundDown(decimal value, int position)
        {
            decimal retValue = 0;

            decimal sign = 1;

            // 絶対値で端数処理を行う
            if (value < 0)
            {
                sign = -1;
                value = Math.Abs(value);
            }

            decimal pos = iConvert.ToDecimal(Math.Pow(10, position).ToString());

            if (0 <= position)
            {
                // 小数未満を切り上げる
                // 例）1 を指定した場合、小数第一位未満切捨て とする
                retValue = Math.Floor(value * pos) / pos;
            }
            else
            {
                // positionが負の場合は切捨ての位置を位が大きい方に動かす
                // 例）-1 の場合は一の位を切り捨てる
                retValue = Math.Floor(value / pos) * pos;
            }

            return retValue * sign;
        }


        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="value">対象の数値</param>
        /// <param name="position">四捨五入位置　1=小数第一位未満を四捨五入  2=小数第二位未満を四捨五入  -1=一の位を四捨五入</param>
        /// <returns>端数処理した数値を返す</returns>
        public static decimal Round(decimal value, int position)
        {
            decimal retValue = 0;

            decimal sign = 1;

            // 絶対値で端数処理を行う
            if (value < 0)
            {
                sign = -1;
                value = Math.Abs(value);
            }

            decimal pos = iConvert.ToDecimal(Math.Pow(10, position).ToString());

            if (0 <= position)
            {
                // 小数未満を四捨五入
                // 例）1 を指定した場合、小数第一位未満四捨五入 とする
                retValue = Math.Round(value * pos) / pos;
            }
            else
            {
                // positionが負の場合は四捨五入の位置を位が大きい方に動かす
                // 例）-1 の場合は一の位を四捨五入
                retValue = Math.Round(value / pos) * pos;
            }

            return retValue * sign;
        }


        /// <summary>
        /// 四捨六入処理　※JIS規格
        /// 有効桁数に丸める際、丸める位置の上の桁の数値によって五入か五捨を決定する
        /// 丸める上の数値が偶数の場合は五捨、奇数の場合は五入
        /// </summary>
        /// <param name="value">対象の数値</param>
        /// <param name="digit">有効桁数</param>
        /// <param name="isWeightKg">valueがキログラムの場合trueを指定する</param>
        /// <returns>端数処理した数値を返す</returns>
        /// <remarks>
        /// 例１：有効桁数が4, 12.345を丸める場合
        ///　　　　丸める数値が5, その上の位の数値が4（偶数）であるため、五捨
        /// 例２：有効桁数が4, 123.55を丸める場合
        ///　　　　丸める数値が5, その上の位の数値が5（奇数）であるため、五入
        /// 例３：有効桁数が4, 123.54を丸める場合
        ///　　　　丸める数値が5以外のため、通常の四捨五入を行う
        /// </remarks>
        public static decimal RoundForJIS(decimal value, int digit, bool isWeightKg)
        {

            // 小数部の桁数を取得
            int precision = iFraction.GetPrecision(value);

            // 小数部が存在しない場合は端数処理しない
            if (precision == 0)
            {
                // そのまま返す
                return value;
            }

            // 重量、且つ1000Kgを超える場合の処理
            if (isWeightKg == true)
            {
                if (1000 < value)
                {
                    // １トンを超える場合、整数に丸める
                    return Math.Round(value, 0);
                }
            }

            decimal retValue = value;

            // 丸め対象か判定する
            int length = (value.ToString().Replace(".", "")).Length;
            if (digit < length)
            {
                // 丸める位置を計算する
                int position = precision - (length - digit);
                if (precision < position)
                {
                    retValue = Math.Round(value, 0);
                }
                else
                {
                    retValue = Math.Round(value, position);
                }
            }

            return retValue;

        }


    }
}