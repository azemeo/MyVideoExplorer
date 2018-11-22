using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoExplorer
{
    public class MyEnum
    {

        public class Item
        {
            public int value;
            public string text;
            public string key;
            public string abbrev;

            public Item()
            {

            }

            public Item(string key, int value, string text)
            {
                this.key = key;
                this.value = value;
                this.text = text;
                this.abbrev = text;
            }

            public Item(string key, int value, string text, string abbrev)
            {
                this.key = key;
                this.value = value;
                this.text = text;
                this.abbrev = abbrev;
            }
        }

        private List<Item> items;
        private const string DEFAULT_TO_PARAMETER = "{DEFAULT_TO_PARAMETER}";
        public int defaultValue;
        public string defaultText;

        public MyEnum()
        {
            items = new List<Item> { };
        }

        public void AddItems(List<Item> items)
        {
            this.items = items;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public List<KeyValuePair<int, string>> ToList()
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>> { };
            foreach (Item item in items)
            {
                list.Add(new KeyValuePair<int, string> ( item.value, item.text ));
            }
            return list;
        }

        private string GetFieldByKey(string field, string key)
        {
            string ret;
            if (defaultText == DEFAULT_TO_PARAMETER)
            {
                ret = key;
            }
            else
            {
                ret = defaultText;
            }
            if (String.IsNullOrEmpty(key))
            {
                return ret;
            }

            try
            {
                Item item = items.Single(m => m.key == key);
                if (item != null)
                {
                    switch (field)
                    {
                        case "abbrev":
                            ret = item.abbrev;
                            break;
                        case "text":
                            ret = item.text;
                            break;
                        case "value":
                            ret = item.value.ToString();
                            break;
                    }
                    
                }
            }
            catch (ArgumentNullException)
            {
                // list null
            }
            catch (InvalidOperationException)
            {
                // result is 0 or more than 1 .. ie not 1
            }
            return ret;
        }

        public string GetAbbrevByKey(string key)
        {
            string abbrev = GetFieldByKey("abbrev", key);
            return abbrev;
        }

        public string GetTextByKey(string key)
        {
            string text = GetFieldByKey("text", key);
            return text;
        }

        public int GetValueByKey(string key)
        {
            string value = GetFieldByKey("value", key);
            if (String.IsNullOrEmpty(value))
            {
                value = "0";
            }
            return Convert.ToInt32(value);
        }


        private string GetFieldByValue(string field, int value)
        {
            string ret;
            if (defaultText == DEFAULT_TO_PARAMETER)
            {
                ret = value.ToString();
            }
            else
            {
                ret = defaultText;
            }

            try
            {
                Item item = items.Single(m => m.value == value);
                if (item != null)
                {
                    switch (field)
                    {
                        case "abbrev":
                            ret = item.abbrev;
                            break;
                        case "key":
                            ret = item.key;
                            break;
                        case "text":
                            ret = item.text;
                            break;
                    }

                }
            }
            catch (ArgumentNullException)
            {
                // list null
                // MyLog.Add("MyEnum.GetFieldByValue: " + field + " - " + value.ToString() + " " + ane.ToString());
            }
            catch (InvalidOperationException)
            {
                // result is 0 or more than 1 .. ie not 1
                // MyLog.Add("MyEnum.GetFieldByValue: " + field + " - " + value.ToString() + " " + ioe.ToString());
            }
            return ret;
        }

        public string GetTextByValue(object value)
        {
            if (value == null)
            {
                value = 0;
            }
            return GetTextByValue((int)value);
        }
        public string GetTextByValue(int value)
        {
            string text = GetFieldByValue("text", value);
            return text;
        }

        public string GetAbbrevByValue(int value)
        {
            string abbrev = GetFieldByValue("abbrev", value);
            return abbrev;
        }

        public string GetKeyByValue(int value)
        {
            string key = GetFieldByValue("key", value);
            return key;
        }

        public KeyValuePair<int, string> GetPairByKey(string key)
        {
            KeyValuePair<int, string> pair = new KeyValuePair<int, string>(defaultValue, key);
            if (String.IsNullOrEmpty(key))
            {
                return pair;
            }
            try
            {
                Item item = items.Single(m => m.key == key);
                pair = new KeyValuePair<int, string>(item.value, key);
            }
            catch (ArgumentNullException)
            {
                // list null
            }
            catch (InvalidOperationException)
            {
                // result is 0 or more than 1 .. ie not 1
            }
            return pair;
        }


        private string GetFieldByText(string field, string text)
        {
            string ret;
            if (defaultText == DEFAULT_TO_PARAMETER)
            {
                ret = text;
            }
            else
            {
                ret = defaultText;
            }

            try
            {
                Item item = items.Single(m => m.text == text);
                if (item != null)
                {
                    switch (field)
                    {
                        case "abbrev":
                            ret = item.abbrev;
                            break;
                        case "key":
                            ret = item.key;
                            break;
                        case "value":
                            ret = item.value.ToString();
                            break;
                    }

                }
            }
            catch (ArgumentNullException)
            {
                // list null
            }
            catch (InvalidOperationException)
            {
                // result is 0 or more than 1 .. ie not 1
            }
            return ret;
        }

        public int GetValueByText(string text)
        {
            string value = GetFieldByText("value", text);
            if (String.IsNullOrEmpty(value))
            {
                value = "0";
            }
            int val;
            bool isNumeric = int.TryParse(value, out val);
            return val;
        }

        public string GetKeyByText(string text)
        {
            string key = GetFieldByText("key", text);
            return key;
        }

        private bool FieldExists(string field, string val)
        {
            bool ret = false;
            try
            {
                Item item = null;
                switch (field)
                {
                    case "abbrev":
                        item = items.Single(m => m.abbrev == val);
                        break;
                    case "key":
                        item = items.Single(m => m.key == val);
                        break;
                    case "text":
                        item = items.Single(m => m.text == val);
                        break;
                    case "value":
                        item = items.Single(m => m.value == Convert.ToInt32(val));
                        break;
                }
                if (item != null)
                {
                    ret = true;
                }
            }
            catch (ArgumentNullException)
            {
                // list null
            }
            catch (InvalidOperationException)
            {
                // result is 0 or more than 1 .. ie not 1
            }
            return ret;
        }

        public bool ValueExists(int value)
        {
            bool ret = FieldExists("value", value.ToString());
            return ret;
        }

        public bool TextExists(string text)
        {
            bool ret = FieldExists("text", text);
            return ret;
        }

        public bool KeyExists(string key)
        {
            bool ret = FieldExists("key", key);
            return ret;
        }
    }

}
