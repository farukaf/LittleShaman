using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LittleShaman1.Model
{
    public enum PlayerState
    {
        walk, jump, land, stand
    }
    public class Player : AnimatedSprite
    {
        //From Samples
        // Constants for controling horizontal movement 
        private const float MoveAcceleration = 12000.0f;
        private const float MaxMoveSpeed = 350.0f;
        private const float GroundDragFactor = 0.48f;
        private const float AirDragFactor = 0.58f;


        // Constants for controlling vertical movement 
        private const float MaxJumpTime = 0.45f;
        private const float JumpLaunchVelocity = -3500.0f;
        private const float GravityAcceleration = 3400.0f;
        private const float MaxFallSpeed = 300.0f;
        private const float JumpControlPower = 0.14f;

        public bool isJumping = false;

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        Vector2 velocity;


        public float jumpTime;


        /// <summary> 
        /// Current user movement input. 
        /// </summary> 
        private float movement = 0;

        private int _lines = 4, _cols = 8;

        public Sprite topChar, botChar, leftChar, rightChar;
        public Vector2 speed;

        public int score;

        public PlayerState playerState = PlayerState.stand, playerStateCopy;
        public int _jumpCounter = 0;
        Vector2 cameraStart = new Vector2(400, 240);
        public SpriteEffects mirror;

        public Vector2 positionCopy;

        public float _auxPositionTopChar;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="spritePath"></param>
        /// <param name="startPosition">Posição Inicial</param>
        public void LoadCharacter(ContentManager content, Vector2 startPosition)
        {
            //content,spritepath,frametime,lines,cols -- modificar quando terminar a sprite            

            Load(content, "Character/SpriteShamanResize", 100, _lines, _cols);

            score = 0;

            position = startPosition;

            color = Color.White;

            currentAnimation = (int)PlayerState.stand;

            LoadRectangles(content);

            LoadStates();
            //cameraStart = camera.Position;
        }


        public void Update(KeyboardState keyboard, KeyboardState keyboardCopy, GameTime gameTime)
        {
            GetInput(keyboard, keyboardCopy, gameTime);

            #region ApplyFisics
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;


            #region Jump
            //se estiver pulando -> pula (mecanica do pulo)
            if (isJumping)
            {
                if (playerStateCopy != PlayerState.jump && playerState == PlayerState.jump)
                {
                    //som do pulo

                }
                jumpTime += (float)gameTime.ElapsedGameTime.TotalSeconds;


                if (jumpTime > 0 && jumpTime <= MaxJumpTime)
                {
                    velocity.Y = JumpLaunchVelocity * (1.0f - (float)Math.Pow(jumpTime / MaxJumpTime, JumpControlPower));
                }
                else
                {
                    jumpTime = 0.0f;
                    isJumping = false;
                }
            }
            else
            {
                jumpTime = 0.0f;
            }
            //else

            #endregion
            //movimenta de acordo com os calculos passados

            velocity.X += movement * MoveAcceleration * elapsed;

            velocity.Y = MathHelper.Clamp(velocity.Y + GravityAcceleration * elapsed, -MaxFallSpeed, MaxFallSpeed);

            velocity.X = MathHelper.Clamp(velocity.X, -MaxMoveSpeed, MaxMoveSpeed);

            if (playerState == PlayerState.jump)
            {
                position += velocity * elapsed;
                position = new Vector2((float)Math.Round(position.X), (float)Math.Round(position.Y));
            }
            else
            {
                position.X += velocity.X * elapsed;
                position.X = (float)Math.Round(position.X);
            }

            if (position.X == positionCopy.X || movement == 0)
                velocity.X = 0;

            if (position.Y == positionCopy.Y)
                velocity.Y = 0;
            #endregion


        }

        private void LoadRectangles(ContentManager content)
        {
            topChar = new Sprite();
            botChar = new Sprite();
            leftChar = new Sprite();
            rightChar = new Sprite();

             _auxPositionTopChar = (float)(((texture.Width / _cols) / 2) - (((texture.Width / _cols) * 0.7) / 2));

            topChar.Load(content, "LevelObjects/whitePixel", new Vector2(position.X - _auxPositionTopChar, position.Y ), Color.DeepPink, (int)((texture.Width / _cols) * 0.7), 20);
            botChar.Load(content, "LevelObjects/whitePixel", new Vector2((int)position.X - _auxPositionTopChar, (int)(position.Y + texture.Height / _lines - 15)), Color.DeepPink, (int)(texture.Width / _cols * 0.7), 15);
            leftChar.Load(content, "LevelObjects/whitePixel", new Vector2((int)position.X, position.Y + 10), Color.Beige, texture.Width / _cols / 2, texture.Height / _lines - 15);
            rightChar.Load(content, "LevelObjects/whitePixel", new Vector2((int)position.X + texture.Width / _cols / 2, position.Y + 10), Color.Yellow, texture.Width / _cols / 2, texture.Height / _lines  -15);

            float _alpha = 0.4f;
            topChar.alpha = _alpha;
            botChar.alpha = _alpha;
            leftChar.alpha = _alpha;
            rightChar.alpha = _alpha;
        }




        public void UpdateStates(GameTime gameTime)
        {
            //atualiza posições e frames necessida estar no fim da classe
            UpdatePlayerFrame(gameTime);

            if (pastAnimation != currentAnimation)
            {
                frameCurrent = 0;
                timeLapsed = TimeSpan.Zero;
            }
            

            //atualização dos rectangulos de colisão
            topChar.rect.X = (int)(position.X + _auxPositionTopChar);
            topChar.rect.Y = (int)(position.Y);

            leftChar.rect.X = (int)position.X;
            leftChar.rect.Y = (int)position.Y + 5;

            rightChar.rect.X = (int)position.X + (texture.Width / _cols) / 2;
            rightChar.rect.Y = (int)position.Y + 5;


            botChar.rect.X = (int)(position.X + _auxPositionTopChar);
            botChar.rect.Y = (int)(position.Y + texture.Height / lines - 15);


            pastAnimation = currentAnimation;
            playerStateCopy = playerState;
            positionCopy = position;

        }


        /// <summary> 
        /// Gets player horizontal movement and jump commands from input. 
        /// </summary> 
        private void GetInput(KeyboardState keyboardState, KeyboardState keyboardCopy, GameTime gameTime)
        {
            // Ignore small movements to prevent running in place. 
            if (Math.Abs(movement) < 0.5f)
                movement = 0.0f;


            // If any digital horizontal movement input is found, override the analog movement. 
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                movement = -1.0f;
                if (playerState != PlayerState.jump)
                {
                    playerState = PlayerState.walk;
                }

                mirror = SpriteEffects.FlipHorizontally;
            }
            else if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                movement = 1.0f;
                if (playerState != PlayerState.jump)
                {
                    playerState = PlayerState.walk;
                }
                mirror = SpriteEffects.None;
            }
            else
            {
                movement = 0;
                playerState = playerState == PlayerState.walk ? PlayerState.stand : playerState;
            }

            if (keyboardState.IsKeyDown(Keys.Space) && keyboardCopy.IsKeyUp(Keys.Space) ||
                keyboardState.IsKeyDown(Keys.Up) && keyboardCopy.IsKeyUp(Keys.Up) ||
                keyboardState.IsKeyDown(Keys.W) && keyboardCopy.IsKeyUp(Keys.W))
            {
                playerState = PlayerState.jump;
                isJumping = playerStateCopy != PlayerState.jump ? true : false;
            }
        }



        public virtual void UpdatePlayerFrame(GameTime gameTime)
        {
            timeLapsed += gameTime.ElapsedGameTime;
            if (timeLapsed.TotalMilliseconds > frameTime)
            {

                if (playerState == PlayerState.jump)
                {
                    currentAnimation = (int)PlayerState.jump;
                    frameCurrent = frameCurrent < 3 ? frameCurrent + 1 : 3;
                }
                else if (playerState == PlayerState.land)
                {
                    currentAnimation = (int)PlayerState.land;
                    frameCurrent++;
                    if (frameCurrent >= frameQuantities[currentAnimation])
                    {
                        playerState = PlayerState.stand;
                        frameCurrent = 0;
                    }
                }
                else if (playerState == PlayerState.walk)
                {
                    currentAnimation = (int)PlayerState.walk;
                    frameCurrent++;
                    frameCurrent = frameQuantities[currentAnimation] > 1 ? frameCurrent % frameQuantities[currentAnimation] : 0;
                }
                else if (playerState == PlayerState.stand)
                {
                    currentAnimation = (int)PlayerState.stand;
                    frameCurrent = 0;
                }


                timeLapsed = TimeSpan.Zero;
            }

        }

        public void LoadStates()
        {
            frameQuantities = new int[lines];
            frameQuantities[(int)PlayerState.walk] = 8;
            frameQuantities[(int)PlayerState.jump] = 4;
            frameQuantities[(int)PlayerState.land] = 5;
            frameQuantities[(int)PlayerState.stand] = 1;
        }



        public override void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, frameList[currentAnimation, frameCurrent],
                color, rotation, Vector2.Zero, 1f, mirror, 0);

            //topChar.DrawRectangle(spriteBatch);
            //botChar.DrawRectangle(spriteBatch);
        }

        /// <summary>
        /// Draw Player
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="alphaColsionsBoxs">Show colisions</param>
        public void Draw(SpriteBatch spriteBatch, bool alphaColsionsBoxs)
        {

            spriteBatch.Draw(texture, position, frameList[currentAnimation, frameCurrent],
                color, rotation, Vector2.Zero, 1f, mirror, 0);

            if (alphaColsionsBoxs)
            {
                topChar.DrawRectangle(spriteBatch);
                botChar.DrawRectangle(spriteBatch);
                leftChar.DrawRectangle(spriteBatch);
                rightChar.DrawRectangle(spriteBatch);
            }

        }
    }
}
