using Puissance4.Player;
using System;

namespace Puissance4
{
    public class MoteurDeJeu : IMoteurDeJeu
    {
        private readonly IJoueur _joueur1;
        private readonly IJoueur _joueur2;
        private Verification verification;
        private int nbtour { get; set; } 
        private Board _board;
        
        public MoteurDeJeu(IJoueur joueur1, IJoueur joueur2)
        {
            _joueur1 = joueur1;
            _joueur2 = joueur2;
            _board = new Board();
            nbtour = 0;
            verification = new Verification();
        }

        public void Jouer(int colonneNumber)
        {
            Colonne colonne = _board.Colonnes[colonneNumber-1];
            for (int i = 0; i < 6; i++)
            {
               if(colonne.Lignes[i] == null)
                {
                    colonne.Lignes[i] = QuiSymbole();
                    break;
                }
            }
        }

        public string QuiAGagner()
        {

            nbtour++;
           if(verification.VerificationVictoire(_board, _joueur1.Symbole)){
                return _joueur1.Name;
            }else if(verification.VerificationVictoire(_board, _joueur2.Symbole)){
                return _joueur2.Name;
            }else if (nbtour == 42)
            {
                return "egalité";
            }
            return "";
        }

        public string QuiJoue()
        {
            if(nbtour%2 == 1)
            {
                return _joueur1.ToString();
            }
            else
            {
                return _joueur2.ToString();
            }
           
        }
        public string QuiSymbole()
        {
            if (nbtour % 2 == 1)
            {
                return _joueur1.Symbole;
            }
            else
            {
                return _joueur2.Symbole;
            }

        }
        public string Affichage()
        {
            return _board.ToString();
        }
    }
}