using Lab2;
using System;
using System.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        static void LINQ()
        {
            V4MainCollection v4MainCollection = new V4MainCollection();
            Console.WriteLine(v4MainCollection.ToLongString("0.000"));
            Console.WriteLine("\n\nMax abs(value): \n");
            Console.WriteLine(v4MainCollection.MaxDistance.ToString());
            Console.WriteLine("\n\nIEnumerable<DataItem> sorted results: \n");
            if (v4MainCollection.V4DLNoneZ != null)
            {
                foreach (var x in v4MainCollection.V4DLNoneZ)
                {
                    Console.WriteLine(x);
                }
            }
            else Console.WriteLine("-");
            Console.WriteLine("\n\nIEnumerable<Vector2> only in DataArray:  \n");
            if (v4MainCollection.AllPoints != null)
            {
                foreach (var x in v4MainCollection.AllPoints)
                {
                    Console.WriteLine(x);
                }
            }
            else Console.WriteLine("-");
            V4DataArray v4DataArray1 = new V4DataArray("V4DataArray1", DateTime.Now, 1, 3, new Vector2(2.0f, 4.0f), DelegateFunction.Fv2);
            V4DataArray v4DataArray2 = new V4DataArray("V4DataArray2", DateTime.Now, 3, 2, new Vector2(1.0f, 0.5f), DelegateFunction.Fv2);
            V4DataArray v4DataArray3 = new V4DataArray("V4DataArray", DateTime.Now, 2, 0, new Vector2(0.4f, 0.6f), DelegateFunction.Fv2);
            v4MainCollection.Add(v4DataArray1);
            v4MainCollection.Add(v4DataArray2);
            v4MainCollection.Add(v4DataArray3);
            V4DataList v4DataList1 = new V4DataList("V4DataList1", DateTime.Now);
            v4DataList1.Add(new DataItem(new Vector2(5.0f, 7.0f), new Vector2(0.1f, 0.2f)));
            v4DataList1.Add(new DataItem(new Vector2(10.0f, 2.5f), new Vector2(4.2f, 1.4f)));
            v4DataList1.Add(new DataItem(new Vector2(0.4f, 11.0f), new Vector2(2.0f, 2.0f)));
            V4DataList v4DataList2 = new V4DataList("V4DataList2", DateTime.Now);
            v4DataList2.Add(new DataItem(new Vector2(1.2f, 3.6f), new Vector2(1.0f, 3.0f)));
            v4DataList2.Add(new DataItem(new Vector2(3f, 2f), new Vector2(5f, 6f)));
            v4DataList2.Add(new DataItem(new Vector2(0f, 0f), new Vector2(0f, 0f)));
            V4DataList v4DataList3 = new V4DataList("V4DataList3", DateTime.Now);
            v4MainCollection.Add(v4DataList1);
            v4MainCollection.Add(v4DataList2);
            v4MainCollection.Add(v4DataList3);
            Console.WriteLine(v4MainCollection.ToLongString("0.000"));
            Console.WriteLine("\n\nMax abs(value): \n");
            Console.WriteLine(v4MainCollection.MaxDistance.ToString());
            Console.WriteLine("\n\nIEnumerable<DataItem> sorted results: \n");
            if (v4MainCollection.V4DLNoneZ != null)
            {
                foreach (var x in v4MainCollection.V4DLNoneZ)
                {
                    Console.WriteLine(x);
                }
            }
            Console.WriteLine("\n\nIEnumerable<Vector2> only in DataArray: \n");
            if (v4MainCollection.AllPoints != null)
            {
                foreach (var x in v4MainCollection.AllPoints)
                {
                    Console.WriteLine(x);
                }
            }
        }
        static void SaveLoad()
        {
            Console.WriteLine("\n===DATA ARRAY===\n");
            V4DataArray v4DataArray1 = new V4DataArray("V4DataArray", DateTime.Now, 3, 2, new Vector2(1.0f, 0.5f), DelegateFunction.Fv2);
            v4DataArray1.SaveBinary("V4DA");
            V4DataArray v4DataArray2 = new V4DataArray("-", DateTime.Now);
            v4DataArray2.LoadBinary("V4DA", ref v4DataArray2);
            Console.WriteLine(v4DataArray1.ToLongString("0.00"));
            Console.WriteLine(v4DataArray2.ToLongString("0.00"));

            Console.WriteLine("\n===DATA LIST===\n");
            V4DataList v4DataList1 = new V4DataList("V4DataList1", DateTime.Now);
            v4DataList1.Add(new DataItem(new Vector2(5.0f, 7.0f), new Vector2(0.1f, 0.2f)));
            v4DataList1.Add(new DataItem(new Vector2(10.0f, 2.5f), new Vector2(4.2f, 1.4f)));
            v4DataList1.Add(new DataItem(new Vector2(0.4f, 11.0f), new Vector2(2.0f, 2.0f)));
            v4DataList1.SaveAsText("V4DL");
            V4DataList v4DataList2 = new V4DataList("-", DateTime.Now);
            v4DataList2.LoadAsText("V4DL", ref v4DataList2);
            Console.WriteLine(v4DataList1.ToLongString("0.00"));
            Console.WriteLine(v4DataList2.ToLongString("0.00"));
        }
        static void Main()
        {
            Console.WriteLine("------------LINQ------------");
            LINQ();
            Console.WriteLine("------------LINQ-end-------------\n\n");


            Console.WriteLine("------------SaveLoad-----------");
            SaveLoad();
            Console.WriteLine("------------SaveLoad-end-------------\n\n");


            /*Console.WriteLine("------------start3-----------");
            for (int i = 0; i < v4MainCollection.Count; i++)
            {
                Console.WriteLine($"Count{i+1} = {v4MainCollection[i].Count}");
                Console.WriteLine($"MaxFromOrigin{i+1} = {v4MainCollection[i].MaxFromOrigin}");
            }
            Console.WriteLine("------------end3-------------\n\n");

            Console.WriteLine(v4MainCollection.ToString());
            V4DataList v4DL = new V4DataList("V4DataList1", DateTime.Now);
            v4DL.AddDefaults(7, DelegateFunction.Fv2);
            //Console.WriteLine(v4DL.ToString());
            //Console.WriteLine(v4DL.ToLongString("00.000"));*/
        }
   }
}
