using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoExplorer
{
    class FilterEnums
    {
        public static MyEnum sortColumn;

        static FilterEnums()
        {
            SetSortColumnEnums();
        }

        private static void SetSortColumnEnums()
        {
            sortColumn = new MyEnum();

            List<MyEnum.Item> items = new List<MyEnum.Item>(5) { };
            items.Add(new MyEnum.Item("TITLE", 0, "Title"));
            items.Add(new MyEnum.Item("YEAR", 1, "Year"));
            items.Add(new MyEnum.Item("LAST_PLAYED", 2, "Last Played"));
            items.Add(new MyEnum.Item("NUMBER_FILES", 3, "Number Files", "Files"));
            items.Add(new MyEnum.Item("PLAY_COUNT", 4, "Play Count", "Played"));

            sortColumn.AddItems(items);
            sortColumn.defaultText = sortColumn.GetTextByKey("TITLE");
            sortColumn.defaultValue = sortColumn.GetValueByKey("TITLE");
        }

    }
}
