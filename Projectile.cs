using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    public class Projectile
    {
        double initDamage;
        double finalDamage;

        CombatUnit target;      //Tracking Projectile


        public Projectile(double damage,CombatUnit _target)
        {
            initDamage = damage;
            target = _target;
            //TODO: Use a method to trigger collide
            Collide();
        }

        public void Collide()
        {
            //TODO: Use a method to modify damage;
            finalDamage = initDamage;
            //TODO: Use a delegete method to trigger TakeDamage();
            target.TakeDamage(finalDamage);
        }
    }
}
