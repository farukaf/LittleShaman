
using LittleShaman1.Helper;
using LittleShaman1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace LittleShaman1.Scene
{
    /// <summary>
    /// Classe para testes de Cena. Todos os Poderes sem nenhuma responsabilidade xD
    /// </summary>
    public class ScenePlay : AutoGenGameplay
    {
        int fase = 1;
        Random rnd;
        bool death = false;

        Fonte fonts;

        Sprite sombra;

        public LevelParallax levelParallax;


        public void Load(ContentManager content, GraphicsDevice graphicsDev)
        {
            rnd = new Random(DateTime.Now.Millisecond);
            base.camLimitX = (int)(Assist.Resolution.X + fase * 150);
            Thread.Sleep(2);
            base.camLimitY = 1200;
            base.exitHeight = 10;
            base.exitWidth = 10;
            playerStartPosition = new Vector2(rnd.Next(200, camLimitX - 200), rnd.Next(200, camLimitY - 200));
            Load(content, graphicsDev,
                playerStartPosition,
                new Vector2[1] {
                new Vector2(playerStartPosition.X-30, playerStartPosition.Y+100)},//1              
                null,
                null,
                new Vector2(-100, -100)
            );

            levelParallax = new LevelParallax();
            levelParallax.Load(content);

            sombra = new Sprite();
            sombra.Load(content, "LevelBackground/Sombra inferior", Vector2.Zero, Color.White);

            fonts = new Fonte();
            fonts.LoadPQ(content, new Vector2(10, 10));

            fonts._string = "Score: " + brokenTotems * 10 + " Totems Restantes: " + (fase - brokenTotems);

            Vector2[] _totem;
            Vector2[] _switch;

            _totem = new Vector2[fase];
            _switch = new Vector2[fase];

            for (int i = 0; i < fase; i++)
            {
                _totem[i] = new Vector2(rnd.Next(100, camLimitX - 300), rnd.Next(100, camLimitY - 300));
                Thread.Sleep(2);
                _switch[i] = new Vector2(_totem[i].X + rnd.Next(-100, 200), _totem[i].Y + rnd.Next(-100, 200));
                Thread.Sleep(2);

            }

            LoadTotem(content, _totem);

            LoadSwitch(content, _switch);

        }



        public bool Update(ContentManager content, GraphicsDevice graphicsDev, GameTime gameTime, MouseState mouse, MouseState mouseCopy, KeyboardState keyboard, KeyboardState keyboardCopy)
        {
            if (CheckTotem())
            {
                fase++;
                Load(content, graphicsDev);
            }

            if (player.position.Y > camLimitY)
            {
                death = true;
                fonts.LoadG(content, new Vector2(Assist.Resolution.X / 2, Assist.Resolution.Y / 2 - 50));
                fonts._string = "";
                fonts.color = Color.Red;
            }

            levelParallax.Update();

            int _alavancaRestantes = 0;

            for (int i = 0; i < alavanca.Length; i++)
            {
                if (alavanca[i].active == false) _alavancaRestantes++;
            }

            if (death)
            {
                return (keyboard.IsKeyUp(Keys.Enter) && keyboardCopy.IsKeyDown(Keys.Enter));
            }
            else
            {
                fonts._string = "Score: " + brokenTotems * 10 + " Totems Restantes: " + (_alavancaRestantes);
                return base.Update(content, gameTime, mouse, mouseCopy, keyboard, keyboardCopy);
            }


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!death)
            {
                DrawBegin(spriteBatch);
                levelParallax.Draw(spriteBatch);
                spriteBatch.End();
                base.Draw(spriteBatch, false, true);
                spriteBatch.End();
                spriteBatch.Begin();
                fonts.Draw(spriteBatch);
                sombra.Draw(spriteBatch);
            }
            else
            {
                spriteBatch.Begin();

                fonts._string = "GAME OVER!!!!!";
                fonts.DrawCenter(spriteBatch);

                fonts._string = "\n\nSCORE: " + (brokenTotems * 10);
                fonts.DrawCenter(spriteBatch);

                fonts._string = "\n\n\n\nPressione Enter para sair.";
                fonts.DrawCenter(spriteBatch);
            }


        }
    }
}
