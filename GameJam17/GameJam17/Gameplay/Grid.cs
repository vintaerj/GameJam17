
using System;
using System.Collections.Generic;
using System.Numerics;
using AlgoStar.Boost;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace GameJam17.Gameplay
{
    public class Grid
    {
        public Graph graph;
        public int[,] grid;
        private Texture2D white;
        private int TileWidth = 32;
        private int TileHeight = 32;
        private int OriginX = 100;
        private int OriginY = 100;
        

        public Grid(int[,] tab)
        {
            grid = tab;
            graph = Graph.TabToGraph(tab);
        }

        public void Load(GraphicsDevice g)
        {
            white = new Texture2D(g,1,1);
            white.SetData(new Color[]{Color.White});
            
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch sp)
        {
          
            for (int line = 0; line < grid.GetLength(0); line++)
            {
                for (int column = 0; column< grid.GetLength(1); column++)
                {
                    int plein = grid[line, column];
                    Rectangle rect =new Rectangle(OriginX+column*TileWidth,OriginY+line*TileHeight,TileWidth,TileHeight);
                    Color color = Color.White;

                    if (plein == 0)
                    {
                        color = Color.White;
                        
                        
                    }
                    else
                    {
                        color = Color.Black;
                    }
                    
                   sp.Draw(white,rect,color);
                   DrawChemin(sp,new System.Numerics.Vector2(1,1),new System.Numerics.Vector2(8,3));
                  
           
                }
            }
         
            
        }

        private void DrawChemin(SpriteBatch sp,System.Numerics.Vector2 depart, System.Numerics.Vector2 fin)
        {
            Noeud d = graph.getNoeud(depart);
            Noeud f = graph.getNoeud(fin);
            List<Noeud> chemins = graph.rechercherChemin(d, f);
            
            
            
            foreach (var n in chemins)
            {
                Rectangle rect =new Rectangle(OriginX+(int)n.Position.X*TileWidth,OriginY+(int)n.Position.Y*TileHeight,TileWidth,TileHeight);
                sp.Draw(white,rect,Color.Green);
            }

        }

        public int GetId(Vector2 v)
        {
            float positionX = v.X - OriginX;
            float positionY = v.Y - OriginY;
            int line = (int)Math.Floor(positionY / TileHeight);
            int column = (int)Math.Floor(positionX / TileWidth);

            Noeud n = graph.getNoeud(new Vector2(column, line));
            if (n != null)
            {
                return n.Indice;
            }
            else
            {
                return -1;
            }
         
        }
        
        

        
        
        
    }
}