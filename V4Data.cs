using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Lab1
{
    delegate Vector2 Fv2Vector2(Vector2 v2);
    abstract class V4Data
    {
        public string IDString { get; }
        public DateTime Date { get; }
        public V4Data(string IDString, DateTime Date)
        {
            this.IDString = IDString;
            this.Date = Date;
        }
        public override string ToString() => $"ID = {IDString} Date = {Date.ToShortDateString() }";
        public abstract int Count { get; }
        public abstract float MaxFromOrigin { get; }
        public abstract string ToLongString(string format);
    }
}
