using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CombatSimulator
{
    class Scene
    {


        List<CombatUnit> redTeam = new List<CombatUnit>();
        List<CombatUnit> blueTeam = new List<CombatUnit>();

        bool bWin = false;
        int bNum =1;

        public void SceneInit()
        {
            
            

            for (int i = 1; 1 < 10; i++)
            {
                List<CombatUnit> redTeam = new List<CombatUnit>();
                MultiAdd(redTeam, i*10, 1, 1);

                bNum = 1;

                while (bWin = false)
                {
                    List<CombatUnit> blueTeam = new List<CombatUnit>();
                    MultiAdd(blueTeam, 10, 1, bNum);
                    bNum += 1;
                }
                UnitDeathEventListener();
            }


           

            
        }

        void MultiAdd(List<CombatUnit> tarList,double hp,double damage,int number)
        {
            for(int i=0;i<number;i++)
            {
                tarList.Add(new CombatUnit(tarList.ToString() + i.ToString(), hp, damage));
            }
        }

        public void Turn()
        {
            foreach (CombatUnit unit in redTeam)
            {
                unit.SearchTarget(blueTeam);
                unit.AttackUnit();
            }

            foreach (CombatUnit unit in blueTeam)
            {
                unit.SearchTarget(redTeam);
                unit.AttackUnit();
            }
        }

        void UnitDeathEventListener()
        {
            foreach (CombatUnit unit in redTeam)
            {
                unit.DeathEvent += new DeathEventHandler(UnitInListDeath);
            }

            foreach (CombatUnit unit in blueTeam)
            {
                unit.DeathEvent += new DeathEventHandler(UnitInListDeath);
            }
        }

        void UnitInListDeath(CombatUnit corpse, EventArgs e)
        {
           

            for (int i = 0; i < redTeam.Count; i++)
            {
                if (redTeam[i] == corpse)
                    redTeam.Remove(corpse);
            }

            if (redTeam.Count == 0)
            {
                Console.WriteLine("Blue team win at "+bNum );
                bWin = true;
                Console.ReadKey();
            }

            for (int i = 0; i < blueTeam.Count; i++)
            {
                if (blueTeam[i] == corpse)
                    blueTeam.Remove(corpse);
            }



            if (blueTeam.Count == 0)
            {
                Console.WriteLine("Red team win!");
                Console.ReadKey();
            }
        }
    }
}
