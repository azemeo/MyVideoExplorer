using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoExplorer
{
    public static class VideoFileEnums
    {
        public static MyEnum sourceType;

        public static MyEnum watched;

        static VideoFileEnums()
        {
            SetWatchedEnums();
            SetSourceTypeEnums();
        }

        private static void SetWatchedEnums()
        {
            watched = new MyEnum();

            List<MyEnum.Item> items = new List<MyEnum.Item>(3) { };
            items.Add(new MyEnum.Item("ANY", -1, "Any"));
            items.Add(new MyEnum.Item("NO", 0, "No"));
            items.Add(new MyEnum.Item("YES", 1, "Yes"));

            watched.AddItems(items);
            watched.defaultText = "{DEFAULT_TO_PARAMETER}";
            watched.defaultValue = watched.GetValueByKey("ANY");
        }

        private static void SetSourceTypeEnums()
        {
            sourceType = new MyEnum();

            List<MyEnum.Item> items = new List<MyEnum.Item>(3) { };
            items.Add(new MyEnum.Item("MOVIE", 0, "Movie"));
            items.Add(new MyEnum.Item("TVSERIES", 1, "TV Series"));

            sourceType.AddItems(items);
            sourceType.defaultText = "Movie";
            sourceType.defaultValue = sourceType.GetValueByKey("MOVIE");
        }
    }
}
