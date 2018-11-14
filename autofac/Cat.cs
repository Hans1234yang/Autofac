using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofac
{
    //猫类 
    public class Cat : ICat
    {
        public void Eat()
        {
            Console.WriteLine("猫在吃东西");
        }
    }

    //猫的代理类  //猫的代理类 可以调用 猫类的方法
    public class CatProxy : ICat
    {
        ICat iCat;
        public CatProxy(ICat _iCat)
        {
            iCat = _iCat;
        }

        public void Eat()
        {
            this.EatBefore();
            iCat.Eat();
            this.EatAfter();
        }

        public void EatBefore()
        {
            Console.WriteLine("猫吃东西前，在睡觉");
        }
        public void EatAfter()
        {
            Console.WriteLine("猫吃完了东西，在唱歌");
        }
    }
}
