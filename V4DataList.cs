using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Lab1
{
    class V4DataList : V4Data
    {
        public List<DataItem> Lst { get; }
        public V4DataList(string IDString, DateTime date) : base(IDString, date)
        {
            this.Lst = new List<DataItem>();
        }
        public bool Add(DataItem newitem)
        {
            if (!Lst.Exists(x => (x.Point.X == newitem.Point.X) && (x.Point.Y == newitem.Point.Y)))
            { this.Lst.Add(newitem); return true; }
            else { return false; }
        }
        public int AddDefaults(int nitems, Fv2Vector2 F)
        {
            int n = 0;
            System.Random rnd = new Random();
            Vector2 v2 = new Vector2();
            for (int i = 0; i < nitems; i++)
            {
                v2.X = ((float)rnd.NextDouble()) * nitems;
                v2.Y = ((float)rnd.NextDouble()) * nitems;
                DataItem DI = new DataItem(v2, F(v2));
                n += Convert.ToInt32(this.Add(DI));
            }
            return n;
        }
        public override int Count { get { return Lst.Count(); } }
        public override float MaxFromOrigin
        {
            get 
            {
                if (Count != 0) return Lst.Max(x => Vector2.Distance(Vector2.Zero, x.Point));
                else return 0;
            }
        }
        public override string ToString()
        {
            return $"V4DataList {base.ToString()} Count = {Count}";
        }
        public override string ToLongString(string format)
        {
            string str = $"V4DataList {base.ToString()} Count = {Count}";
            foreach (DataItem i in Lst) str += "\n" + i.ToLongString(format);
            //str += string.Join("\n", Lst);
            return str;
        }
    }
}