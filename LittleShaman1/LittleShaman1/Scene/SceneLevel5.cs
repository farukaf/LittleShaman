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
    class SceneLevel5:Gameplay
    {
        public void Load(ContentManager content, GraphicsDevice graphicsDev)
        {
            Load(content, graphicsDev,
                 new Vector2(100, 100), //Player position
                 new Vector3[1] {
                 new Vector3(0,715,1280)},
                 new Vector2[1] { new Vector2(600, 620) }, //Fire position 0
                 new Vector3[2] {
                 new Vector3(-5, 0, 760),
                 new Vector3(0, -5, 1280)}, //Wall position
                 new Vector2(1150, 620) //Exit position
            );
            LoadTotem(content, new Vector2[1] { new Vector2(1000, 540) });
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
