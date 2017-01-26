using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphism
{
    public class ClassA
    {
        public virtual void AAA()
        {
            Console.WriteLine("ClassA AAA");
        }
        public virtual void BBB()
        {
            Console.WriteLine("ClassA BBB");
        }
        public virtual void CCC()
        {
            Console.WriteLine("ClassA CCC");
        }
        public virtual void XXX()
        {
            Console.WriteLine("ClassA XXX");
        }
        public virtual void ZZZ()
        {
            Console.WriteLine("ClassA ZZZ");
        }
    }
}
