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
    class SceneLevel4:Gameplay
    {
        public void Load(ContentManager content, GraphicsDevice graphicsDev)
        {
            camLimitX = 1280;
            camLimitY = 1000;

            Load(content, graphicsDev,
                new Vector2(305, 530), //Player position
                new Vector3[3] {
                new Vector3(180,300,300),
                new Vector3(860,450,200),
                new Vector3(220,600,200)},
                new Vector2[1] { new Vector2(945, 380) }, //Fire position
                new Vector3[2] {
                new Vector3(-5, 0, 760),
                new Vector3(0, -5, 1280)}, //Wall position
                new Vector2(290, 220) //Exit position
            );
            LoadTotem(content, 
                new Vector2[2] {
                    new Vector2(180, 140),  ///75/160
                    new Vector2(400, 140)});
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
