using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LittleShaman1.Model
{
    public class Switch : Sprite
    {
        public bool active = false;

        public Rectangle colision;
        // ativado ? new Vector2(0, 1) : new Vector2(0,0))
        public void Load(ContentManager content, Vector2 position)
        {
            string path = "LevelObjects/Alavanca";


            base.LoadSlice(content, path, position, color, 1, 2, new Vector2(0, 0));
            color = Color.White;

            colision = new Rectangle((int)position.X, (int)position.Y, texture.Width / 2, texture.Height / 1);
        }

        public override void DrawSlice(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, new Rectangle((active ? 1 : 0) * rect.Width, 0 * rect.Height, rect.Width, rect.Height), color);
        }
    }
}
