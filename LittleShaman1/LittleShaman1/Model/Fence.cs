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
    public class Fence
    {
        Sprite fence1, fence2, fence3;

        public int qntAlpha;

        public int width = 40, height = 60;

        /// <summary>
        /// Carrega a quantidade de cercas; Mudar valor de Width e Height antes do Load();
        /// </summary>
        /// <param name="content"></param>
        /// <param name="position"></param>
        /// <param name="qntAlpha">Uso de Fence para a quantidade de fire no lvl=1qntAlpha:1fire</param>
        public void Load(ContentManager content, Vector2 position, int qntAlpha)
        {
            this.qntAlpha = qntAlpha;

            fence1 = new Sprite();
            fence1.Load(content, "LevelObjects/Fence 1", position, Color.White, width, height);

            fence2 = new Sprite();
            fence2.Load(content, "LevelObjects/Fence 2", position, Color.White, width, height);

            fence3 = new Sprite();
            fence3.Load(content, "LevelObjects/Fence 3", position, Color.White, width, height);

            fence1.alpha = qntAlpha >= 1 ? 1 : 0;
            fence2.alpha = qntAlpha >= 2 ? 1 : 0;
            fence3.alpha = qntAlpha >= 3 ? 1 : 0;
        }

        /// <summary>
        /// vazio--não precisa
        /// </summary>
        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fence1.alpha = qntAlpha >= 1 ? 1 : 0;
            fence2.alpha = qntAlpha >= 2 ? 1 : 0;
            fence3.alpha = qntAlpha >= 3 ? 1 : 0;

            fence1.DrawRectangle(spriteBatch);
            fence2.DrawRectangle(spriteBatch);
            fence3.DrawRectangle(spriteBatch);
        }

    }
}
