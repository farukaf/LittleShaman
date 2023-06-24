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
    public class Fonte
    {
        SpriteFont font;
        Vector2 position;
        //Texture2D texture;
        public string _string;
        public Color color = Color.Blue;



        public void LoadPQ(ContentManager content, Vector2 position)
        {
            font = content.Load<SpriteFont>("font/showcardgothic18");
            this.position = position;
        }

        public void LoadPQ(ContentManager content, Vector2 position, string _string)
        {
            font = content.Load<SpriteFont>("font/showcardgothic18");
            this.position = position;
            this._string = _string;
        }

        public void LoadG(ContentManager content, Vector2 position)
        {
            font = content.Load<SpriteFont>("font/showcardgothic26");
            this.position = position;
        }

        public void LoadG(ContentManager content, Vector2 position, string _string)
        {
            font = content.Load<SpriteFont>("font/showcardgothic26");
            this.position = position;
            this._string = _string;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, positionRec, Color.White);
            spriteBatch.DrawString(font, _string, position, color);
        }

        public void DrawCenter(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, _string, position, color, 0, new Vector2(font.MeasureString(_string).X/2, font.MeasureString(_string).Y / 2), 1, SpriteEffects.None, 0);
        }
    }
}
