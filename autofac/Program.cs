using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            ICat cat1 = new Cat();

            ICat catProxy = new CatProxy(cat1);

            catProxy.Eat();
            Console.ReadLine();

        }
    }
}
