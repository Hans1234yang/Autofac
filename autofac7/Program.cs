using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace autofac7
{
    class Program
    {
        static void Main(string[] args)
        {
            //容器工厂
            var builder = new ContainerBuilder();

            //注册猫类
            builder.RegisterType<Cat>().As<ICat>();

            //注册猫拦截器类
            builder.RegisterType<CatInterceptor>();

            //注册猫主人类，并且绑定了猫拦截器的方法
            builder.RegisterType<CatOwner>().InterceptedBy(typeof(CatInterceptor))
                .EnableClassInterceptors(ProxyGenerationOptions.Default,additionalInterfaces:
            typeof(ICat));

            //定义容器
            var container = builder.Build();

            //获取猫主人的 实例
            var catOwner1 = container.Resolve<CatOwner>();

            catOwner1.GetType().GetMethod("Eat").Invoke(catOwner1,null);    ///比较难，目前看不是很懂

            Console.ReadLine();

        }
    }

    //猫接口
    public interface ICat
    {
        void Eat();
    }

    //猫类
    public class Cat : ICat
    {
        public void Eat()
        {
            Console.WriteLine("猫在吃东西 ");
        }
    }


    //猫主人类
    public class CatOwner
    {

    }

    //猫拦截器类
    public class CatInterceptor : IInterceptor
    {
        private ICat icat;
        public CatInterceptor(ICat _icat)
        {
            icat = _icat;
        }

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("喂猫吃东西");
            invocation.Method.Invoke(icat, invocation.Arguments);   //调用cat指定的方法
        }
    }
}
