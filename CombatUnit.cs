using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{

    public delegate void DeathEventHandler(CombatUnit corpse, EventArgs e);
    public class CombatUnit
    {
        string name;
        double staticHealth;
        double currentHealth;
        double staticDamage;
        double currentDamage;

        public event DeathEventHandler DeathEvent;

        CombatUnit target;

        public CombatUnit(string _name, double health, double damage)
        {
            name = _name;
            staticHealth = health;
            staticDamage = damage;

            currentHealth = staticHealth;
            currentDamage = staticDamage; 
        }

        public void SearchTarget(List<CombatUnit> enemies)
        {
            double tarHealth =999999999;

            if(enemies == null)
            {
                Console.WriteLine("GameEnd");
            }

            foreach (CombatUnit enemy in enemies)
            {
                if (enemy.currentHealth<tarHealth)
                {
                    target = enemy;
                    tarHealth = enemy.currentHealth;
                }
            }
        }

        public Projectile AttackUnit()   //Attack action, create a projectile
        {
            Projectile p = new Projectile(currentDamage,target);
            return p;
        }

        public void TakeDamage(double damage)
        {
            currentHealth -= damage;
            //Console.WriteLine(name + " current hp = " + currentHealth);
            if (currentHealth <= 0)
                Death();
        }

        void Death()
        {            
            //Console.WriteLine(name + " is dead.");
            if (DeathEvent != null)
                DeathEvent(this, EventArgs.Empty);
        }
    }
}
