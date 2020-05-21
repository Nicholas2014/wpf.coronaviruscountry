using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Model
{
    public static class States
    {
        private static readonly List<string> _names;

        static States()
        {
            _names = new List<string>(50);
            _names.Add("阿联酋");
            _names.Add("阿富汗");
            _names.Add("安提瓜和巴布达");
            _names.Add("安圭拉");
            _names.Add("阿尔巴尼亚");
            _names.Add("亚美尼亚");
            _names.Add("安哥拉");
            _names.Add("南极洲");
            _names.Add("阿根廷");
            _names.Add("美属萨摩亚");
            _names.Add("奥地利");
            _names.Add("澳大利亚");
            _names.Add("阿鲁巴");
            _names.Add("奥兰群岛");
            _names.Add("阿塞拜疆");
            _names.Add("波黑");
            _names.Add("巴巴多斯");
            _names.Add("孟加拉");
            _names.Add("比利时");
            _names.Add("布基纳法索");
            _names.Add("保加利亚");
            _names.Add("巴林");
            _names.Add("布隆迪");
            _names.Add("贝宁");
            _names.Add("圣巴泰勒米岛");
            _names.Add("百慕大");
            _names.Add("文莱");
            _names.Add("玻利维亚");
            _names.Add("荷兰加勒比区");
            _names.Add("巴西");
        }

        public static IList<string> GetNames()
        {
            return _names;
        }
    }

}
