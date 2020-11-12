using System;
using System.Collections.Generic;
using System.Text;

namespace Puissance4
{
    class Verification : IVerification 
    {
      
  
        public bool VerificationVictoire(Board board, string symbole)
        {
            return VerificationHorizontal(board, symbole) || VerificationeVertical(board, symbole);
        }
        private static bool VerificationHorizontal(Board board, string symbole)
        {

            foreach (Colonne colonne in board.Colonnes)
            {
                int count = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (colonne.Lignes[i] == symbole)
                    {
                        count++;
                        if (count == 4)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            return false;
        }
        private static bool VerificationeVertical(Board board, string symbole)
        {
            int count = 0;
            for (int i = 0; i < 6; i++)
            {
                foreach (Colonne colonne in board.Colonnes)
                {
                    if (colonne.Lignes[i] == symbole)
                    {
                        count++;
                        if (count == 4)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            return false;
        }

    }
}
