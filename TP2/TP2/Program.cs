using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {
            PlantationErables maPlantation = new PlantationErables(10.0F, 400, 250);
            Console.WriteLine(maPlantation);            maPlantation.Plantation = 12.5F;
            maPlantation.ErableASucreTotal = 350;
            maPlantation.ErableASucreEntaille = 275;
            maPlantation.CalculerPoucentageEntaille();
            maPlantation.CalculerEfficacitePlantaion();
            Console.WriteLine(maPlantation);
            maPlantation.ModifierChamps(15.0F);
            Console.WriteLine(maPlantation);
            maPlantation.ModifierChamps(16.0F, 375);            Console.WriteLine(maPlantation);
            maPlantation.ModifierChamps(12.5F, 480, 350);            Console.WriteLine(maPlantation);
        }
    }
}
