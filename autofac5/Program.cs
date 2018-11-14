using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofac5
{
    //注入高级对象
    class Program
    {
        static void Main(string[] args)
        {
            //创建容器工厂
            var builder = new ContainerBuilder();

            //注册Test 类
            builder.RegisterType<Test>();


            //注入Say类和ISay接口
            builder.RegisterType<Say>().As<ISay>();

            //创建容器
            var container = builder.Build();

            //解析test 返回Test 实例
            var test1 = container.Resolve<Test>();
            test1.Weather();

            Console.ReadLine();
        }
    }
    public class Test
    {
        public Test(ISay say)  //构造方法输出东西
        {
            Console.WriteLine($"大声说 {say}");
        }

        public void Weather()
        {
            Console.WriteLine("深圳要下暴雨");
        }
    }

    /// <summary>
    /// 实现接口
    /// </summary>
    public class Say : ISay
    {
        public string Get()
        {
            return "Hello world";
        }
    }

    /// <summary>
    /// 先定义一个接口
    /// </summary>
    public interface ISay
    {
        string Get();
    }
}
