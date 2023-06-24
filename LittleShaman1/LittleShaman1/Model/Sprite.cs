using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleShaman1.Model
{
    public class Sprite
    {
        public Texture2D texture;
        public Vector2 position;
        public Color color;
        public Rectangle rect;
        public float alpha = 1;
        private Rectangle sliceRect;
        public int c, l;
        public int[] sSelect;
        public Vector2 vSelect;
        public Sprite()
        {
        }
        /// <summary>
        /// Load simples com posição sprite e cor;
        /// </summary>
        /// <param name="content"></param>
        /// <param name="path"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        public virtual void Load(ContentManager content, string path, Vector2 position, Color color)
        {
            texture = content.Load<Texture2D>(path);
            this.position = position;
            this.color = color;
        }
        /// <summary>
        ///  Load com uso do retangulo; Não utiliza o valor position. Usar rect.X/Y
        /// </summary>
        /// <param name="content"></param>
        /// <param name="path"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="rectWidth"></param>
        /// <param name="rectHeight"></param>
        public virtual void Load(ContentManager content, string path, Vector2 position, Color color, int rectWidth, int rectHeight)
        {
            texture = content.Load<Texture2D>(path);
            this.position = position;
            this.color = color;
            rect = new Rectangle((int)position.X, (int)position.Y, rectWidth, rectHeight);
        }

        /// <summary>
        /// Load com uso do retangulo; Não utiliza o valor position. Usar rect.X/Y
        /// </summary>
        /// <param name="content"></param>
        /// <param name="path"></param>
        /// <param name="color"></param>
        /// <param name="rect"></param>
        public virtual void Load(ContentManager content, string path, Color color, Rectangle rect)
        {
            texture = content.Load<Texture2D>(path);
            position = new Vector2(rect.X, rect.Y);
            this.color = color;
            this.rect = rect;
        }

        /// <summary>
        /// Recorta uma folha de sprite
        /// </summary>
        /// <param name="content"></param>
        /// <param name="path">A path to de texture file</param>
        /// <param name="position">A position</param>
        /// <param name="color">A color :)</param>
        /// <param name="line">How many lines</param>
        /// <param name="col">How many colums</param>
        /// <param name="sSelect">Select the require slice. Seleciona qual faixa da sprite vai selecionar (um vetor com dois numeros: linha e coluna, do endereço da faixa)</param>
        public virtual void LoadSlice(ContentManager content, string path, Vector2 position, Color color, int line, int col, int[] sSelect)
        {
            l = line;
            c = col;
            this.sSelect = sSelect;
            Load(content, path, position, color);
            rect = new Rectangle((int)position.X, (int)position.Y, texture.Width / col, texture.Height / line);
        }

        /// <summary>
        /// Recorta uma folha de sprite
        /// </summary>
        /// <param name="content"></param>
        /// <param name="path"></param>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="line"></param>
        /// <param name="col"></param>
        /// <param name="vSelect">Select the require slice. Seleciona qual faixa da sprite vai selecionar (um vetor com dois numeros: linha e coluna, do endereço da faixa)</param>
        public virtual void LoadSlice(ContentManager content, string path, Vector2 position, Color color, int line, int col, Vector2 vSelect)
        {
            l = line;
            c = col;
            this.vSelect = vSelect;
            Load(content, path, position, color);
            rect = new Rectangle((int)position.X, (int)position.Y, texture.Width / col, texture.Height / line);
        }

        /// <summary>
        /// Recorta uma folha de sprite e a posiciona em um retangulo.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="path"></param>
        /// <param name="position">Position and Size of the Rectangle/ColisionBox (.rect for colision)</param>
        /// <param name="color"></param>
        /// <param name="line"></param>
        /// <param name="col"></param>
        /// <param name="vSelect"></param>
        public virtual void LoadSlice(ContentManager content, string path, Rectangle rectangle, Color color, int line, int col, Vector2 vSelect)
        {
            l = line;
            c = col;
            this.vSelect = vSelect;
            Load(content, path, position, color);
            rect = rectangle;
        }

        /// <summary>
        /// Draw para usar com sprites. Não usa/suporta Retangulos...
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, color * alpha);
        }
        /// <summary>
        /// Versão para ser usado quando retangulo com sprite; não é necessario usar o .Draw
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void DrawRectangle(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rect, color * alpha);
        }

        public virtual void DrawSlice(SpriteBatch spriteBatch)
        {
            if (sSelect != null)
            {
                spriteBatch.Draw(texture, rect, new Rectangle(sSelect[0] * (texture.Width / c), sSelect[1] * (texture.Height / l), (texture.Width / c), (texture.Height / l)), color);
            }
            if (vSelect != null)
            {
                spriteBatch.Draw(texture, rect, new Rectangle((int)vSelect.X * (texture.Width / c), (int)vSelect.Y * (texture.Height / l), (texture.Width / c), (texture.Height / l)), color);
            }

        }

    }
}
