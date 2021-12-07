using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Numerics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace Lab2
{
    [Serializable]
    class V4DataList : V4Data, IEnumerable<DataItem>
    {
        List<DataItem> Lst { get; set; }
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

        public override IEnumerator<DataItem> GetEnumerator()
        {
            return Lst.GetEnumerator();
        }

        public bool SaveAsText(string filename)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filename, false);
                writer.WriteLine(IDString);
                writer.WriteLine(Date.ToString("dd.MM.yyyy HH:mm:ss"));
                for (int i = 0; i < Lst.Count; i++)
                {
                    writer.WriteLine(Lst[i].Point.X);
                    writer.WriteLine(Lst[i].Point.Y);
                    writer.WriteLine(Lst[i].Value.X);
                    writer.WriteLine(Lst[i].Value.Y);
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
                if (writer != null) writer.Close();
            }
        }

        public bool LoadAsText(string filename, ref V4DataList v4)
        {
            StreamReader reader = null;
            v4 = new V4DataList("-", DateTime.Now);
            v4.Lst = new List<DataItem>();
            try
            {
                if (!File.Exists(filename)) return false;
                reader = new StreamReader(filename);
                string idstr = reader.ReadLine();
                v4.IDString = idstr;
                DateTime date = DateTime.ParseExact(reader.ReadLine(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                v4.Date = date;
                while (reader.Peek()>-1)
                {
                    float x = float.Parse(reader.ReadLine());
                    float y = float.Parse(reader.ReadLine());
                    float xval = float.Parse(reader.ReadLine());
                    float yval = float.Parse(reader.ReadLine());
                    v4.Lst.Add(new DataItem(new Vector2(x,y), new Vector2(xval,yval)));
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
                if (reader != null) reader.Close();
            }
        }
    }
}