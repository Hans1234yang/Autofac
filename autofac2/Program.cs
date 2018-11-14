using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofac2
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();   ///定义容器工厂

            builder.RegisterType<CatInterceptor>();   //注册猫拦截器类 

            //注册Cat类 ,为其添加拦截器
            builder.RegisterType<Cat>().As<ICat>().InterceptedBy(typeof(CatInterceptor)).EnableInterfaceInterceptors();

            //获取容器
            var container = builder.Build();
            //解析Cat类，获取Cat实例
            var cat = container.Resolve<ICat>();
            cat.Eat();

            Console.ReadLine();

            cat.Drink();
            Console.ReadLine();

        }
    }
    /// <summary>
    /// 定义一个拦截器        
    /// </summary>
    public class CatInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("猫吃东西前，在睡觉");
            invocation.Proceed();
            Console.WriteLine("猫吃东西后，在唱歌");
        }
    }

    public interface ICat
    {
        void Eat();

        void Drink();
    }

    public class Cat : ICat
    {
        public void Eat()
        {
            Console.WriteLine("猫在吃红烧鱼");
        }

        public void Drink()
        {
            Console.WriteLine("猫在喝水");
        }
    }
}
