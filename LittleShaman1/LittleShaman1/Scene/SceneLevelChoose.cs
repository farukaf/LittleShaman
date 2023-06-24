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
    class SceneLevelChoose
    {
        //Button btnLevel1, btnLevel2, btnLevel3, btnLevel4, btnLevel5, btnLevel6, btnLevel7, btnLevel8, btnLevel9;
        ChooseBtn btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12, btn13, btn14, btn15;
        Sprite anibtnLevel;
        Parallax backGround;
        Sprite textCl;
        public void Load(ContentManager content)
        {
            

            btn1 = new ChooseBtn();
            btn1.Load(content, 1, new Vector2(124, 122));
            btn2 = new ChooseBtn();
            btn2.Load(content, 2, new Vector2(347, 122));
            btn3 = new ChooseBtn();
            btn3.Load(content, 3, new Vector2(570, 122));
            btn4 = new ChooseBtn();
            btn4.Load(content, 4, new Vector2(793, 122));
            btn5 = new ChooseBtn();
            btn5.Load(content, 5, new Vector2(1016, 122));
            btn6 = new ChooseBtn();
            btn6.Load(content, 6, new Vector2(124, 320));
            btn7 = new ChooseBtn();
            btn7.Load(content, 7, new Vector2(347, 320));
            btn8 = new ChooseBtn();
            btn8.Load(content, 8, new Vector2(570, 320));
            btn9 = new ChooseBtn();
            btn9.Load(content, 9, new Vector2(793, 320));
            btn10 = new ChooseBtn();
            btn10.Load(content, 1, 0, new Vector2(1016, 320));
            btn11 = new ChooseBtn();
            btn11.Load(content, 1, 1, new Vector2(124, 518));
            btn12 = new ChooseBtn();
            btn12.Load(content, 1, 2, new Vector2(347, 518));
            btn13 = new ChooseBtn();
            btn13.Load(content, 1, 3, new Vector2(570, 518));
            btn14 = new ChooseBtn();
            btn14.Load(content, 1, 4, new Vector2(793, 518));
            btn15 = new ChooseBtn();
            btn15.Load(content, 1, 5, new Vector2(1016, 518));


            textCl = new Sprite();
            textCl.Load(content, "newTextCL", new Vector2(487, 32), Color.White);
            backGround = new Parallax();
            backGround.Load(content, "Menu/Background/NewBG");
        }
        public EnumScene Update(GameTime gameTime, MouseState mouse)
        {
            backGround.Update();
            
            if (btn1.Update(mouse))
            {
                return EnumScene.level1;
            }
            if (btn2.Update(mouse))
            {
                return EnumScene.level2;
            }
            if (btn3.Update(mouse))
            {
                return EnumScene.level3;
            }
            if (btn4.Update(mouse))
            {
                return EnumScene.level4;
            }
            if (btn5.Update(mouse))
            {
                return EnumScene.level5;
            }
            if (btn6.Update(mouse))
            {
                return EnumScene.level6;
            }
            if (btn7.Update(mouse))
            {
                return EnumScene.level7;
            }
            if (btn8.Update(mouse))
            {
                return EnumScene.level8;
            }
            if (btn9.Update(mouse))
            {
                return EnumScene.gamePlay;
            }
            if (btn10.Update(mouse))
            {
                return EnumScene.chooseLevel;
            }
            if (btn11.Update(mouse))
            {
                return EnumScene.chooseLevel;
            }
            if (btn12.Update(mouse))
            {
                return EnumScene.chooseLevel;
            }
            if (btn13.Update(mouse))
            {
                return EnumScene.chooseLevel;
            }
            if (btn14.Update(mouse))
            {
                return EnumScene.chooseLevel;
            }
            if (btn15.Update(mouse))
            {
                return EnumScene.chooseLevel;
            }


           

            return EnumScene.chooseLevel;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            backGround.Draw(spriteBatch);
            textCl.Draw(spriteBatch);
            btn1.Draw(spriteBatch);
            btn2.Draw(spriteBatch);
            btn3.Draw(spriteBatch);
            btn4.Draw(spriteBatch);
            btn5.Draw(spriteBatch);
            btn6.Draw(spriteBatch);
            btn7.Draw(spriteBatch);
            btn8.Draw(spriteBatch);
            btn9.Draw(spriteBatch);
            btn10.Draw(spriteBatch);
            btn11.Draw(spriteBatch);
            btn12.Draw(spriteBatch);
            btn13.Draw(spriteBatch);
            btn14.Draw(spriteBatch);
            btn15.Draw(spriteBatch);
            //btnLevel1.DrawRectangle(spriteBatch);
            //btnLevel2.DrawRectangle(spriteBatch);
            //btnLevel3.DrawRectangle(spriteBatch);
            //btnLevel4.DrawRectangle(spriteBatch);
            //btnLevel5.DrawRectangle(spriteBatch);
            //btnLevel6.DrawRectangle(spriteBatch);
            //btnLevel7.DrawRectangle(spriteBatch);
            //btnLevel8.DrawRectangle(spriteBatch);
            //btnLevel9.DrawRectangle(spriteBatch);
        }
    }
}
