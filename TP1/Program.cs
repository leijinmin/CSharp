using System;
using System.Collections.Generic;


namespace TP1
{
    class Program
    {

        static void Main(string[] args)
        {

            // Tester les fonctions de validation   
            /*Test.TestTemplate(new string[] { " N e w York  ", "new york123", "   ", "", " N e", "  a", "Montréal", "Baden-Wrttemberg ", "Amöneburg", "Golßen", "Bandar Seri Begawan", " S ão Tomé ", "	Saint  John's ", "	Asunción" }, new Test.TestFonction(Validation.EstValideVille));

            Test.TestTemplate(new string[] { "2017/ 3/30", "2017/2/29", "   ", "", "2017/4/31", "  a", "2019", " 2017/01/4", "2018/2/29","2018/6/31","2018/6/30" }, new Test.TestFonction(Validation.EstValideDateDepart));

            Test.TestTemplate(new string[] { "23:59", "0 :0", " 2:3 ", " 12: 0 ", "0: 05"," ","" }, new Test.TestFonction(Validation.EstValideHeureDepart));

            Test.TestEstValideDateArrivee(new string[] { "2017/3/30", " 2017/4/1", " 2017/12/ 30" }, new string[] { "2017/3/30", " 2017/4/1", " 2017 /12/ 31" });

            Test.TestEstValideHeureArrivee(new string[] { "23:59", "0 :0", " 13:4 "},
                new DateTime[] { new DateTime(2017, 3, 30, 5, 50, 0), new DateTime(2017, 3, 31, 5, 50, 0), new DateTime(2018, 12, 30, 14, 3, 0) },
                new DateTime[] { new DateTime(2017,3,30,0,0,0), new DateTime(2017, 4, 1, 0, 0, 0),
                new DateTime(2018, 12, 30, 0, 0, 0) });
            */
            VolAvion[] vols = new VolAvion[4];

            // Créer l'objet à partir du constructeur par défaut
            vols[0] = new VolAvion();

            // Les étapes pour assigner les valeur nouvelles à cet objet
            assignerProprietes(vols[0]);

            // Créer un objet nouveau à partir du constructeur en passant les paramètres
            vols[1] = new VolAvion("Toronto", "Beijing", "21/1/2017", "0:5", "21/1/2017", "12:9");

            // Créer un objet nouveau à partir du constructeur en passant un objet
            vols[2] = new VolAvion(vols[1]);

            // Créer un objet anonymous en passant un objet
            var objet = new VolAvion(vols[0]);
            vols[3] = objet;

            "\n ************* Les objets crées *************\n".Afficher();
            "\n-----------------------------------\n".Afficher();
            for (int i = 0; i < 4; i++)
            {
                vols[i].Afficher();
                "\n-----------------------------------\n".Afficher();
            }
        }

        public static void ab(ref string a)
        {
            a = "Inside the function changed";
        }
        /// <summary>
        /// Modifier l'objet en modifiantn les propriétés
        /// </summary>
        /// <param name="unVol">L'objet à modifier</param>
        public static void assignerProprietes(VolAvion unVol)
        {            
            "Le système a créé un vol de défaut automatiquement: \n".Afficher();
            // Changer la couleur d'affichage de l'information du vol créé par défaut 
            Outils.InterfaceDecorator(
                new Action(() => {
                    unVol.Afficher("\n\n");
                }));

            "Vous devez modifier l'information au dessus en suivant les étapes suivants: \n".Afficher();
            List<string> options = new List<string>()
            {
                "Départ: ",
                "Destination: ",
                "Date de départ [format: dd/MM/yyyy]: ",
                "Heure de départ [format: hh:mm]: ",
                "Date d'arrivée [format: dd/MM/yyyy]: ",
                "Heure d'arrivée [format: hh:mm]: "
            };

            // Faire l'affectation des valeurs au propriétés de l'objet et attraper les exceptions lancées
            exceptionHandler(options[0], new Action(() => { unVol.VilleDepart  = Outils.Lire(); }));
            exceptionHandler(options[1], new Action(() => { unVol.VilleArrivee = Outils.Lire(); }));
            exceptionHandler(options[2], new Action(() => { unVol.DateDepart   = Outils.Lire(); }));
            exceptionHandler(options[3], new Action(() => { unVol.HeureDepart  = Outils.Lire(); }));
            exceptionHandler(options[4], new Action(() => { unVol.DateArrivee  = Outils.Lire(); }));
            exceptionHandler(options[5], new Action(() => { unVol.HeureArrivee = Outils.Lire(); }));
        }

        /// <summary>
        /// Attraper les exceptions et sortir les messages d'erreurs
        /// </summary>
        /// <param name="message">Le message d'erreur</param>
        /// <param name="action">L'action qui lancerait les exceptions</param>
        private static void exceptionHandler(string message,Action action)
        {
            string erreur = null;
            do
            {
                try
                {
                    if (erreur != null) //Si les erreurs existent, avertir à rentrer.
                        // Changer la couleur du message d'erreur affichant sur le console
                        Outils.InterfaceDecorator(
                            new Action(() => { erreur.Afficher("Rentrez s'il vous plait!\n");}) 
                            );

                    if (message != null) message.Afficher();

                    action();
                    break; 
                }
                catch(Exception ex)
                {
                    if (ex is VilleInattandueExceiption || ex is DateOutOfRangeExceiption ||
                       ex is HeureOutOfRangeExceiption || ex is TempsDifferenceExceiption)
                        erreur = ex.Message;
                    //else
                    //    erreur = ex.Message;
                }
            } while (true);

        }

    }
}
