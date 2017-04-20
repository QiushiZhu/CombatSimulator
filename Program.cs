using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Scene a = new Scene();
            a.SceneInit();
           
            Console.ReadKey();
        }
    }
}
