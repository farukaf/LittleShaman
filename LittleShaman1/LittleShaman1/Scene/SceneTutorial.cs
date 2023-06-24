using LittleShaman1.Helper;
using LittleShaman1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleShaman1.Scene
{
    class SceneTutorial
    {
        Sprite sprite;
        float alpha;
        TimeSpan timeLapsed;


        public void Load(ContentManager content)
        {
            sprite = new Sprite()
            {
                texture = content.Load<Texture2D>("LevelBackground/tutorial"),
                color = Color.White
            };
            alpha = 0;
            sprite.rect = new Rectangle(0, 0, (int) Assist.Resolution.X, (int)Assist.Resolution.Y);

        }


        public EnumScene Update(GameTime gameTime, KeyboardState kb)
        {
            timeLapsed += gameTime.ElapsedGameTime;
            if (timeLapsed.TotalMilliseconds < 7000)
            {
                alpha += 0.005f;
            }
            else
            {
                alpha -= 0.005f;
                if (alpha < 0) return EnumScene.gamePlay;
            }

            if (kb.IsKeyDown(Keys.Enter) || kb.IsKeyDown (Keys.Space))
            {
                return EnumScene.gamePlay;
            }
            return EnumScene.tutorial;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite.texture, sprite.rect, sprite.color * alpha);
        }

    }
}
