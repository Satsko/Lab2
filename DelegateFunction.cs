using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Lab1
{
    public static class DelegateFunction
    {
        public static Vector2 Fv2(Vector2 v2)
        {
            Vector2 v0 = v2;
            v2.X = v0.Y;
            v2.Y = v0.X;
            return v2;
        }
    }
}
