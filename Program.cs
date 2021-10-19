using Lab1;
using System;
using System.Numerics;

namespace ConsoleApp1
{
   class Program
   {
        static void Main()
        {
            Console.WriteLine("------------start1------------");
            V4DataArray v4DataArray = new V4DataArray("V4DataArray", DateTime.Now, 2, 0, new Vector2(0.4f,0.6f), DelegateFunction.Fv2);
            Console.WriteLine(v4DataArray.ToLongString("0.00"));
            V4DataList v4DataList = v4DataArray.TransForm();
            Console.WriteLine(v4DataList.ToLongString("0.00"));
            Console.WriteLine($"Count V4DataArray = {v4DataArray.Count}");
            Console.WriteLine($"Count V4DataList = {v4DataList.Count}");
            Console.WriteLine($"MaxFromOrigin V4DataArray = {v4DataArray.MaxFromOrigin}");
            Console.WriteLine($"MaxFromOrigin V4DataList = {v4DataList.MaxFromOrigin}");
            Console.WriteLine("------------end1-------------\n\n");


            Console.WriteLine("------------start2-----------");
            V4MainCollection v4MainCollection = new V4MainCollection();
            V4DataArray v4DataArray1 = new V4DataArray("V4DataArray1", DateTime.Now, 1, 3, new Vector2(2.0f, 4.0f), DelegateFunction.Fv2);
            V4DataArray v4DataArray2 = new V4DataArray("V4DataArray2", DateTime.Now, 3, 2, new Vector2(1.0f, 0.5f), DelegateFunction.Fv2);
            v4MainCollection.Add(v4DataArray1);
            v4MainCollection.Add(v4DataArray2);
            V4DataList v4DataList1 = new V4DataList("V4DataList1", DateTime.Now);
            v4DataList1.Add(new DataItem(new Vector2(5.0f,7.0f), new Vector2(0.1f,0.2f)));
            v4DataList1.Add(new DataItem(new Vector2(10.0f,2.5f), new Vector2(4.2f, 1.4f)));
            v4DataList1.Add(new DataItem(new Vector2(0.4f,11.0f), new Vector2(2.0f,2.0f)));
            V4DataList v4DataList2 = new V4DataList("V4DataList2", DateTime.Now);
            v4DataList2.Add(new DataItem(new Vector2(1.2f,3.6f), new Vector2(1.0f,3.0f)));
            v4DataList2.Add(new DataItem(new Vector2(3f,2f), new Vector2(5f,6f)));
            v4MainCollection.Add(v4DataList1);
            v4MainCollection.Add(v4DataList2);
            Console.WriteLine(v4MainCollection.ToLongString("0.000"));
            Console.WriteLine("------------end2-------------\n\n");


            Console.WriteLine("------------start3-----------");
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
            //Console.WriteLine(v4DL.ToLongString("00.000"));
        }
   }
}
