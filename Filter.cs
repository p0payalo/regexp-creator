using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ObsceneWordsFilter
{
    public enum WordLanguage
    {
        English,
        Russian
    };

    public static class Filter
    {
        public static string BuildRegularExpression(string source, WordLanguage wl)
        {
            Dictionary<string, List<string>> TargetAlphabet = EnglishLetters;
            switch (wl)
            {
                case WordLanguage.English:
                    TargetAlphabet = EnglishLetters;
                    break;
                case WordLanguage.Russian:
                    TargetAlphabet = RussianLetters;
                    break;
            }
            string result = "(";
            foreach (var i in source)
            {
                result += "(?:";
                foreach (var j in TargetAlphabet[i.ToString().ToLower()])
                {
                    result = result += j + "|";
                }
                result = result.Remove(result.Length - 1);
                result += ")";
                result += @"{1,}[*|`|.|,|_|\s|-]*";
            }
            result = result.Remove(result.Length - 17);
            result += ")";
            return result;
        }

        public static string FormatString(string source, IEnumerable<string> patterns)
        {
            foreach (var i in patterns)
            {
                source = Regex.Replace(source, i, "***", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            }
            return source;
        }

        public static string FormatString(string source, string pattern)
        {
            source = Regex.Replace(source, pattern, "***", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return source;
        }

        public static Dictionary<string, List<string>> RussianLetters = new Dictionary<string, List<string>>
        {
            [" "] = new List<string>()
            {
                " "
            },
            ["а"] = new List<string>()
            {
                "а",
                "a",
                "4",
                "@"
            },
            ["б"] = new List<string>()
            {
                "б",
                "6",
                "b"
            },
            ["в"] = new List<string>()
            {
                "в",
                "8",
                "v",
                "B"
            },
            ["г"] = new List<string>()
            {
                "г",
                "r",
                "g"
            },
            ["д"] = new List<string>()
            {
                "д",
                "d"
            },
            ["е"] = new List<string>()
            {
                "е",
                "e",
                "ё",
                "3"
            },
            ["ё"] = new List<string>()
            {
                "е",
                "e",
                "ё",
                "3"
            },
            ["ж"] = new List<string>()
            {
                "ж",
                "zh",
                "j"
            },
            ["з"] = new List<string>()
            {
                "з",
                "3",
                "z"
            },
            ["и"] = new List<string>()
            {
                "и",
                "u",
                "i",
                "1",
                "e"
            },
            ["й"] = new List<string>()
            {
                "й",
                "y",
                "у"
            },
            ["к"] = new List<string>()
            {
                "к",
                "k"
            },
            ["л"] = new List<string>()
            {
                "л",
                "l"
            },
            ["м"] = new List<string>()
            {
                "м",
                "m"
            },
            ["н"] = new List<string>()
            {
                "н",
                "n",
                "h"
            },
            ["о"] = new List<string>()
            {
                "о",
                "o",
                "0"
            },
            ["п"] = new List<string>()
            {
                "п",
                "n",
                "p",
                "р"
            },
            ["р"] = new List<string>()
            {
                "р",
                "p",
                "r"
            },
            ["с"] = new List<string>()
            {
                "с",
                "c",
                "s",
                @"\("
            },
            ["т"] = new List<string>()
            {
                "т",
                "t",
                "7"
            },
            ["у"] = new List<string>()
            {
                "у",
                "y",
                "u"
            },
            ["ф"] = new List<string>()
            {
                "ф",
                "f"
            },
            ["х"] = new List<string>()
            {
                "х",
                "x",
                "h"
            },
            ["ц"] = new List<string>()
            {
                "ц",
                "c",
                "с"
            },
            ["ч"] = new List<string>()
            {
                "ч",
                "ch",
                "4"
            },
            ["ш"] = new List<string>()
            {
                "ш",
                "w",
                "sh"
            },
            ["щ"] = new List<string>()
            {
                "ш",
                "щ",
                "w",
                "sch",
                "shch",
            },
            ["ь"] = new List<string>()
            {
                "ь",
                "b",
                "ъ"
            },
            ["ы"] = new List<string>()
            {
                "ы",
                "bi"
            },
            ["ъ"] = new List<string>()
            {
                "ь",
                "b",
                "ъ"
            },
            ["э"] = new List<string>()
            {
                "э",
                "е",
                "e"
            },
            ["ю"] = new List<string>()
            {
                "ю",
                "yu"
            },
            ["я"] = new List<string>()
            {
                "я",
                "ya",
                "9"
            }
        };

        public static Dictionary<string, List<string>> EnglishLetters = new Dictionary<string, List<string>>
        {
            [" "] = new List<string>()
            {
                " "
            },
            ["a"] = new List<string>()
            {
                "a",
                "а",
                "4",
                "@"
            },
            ["b"] = new List<string>()
            {
                "б",
                "6",
                "b"
            },
            ["c"] = new List<string>()
            {
                "c",
                "с",
                @"\("
            },
            ["d"] = new List<string>()
            {
                "d",
                "д"
            },
            ["e"] = new List<string>()
            {
                "e",
                "е",
                "3"
            },
            ["f"] = new List<string>()
            {
                "f",
                "ф"
            },
            ["g"] = new List<string>()
            {
                "g",
                "г",
                "r"
            },
            ["h"] = new List<string>()
            {
                "h",
                "н"
            },
            ["i"] = new List<string>()
            {
                "i",
                "и",
                "N",
                "1",
                "l"
            },
            ["j"] = new List<string>()
            {
                "j",
                "дж",
                "ж"
            },
            ["k"] = new List<string>()
            {
                "k",
                "к"
            },
            ["l"] = new List<string>()
            {
                "l",
                "1",
                "л",
                "I"
            },
            ["m"] = new List<string>()
            {
                "m",
                "м"
            },
            ["n"] = new List<string>()
            {
                "n",
                "п",
                "h"
            },
            ["o"] = new List<string>()
            {
                "o",
                "0",
                "о"
            },
            ["p"] = new List<string>()
            {
                "p",
                "р",
                "п",
                "n"
            },
            ["q"] = new List<string>()
            {
                "q",
                "o",
                "o,",
                "o."
            },
            ["r"] = new List<string>()
            {
                "р",
                "p",
                "r",
                "г"
            },
            ["s"] = new List<string>()
            {
                "s",
                "c",
                "с",
                "5"
            },
            ["t"] = new List<string>()
            {
                "т",
                "t",
                "7"
            },
            ["u"] = new List<string>()
            {
                "у",
                "y",
                "u"
            },
            ["v"] = new List<string>()
            {
                "v",
                "в"
            },
            ["w"] = new List<string>()
            {
                "w",
                "ш",
                "vv",
                "v"
            },
            ["x"] = new List<string>()
            {
                "x",
                "х"
            },
            ["y"] = new List<string>()
            {
                "y",
                "у",
                "u"
            },
            ["z"] = new List<string>()
            {
                "z",
                "з",
                "3"
            }
        };
    }
}
