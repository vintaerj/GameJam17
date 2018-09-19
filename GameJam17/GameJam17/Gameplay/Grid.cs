
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using AlgoStar.Boost;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private bool isDrawChemin = false;
        

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
            
            MouseState ms = Mouse.GetState();
            if (ms.RightButton == ButtonState.Pressed)
            {
                Console.WriteLine("pressed");
                changeCase(ms.X,ms.Y,0);
            }else if (ms.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("pressed");
                changeCase(ms.X,ms.Y,1);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                isDrawChemin = true;
            }

        }

        public void Draw(SpriteBatch sp)
        {


            int cellW = 28;
            int cellH = 28;

            int posX = OriginX;
            int posY = OriginY;
        
            for (int line = 0; line < grid.GetLength(0); line++)
            {
                Boolean bLignePaire = (line % 2 == 0);
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    Boolean bColonnePaire = (column % 2 == 0);

                  
                    //Ligne paire + colonne impaire = mur vertical
                    if (bLignePaire == false && bColonnePaire  && grid[line, column] == 1)
                    {
          
                        sp.Draw(white, new Rectangle(posX, posY, 3, cellH), Color.Black);

                    }
                    
                    if (bLignePaire && bColonnePaire == false && grid[line, column] == 1)
                    {
          
                        sp.Draw(white, new Rectangle(posX, posY, cellW, 3), Color.Black);

                    }

                    if (!bLignePaire && !bColonnePaire && grid[line, column] == 0)
                    {
                        sp.Draw(white, new Rectangle(posX, posY, cellW, cellH), Color.White);
                    }

                    if (bColonnePaire)
                    {
                        posX = posX + cellW;
                    }
                    



                }

                if (bLignePaire)
                {
                    posY = posY + cellH;
                }
                posX = OriginX;
            }
         
            
        }

        private void DrawChemin(SpriteBatch sp,System.Numerics.Vector2 depart, System.Numerics.Vector2 fin)
        {
            graph = Graph.TabToGraph(grid);
            Noeud d = graph.getNoeud(depart);
            Noeud f = graph.getNoeud(fin);
            List<Noeud> chemins = graph.rechercherChemin(d, f);
            
            
            
            foreach (var n in chemins)
            {
                Rectangle rect =new Rectangle(OriginX+(int)n.Position.X*TileWidth,OriginY+(int)n.Position.Y*TileHeight,TileWidth,TileHeight);
                sp.Draw(white,rect,Color.Green);
                
            }

        }

        public void changeCase(double positionX,double positionY,int valeur)
        {
            int line = (int)Math.Floor((positionY- OriginY) / TileHeight );
            int column = (int)Math.Floor((positionX-OriginX) / TileWidth );
            Console.WriteLine(line+"  "+column);
           
            
            
            if (line >= 0 && column >= 0 && line < grid.GetLength(0) && column < grid.GetLength(1))
            {
                grid[line, column] = valeur;
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