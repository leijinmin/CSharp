using System;


namespace TP1
{
    /// <summary>
    /// Une classe sur le vol
    /// </summary>
    class VolAvion
    {
        // Le numéro du vol courrant
        private int monNombre = 0;
        // Le temps de départ et d'arrivée
        private DateTime tempsDepart = DateTime.Now,
                         tempsArrivee;

        private string villeDepart;
        private string villeArrivee;
        private string dateDepart;
        private string heureDepart;
        private string dateArrivee;
        private string heureArrivee;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public VolAvion() : this("Montréal", "Edmonton", "30/04/2017", "0:0", "30/04/2017", "7:59")
        {
        }
        /// <summary>
        /// Constructeur recevant les paramètres
        /// </summary>
        /// <param name="villeDepart"></param>
        /// <param name="villeArrivee"></param>
        /// <param name="dateDepart"></param>
        /// <param name="heureDepart"></param>
        /// <param name="dateArrivee"></param>
        /// <param name="heureArrivee"></param>
        public VolAvion(string villeDepart, string villeArrivee, string dateDepart, string heureDepart, string dateArrivee, string heureArrivee)
        {
            this.VilleDepart = villeDepart;
            this.VilleArrivee = villeArrivee;
            this.DateDepart = dateDepart;
            this.HeureDepart = heureDepart;
            this.DateArrivee = dateArrivee;
            this.HeureArrivee = heureArrivee;
            this.monNombre = ++Nombre;
        }
        /// <summary>
        /// Constructeur de copie
        /// </summary>
        /// <param name="objet"></param>
        public VolAvion(VolAvion objet) : this(objet.VilleDepart, objet.VilleArrivee, objet.DateDepart, objet.HeureDepart, objet.DateArrivee, objet.HeureArrivee)
        {
        }
        
        // L'identifiant d'un vol
        public string Identifiant { get; private set; }

        // Le numéro des vols
        public static int Nombre { get; private set; } = 0;

        public string VilleDepart
        {
            get
            {
                return villeDepart.MajusculePremiereLettre(); // Convertir les premières lettres des mots en majuscule
            }
            set
            {
                assignerVille(value, ref villeDepart);
            }
        }
        /// <summary>
        /// Affecter la valeur à la variable passée dans la fonction
        /// </summary>
        /// <param name="chaine">La valeur de la ville entrée</param>
        /// <param name="ville">La variable recevant la valeur valide de ville</param>
        private void assignerVille(string chaine, ref string ville)
        {
            if (chaine.EstValideVille())
                ville = string.Copy(chaine);
        }
        public string VilleArrivee
        {
            get
            {
                return villeArrivee.MajusculePremiereLettre(); // Convertir les premières lettres des mots en majuscule
            }
            set
            {
                assignerVille(value, ref villeArrivee);
            }
        }

        public string DateDepart
        {
            get
            {
                return tempsDepart.DateFormat();
            }
            set
            {
                string chaine = value.Trim().Replace(" ","");
                // Enverser la date du format [dd/MM/YYYY] au [YYYY/MM/dd] et puis faire la validation
                if(chaine.Enverser().EstValideDateDepart())
                {
                    assignerDate(chaine, ref dateDepart,ref tempsDepart);
                }
            }
        }
        /// <summary>
        /// Affecter les valeurs aux variables passées dans la fonction
        /// </summary>
        /// <param name="pDate">La chaine entrée représentant la date</param>
        /// <param name="date">La variable sauvegarder la date valide</param>
        /// <param name="temps">La variable représentant le temps</param>
        private void assignerDate(string pDate,ref string date, ref DateTime temps)
        {
            date = pDate;
            temps = DateTime.Parse(pDate.Enverser());
        }
        public string DateArrivee
        {
            get
            {
                return tempsArrivee.DateFormat();
            }
            set
            {
                string chaine = value.Trim().Replace(" ","");
                // Enverser la date du format [dd/MM/YYYY] au [YYYY/MM/dd] et puis faire la validation
                if(chaine.Enverser().EstValideDateArrivee(dateDepart.Enverser()))
                {
                    assignerDate(chaine, ref dateArrivee, ref tempsArrivee);                  
                }
            }
        }

        public string HeureDepart
        {
            get
            {
                return tempsDepart.HeureFormat();
            }
            set
            {
                string chaine = value.Trim().Replace(" ","");
                if (chaine.EstValideHeureDepart())
                {
                    assignerHeure(chaine, ref heureDepart, ref tempsDepart);
                }

            }
        }

        private void assignerHeure(string pHeure,ref string heure, ref DateTime temps)
        {
            heure = pHeure;
            temps = temps.PlusHeure(heure);
        }

       // private void assignerTemps(string )
        public string HeureArrivee
        {
            get
            {
                return tempsArrivee.HeureFormat();
            }
            set
            {
                string chaine = value.Trim().Replace(" ", "");
                if(chaine.EstValideHeureArrivee(tempsDepart, tempsArrivee))
                    assignerHeure(chaine, ref heureArrivee, ref tempsArrivee);
            }
        }

        // La durée d'un vol
        public string Duree { get; private set; }

        /// <summary>
        /// Calculer la durée du vol
        /// </summary>
        public void CalculerDuree()
        {
            Duree = tempsArrivee.Subtract(tempsDepart).ToString(@"dd\:hh\:mm"); 
        }
        /// <summary>
        /// Construire l'identifiant du vol
        /// </summary>
        public void CalculerIdentifiant()
        {
            Identifiant = string.Concat(VilleArrivee.Replace(" ","").Substring(0, 2), VilleDepart.Replace(" ", "").Substring(0, 2), // Éviter la situation comme "N ew Y ork (ça doit être New York)"
                tempsArrivee.Month.ToString("00"), tempsArrivee.Day.ToString("00"), 
                tempsDepart.Month.ToString("00"), tempsDepart.Day.ToString("00"), monNombre.ToString("0000"));
        }
        public override string ToString()
        {
            CalculerDuree();
            CalculerIdentifiant();

            return string.Format("Le numéro du vol: {0}\n"+ 
                "L'identifiant du vol: {1}\n" +
                "Départ: {2}\n" +  
                "Destination: {3}\n" +
                "Date de départ: {4}\n"  +
                "Heure de départ: {5}\n"  +
                "Date d'arrivée: {6}\n"  +
                "Heure d'arrivée: {7}\n\n" + 
                "Durée du vol: {8}", 
                monNombre.ToString(),Identifiant,VilleDepart,VilleArrivee,
                DateDepart,HeureDepart,DateArrivee,HeureArrivee,Duree);
        }

    }


}
