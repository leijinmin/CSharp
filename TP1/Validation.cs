using System;

namespace TP1
{
    /// <summary>
    /// Validation des affectations des propriétés de la classe VolAvion
    /// </summary>
    internal static class Validation
    {
        /// <summary>
        /// Valider la ville entrée
        /// </summary>
        /// <param name="ville">La ville entrée</param>
        /// <returns>Vrai si valide</returns>
        internal static bool EstValideVille(this string ville)
        {
            // La ville ne contient pas de chiffres;  ne peut que contenir les lettres et les espaces.
            if (!ville.Match(@"^(\s*[\p{L}-']*)(\s*[\p{L}-']*)*([\p{L}-']*\s*)$") || ville.Replace(" ", "").Length <2)
                throw new VilleInattandueExceiption("Le nom de la ville doit contenir au moins 2 caracères et contenir seulement les lettres et espaces! ");
            return true;
        }
        /// <summary>
        /// Valider la date de départ
        /// </summary>
        /// <param name="date">La date à valider</param>
        /// <returns>Vrai si valide</returns>
        internal static bool EstValideDateDepart(this string date)
        {
            if(!date.estValideDate())
                throw new DateOutOfRangeExceiption("La date n'est pas correcte! Assurez-vous qu'elle est logique et en format [dd/MM/yyyy]! ");

            return true;
        }

        /// <summary>
        /// Valider si la date est en format correct
        /// </summary>
        /// <param name="date">La date à valider</param>
        /// <returns>Vrai si en format correct</returns>
        private static bool estValideDate(this string date)
        {
            DateTime tempsDepart;
            if (!date.Match(@"^(\d{4})/\d{1,2}/(\d{1,2})$") || !DateTime.TryParse(date, out tempsDepart))
                return false;

            return true;    
        }
        /// <summary>
        /// Valider la date d'arrivée
        /// </summary>
        /// <param name="dateArrivee">La date d'arrivée</param>
        /// <param name="dateDepart">La date de départ auquelle la date d'arrivée va être comparée.</param>
        /// <returns>Vrai si valide</returns>
        internal static bool EstValideDateArrivee(this string dateArrivee,string dateDepart)
        {
            if(!dateArrivee.estValideDate() || DateTime.Parse(dateArrivee).Subtract(DateTime.Parse(dateDepart)).TotalMinutes<0 )
                throw new DateOutOfRangeExceiption("Assurez-vous que la date d'arrivée n'est pas plus petite que celle de départ! ");

            return true;
        }
        /// <summary>
        /// Valider l'heure de départ
        /// </summary>
        /// <param name="heure">L'heure à valider</param>
        /// <returns>Vrai si valide</returns>
        internal static bool EstValideHeureDepart(this string heure)
        {
            if(!heure.estValideHeure())
                throw new HeureOutOfRangeExceiption("L'heure doit varier de 00:00 à 23:59! ");

            return true;
        }

        /// <summary>
        /// Valider si l'heure varie entre 00:00 et 23:59
        /// </summary>
        /// <param name="heure">L'heure à valider</param>
        /// <returns>Vrai si le format de l'heure est correcte</returns>
        private static bool estValideHeure(this string heure)
        {
            // Valider le format de l'heure ([d:d] et [dd:dd] sont tous correts)
            if (!heure.Match(@"^(\d{1,2}):(\d{1,2})$"))
                return false;

            string[] items = heure.Split(':');
            return int.Parse(items[0]).EstEntre(0,23) && int.Parse(items[1]).EstEntre(0,59);
        }
        /// <summary>
        /// Valider l'heure d'arrivée
        /// </summary>
        /// <param name="heure">L'heure d'arrivée</param>
        /// <param name="tempsDepart">Le temps de départ</param>
        /// <param name="tempsArrivee">Le temps d'arrivée</param>
        /// <returns>Vrai si valide</returns>
        internal static bool EstValideHeureArrivee(this string heure,DateTime tempsDepart, DateTime tempsArrivee)
        {
            if(!heure.estValideHeure() || tempsArrivee.PlusHeure(heure).Subtract(tempsDepart).TotalMinutes <= 0)
                throw new TempsDifferenceExceiption("La date d'arrivée n'est pas valide ou plus petite que celle de départ.");

            return true;
        }
    }
}
