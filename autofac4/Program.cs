using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
namespace autofac4
{
    class Program
    {
        static void Main(string[] args)
        {

            //创建容器工厂
            var builder = new ContainerBuilder();
            //注册Test类到工厂中

            builder.RegisterType<Test>();
            //获取解析Test 类，返回test 实例
            using (var container = builder.Build())
            {
                var test = container.Resolve<Test>(new NamedParameter("name", "Hans"));
                test.Hello();
            }

            Console.ReadLine();
        }
    }
    public class Test
    {
        public Test(string name)
        {
            Console.WriteLine("Hello " + name);
        }

        public void Hello()
        {
            Console.WriteLine("你好啊，同学");
        }
    }
}
