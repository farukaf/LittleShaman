using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleShaman1.Model
{
    class Parallax
    {
         public Sprite background1;
        public Sprite background2;
        public float speed1 = 2;
        public void Load(ContentManager content, string path)
        {
            background1 = new Sprite()
            {
                texture = content.Load<Texture2D>(path),
                position = Vector2.Zero,
                color = Color.White
            };

            background2 = new Sprite()
            {
                texture = content.Load<Texture2D>(path),
                position = new Vector2(background1.texture.Width, 0),
                color = Color.White
            };

            speed1 = 2;
        }
        public void Update()
        {
            background1.position.X -= speed1;
            background2.position.X -= speed1;

            if (background1.position.X <= 0 - background1.texture.Width)
            {
                background1.position.X = 1280;
            }

            if (background2.position.X <= 0 - background2.texture.Width)
            {
                background2.position.X = 1280;
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(background1.texture, background1.position, background1.color);
            sb.Draw(background2.texture, background2.position, background2.color);
        }

    }
}
