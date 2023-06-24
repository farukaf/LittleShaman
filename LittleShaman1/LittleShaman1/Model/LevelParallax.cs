using LittleShaman1.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleShaman1.Model
{
    public class LevelParallax
    {

        public Texture2D back1, back2, back3, back4, estrelas;

        public float mBack1 = 0f, mBack2 = 0.1f, mBack3 = 0.2f, mBack4 = 0.3f;

        float x1, x2, x3, x4;

        public void Load(ContentManager content)
        {
            back1 = content.Load<Texture2D>("LevelBackground/ArvorePreta1");
            back2 = content.Load<Texture2D>("LevelBackground/ArvoreCinza2");
            back3 = content.Load<Texture2D>("LevelBackground/ArvoreVerde3");
            back4 = content.Load<Texture2D>("LevelBackground/FundoVerdeSombraSup");
            estrelas = content.Load<Texture2D>("LevelBackground/FundoEstrelas");

        }


        /// <summary>
        /// Moves the Parallax
        /// </summary>
        /// <param name="camM">CamPosition.X</param>
        public void Update()
        {
            x1 = -Assist.camPosition.X * mBack1;
            x2 = -Assist.camPosition.X * mBack2;
            x3 = -Assist.camPosition.X * mBack3;
            x4 = -Assist.camPosition.X * mBack4;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(back4, new Vector2(x4, 0), new Color(120, 120, 120));
            spriteBatch.Draw(back4, new Vector2(x4 + back4.Width, 0), new Color(120, 120, 120));
            spriteBatch.Draw(back4, new Vector2(x4 + (2 * back4.Width), 0), new Color(120, 120, 120));
            spriteBatch.Draw(estrelas, new Vector2(x4, 0), Color.White);
            spriteBatch.Draw(estrelas, new Vector2(x4 + back4.Width, 0), Color.White);
            spriteBatch.Draw(estrelas, new Vector2(x4 + (2 * back4.Width), 0), Color.White);
            spriteBatch.Draw(back3, new Vector2(x3, 0), new Color(120, 120, 120));
            spriteBatch.Draw(back3, new Vector2(x3 + back3.Width, 0), new Color(120, 120, 120));
            spriteBatch.Draw(back3, new Vector2(x3 + (2 * back3.Width), 0), new Color(120, 120, 120));
            spriteBatch.Draw(back2, new Vector2(x2, 0), Color.DarkGray);
            spriteBatch.Draw(back2, new Vector2(x2 + back2.Width, 0), Color.DarkGray);
            spriteBatch.Draw(back2, new Vector2(x2 + (2 * back2.Width), 0), Color.DarkGray);
            spriteBatch.Draw(back1, new Vector2(x1, 0), Color.White);
            spriteBatch.Draw(back1, new Vector2(x1 + back1.Width, 0), Color.White);
            spriteBatch.Draw(back1, new Vector2(x1 + (2 * back1.Width), 0), Color.White);



        }

    }
}
