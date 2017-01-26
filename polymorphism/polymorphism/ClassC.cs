using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polymorphism
{
    public class ClassC:ClassB
    {
        public override void XXX()
        {
            base.XXX();
            Console.WriteLine("ClassC XXX");
        }
    }
}
