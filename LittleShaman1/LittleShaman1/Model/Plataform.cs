using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using LittleShaman1.Helper;

namespace LittleShaman1.Model
{
    public class Plataform : Sprite
    {
        string path = "LevelObjects/SpriteTerraPlat";
        Random rnd;

        public void Load(ContentManager content, Vector2 position)
        {
            rnd = new Random();

            base.LoadSlice(content, path, new Rectangle((int)position.X, (int)position.Y, (int)Assist.PlataformRectangleSize.X, (int)Assist.PlataformRectangleSize.Y), Color.White, 1, 4, new Vector2(rnd.Next(0, 4), 0));


        }

        //public void Load(ContentManager content, Rectangle rectangle)
        //{
        //    rnd = new Random();
        //   base.LoadSlice(content, path, rectangle, Color.White, 1, 4, new Vector2(0, rnd.Next(0, 4)));
        //}
        public override void DrawSlice(SpriteBatch spriteBatch)
        {
            base.DrawSlice(spriteBatch);
        }
    }
}
