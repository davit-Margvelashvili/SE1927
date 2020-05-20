using System;
using Shooter.Core;
using Shooter.Core.Abstractions;
using Shooter.Core.Implementations;
using Shooter.Core.Implementations.Transport;
using Shooter.Core.Implementations.Weapons;

namespace Shooter.ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var player1 = new Player
            {
                Name = "Player 1"
            };

            player1.BuyWeapon(new Glock47());

            var player2 = new Player()
            {
                Name = "Player 2"
            };

            player2.BuyWeapon(new Glock47());

            while (player1.IsAlive || player2.IsAlive)
            {
                player1.TakeDamage(player2.Shoot());

                Console.WriteLine($"{player2.Name} shoot to {player1.Name}");
                Console.WriteLine($"{player1.Name } Health: {player1.Health} ");

                if (!player1.IsAlive)
                    break;

                player2.TakeDamage(player1.Shoot());
                Console.WriteLine($"{player1.Name} shoot to {player2.Name}");
                Console.WriteLine($"{player2.Name} Health: {player2.Health}");
            }

            //    უნდა გვქონდეს იარაღების არსენალი(კოლექცია) საიდანაც მოთამაშე იყიდის(აიღებს) იარაღს.
            //    თუ ფული არ ყოფნის იარაღი ვერ უნდა იყიდოს.
            //    როდესაც ერთი მოთამაშე მეორეზე გაიმარჯვებს უნდა მოემატოს ფული.

            ITankDriver tankDriver = player2;

            Tank t = new Tank();
            Jumpjet jet = new Jumpjet();

            Console.ReadLine();
        }
    }
}