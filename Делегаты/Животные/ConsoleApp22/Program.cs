using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp22.Program;

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
        static void ActionAnimals(List<Animal> animals, Action<Animal> action)
        {
            foreach (var animal in animals)
            {
                action(animal);
            }
        }
        static void ActionAnimal(Animal animal)
        {
            Console.WriteLine(animal.Name);
        }

        static void ActionDog(Dog dog)
        {
            Console.WriteLine(dog.Name);
        }

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

            ActionAnimals(animals, animal => animal.SayHello());

            //ковариантность,присваиваем список собак переменной,которой ожидает список животных
            List<Dog> dogs = new List<Dog>
            {
                new Dog("Рэкс"),
                new Dog("Арчи")
            };
            List<Animal> animals1 = new List<Animal>(dogs);
            //контрвариантность,ActionAnimal принимает Animal, а actionDog ожидает Dog 
            Action<Dog> actionDog = ActionAnimal;
            actionDog(new Dog("Алекс"));


        }
    }
}
