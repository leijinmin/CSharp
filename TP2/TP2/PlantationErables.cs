using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public struct PlantationErables
    {
        // La taille de la plantation (terrain) en nombre de km carrés
        public float Plantation
        { get; set; }
        // Le nombre total d'érables à sucres sur le terrain
        public int ErableASucreTotal
        { get; set; }
        // Le nombre d'érables à sucres entaillés et produisant de l'eau d'érable
        public int ErableASucreEntaille
        { get; set; }
        // Le pourcentage d'érables à sucres entaillés par rapport au nombre total d'érables à sucres sur le terrain
        public float Pourcentage
        { get; private set; } 
        // L'efficacité de l'érablière est le nombre d'érables entaillés divisé par la taille de la plantation
        public float Efficacite
        { get; private set; }
        public PlantationErables(float plantation, int erableASucreTotal, int erableASucreEntaille)
        {
            this.Plantation = plantation;
            this.ErableASucreTotal = erableASucreTotal;
            this.ErableASucreEntaille = erableASucreEntaille;
            this.Pourcentage = 0;
            this.Efficacite = 0;
        }
        /// <summary>
        ///  L'affectation des paramètres aux champs de la structure
        /// </summary>
        /// <param name="plantation">Le nombre total d'érables à sucres sur le terrain</param>
        /// <param name="erableASucreTotal">Le nombre total d'érables à sucres sur le terrain</param>
        /// <param name="erableASucreEntaille">Le nombre d’érables à sucres entaillés et produisant de l'eau d'érable</param>
        public void ModifierChamps(params Object[] parametres)
        {
            if(parametres.Length >= 1) this.Plantation = (float)parametres[0];
            if(parametres.Length >= 2) this.ErableASucreTotal = (int)parametres[1];
            if(parametres.Length >= 3) this.ErableASucreEntaille = (int)parametres[2];          
        }
        /// <summary>
        ///  Calculer le pourcentage d'érables à sucres entaillés par rapport au nombre total d'érables à sucres sur le terrain
        /// </summary>
        /// <returns>Le résultat</returns>
        public float CalculerPoucentageEntaille()
        {
            this.Pourcentage = (float)this.ErableASucreEntaille / (float)this.ErableASucreTotal;
            return this.Pourcentage;
        }
        /// <summary>
        ///  Calculer l'efficacité de l'érablière
        /// </summary>
        /// <returns>Le résultat</returns>
        public float CalculerEfficacitePlantaion()
        {
            this.Efficacite = (float)this.ErableASucreEntaille / (float)this.Plantation;
            return this.Efficacite;
        }
        public override string ToString()
        {
            return String.Format("La taille de la plantation (terrain) en nombre de km carrés: {0}\n" +
                "Le nombre total d'érables à sucres sur le terrain: {1}\n" +
                "Le nombre d'érables à sucres entaillés et produisant de l'eau d'érable: {2}\n" + 
                "Le pourcentage d'érables à sucres entaillés par rapport au nombre total d'érables à sucres sur le terrain: {3:P2}\n" +
                "L'efficacité de l'érablière: {4:0.00}",
                this.Plantation,this.ErableASucreTotal,this.ErableASucreEntaille, CalculerPoucentageEntaille(), CalculerEfficacitePlantaion());
        }
    }
 
}
