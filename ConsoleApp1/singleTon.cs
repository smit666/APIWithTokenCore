using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public sealed class singleTon
    {

        public Int32 Data = 0;
        private static singleTon instance;
        private static object syncRoot = new Object(); //For locking mechanism  
        private singleTon() { } //Private constructor  
        public  static singleTon Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new singleTon();
                    }
                }
                return instance;
            }

        }
    }

    public interface ISupplier
    {
        void CarSupplier();
    }
    class namo : ISupplier
    {
        public void CarSupplier()
        {
            Console.WriteLine("I am nano supplier");
        }
    }
    class alto : ISupplier
    {
        public void CarSupplier()
        {
            Console.WriteLine("I am Alto supplier");
        }
    }
    class CarFactory
    {
       

        public static ISupplier GiveMyCar(int Key)
        {
            if (Key == 0)
                return new namo();
            else if (Key == 1)
                return new alto();
            else
                return null;
        }

     
    }

    public class TestType
    {
        public readonly string name = "Smit";

        public TestType()
        {
            //name = "Thakur";
        }
        public string GetValue()
        {
            // string a= name;
            return name;
        }
    }



}
