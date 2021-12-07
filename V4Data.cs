using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab2
{
    delegate Vector2 Fv2Vector2(Vector2 v2);
    [Serializable]
    abstract class V4Data: IEnumerable<DataItem>
    {
        public string IDString { get; protected set; }
        public DateTime Date { get; protected set; }
        public V4Data(string IDString, DateTime Date)
        {
            this.IDString = IDString;
            this.Date = Date;
        }
        public override string ToString() => $"ID = {IDString} Date = {Date.ToShortDateString() }";
        public abstract int Count { get; }
        public abstract float MaxFromOrigin { get; }
        public abstract string ToLongString(string format);
        public abstract IEnumerator<DataItem> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
             return GetEnumerator();
        }
    }
}
