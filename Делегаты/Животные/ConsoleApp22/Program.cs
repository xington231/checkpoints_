using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    internal class Program
    {
        
        public abstract class Animal
        {
            public string Name { get; set; }
            public Animal(string name)
            {
                Name = name;
            }
            public abstract void SayHello();

        }

        class Dog : Animal
        {
            public Dog(string name) : base(name) { }
            public override void SayHello()
            {
                Console.WriteLine($"Привет,я собака! Меня зовут {Name}!");
            }
        }
        class Cat : Animal
        {
            public Cat(string name) : base(name) { }
            public override void SayHello()
            {
                Console.WriteLine($"Привет,я кошка! Меня зовут {Name}!");
            }
        }
        static void Animals(List<Animal> animals, Action<Animal> action)
        {
            foreach (var animal in animals)
            {
                action(animal);
            }
        }
        delegate void AnimalAction(Animal a);

        static void Main(string[] args)
        {
            Dog Rax = new Dog("Рэкс");
            Cat Murka = new Cat("Мурка");
            Rax.SayHello();
            Murka.SayHello();
            var animals = new List<Animal>
            {
                new Dog("Рэкс"),
                new Cat("Мурка")
            };

            Animals(animals, animal => animal.SayHello());


        }
    }
}
