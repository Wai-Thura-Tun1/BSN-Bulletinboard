namespace Bulletinboard.CommonLibrary
{
    public class iCharacter
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="zen">全角文字</param>
        /// <param name="han">半角文字</param>
        public iCharacter(string zen, string han)
        {
            this.Zenkaku = zen;
            this.Hankaku = han;
        }

        /// <summary> 全角文字 </summary>
        public string Zenkaku { get; set; }

        /// <summary> 半角文字 </summary>
        public string Hankaku { get; set; }

    }
}