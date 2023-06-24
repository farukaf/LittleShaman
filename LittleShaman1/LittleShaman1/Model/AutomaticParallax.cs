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
    
    public class AutomaticParallax
    {
        Sprite back1, back2;
        
        int speed;

        /// <summary>
        /// Utiliza 2 imagens para ficar automaticamente andando na horizontal <-
        /// </summary>
        public void Load(ContentManager content,string path1, string path2, int speed)
        {
            back1 = new Sprite();
            back1.Load(content, path1, new Vector2(0, 0), Color.White);
            
            

            back2 = new Sprite();
            back2.Load(content, path2, new Vector2(back1.texture.Width, 0), Color.White);

            this.speed = speed;

        }

        public void Update()
        {
            back1.position.X -= this.speed;

            back2.position.X -= this.speed;

            if (back1.position.X <= -back1.texture.Width)
            {
                back1.position.X = back2.position.X + back2.texture.Width;               
            }

            if (back2.position.X <= -back2.texture.Width)
            {
                back2.position.X = back1.position.X + back1.texture.Width;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            back1.Draw(spriteBatch);
            back2.Draw(spriteBatch);
        }

    }
}
