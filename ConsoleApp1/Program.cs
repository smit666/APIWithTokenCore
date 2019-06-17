using System;

namespace ConsoleApp1
{
   
    class Program
    {

       

        static void Main(string[] args)
        {
           // name = "";
            Test2 tt = new Test2();
            tt.GetDD();
            tt.Test();
            ISupplier obj = CarFactory.GiveMyCar(0);
            obj.CarSupplier();
            obj = CarFactory.GiveMyCar(1);
            obj.CarSupplier();

            TestType t = new TestType();
            string a = t.GetValue();
            Console.Write(a);
            Console.ReadLine();

            //singletone design pattern  
            //singleTon s = singleTon.Instance;
            //s.Data = 100;
            //Console.WriteLine("Data of S object : " + s.Data);
            //singleTon s1 = singleTon.Instance;
            //Console.WriteLine("Data of S1 object : " + s.Data);
            //Console.ReadLine();


            //Console.WriteLine("Hello World!");
            //Customer cu = new Customer(new OracleServer());
            //cu.cusAdd();
            //Console.ReadKey();
        }
    }

    abstract class Test1
    {
        public string Test()
        {
            return "asds";
        }
        public abstract int mul(int i, int j);
    }
    class Test2:Test1
    {
        public void GetDD()
        {

        }
        public override int mul(int i, int j)
        {
            return i * j;
        }

    }

    class Test3 : Test1
    {
        public void GetDD()
        {

        }

        public override int mul(int i, int j)
        {
            return i + j;
        }
    }

    class Customer
    {
        private Idal dal;
        public Customer(Idal objDal)
        {
            dal = objDal;
        }
        public void cusAdd()
        {
            dal.Add();
        }
       
    }

    interface Idal
    {
        void Add();
    }

    class SqlServer:Idal
    {
        public void Add()
        {
            Console.WriteLine("Sql Server Add");
        }
    }
    class OracleServer : Idal
    {
      
      //  Smit s = new Smit();
        public void Add()
        {
         
            Console.WriteLine("Oracle Server Add");
        }
    }

     class Smit
    {
        enum Mode{ Admin,User,Twar}
        public void GetData()
        {
          //  if(Mode.Admin)
            Console.WriteLine(" Add");

        }
    }

}
