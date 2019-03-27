using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;

namespace Appoa.Common
{
    public class YBDConvertToHashtable
    {
        public static HashSet<Hashtable> ConvertToHashSet(DataTable dt)
        {
            HashSet<Hashtable> hs = new HashSet<Hashtable>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Hashtable hash = new Hashtable();
                DataRow row = dt.Rows[i];
                for (int j = 0; j < row.Table.Columns.Count; j++)
                {
                    hash.Add(row.Table.Columns[j].ColumnName, row[j]);
                }
                hs.Add(hash);
            }
            return hs;
        }
        public static Hashtable ConvertToHashtable(DataRow row)
        {
            Hashtable hash = new Hashtable();
            for (int j = 0; j < row.Table.Columns.Count; j++)
            {
                hash.Add(row.Table.Columns[j].ColumnName, row[j]);
            }
            return hash;
        }
        public static Hashtable ConvertToHashtable(object o)
        {
            Hashtable _ht = new Hashtable();
            PropertyInfo[] propertyInfos = o.GetType().GetProperties();
            foreach (PropertyInfo item in propertyInfos)
            {
                _ht.Add(item.Name, item.GetValue(o, null));
            }
            return _ht;
        }
    }
}
