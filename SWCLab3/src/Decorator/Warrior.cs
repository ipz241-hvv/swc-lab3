using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWCLab3.src.Decorator
{
    public class Warrior : IHero
    {
        public string Name => "Воїн";
        public int Health { get; private set; } = 150;
        public int AttackPower => 20;
        public int Defense => 15;

        public string GetFullDescription() => $"{Name} (HP: {Health}, ATK: {AttackPower}, DEF: {Defense})";

        public void TakeDamage(int damage)
        {
            int effectiveDamage = Math.Max(0, damage - Defense);
            Health -= effectiveDamage;
            Console.WriteLine($"{Name} отримав {effectiveDamage} шкоди. Залишилось HP: {Health}");
        }
    }
}
