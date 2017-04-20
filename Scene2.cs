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
        bool aWin = false;
        int bNum =1;

        public void SceneInit()
        {
            BNumberSeries(20,10);
            BNumberSeries(50, 10);
            BNumberSeries(100, 10);
            BNumberSeries(500, 10);
            BNumberSeries(1000, 10);
            BNumberSeries(5000, 10);
            BNumberSeries(10000, 10);
            BNumberSeries(50000, 10);
            BNumberSeries(100000, 10);
        }

        void BNumberSeries(double ahp,double adamage)
        {
            int BNumber = 3;

            while (Battle(ahp, adamage, BNumber) == false)
            {
                BNumber++;
            }

            Console.WriteLine("b number is " + BNumber);
        }



        bool Battle(double AHP,double ADamage, int BNumber)
        {
            int turnNum = 0;
            bWin = false;
            aWin = false;            

            redTeam.Clear();
            blueTeam.Clear();

            MultiAdd(redTeam, AHP, ADamage, 3);
            MultiAdd(blueTeam, 10, 1, BNumber);

            UnitDeathEventListener();

            while(bWin ==false && aWin ==false)
            {
                Turn();
            }
            turnNum++;
            if(bWin)
            {
                Console.WriteLine("Bwin");
                return true;
            }
            if (aWin)
            {
                //Console.WriteLine("Awin");
                return false;
            }
            else
                return false;
            
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

            //DEBUG:Console.WriteLine("current red team num = " + redTeam.Count);

            if (redTeam.Count == 0)
            {
                //Console.WriteLine("Blue team win at "+bNum );
                bWin = true;
                //DEBUG:Console.ReadKey();
            }

            for (int i = 0; i < blueTeam.Count; i++)
            {
                if (blueTeam[i] == corpse)
                    blueTeam.Remove(corpse);
            }

            //DEBUG:Console.WriteLine("current blue team num = " + blueTeam.Count);

            if (blueTeam.Count == 0)
            {
                aWin = true;
                //Console.WriteLine("Red team win!");
            }
        }
    }
}
