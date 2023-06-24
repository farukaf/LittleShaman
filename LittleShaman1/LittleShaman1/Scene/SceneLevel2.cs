using LittleShaman1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleShaman1.Scene
{
    class SceneLevel2 : Gameplay
    {
        public void Load(ContentManager content, GraphicsDevice graphicsDev)
        {
            camLimitX = 1280;
            camLimitY = 1000;
            
            Load(content, graphicsDev,
               new Vector2(380, 330), //Player position
               new Vector3[4] {
                new Vector3(100,350,75),
                new Vector3(613,350,75),//Platform position
                new Vector3(300,400,200),
                new Vector3(800,400,200)},
               new Vector2[1] { new Vector2(115, 300) }, //Fire position
               new Vector3[2] {
                new Vector3(-5, 0, 760),
                new Vector3(0, -5, 1280)}, //Wall position
               new Vector2(915, 320) //Exit position
           );
            LoadTotem(content, new Vector2[1] { new Vector2(613, 200) });//75,160
        }
        public override bool Update(ContentManager content, GameTime gameTime, MouseState mouse, MouseState mouseCopy, KeyboardState keyboard, KeyboardState keyboardCopy)
        {
            return base.Update(content, gameTime, mouse, mouseCopy, keyboard, keyboardCopy);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
