using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleShaman1.Model
{
    public class Tiles
    {
        //Controla os tiles do fundo do jogo
        public Sprite[] tiles;

        public int[,] matrixTiles;


        public Rectangle bounds;


        //metodo para carregar os tiles
        public void Load(ContentManager content)
        {
            #region tiles
            tiles = new Sprite[4];


        

            tiles[0] = new Sprite()
            {
                texture = content.Load<Texture2D>("Tile/grama"),
                color = Color.White
            };
            tiles[1] = new Sprite()
            {
                texture = content.Load<Texture2D>("Tile/pedra"),
                color = Color.White
            };
            tiles[2] = new Sprite()
            {
                texture = content.Load<Texture2D>("Tile/flor"),
                color = Color.White
            };
            tiles[3] = new Sprite()
            {
                texture = content.Load<Texture2D>("Tile/terra"),
                color = Color.White
            };
            #endregion
            matrixTiles = new int[,] {
                {1,0,3,3,3,3,0,0,0,0,0,1},
                {1,0,3,0,0,0,0,0,0,0,0,1},
                {1,0,3,3,0,0,0,0,3,0,0,1},
                {1,0,3,0,0,0,0,3,0,3,0,1},
                {1,0,3,0,2,2,0,3,3,3,0,1},
                {1,0,3,0,2,2,0,3,0,3,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0},
                {1,0,3,0,2,2,0,3,0,3,0,1},
                {1,0,3,0,2,2,0,3,3,3,0,1},
                {1,0,3,0,2,2,0,3,0,3,0,1}
            };


            bounds = new Rectangle(
                0,
                0,
                (matrixTiles.GetLength(1) - 1) * tiles[0].texture.Width,
                (matrixTiles.GetLength(0) - 1) * tiles[0].texture.Height);
        }
        public void DrawTiles(SpriteBatch sprite)
        {
            for (int i = 0; i < matrixTiles.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTiles.GetLength(1); j++)
                {
                    sprite.Draw(tiles[matrixTiles[i,j]].texture, new Vector2(100 * j, 100 * i), Color.White);
                }
            }
        }

    }
}
