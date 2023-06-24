using LittleShaman1.Helper;
using LittleShaman1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LittleShaman1.Scene
{
    class SceneLevel1 : AutoGenGameplay
    {
        int _contador = 1;
        Random rnd;
        bool death = false;
        string score;
        

        Fonte fonts;


        public void Load(ContentManager content, GraphicsDevice graphicsDev)
        {
            rnd = new Random(DateTime.Now.Millisecond);
            base.camLimitX = (int)(Assist.Resolution.X + _contador * rnd.Next(100, 400));
            Thread.Sleep(2);
            base.camLimitY = (int)(Assist.Resolution.Y + _contador * rnd.Next(100, 400));
            base.exitHeight = 10;
            base.exitWidth = 10;
            Load(content, graphicsDev,
                new Vector2(100, 50),
                new Vector2[1] {
                new Vector2(50,150) },//1              
                null,
                null,
                new Vector2(-100, -100)
            );

            fonts = new Fonte();
            fonts.LoadPQ(content, new Vector2(10,10));
            score = "Score: " + _contador + " Totems: ";
            fonts._string = score;

            Vector2[] _totem;
            Vector2[] _switch;

            _totem = new Vector2[_contador];
            _switch = new Vector2[_contador];

            for (int i = 0; i < _contador; i++)
            {
                _totem[i] = new Vector2(rnd.Next(100, camLimitX - 300), rnd.Next(100, camLimitY - 300));
                Thread.Sleep(2);
                _switch[i] = new Vector2(_totem[i].X + rnd.Next(-100, 300), _totem[i].Y + rnd.Next(-100, 300));
                Thread.Sleep(2);
            }

            LoadTotem(content, _totem);

            LoadSwitch(content, _switch);
            
        }

        

        public bool Update(ContentManager content, GraphicsDevice graphicsDev, GameTime gameTime, MouseState mouse, MouseState mouseCopy, KeyboardState keyboard, KeyboardState keyboardCopy)
        {
            if (CheckTotem())
            {
                _contador++;
                Load(content, graphicsDev);

            }
            
            if (player.position.Y > camLimitY)
            {
                death = true;
                fonts.LoadG(content, new Vector2( Assist.Resolution.X / 2, Assist.Resolution.Y / 2));
                fonts._string = "GAME OVER!!!!!\n SCORE: " + _contador;
                fonts.color = Color.Red; 
                
            }
            if (death)
            {
                return (keyboard.IsKeyUp(Keys.Enter) && keyboardCopy.IsKeyDown(Keys.Enter));
            }
            else
            {
                return base.Update(content, gameTime, mouse, mouseCopy, keyboard, keyboardCopy);

            }

            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!death)
            {
                base.Draw(spriteBatch, false, true);
                spriteBatch.End();
                spriteBatch.Begin();
                fonts.Draw(spriteBatch);
            }
            else
            {
                spriteBatch.Begin();
                fonts.Draw(spriteBatch);
            }
        }
    }
}
