using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleShaman1.Model
{
    public class FallingBranch : Sprite
    {
        int count = 0;
        bool fall = false;
        float resistance;
        /// <summary>
        /// A falling branch, um galho que cai
        /// </summary>
        /// <param name="content"></param>
        /// <param name="position"></param>
        /// <param name="resistance"></param>
        public void Load(ContentManager content, Vector2 position, float resistance)
        {
            this.resistance = resistance;

            base.Load(content, "LevelObjects/littleRectangle", position, Color.Wheat, 75, 15);
        }


        public void Update(bool colision)
        {
            if (colision)
            {
                count++;
            }
            else
            {
                count = 0;
            }
            Debug.Write("Count: " + count + "  ");

            if (count > resistance) fall = true;


            if (fall)
            {
                rect.Y += 7;
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            base.DrawRectangle(spriteBatch);
        }

    }
}
