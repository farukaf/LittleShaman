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

    public class Totem : AnimatedSprite
    {
        public bool broken = false;

        string path = "LevelObjects/BrokenTotem";

        public Sprite colisionBox;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="position"></param>
        public void Load(ContentManager content, Vector2 position)
        {
            lines = 2;
            columns = 12;
            frameTime = 140;
            Load(content, path, frameTime, lines, columns);
            this.position = position;

            frameQuantities = new int[lines];
            frameQuantities[lines - 1] = columns;
            currentAnimation = 0;

            color = Color.White;

            rect.Width = texture.Width / columns;
            rect.Height = texture.Height / lines;
            rect.X = (int)position.X;
            rect.Y = (int)position.Y;

            colisionBox = new Sprite();
            colisionBox.Load(content, "LevelObjects/whitePixel", Color.DeepSkyBlue * 0.4f, new Rectangle((int)position.X + 83, (int)position.Y + 5, 70, 152));

        }

        public override void UpdateFrame(GameTime gameTime)
        {
            if (broken)
            {
                timeLapsed += gameTime.ElapsedGameTime;
                if (timeLapsed.TotalMilliseconds > frameTime)
                {
                    frameCurrent++;

                    if (currentAnimation == 1 && frameCurrent >= 11)
                    {
                        frameCurrent = 10;
                    }
                    else if (frameCurrent >= columns)
                    {
                        currentAnimation = 1;
                        frameCurrent = 0;
                    }


                    timeLapsed = TimeSpan.Zero;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            UpdateFrame(gameTime);
        }

        public override void DrawRectangle(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, frameList[currentAnimation, frameCurrent], color * alpha, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            //colisionBox.DrawRectangle(spriteBatch);
        }

    }
}
