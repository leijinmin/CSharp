using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    internal static class Test
    {
        internal delegate bool TestFonction(string parametres);        
        internal static void TestTemplate(string[] parameters,TestFonction fonction)
        {
            int longeur = parameters.Length;
            //string methodecourante = MethodBase.GetCurrentMethod().Name;
            string methodecourante = fonction.Method.Name;
            string message = "";
            for (int i = 0; i < longeur; i++)
            {
                message = methodecourante + " avec la valeur [" + parameters[i] + "]";
                try
                {
                    if (fonction(parameters[i].Trim().Replace(" ", "")))
                        message.Afficher(" a passé avec succès.\n");
                }
                catch (Exception ex)
                {
                    afficherErreurs(ex, message);
                }
            }
        }
    
        internal static void TestEstValideDateArrivee(string[] datesArrivee, string[] datesDepart)
        {
            int longeur = datesArrivee.Length;
            string methodecourante = MethodBase.GetCurrentMethod().Name.Replace("Test","");
            string message = "";
            for (int i=0;i<longeur;i++)
            {
                message = methodecourante + " avec la date d'arrivée [" + datesArrivee[i] + "] et la date de départ [" + datesDepart[i] + "]";
                try
                {
                    if (datesArrivee[i].Trim().Replace(" ", "").EstValideDateArrivee(datesDepart[i].Trim().Replace(" ", ""))) 
                        message.Afficher(" a passé avec succès.\n");               
                }
                catch(Exception ex)
                {
                    afficherErreurs(ex, message);
                }
            }
        }

        private static void afficherErreurs(Exception ex, string message)
        {
            Outils.InterfaceDecorator(new Action(() => {
                message.Afficher(" est échouée\n");
                "Le message d'erreur: ".Afficher();
                ex.Message.Afficher("\n");
            }));
        }

        internal static void TestEstValideHeureArrivee(string[] heures, DateTime[] tempsDepart, DateTime[] tempsArrivee)
        {
            int longeur = heures.Length;
            string methodecourante = MethodBase.GetCurrentMethod().Name.Replace("Test", "");
            string message = "";
            for (int i = 0; i < longeur; i++)
            {
                message = methodecourante + " avec l'heure d'arrivée [" + heures[i] + "], le temps de départ ["+ tempsDepart[i].ToString() + "], le temps d'arrivée ["+ tempsArrivee[i].ToString() +"]";
                try
                {
                    if (heures[i].Trim().Replace(" ","").EstValideHeureArrivee(tempsDepart[i],tempsArrivee[i]))
                        message.Afficher(" a passé avec succès.\n");
                }
                catch (Exception ex)
                {
                    afficherErreurs(ex, message);
                }
            }
        }
    

        
    }
}
