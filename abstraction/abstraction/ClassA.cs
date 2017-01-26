using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstraction
{
    public abstract class ClassA
    {
        public int a;
        public virtual void XXX()
        {
            Console.WriteLine("ClassA XXX");
        }

        //public void YYY(); // Так нельзя
        abstract public void YYY(); // так можно - объявляем метод в абстрактном классе и при этом хотим, чтобы его конкретное поведение было определено в производных классах
    }
}
