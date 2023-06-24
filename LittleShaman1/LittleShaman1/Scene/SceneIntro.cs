using LittleShaman1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleShaman1.Scene
{
    class SceneIntro
    {
        Sprite logo;
        float alpha;
        TimeSpan timeLapsed;

       

        public void Load(ContentManager content)
        {
            logo = new Sprite()
            {
                texture = content.Load<Texture2D>("Menu/Background/introMB"),
                color = Color.White
            };
            logo.position = new Vector2(1280 / 2 - logo.texture.Width / 2, 10);
            alpha = 0;

           
        }


        public EnumScene Update(GameTime gameTime)
        {
            timeLapsed += gameTime.ElapsedGameTime;
            if (timeLapsed.TotalMilliseconds < 3500)
            {
                alpha += 0.005f;
            }
            else
            {
                alpha -= 0.005f;
                if (alpha < 0) return EnumScene.menu;
            }
            return EnumScene.intro;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(logo.texture, logo.position, logo.color * alpha);
        }


    }
}
