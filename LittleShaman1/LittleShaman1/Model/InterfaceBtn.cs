using LittleShaman1.Helper;
using LittleShaman1.Scene;
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
    public class InterfaceBtn
    {
        Button btnPaused, btnUp, btnLeft, btnRigth, btnContinue, btnExit, btnRestart;
        Sprite scenePause;
        Vector2 position;
        float alpha;
        bool btnPause = false;
        bool btnstatus = false;

        //Texture2D texture;
        //Vector2 position;
        //Color color;

        public void Load(ContentManager content)
        {
            btnPaused = new Button();
            btnPaused.Load(content, "Menu/Button/BtnPaused", new Vector2(1100, 20), Color.White, 120, 65);
            //btnUp = new Button();
            //btnUp.Load(content, "Menu/Button/BtnUp", new Vector2(650, 400), Color.White, 93, 63);
            //btnUp.alpha = 0.5f;
            //btnLeft = new Button();
            //btnLeft.Load(content, "Menu/Button/BtnLeft", new Vector2(50, 400), Color.White, 93, 63);
            //btnLeft.alpha = 0.5f;
            //btnRigth = new Button();
            //btnRigth.Load(content, "Menu/Button/BtnRigth", new Vector2(250, 400), Color.White, 93, 63);
            //btnRigth.alpha = 0.5f;


            //texture = content.Load<Texture2D>("Menu/Background/interface");
            //this.position = new Vector2(0,0);
            //this.color = Color.White;
        }
        public bool Update(ContentManager content, GameTime gameTime, MouseState mouse, MouseState mouseCopy)
        {

            if (btnPaused.Update(mouse, mouseCopy)) scenePause = new Sprite();

            if (scenePause != null)
            {
                scenePause = new Sprite();
                scenePause.Load(content, "Menu/Background/ScenePause", Vector2.Zero, Color.White, (int)Assist.Resolution.X, (int)Assist.Resolution.Y);


                btnContinue = new Button();
                btnContinue.Load(content, "Menu/Button/BtnContinue", new Vector2(Assist.Resolution.X / 2 - 120, Assist.Resolution.Y / 2), Color.White, 240, 50);
                if (btnContinue.UpdateSKRelease(mouse, mouseCopy))
                {
                    scenePause = null;
                    btnContinue = null;
                }
                btnRestart = new Button();
                btnRestart.Load(content, "Menu/Button/BtnRestart", new Vector2(Assist.Resolution.X / 2 - 98, Assist.Resolution.Y / 2), Color.White, 196, 50);

                btnExit = new Button();
                btnExit.Load(content, "Menu/Button/BtnExit", new Vector2(Assist.Resolution.X / 2 - 53, Assist.Resolution.Y / 2 + 120), Color.White, 106, 50);


                return btnExit.UpdateSKRelease(mouse, mouseCopy);




            }
            return false;
        }



        public bool Restart(MouseState mouse, MouseState mouseCopy)
        {
            if (scenePause != null) return btnRestart.UpdateSKRelease(mouse, mouseCopy);

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (scenePause != null)
            {
                scenePause.DrawRectangle(spriteBatch);
                btnContinue.DrawRectangle(spriteBatch);
                //btnRestart.DrawRectangle(spriteBatch);
                btnExit.DrawRectangle(spriteBatch);
                return;
            }

            btnPaused.DrawRectangle(spriteBatch);
            //btnUp.DrawRectangle(spriteBatch);
            //btnLeft.DrawRectangle(spriteBatch);
            //btnRigth.DrawRectangle(spriteBatch);
            //spriteBatch.Draw(texture, position, color);
        }

    }
}
