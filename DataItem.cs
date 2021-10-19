using System;
using System.Numerics;

namespace Lab1
{
    struct DataItem
    {
        public Vector2 Point { get; set; }
        public Vector2 Value { get; set; }
        public DataItem(Vector2 Point, Vector2 Value)
        {
            this.Point = Point;
            this.Value = Value;
        }
        public override string ToString() => $"({Point.X},{Point.Y}):  ({Value.X},{Value.Y})";
        public string ToLongString(string format)
        {
            return $"({Point.X.ToString(format)},{Point.Y.ToString(format)}):  ({Value.X.ToString(format)},{Value.Y.ToString(format)}),  |({Value.X.ToString(format)},{Value.Y.ToString(format)})| = {Vector2.Distance(Vector2.Zero, Value)} ";
        }
    }
}