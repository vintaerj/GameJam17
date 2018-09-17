using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace AlgoStar.Boost
{
    public class Noeud
    {
        
        public Vector2 Position { get; private set;}
        public List<Noeud> ListNoeudAdjacents { get ; set;}
        public int Obstacle { get; set; }
        public int Indice { get; set; }

        public double CoutG { get; set; }
        public double CoutH { get; set; }
        public double CoutF { get; set; }
        public Noeud Parent { get; set; }

        public Noeud(Vector2 pos)
        {
            
            ListNoeudAdjacents = new List<Noeud>();
            Position = pos;
            Obstacle = 0;
            CoutF = 0.0;
            CoutG = 0.0;
            CoutH = 0.0;
            Parent = null;

        }
        
        
        
        
        
    }
}