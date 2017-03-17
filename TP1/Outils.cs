using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
using System.Reflection;

namespace TP1
{
    /// <summary>
    /// Les outils utilisés dans le projet
    /// </summary>
    public static class Outils
    {
        
        /// <summary>
        /// Vérifier si un objet est entre la valeur plus petite et celle de plus grande
        /// </summary>
        /// <param name="objet">La valeur à tester</param>
        /// <param name="lower">La valeur plus petite</param>
        /// <param name="upper">La valeur plus grande</param>
        /// <returns></returns>
        public static bool EstEntre(this int objet, int lower, int upper)
        {
            return objet >= lower && objet <= upper;
        }
        /// <summary>
        /// Lire du console
        /// </summary>
        /// <returns>Une chaine</returns>
        public static string Lire()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Afficher une chaine en fonction du séparateur
        /// </summary>
        /// <param name="chaine">La chaine à afficher</param>
        /// <param name="avecSeparateur">Le séparateur</param>
        public static void Afficher<T>(this T chaine, string avecSeparateur = "")
        {
            Console.Write(chaine + avecSeparateur);            
        }

        /// <summary>
        /// Si la chaine correspond au quelque format spécifique
        /// </summary>
        /// <param name="chaine">La chaine à tester</param>
        /// <param name="format">Le format à faire correspondre</param>
        /// <returns></returns>
        public static bool Match(this string chaine, string format)
        {
            Match m = Regex.Match(chaine,format);
            return m.Success;
        }
        /// <summary>
        /// Changer la couleur des mots du console
        /// </summary>
        /// <param name="nouvelle">La couleur nouvelle</param>
        /// <param name="action">Action à faire</param>
        public static void InterfaceDecorator(Action action)
        {
            List<ConsoleColor> couleur = new List<ConsoleColor>() { ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Red, ConsoleColor.Yellow };

            ConsoleColor vieuxforeground = Console.ForegroundColor;
            ConsoleColor vieuxbackground = Console.BackgroundColor;

            Console.BackgroundColor = ConsoleColor.Black;
            if (couleur.Contains(vieuxforeground))             
                couleur.RemoveAt(couleur.IndexOf(vieuxforeground));

            Console.ForegroundColor = couleur[0];
            action();
            Console.BackgroundColor = vieuxbackground;
            Console.ForegroundColor = vieuxforeground;            
        }
        /// <summary>
        /// Enverser la chaine en fonction du separateur 
        /// </summary>
        /// <param name="chaine"></param>
        /// <returns>La chaine enversée</returns>
        public static string Enverser(this string chaine)
        {
            return string.Join("/", chaine.Split('/').Reverse());
        }
        /// <summary>
        /// Faire la lettre première majuscule
        /// </summary>
        /// <param name="chaine">La chaine à modifier</param>
        /// <returns>La chaine dont les premiéres lettres de chaque mot sont en majuscules</returns>
        public static string MajusculePremiereLettre(this string chaine)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(chaine.Trim());
        }
        /// <summary>
        /// Garder le format de date comme [dd/MM/yyyy]
        /// </summary>
        /// <param name="temps"></param>
        /// <returns></returns>
        public static string DateFormat(this DateTime temps)
        {
            return temps.Day.ToString("00") + "/" + temps.Month.ToString("00") + "/" + temps.Year.ToString();
        }
        /// <summary>
        /// Garder le format d'heure comme [hh:mm]
        /// </summary>
        /// <param name="temps">Le temps</param>
        /// <returns>L'heure avec format [00:00]</returns>
        public static string HeureFormat(this DateTime temps)
        {
            return temps.Hour.ToString("00") + ":" + temps.Minute.ToString("00");
        }
        /// <summary>
        /// Ajouter l'heure au temps
        /// </summary>
        public static DateTime PlusHeure(this DateTime temps,string heure)
        {
            string[] items = heure.Split(':');
            return temps.AddHours(int.Parse(items[0])).AddMinutes(int.Parse(items[1]));
        }
        /// <summary>
        /// Noms des méthodes dans une classe
        /// </summary>
        /// <param name="nomClasse">Le nom de classe</param>
        public static void NomsMethodesDe(string nomClasse)
        {
            MethodInfo[] methodInfos = Type.GetType(nomClasse).GetMethods(BindingFlags.NonPublic | BindingFlags.Static);
            methodInfos.ToList().ForEach(item => item.ToString().Afficher("\n"));
        }
    }
}
