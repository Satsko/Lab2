using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace Lab1
{
    class V4DataArray : V4Data
    {
        public int X { get; }
        public int Y { get; }
        public Vector2 Step { get; }
        public Vector2[,] Node { get; }
        public V4DataArray(string IDString, DateTime date) : base(IDString, date)
        {
            this.Node = new Vector2[0, 0];
        }
        public V4DataArray(string IDString, DateTime date, int x, int y, Vector2 step, Fv2Vector2 node) : base(IDString, date)
        {
            this.X = x;
            this.Y = y;
            this.Step = step;
            this.Node = new Vector2[x, y];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                {
                    this.Node[i, j] = node(new Vector2(i * step.X, j * step.Y));
                }
        }
        public override int Count { get { return Node.Length; } }
        public override float MaxFromOrigin
        {
            get 
            {
                if (Count!=0) return Vector2.Distance(Vector2.Zero, new Vector2((X - 1) * Step.X, (Y - 1) * Step.Y));
                else return 0;
            }
        }
        public override string ToString() => $"V4DataArray {base.ToString()} \nnX = {X}, nY = {Y}, Step({Step.X},{Step.Y})";
        public override string ToLongString(string format)
        {
            string str = ToString();
            for (int i = 0; i < X; i++)
                for (int j = 0; j < Y; j++)
                {
                    str += $"\n({(i * Step.X).ToString(format)},{(j * Step.Y).ToString(format)}):  ({(Node[i, j].X).ToString(format)},{(Node[i, j].Y).ToString(format)}),  |({Node[i, j].X.ToString(format)},{Node[i, j].Y.ToString(format)})| = {Vector2.Distance(Vector2.Zero, Node[i, j])} ";
                }
            return str;
        }
        public V4DataList TransForm()
        {
            V4DataList V4DL = new V4DataList(IDString, Date);
            Vector2 v21 = new Vector2();
            Vector2 v22 = new Vector2();
            for (int i = 0; i < X; i++)
                for (int j = 0; j < Y; j++)
                {
                    v21.X = i * Step.X;
                    v21.Y = j * Step.Y;
                    v22.X = Node[i, j].X;
                    v22.Y = Node[i, j].Y;
                    DataItem DI = new DataItem(v21, v22);
                    V4DL.Add(DI);
                }
            return V4DL;
        }
    }
}