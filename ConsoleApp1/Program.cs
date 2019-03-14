using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Customer cu = new Customer(new OracleServer());
            cu.cusAdd();
            Console.ReadKey();
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
        public void Add()
        {
            Console.WriteLine("Oracle Server Add");
        }
    }

}
