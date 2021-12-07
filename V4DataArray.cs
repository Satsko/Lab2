using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace Lab2
{
    [Serializable]
    class V4DataArray : V4Data, IEnumerable<DataItem>, ISerializable
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Vector2 Step { get; private set; }
        public Vector2[,] Node { get; private set; }
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

        public override IEnumerator<DataItem> GetEnumerator()
        {
            for (int i = 0; i < X; i++)
                for (int j = 0; j < Y; j++)
                {
                    yield return new DataItem(new Vector2(i * Step.X, j * Step.Y), Node[i,j]);
                }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IDString", IDString);
            info.AddValue("date", Date);
            info.AddValue("X", X);
            info.AddValue("Y", Y);
            info.AddValue("Step", Step);
            info.AddValue("Node", Node);
        }

        public bool SaveBinary(string filename)
        {
            FileStream file = null;
            try
            {
                file = File.Open(filename, FileMode.OpenOrCreate);
                BinaryWriter writer = new BinaryWriter(file);
                writer.Write(IDString);
                writer.Write(Date.ToString("dd.MM.yyyy HH:mm:ss"));
                writer.Write(X);
                writer.Write(Y);
                writer.Write(Step.X.ToString());
                writer.Write(Step.Y.ToString());
                for (int i = 0; i < X; i++)
                    for (int j = 0; j < Y; j++)
                    {
                        writer.Write(Node[i, j].X.ToString());
                        writer.Write(Node[i, j].Y.ToString());
                    }
                writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption: {ex.Message}");
                return false;
            }
            finally
            {
                if (file != null) file.Close();
            }
        }

        public bool LoadBinary(string filename, ref V4DataArray v4)
        {
            FileStream file = null;
            try
            {
                if (!File.Exists(filename)) return false;
                file = File.Open(filename, FileMode.Open);
                BinaryReader reader = new BinaryReader(file);
                string idstr = reader.ReadString();
                v4.IDString = idstr;
                DateTime date = DateTime.ParseExact(reader.ReadString(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                v4.Date = date;
                v4.X = reader.ReadInt32();
                v4.Y = reader.ReadInt32();
                v4.Step = new Vector2(float.Parse(reader.ReadString()), float.Parse(reader.ReadString()));
                v4.Node = new Vector2[v4.X, v4.Y];
                for (int i = 0; i < v4.X; i++)
                    for (int j = 0; j < v4.Y; j++)
                    {
                        v4.Node[i, j] = new Vector2(float.Parse(reader.ReadString()), float.Parse(reader.ReadString()));
                    }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption: {ex.Message}");
                return false;
            }
            finally 
            {
                if (file != null) file.Close();
            }
        }
    }
}