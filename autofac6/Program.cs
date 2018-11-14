using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
namespace autofac6
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建容器工厂
            var builder = new ContainerBuilder();

            //注册猫拦截器类
            builder.RegisterType<CatInterceptor>();

            //注册猫类  因为Attribute 绑定了哪个拦截器类型，所以不需要在注册猫的时候，指定哪一个拦截类
            builder.RegisterType<Cat>().As<ICat>().EnableInterfaceInterceptors();

            //创建容器
            var container = builder.Build();

            //获取猫实例
            var cat = container.Resolve<ICat>();

            cat.Eat();
            Console.ReadLine();
        }
    }

    public interface ICat
    {
        void Eat();
    }

    [Intercept(typeof(CatInterceptor))]
    public class Cat : ICat
    {
        public void Eat()
        {
            Console.WriteLine("猫在吃红烧鱼");
        }
    }


    public class CatInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("猫吃东西之前");
            invocation.Proceed();
            Console.WriteLine("猫吃东西之后");
        }
    }
}
