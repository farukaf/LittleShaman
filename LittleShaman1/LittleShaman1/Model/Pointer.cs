using LittleShaman1.Helper;
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
    public class Pointer
    {
        public Sprite point;
        Sprite BlackScreen;
        int speed = 5;
        public void Load(ContentManager content)
        {
            point = new Sprite();
            point.Load(content, "LevelObjects/littleRectangle", new Vector2(Assist.Resolution.X / 2, Assist.Resolution.Y / 2), Color.Wheat, 5, 5);

            BlackScreen = new Sprite();
            BlackScreen.Load(content, "LevelObjects/whitePixel", Vector2.Zero, Color.Black, (int)Assist.Resolution.X, (int)Assist.Resolution.Y);
        }

        public void LoadPointer(ContentManager content)
        {
            point = new Sprite();
            point.Load(content, "LevelObjects/point2", new Vector2(Assist.Resolution.X / 2, Assist.Resolution.Y / 2), Color.Wheat, 19, 19);

        }

        public void Update(KeyboardState keyboard, bool controlState)
        {
            point.alpha = controlState ? 1 : 0;
            BlackScreen.alpha = controlState ? 0.1f : 0;
            #region KeyboardVerification

            if (controlState)
            {

                if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
                {
                    point.rect.X += speed;
                }
                else if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
                {
                    point.rect.X -= speed;
                }
                else if ((keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left)) && (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right)))
                {

                }

                if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
                {
                    point.rect.Y += speed;
                }
                else if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
                {
                    point.rect.Y -= speed;
                }
                else if ((keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down)) && (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up)))
                {

                }
            }
            #endregion
        }

        public void Update(MouseState mouse)
        {
            point.alpha = 1;
            point.rect.X = mouse.X;
            point.rect.Y = mouse.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (BlackScreen != null) BlackScreen.DrawRectangle(spriteBatch);
            point.DrawRectangle(spriteBatch);
        }



    }
}
