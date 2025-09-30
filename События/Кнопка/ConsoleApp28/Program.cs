using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    public class Button
    {
        public string Text { get; set;}
        private EventHandler click;
        public event EventHandler Click
        {
            add
            {
                var subscribers = click?.GetInvocationList();
                if (subscribers != null)
                {
                    if (subscribers.Contains(value))
                    {
                        Console.WriteLine("Этот подписчик уже добавлен!");
                        return;
                    }

                    if (subscribers.Length >= 3)
                    {
                        Console.WriteLine("Достигнуто максимальное количество подписчиков(3)");
                        return;
                    }
                }

                click += value;

            }
            remove
            {
                click -= value;
            }
        }

        public void PrintText(object sender, EventArgs e)
        {
            Console.WriteLine("Текст кнопки: " + Text);
        }
        public void ChangeColor(object sender, EventArgs e)
        {
            Console.WriteLine("Выберите цвет(Red,Green,Blue)"); 
            string color = Console.ReadLine();
            Console.WriteLine("Вы выбрали цвет: "+color);
        }
        public void OnClick()
        {
            click?.Invoke(this, EventArgs.Empty);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Button button = new Button { Text = "кнопка" };
            button.Click += button.PrintText;
            button.Click += button.ChangeColor;
            button.OnClick();

        }
    }
}
