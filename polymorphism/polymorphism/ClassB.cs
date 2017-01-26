using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphism
{
    public class ClassB:ClassA
    {
        public override void AAA()
        {
            Console.WriteLine("ClassB AAA");
        }
        public new void BBB()
        {
            Console.WriteLine("ClassB BBB");
        }
        public void CCC()
        {
            Console.WriteLine("ClassB CCC");
        }
        public override void XXX()
        {
            base.XXX();
            Console.WriteLine("ClassB XXX");
        }
        public override void ZZZ()
        {
            ((ClassA)this).ZZZ(); // рекурсия. создает объект типа классБ в ссылке классА
            Console.WriteLine("ClassB ZZZ");
        }
    }
}
