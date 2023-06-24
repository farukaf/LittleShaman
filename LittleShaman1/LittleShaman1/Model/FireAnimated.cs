using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleShaman1.Model
{
    public class FireAnimated : AnimatedSprite
    {

        public void LoadFire(ContentManager content, Vector2 position)
        {
            columns = 7;
            lines = 1;
            Load(content, "LevelObjects/Blackfire", 100, lines, columns);
            this.position = position;
            color = Color.White;

            frameQuantities = new int[lines];
            frameQuantities[lines - 1] = columns;
            currentAnimation = 0;

            rect.Width = texture.Width / columns;
            rect.Height = texture.Height / lines;
            rect.X = (int)position.X;
            rect.Y = (int)position.Y;

        }

        public override void UpdateFrame(GameTime gameTime)
        {
            timeLapsed += gameTime.ElapsedGameTime;
            if (timeLapsed.TotalMilliseconds > frameTime)
            {
                frameCurrent++;

                frameCurrent = frameCurrent % frameQuantities[currentAnimation];

                timeLapsed = TimeSpan.Zero;
            }
        }



        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, frameList[currentAnimation, frameCurrent], color * alpha, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }

    }
}
