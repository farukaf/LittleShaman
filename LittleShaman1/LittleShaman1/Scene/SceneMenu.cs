using LittleShaman1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleShaman1.Scene
{
    class SceneMenu
    {

        //AutomaticParallax parallax;
        //Button buttonPlay;
        //Sprite menu;
        Sprite luzBnt;
        bool btn;
        Button btnStart, Exit;
        Parallax backGround;
        float alpha;
        TimeSpan timeLapsed;
        Rectangle btnSCollision;
        

        public void Load(ContentManager content)
        {
            backGround = new Parallax();
            backGround.Load(content,"Menu/Background/newwbg");
            btn = false;
            btn = true;
            btnStart = new Button();
            btnStart.Load(content, "Menu/Button/BnStart2", new Vector2(500, 300), Color.White, 0, 0);
            btnStart.rect.Width = btnStart.texture.Width;
            btnStart.rect.Height = btnStart.texture.Height;
            luzBnt = new Sprite();
            luzBnt.Load(content, "Menu/Button/luzBnt", new Vector2(btnStart.position.X - 5, btnStart.position.Y - 4), Color.White, 200, 200);
            luzBnt.rect.Width = luzBnt.texture.Width + 10;
            luzBnt.rect.Height = luzBnt.texture.Height + 10;
            luzBnt.alpha = 0;
            btnSCollision = new Rectangle(250, 200, btnStart.texture.Width, btnStart.texture.Height);
            Exit = new Button();
            Exit.Load(content, "Menu/Button/BtnExit", new Vector2(600 , 500), Color.White, 106, 50);
            //menu = new Sprite()
            //{
            //    texture = content.Load<Texture2D>("Menu/Background/menu"),
            //    color = Color.White,
            //    position = new Vector2(0,0)
            //};

            //menu = new Sprite();

            //menu.Load(content, "Menu/Background/BGShaman", new Vector2(0, 0), Color.White,
            //    0, 0);
            //menu.rect.Width = (int)menu.texture.Width;
            //menu.rect.Height = (int)menu.texture.Height;

            //background = new Sprite();

            //parallax = new AutomaticParallax();
            //parallax.Load(content, "Background/bgAbertura01", "Background/bgAbertura02", 5);


            //logo = new Sprite()
            //{
            //    texture = content.Load<Texture2D>("logo/logoTAKWSN"),

            //    color = Color.White,
            //    position = new Vector2(50, 50)
            //};


            //buttonPlay = new Button();
            //buttonPlay.Load(content, "icon/btnPlay", "SoundEffect/noo", new Vector2(600, 380));
        }

        public EnumScene Update(GameTime gameTime, KeyboardState keyboard, MouseState mouse, MouseState mouseCopy)
        {
            if (btnStart.UpdateSKRelease(mouse, mouseCopy) || keyboard.IsKeyDown(Keys.Enter))
            {
                return EnumScene.tutorial;
            }
            
            backGround.Update();
            //parallax.Update();
            timeLapsed += gameTime.ElapsedGameTime;
            if (timeLapsed.TotalMilliseconds < 3500)
            {
                alpha += 0.005f;
            }

            if (luzBnt.rect.Contains(mouse.Position))
            {
                luzBnt.alpha = 0.4f;
            }
            else
            {
                luzBnt.alpha = 0;
            }
            if (Exit.UpdateSKRelease(mouse, mouseCopy) || keyboard.IsKeyDown(Keys.Escape))
            {
                
            }
         

            
            return EnumScene.menu;
        }


        public void Draw(SpriteBatch spriteBatch)
        {

            backGround.Draw(spriteBatch);
            luzBnt.DrawRectangle(spriteBatch);
            btnStart.Draw(spriteBatch);
            Exit.Draw(spriteBatch);

            //parallax.Draw(spriteBatch);

            //spriteBatch.Draw(backGround.texture, menu.rect, menu.color * alpha);

            //8ª draw
            //spriteBatch.Draw(
            //    menu.texture, //textura
            //    menu.position, //posicao
            //    null, //retangulo de corte da imagem
            //    menu.color, //cor
            //    0, //rotacao
            //    Vector2.Zero, //centro da imagem
            //    0.8f, //escala
            //    SpriteEffects.None, //efeito de espelho
            //    1 // profundidade
            //    );


            //buttonPlay.Draw(spriteBatch);


        }
    }
}
