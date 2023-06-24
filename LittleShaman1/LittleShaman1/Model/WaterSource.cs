using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using LittleShaman1.Helper;
using System.Diagnostics;

namespace LittleShaman1.Model
{

    public class WaterSource
    {
        //talvez mudar pra animated sprite depois
        public Sprite[] waterSprite;
        float[] rotation;
        int waterSpriteCounter = 1;
        int sprayCount = 0;
        int count = 0;
        //bool para reiniciar o processor
        public bool done = true;
        //offset para linear o movimento da agua
        Vector2 positionOffset, mouse, mouseCopy;


        public AnimatedSprite[] spray;
        public AnimatedSprite source;

        int distance = 12;

        private Vector2 _position { get; set; }
        public float RotationAngle { get; set; }

        private float scale = 2.3f;
        private float waterSourceScale = 2.3f;

        Texture2D _teste;

        /// <summary>
        /// Versão com SpriteAnimada
        /// </summary>
        /// <param name="content"></param>
        /// <param name="position"></param>
        /// <param name="sourceSize"></param>
        public void LoadAnimated(ContentManager content, Vector2 position, int sourceSize)
        {
            _teste = content.Load<Texture2D>("LevelObjects/littleRectangle");

            source = new AnimatedSprite();
            source.Load(content, "LevelObjects/waterSource", 100f, 1, 7, position);
            source.alpha = 1f;
            source.rotation = 0;
            source.color = Color.White;

            spray = new AnimatedSprite[sourceSize];

            for (int i = 0; i < sourceSize; i++)
            {
                spray[i] = new AnimatedSprite();
                spray[i].Load(content, "LevelObjects/waterSpray-16px", 100, 1, 8, position);
                spray[i].frameCurrent = i % 8;
                spray[i].alpha = 0;
                spray[i].color = Color.White;
            }
        }

        /// <summary>
        /// Versão sem sprite com retangulo com cor azul no primeiro e aquamarine nos proximos...
        /// O modelo a ser seguido é para ser subistitudo pelas sprites animadas....
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sourceSize">"Força" da fonte, quantos retangulos a fonte vai produzir</param>
        /// <param name="position">Posição inicial do WaterSource</param>
        public void Load(ContentManager content, int sourceSize, Vector2 position)
        {
            waterSprite = new Sprite[sourceSize];
            rotation = new float[sourceSize];
            for (int i = 0; i < sourceSize; i++)
            {
                waterSprite[i] = new Sprite();
                waterSprite[i].Load(content, "LevelObjects/littleRectangle", position, Color.Aquamarine, 15, 10);
                waterSprite[i].rect.Width = (int)(waterSprite[0].texture.Width * scale);
                waterSprite[i].rect.Height = (int)(waterSprite[0].texture.Height * scale);
            }

            waterSprite[0].rect.Width = (int)(waterSprite[0].texture.Width * waterSourceScale);
            waterSprite[0].rect.Height = (int)(waterSprite[0].texture.Height * waterSourceScale);
            waterSprite[0].color = Color.Blue;
            waterSprite[0].alpha = 0.2f;
            rotation[0] = 0;


        }

