using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enum_test
{
    /*Создайте класс Кошка. У кошки будет свойство «уровень сытости» и метод «съесть что-то». 
     * Создайте перечисление Еда (рыба, мышь…). Каждый вид еды должен по-разному изменять уровень сытости.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            cat.prnt();
            cat.EatSmth(Food.fish);
            cat.prnt();
            cat.EatSmth(Food.mouse);
            cat.prnt();
            Console.ReadKey();

        }
    }


    enum Food : int { mouse = 50 , fish = 20 };

    class Cat
    {
        private int satiety;

        public void EatSmth(Food smth)
        {
            this.satiety = this.satiety + (int)smth;
        }

        public Cat()
        {
            satiety = 0;  
        }

        public void prnt()
        {
            Console.WriteLine(this.satiety);
        }
    }

}
