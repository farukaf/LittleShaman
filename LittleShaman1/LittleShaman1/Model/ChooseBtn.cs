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
    class ChooseBtn
    {
        Button btn;
        Texture2D texture;

        Vector2 position;
        Rectangle rect, rect2;

        bool dezena = false;

        /// <summary>
        /// Carrega o btn com UM numero centralizado por cima
        /// </summary>
        /// <param name="content"></param>
        /// <param name="n">0-9</param>
        /// <param name="position"></param>
        public void Load(ContentManager content, int n, Vector2 position)
        {
            this.position = position;

            texture = content.Load<Texture2D>("Menu/Background/numeros");

            int frameWidth = texture.Width / 5, frameHeight = texture.Height / 2;

            rect = new Rectangle((int)(frameWidth * NumberPos(n).X),
                (int)(frameHeight * NumberPos(n).Y),
                frameWidth, frameHeight);

            btn = new Button();
            btn.Load(content, "Menu/Background/iconstages", position, Color.White, 140, 80);
            
        }

        /// <summary>
        /// Carrega o btn com 2 numeros centralizados por cima
        /// </summary>
        /// <param name="content"></param>
        /// <param name="m">primeiro numero 0-9</param>
        /// <param name="n">segundo numero 0-9</param>
        /// <param name="position"></param>
        public void Load(ContentManager content, int m, int n, Vector2 position)
        {
            dezena = true;
            this.position = position;

            texture = content.Load<Texture2D>("Menu/Background/numeros");

            int frameWidth = texture.Width / 5, frameHeight = texture.Height / 2;

            rect = new Rectangle((int)(frameWidth * NumberPos(m).X),
                (int)(frameHeight * NumberPos(m).Y),
                frameWidth, frameHeight);

            rect2 = new Rectangle((int)(frameWidth * NumberPos(n).X),
                (int)(frameHeight * NumberPos(n).Y),
                frameWidth, frameHeight);

            btn = new Button();
            btn.Load(content, "Menu/Background/iconstages", position, Color.White, 140, 80);
           
        }

        /// <summary>
        /// Acha a posição do numero na sprite
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private Vector2 NumberPos(int n)
        {
            Vector2 pos;
            if (n == 0)
            {
                pos = new Vector2(4, 1);
                return pos;
            }


            pos = new Vector2(
                n < 6 ? n - 1 : n - 6,
                n < 6 ? 0 : 1
                );

            return pos;
        }



        public bool Update(MouseState mouse)
        {
            return btn.Update(mouse);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (dezena)
            {
                btn.DrawRectangle(spriteBatch);
                spriteBatch.Draw(texture, new Vector2(position.X - 9, position.Y - 12), rect, Color.White);
                spriteBatch.Draw(texture, new Vector2(position.X + 38, position.Y - 12), rect2, Color.White);
            }
            else
            {
                btn.DrawRectangle(spriteBatch);
                spriteBatch.Draw(texture, new Vector2(position.X + 12, position.Y - 12), rect, Color.White);
            }

        }
    }
}
