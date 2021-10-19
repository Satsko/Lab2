using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class V4MainCollection
    {
        List<V4Data> V4Lst;
        public V4MainCollection()
        {
            this.V4Lst = new List<V4Data>();
        }
        public int Count { get { return V4Lst.Count; } }
        public V4Data this[int id]
        {
            get { if (V4Lst.Count <= id) return V4Lst[0]; else return V4Lst[id]; }
        }
        public bool Contains(string ID)
        {
            return V4Lst.Exists(x => (x.IDString == ID));
        }
        public bool Add(V4Data v4Data)
        {
            if (!Contains(v4Data.IDString))
            { this.V4Lst.Add(v4Data); return true; }
            else { return false; }
        }
        public override string ToString()
        {
            string str = "V4MainCollection\n";
            //foreach (V4Data i in this.V4Lst) str += "\n" + i.ToString();
            str += string.Join("\n", V4Lst);
            return str;
        }
        public string ToLongString(string format)
        {
            string str = "V4MainCollection";
            foreach (V4Data i in V4Lst) str += "\n" + i.ToLongString(format);
            //str += string.Join("\n", V4Lst);
            return str;
        }
    }
}
