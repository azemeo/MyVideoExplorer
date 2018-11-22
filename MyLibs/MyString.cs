using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoExplorer
{
    class MyString
    {

        public static List<string> WordWrap(string text, int maxLineLength)
        {
            var list = new List<string>();
            if (text == null)
            {
                return list;
            }

            int currentIndex;
            var lastWrap = 0;
            var whitespace = new[] { ' ', '\r', '\n', '\t' };
            do
            {
                currentIndex = lastWrap + maxLineLength > text.Length ? text.Length : (text.LastIndexOfAny(new[] { ' ', ',', '.', '?', '!', ':', ';', '-', '\n', '\r', '\t' }, Math.Min(text.Length - 1, lastWrap + maxLineLength)) + 1);
                if (currentIndex <= lastWrap)
                    currentIndex = Math.Min(lastWrap + maxLineLength, text.Length);
                list.Add(text.Substring(lastWrap, currentIndex - lastWrap).Trim(whitespace));
                lastWrap = currentIndex;
            } while (currentIndex < text.Length);

            return list;
        }
    }
}