        /// <summary>
        /// Versão para teste
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="mouseCopy"></param>
        public void Update(MouseState mouse, MouseState mouseCopy)
        {
            this.mouse.X = (int)(mouse.X - Assist.camPosition.X);
            this.mouse.Y = (int)(mouse.Y - Assist.camPosition.Y);
            this.mouseCopy.X = (int)(mouseCopy.X - Assist.camPosition.X);
            this.mouseCopy.Y = (int)(mouseCopy.Y - Assist.camPosition.Y);

            if (mouse.LeftButton == ButtonState.Released)
            {
                count = 0;
                waterSpriteCounter = 0;
                done = true;
            }
            // WIP: para esconder as sprites quando estiver em sem fluxo tem duas opções
            // 1-retirar os alfa quando estiver proximod o centro da primeira sprite
            // 2- fazer a sprite grande o suficiente para tampar o fluxo proximo...(escolhi essa :P )
            if (mouse.LeftButton == ButtonState.Pressed && mouseCopy.LeftButton == ButtonState.Released)
            {
                if (waterSprite[0].rect.Contains(this.mouse.X, this.mouse.Y) && done)
                {
                    for (int i = 1; i < waterSprite.Length; i++)
                    {
                        waterSprite[i].rect.X = waterSprite[0].rect.X;
                        waterSprite[i].rect.Y = waterSprite[0].rect.Y;
                        rotation[i] = rotation[0];
                        waterSpriteCounter = 0;
                    }
                    done = false;
                }

            }

            if (!done)
            {
                try
                {
                    float _mouseDistance = Vector2.Distance(
                        new Vector2(waterSprite[waterSpriteCounter].rect.X, waterSprite[waterSpriteCounter].rect.Y)
                        , this.mouse);

                    if (_mouseDistance > 30)
                    {
                        count++;

                        if (count > 1)
                        {
                            waterSpriteCounter++;
                            WaterMoviment(this.mouse);
                            count = 0;
                        }
                        if (mouse.LeftButton == ButtonState.Released)
                        {
                            count = 0;
                            waterSpriteCounter = 1;
                            done = true;
                        }
                    }
                }

                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// Versão com animações e controle pelos direcionais em tempo real...(não gostei)
        /// </summary>
        public void UpdateAnimated(GameTime gameTime, bool controlState, Pointer pointer, KeyboardState keyboard, KeyboardState keyboardCopy)
        {
            //this.mouse.X = (int)(mouse.X - Assist.camPosition.X);
            //this.mouse.Y = (int)(mouse.Y - Assist.camPosition.Y);
            //this.mouseCopy.X = (int)(mouseCopy.X - Assist.camPosition.X);
            //this.mouseCopy.Y = (int)(mouseCopy.Y - Assist.camPosition.Y);

            source.UpdateFrame(gameTime);

            for (int i = 0; i < spray.Length; i++)
            {
                spray[i].UpdateFrame(gameTime);
            }

            if (controlState && keyboard.IsKeyDown(Keys.Space))
            {
                if (keyboardCopy.IsKeyUp(Keys.Space) && source.rect.Contains(pointer.point.rect.X - Assist.camPosition.X, pointer.point.rect.Y - Assist.camPosition.Y))
                {
                    for (int i = 0; i < spray.Length; i++)
                    {
                        spray[i].frameCurrent = i % 8;
                        spray[i].alpha = 0;
                        spray[i].color = Color.White;
                        spray[i].position = new Vector2(source.rect.X, source.rect.Y);
                        sprayCount = 0;
                        done = false;
                    }
                }
                if ((!done) && !(source.rect.Contains(pointer.point.rect.X, pointer.point.rect.Y)) &&
                    ((pointer.point.rect.X - Assist.camPosition.X) - spray[sprayCount].rect.X > distance ||
                    (pointer.point.rect.Y - Assist.camPosition.Y) - spray[sprayCount].rect.Y > distance ||
                    (pointer.point.rect.X - Assist.camPosition.X) - spray[sprayCount].rect.X < -distance ||
                    (pointer.point.rect.Y - Assist.camPosition.Y) - spray[sprayCount].rect.Y < -distance))
                {
                    spray[sprayCount].rect.X = (int)(pointer.point.rect.X - Assist.camPosition.X);
                    spray[sprayCount].rect.Y = (int)(pointer.point.rect.Y - Assist.camPosition.Y);
                    spray[sprayCount].alpha = 1;

                    //find out spray rotation
                    if (sprayCount > 0)
                    {
                        positionOffset = new Vector2(spray[sprayCount - 1].rect.X - spray[sprayCount].rect.X,
                            spray[sprayCount - 1].rect.Y - spray[sprayCount].rect.Y);
                        positionOffset.Normalize();
                        spray[sprayCount].rotation = (float)Math.Atan2((double)positionOffset.Y, (double)positionOffset.X);
                    }



                    sprayCount++;
                    if (sprayCount > spray.Length - 3)
                    {
                        done = true;
                    }
                }
            }

        }

        /// <summary>
        /// Versão que cria em linha reta com um "preview" (WIP)
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="pointer"></param>
        /// <param name="controlState"></param>
        /// <param name="keyboard"></param>
        /// <param name="keyboardCopy"></param>
        public void UpdateAnimated(GameTime gameTime, Pointer pointer, bool controlState, KeyboardState keyboard, KeyboardState keyboardCopy)
        {
            //this.mouse.X = (int)(mouse.X - Assist.camPosition.X);
            //this.mouse.Y = (int)(mouse.Y - Assist.camPosition.Y);
            //this.mouseCopy.X = (int)(mouseCopy.X - Assist.camPosition.X);
            //this.mouseCopy.Y = (int)(mouseCopy.Y - Assist.camPosition.Y);

            source.UpdateFrame(gameTime);

            for (int i = 0; i < spray.Length; i++)
            {
                spray[i].UpdateFrame(gameTime);
            }

            if (controlState && keyboard.IsKeyDown(Keys.Space))
            {
                if (keyboardCopy.IsKeyUp(Keys.Space) && source.rect.Contains(pointer.point.rect.X - Assist.camPosition.X, pointer.point.rect.Y - Assist.camPosition.Y))
                {
                    for (int i = 0; i < spray.Length; i++)
                    {
                        spray[i].frameCurrent = i % 8;
                        spray[i].alpha = 0;
                        spray[i].color = Color.White;
                        spray[i].position = new Vector2(source.rect.X, source.rect.Y);
                        sprayCount = 0;
                        done = false;
                    }
                }
                if ((!done) && !(source.rect.Contains(pointer.point.rect.X, pointer.point.rect.Y)) &&
                    ((pointer.point.rect.X - Assist.camPosition.X) - spray[sprayCount].rect.X > distance ||
                    (pointer.point.rect.Y - Assist.camPosition.Y) - spray[sprayCount].rect.Y > distance ||
                    (pointer.point.rect.X - Assist.camPosition.X) - spray[sprayCount].rect.X < -distance ||
                    (pointer.point.rect.Y - Assist.camPosition.Y) - spray[sprayCount].rect.Y < -distance))
                {
                    spray[sprayCount].rect.X = (int)(pointer.point.rect.X - Assist.camPosition.X);
                    spray[sprayCount].rect.Y = (int)(pointer.point.rect.Y - Assist.camPosition.Y);
                    spray[sprayCount].alpha = 1;

                    //find out spray rotation
                    if (sprayCount > 0)
                    {
                        if (spray[sprayCount].rect.Y >= spray[sprayCount - 1].rect.Y)
                        {
                            spray[sprayCount].rect.Y = spray[sprayCount - 1].rect.Y - 1;
                        }
                        positionOffset = new Vector2(spray[sprayCount - 1].rect.X - spray[sprayCount].rect.X,
                            spray[sprayCount - 1].rect.Y - spray[sprayCount].rect.Y);
                        positionOffset.Normalize();

                        spray[sprayCount].rotation = (float)Math.Atan2((double)positionOffset.Y, (double)positionOffset.X);
                        if (spray[sprayCount].rotation > spray[sprayCount - 1].rotation + 0.1f)
                        {
                            spray[sprayCount - 1].rotation += 0.1f;
                            spray[sprayCount].rotation = spray[sprayCount - 1].rotation + 0.1f;

                        }
                        else if (spray[sprayCount].rotation < spray[sprayCount - 1].rotation - 0.1f)
                        {
                            spray[sprayCount - 1].rotation -= 0.1f;
                            spray[sprayCount].rotation = spray[sprayCount - 1].rotation - 0.1f;

                        }
                        //spray[sprayCount].rotation = (spray[sprayCount].rotation + spray[sprayCount - 1].rotation) / 2;

                    }
                    else if (sprayCount == 0)
                    {
                        spray[sprayCount].rotation = 1.5f;
                    }



                    sprayCount++;
                    if (sprayCount > spray.Length - 3)
                    {
                        done = true;
                    }
                }
            }

        }


        /// <summary>
        /// Desanimado (sem animação)     
        /// </summary>
        /// <param name="mouse"></param>
        private void WaterMoviment(Vector2 mouse)
        {
            float _distance = Vector2.Distance(new Vector2(waterSprite[waterSpriteCounter - 1].rect.X, waterSprite[waterSpriteCounter - 1].rect.Y),
                new Vector2(mouse.X - waterSprite[0].rect.Width / 2, mouse.Y - waterSprite[0].rect.Height / 2));
            positionOffset = new Vector2(mouse.X - waterSprite[0].rect.Width / 2, mouse.Y - waterSprite[0].rect.Height / 2) -
                new Vector2(waterSprite[waterSpriteCounter - 1].rect.X, waterSprite[waterSpriteCounter - 1].rect.Y);
            positionOffset.Normalize();

            Vector2 _nextPosition = new Vector2(
                waterSprite[waterSpriteCounter - 1].rect.X,
                waterSprite[waterSpriteCounter - 1].rect.Y);

            _nextPosition += 10 * positionOffset;

            if (Vector2.Distance(_nextPosition, new Vector2(mouse.X - waterSprite[0].rect.Width / 2, mouse.Y - waterSprite[0].rect.Height / 2)) >= _distance)
            {
                _nextPosition = new Vector2(mouse.X - waterSprite[0].rect.Width / 2, mouse.Y - waterSprite[0].rect.Height / 2);
            }

            waterSprite[waterSpriteCounter].rect.X = (int)_nextPosition.X;
            waterSprite[waterSpriteCounter].rect.Y = (int)_nextPosition.Y;

            rotation[waterSpriteCounter] = (float)Math.Atan2((double)positionOffset.Y, (double)positionOffset.X);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 2; i < waterSprite.Length; i++)
            {
                spriteBatch.Draw(waterSprite[i].texture, new Vector2(waterSprite[i].rect.X, waterSprite[i].rect.Y)
                    , null, waterSprite[i].color
                    , rotation[i]
                    , new Vector2(0, 0), //Origem
                    scale, //scala tem que ser calculada a partir da textura e depois para o tamanho do retangulo
                    SpriteEffects.None, 1.0f); //spriteEffect,profundidade
                //waterSprite[i].DrawRectangle(spriteBatch);
            }
            waterSprite[0].DrawRectangle(spriteBatch);
            spriteBatch.Draw(waterSprite[0].texture, new Vector2(waterSprite[0].rect.X, waterSprite[0].rect.Y), null, waterSprite[0].color, rotation[0]
                   , new Vector2(0, 0), //Origem
                   waterSourceScale, //escala
                   SpriteEffects.None, 1.0f); //spriteEffect,profundidade


        }


        public void DrawAnimated(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < spray.Length; i++)
            {
                spray[i].DrawRectangle(spriteBatch, true);
            }
            source.DrawRectangle(spriteBatch);

            //spriteBatch.Draw(_teste, source.rect, Color.Yellow * 0.6f);

        }

        /// <summary>
        /// Show Start Rect for tests
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="testRect"></param>
        public void DrawAnimated(SpriteBatch spriteBatch, bool testRect)
        {
            for (int i = 0; i < spray.Length; i++)
            {
                spray[i].DrawRectangle(spriteBatch, true);
            }
            source.DrawRectangle(spriteBatch);

            if (testRect) spriteBatch.Draw(_teste, source.rect, Color.Yellow * 0.6f);

        }
    }
}
