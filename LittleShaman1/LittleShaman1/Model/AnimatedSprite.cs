using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleShaman1.Model
{
    public class AnimatedSprite : Sprite
    {
        public int lines;
        public int columns;

        public float rotation = 0f;

        public float frameTime;
        public int frameCurrent;
        public TimeSpan timeLapsed;

        public Rectangle[,] frameList;

        public int currentAnimation;
        public int[] frameQuantities;

        public int pastAnimation;

        public int frameWidth;
        public int frameHeight;



        public void Load(ContentManager content, string path, float frameTime, int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;

            this.frameTime = frameTime;
            frameCurrent = 0;
            timeLapsed = TimeSpan.Zero;

            texture = content.Load<Texture2D>(path);

            frameWidth = texture.Width / columns;
            frameHeight = texture.Height / lines;

            frameList = new Rectangle[lines, columns];

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    frameList[i, j] = new Rectangle(frameWidth * j,
                        frameHeight * i,
                        frameWidth,
                        frameHeight);
                }
            }

            //rect = new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight);
        }

        public void Load(ContentManager content, string path, float frameTime, int lines, int columns, Vector2 position)
        {
            this.lines = lines;
            this.columns = columns;

            this.frameTime = frameTime;
            frameCurrent = 0;
            timeLapsed = TimeSpan.Zero;

            texture = content.Load<Texture2D>(path);

            frameWidth = texture.Width / columns;
            frameHeight = texture.Height / lines;

            frameList = new Rectangle[lines, columns];

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    frameList[i, j] = new Rectangle(frameWidth * j,
                        frameHeight * i,
                        frameWidth,
                        frameHeight);
                }
            }

            rect = new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight);
        }
        public virtual void UpdateFrame(GameTime gameTime)
        {
            timeLapsed += gameTime.ElapsedGameTime;
            if (timeLapsed.TotalMilliseconds > frameTime)
            {
                frameCurrent++;

                frameCurrent = frameCurrent % columns;

                timeLapsed = TimeSpan.Zero;
            }
            //rect = new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight);
        }

        //public virtual void UpdateRectangleFrame(GameTime gameTime)
        //{
        //    timeLapsed += gameTime.ElapsedGameTime;
        //    if (timeLapsed.TotalMilliseconds > frameTime)
        //    {
        //        frameCurrent++;

        //        frameCurrent = frameCurrent % columns;

        //        timeLapsed = TimeSpan.Zero;
        //    }
        //    //rect = new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight);
        //}


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, frameList[1, frameCurrent], color);
        }

        public override void DrawRectangle(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, frameList[currentAnimation, frameCurrent], color * alpha, rotation, Vector2.Zero, SpriteEffects.None, 0);
        }

        /// <summary>
        /// Draw centering the frame or not;
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="center"></param>
        public void DrawRectangle(SpriteBatch spriteBatch, bool center)
        {
            if (center)
            {
                spriteBatch.Draw(texture, rect, frameList[currentAnimation, frameCurrent], color * alpha, rotation, new Vector2(frameWidth / 2, frameHeight / 2), SpriteEffects.None, 0);
            }
            else
            {
                spriteBatch.Draw(texture, rect, frameList[currentAnimation, frameCurrent], color * alpha, rotation, Vector2.Zero, SpriteEffects.None, 0);
            }

        }
    }

}
