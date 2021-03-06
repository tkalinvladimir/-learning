﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abstraction
// абстрактные классы
// нельзя создать с помощью new
// унаследовать обычный класс от абстрактного - можно. и создать его с помощью new
// Абстрактный класс не может иметь модификатор sealed. - сиелд означает что класс нельзя наследовать
// Что нужно запомнить: Абстрактный класс не может иметь модификатор static.
// Если мы хотим объявить метод в абстрактном классе, но не реализовывать его, к методу нужно добавить ключевое слово abstract;
// Если мы объявляем абстрактный метод в абстрактном классе, то этот метод должен реализовываться в неабстрактных наследниках этого класса;
// Абстрактные методы могут быть объявлены только в абстрактных классах
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //ClassA a = new ClassA(); // - так не скомпилируется
            ClassB b = new ClassB();
            Console.ReadKey();
            */
            ClassA a = new ClassC();
            ClassB b = new ClassC();
            a.XXX();
            b.XXX();
            Console.ReadKey();
        }
    }
}
