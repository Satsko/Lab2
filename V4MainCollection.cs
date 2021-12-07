using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;

namespace Lab2
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

        public float MaxDistance
        {
            get
            {
                if (V4Lst.Count == 0) { return float.NaN; }
                var Items = from item in V4Lst.OfType<V4DataArray>()
                            from item2 in item
                            select Vector2.Distance(Vector2.Zero, item2.Value);
                float res = Items.Max();
                return res;
            }
        }

        public IEnumerable<Vector2> AllPoints
        {
            get 
            {
                var res1 = from item1 in V4Lst.OfType<V4DataArray>()
                          from item2 in item1
                          select item2.Point;
                var res2 = from item1 in V4Lst.OfType<V4DataList>()
                          from item2 in item1
                          select item2.Point;
                var res = res1.Except(res2).Distinct();
                if (res.Any()) { return res; }
                else { return null; }
            }
        }

        public IEnumerable<DataItem> V4DLNoneZ
        {
            get
            {
                var Items = from item in V4Lst
                            from item2 in item
                            select item2;
                var res = Items.OrderBy(x => Vector2.Distance(Vector2.Zero, x.Point));
                if (res.Any()) { return res.Reverse().Distinct(); }
                else { return null; }

            }
        }

    }
}
