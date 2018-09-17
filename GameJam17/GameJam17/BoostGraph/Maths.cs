using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AlgoStar.Boost;

namespace AlgoStar
{
    public class Maths
    {
        
        
        

        public static double distance(Vector2 p1, Vector2 p2)
        {
            return Math.Sqrt(  (p1.X - p2.X)*(p1.X-p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y) );
        }

        public static Noeud bestNoeud(List<Noeud> lstNoeuds)
        {
            Noeud noeudBest = null;
            if(lstNoeuds.Count() != 0)
            {
                noeudBest = lstNoeuds[0];
                foreach (var n in lstNoeuds)
                {
                    if (n.CoutF <= noeudBest.CoutF)
                    {
                        noeudBest = n;
                    }
                }
                
            }

            return noeudBest;

        }
        
        
        
        
        
        
        
    }
}