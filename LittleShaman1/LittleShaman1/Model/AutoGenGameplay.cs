using LittleShaman1.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleShaman1.Model
{
    public class AutoGenGameplay
    {
        SoundEffect switchEffect;

        public int brokenTotems = 0;

        bool waterColision = false;

        public bool nextLvl = false;
        public Sprite exit;
        public float alpha = 0.5f;

        public Plataform[] platform;
        public Sprite[] wall;
        public FireAnimated[] fire;
        public Player player;
        public Vector2 playerStartPosition;
        public WaterSource[] waterSource;
        public Fence fence;
        public Totem[] totem;
        public FallingBranch[] fallingBranch;

        InterfaceBtn interfaceBtn;



        public int exitWidth = 75, exitHeight = 75;

        Vector2 mouse, mouseCopy;

        public Camera2D cam;
        /// <summary>
        /// Limite da Largura do Level cant be less than 1280 - valor padrão 3000
        /// </summary>
        public int camLimitX = 3000;
        /// <summary>
        /// Limite da Altura do level cant be less than 720 - valor padrão 3000 (se o personagem for alem ele retorna ao ponto inicial)
        /// </summary>
        public int camLimitY = 3000;
        //resolver os portões/totems

        public bool dragingPlataform = false;
        public Plataform dragingPlataformSprite;


        public Switch[] alavanca;
        private int platformLimit = 3;

        /// <summary>
        /// Use de base.Load when in heinrance. all variables are public to later change
        /// Passe todos os parametros pelo base.Load ao fazer herança
        /// Obrigatório player, wall, platform
        /// </summary>
        /// <param name="content"></param>
        /// <param name="graphicsDev"></param>
        /// <param name="playerPosition"></param>
        /// <param name="platform">Rectangle</param>
        /// <param name="firePositions"></param>
        /// <param name="wallPositions"></param>
        /// <param name="exitPosition"></param>
        public virtual void Load(ContentManager content, GraphicsDevice graphicsDev, Vector2 playerPosition, Vector2[] platform,
            Vector2[] firePositions, Vector3[] wallPositions, Vector2 exitPosition)
        {
            //mouse = mouseCopy = Vector2.Zero;

            switchEffect = content.Load<SoundEffect>("SoundEffects/Switch 02");

            this.platform = new Plataform[platform.Length];
            for (int i = 0; i < this.platform.Length; i++)
            {
                this.platform[i] = new Plataform();
                this.platform[i].Load(content, platform[i]);
            }

            if (wallPositions != null)
            {
                wall = new Sprite[wallPositions.Length];
                for (int i = 0; i < wall.Length; i++)
                {
                    wall[i] = new Sprite();
                    wall[i].Load(content, "LevelObjects/littleRectangle", new Vector2(wallPositions[i].X, wallPositions[i].Y), Color.Chocolate * alpha, 5, (int)wallPositions[i].Z);
                }
            }

            if (firePositions != null)
            {
                fire = new FireAnimated[firePositions.Length];
                for (int i = 0; i < fire.Length; i++)
                {
                    fire[i] = new FireAnimated();
                    fire[i].LoadFire(content, firePositions[i]);
                }
            }

            //if (waterSourcePositions != null)
            //{
            //    waterSource = new WaterSource[waterSourcePositions.Length];
            //    for (int i = 0; i < waterSourcePositions.Length; i++)
            //    {
            //        waterSource[i] = new WaterSource();
            //        waterSource[i].LoadAnimated(content, new Vector2(waterSourcePositions[i].X, waterSourcePositions[i].Y), (int)waterSourcePositions[i].Z);
            //    }
            //}

            interfaceBtn = new InterfaceBtn();
            interfaceBtn.Load(content);

            playerStartPosition = playerPosition;
            player = new Player();
            player.LoadCharacter(content, playerPosition);

            exit = new Sprite();
            exit.Load(content, "LevelObjects/littleRectangle", exitPosition, Color.LightGray, exitWidth, exitHeight);

            cam = new Camera2D(graphicsDev.Viewport, camLimitX, camLimitY);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="graphicsDev"></param>
        /// <param name="playerPosition"></param>
        /// <param name="platform">Vector3</param>
        /// <param name="firePositions"></param>
        /// <param name="wallPositions"></param>
        /// <param name="exitPosition"></param>
        public virtual void Load(ContentManager content, GraphicsDevice graphicsDev, Vector2 playerPosition, Vector3[] platform,
           Vector2[] firePositions, Vector3[] wallPositions, Vector2 exitPosition)
        {
            //mouse = mouseCopy = Vector2.Zero;


            this.platform = new Plataform[platform.Length];
            for (int i = 0; i < this.platform.Length; i++)
            {
                this.platform[i] = new Plataform();
                this.platform[i].Load(content, "LevelObjects/SpriteTerraPlat", new Vector2(platform[i].X, platform[i].Y), Color.White * 1, (int)platform[i].Z, 10);
            }

            if (wallPositions != null)
            {
                wall = new Sprite[wallPositions.Length];
                for (int i = 0; i < wall.Length; i++)
                {
                    wall[i] = new Sprite();
                    wall[i].Load(content, "LevelObjects/littleRectangle", new Vector2(wallPositions[i].X, wallPositions[i].Y), Color.Chocolate * alpha, 5, (int)wallPositions[i].Z);
                }
            }

            if (firePositions != null)
            {
                fire = new FireAnimated[firePositions.Length];
                for (int i = 0; i < fire.Length; i++)
                {
                    fire[i] = new FireAnimated();
                    fire[i].LoadFire(content, firePositions[i]);
                }
            }

            //if (waterSourcePositions != null)
            //{
            //    waterSource = new WaterSource[waterSourcePositions.Length];
            //    for (int i = 0; i < waterSourcePositions.Length; i++)
            //    {
            //        waterSource[i] = new WaterSource();
            //        waterSource[i].LoadAnimated(content, new Vector2(waterSourcePositions[i].X, waterSourcePositions[i].Y), (int)waterSourcePositions[i].Z);
            //    }
            //}

            interfaceBtn = new InterfaceBtn();
            interfaceBtn.Load(content);

            playerStartPosition = playerPosition;
            player = new Player();
            player.LoadCharacter(content, playerPosition);

            exit = new Sprite();
            exit.Load(content, "LevelObjects/littleRectangle", exitPosition, Color.LightGray, exitWidth, exitHeight);

            cam = new Camera2D(graphicsDev.Viewport, camLimitX, camLimitY);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fallingBranchPosition">XY = Position, Z= Resistance</param>
        public virtual void LoadFallingBranch(ContentManager content, Vector3[] fallingBranchPosition)
        {
            fallingBranch = new FallingBranch[fallingBranchPosition.Length];
            for (int i = 0; i < fallingBranchPosition.Length; i++)
            {
                fallingBranch[i] = new FallingBranch();
                fallingBranch[i].Load(content, new Vector2(fallingBranchPosition[i].X, fallingBranchPosition[i].Y), fallingBranchPosition[i].Z);
            }

        }

        public virtual void LoadSwitch(ContentManager content, Vector2[] switchPosition)
        {
            alavanca = new Switch[switchPosition.Length];
            for (int i = 0; i < alavanca.Length; i++)
            {
                alavanca[i] = new Switch();
                alavanca[i].Load(content, switchPosition[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="totemPositions"></param>
        public virtual void LoadTotem(ContentManager content, Vector2[] totemPositions)
        {
            totem = new Totem[totemPositions.Length];
            for (int i = 0; i < totemPositions.Length; i++)
            {
                totem[i] = new Totem();
                totem[i].Load(content, totemPositions[i]);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="playerPosition"></param>
        /// <param name="exitPosition"></param>
        public virtual void Load(ContentManager content, Vector2 playerPosition, Vector2 exitPosition)
        {
            exit = new Sprite();
            exit.Load(content, "LevelObjects/littleRectangle", exitPosition, Color.Yellow * alpha, 60, 80);

            player = new Player();
            player.LoadCharacter(content, playerPosition);
            player.LoadStates();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="platformPositions"></param>
        public void LoadPlatform(ContentManager content, Vector3[] platformPositions)
        {
            platform = new Plataform[platformPositions.Length];
            for (int i = 0; i < platform.Length; i++)
            {
                platform[i] = new Plataform();
                platform[i].Load(content, new Vector2(platformPositions[i].X, platformPositions[i].Y));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="waterSourcePositions"></param>
        public void LoadWater(ContentManager content, Vector3[] waterSourcePositions)
        {
            waterSource = new WaterSource[waterSourcePositions.Length];
            for (int i = 0; i < waterSourcePositions.Length; i++)
            {
                waterSource[i] = new WaterSource();
                waterSource[i].LoadAnimated(content, new Vector2(waterSourcePositions[i].X, waterSourcePositions[i].Y), (int)waterSourcePositions[i].Z);
            }
        }


        /// <summary>
        /// Width standard 5px
        /// </summary>
        /// <param name="content"></param>
        /// <param name="wallPositions">position: X.Y; Z: Height</param>
        public void LoadWall(ContentManager content, Vector3[] wallPositions)
        {
            wall = new Sprite[wallPositions.Length];
            for (int i = 0; i < wall.Length; i++)
            {
                wall[i] = new Sprite();
                wall[i].Load(content, "LevelObjects/littleRectangle", new Vector2(wallPositions[i].X, wallPositions[i].Y), Color.Chocolate * alpha, 5, (int)wallPositions[i].Z);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="wallPositions">position: X.Y; Z: Height</param>
        /// <param name="width">Rectangle width</param>
        public void LoadWall(ContentManager content, Vector3[] wallPositions, int width)
        {
            wall = new Sprite[wallPositions.Length];
            for (int i = 0; i < wall.Length; i++)
            {
                wall[i] = new Sprite();
                wall[i].Load(content, "LevelObjects/littleRectangle", new Vector2(wallPositions[i].X, wallPositions[i].Y), Color.Chocolate * alpha, width, (int)wallPositions[i].Z);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="firePositions"></param>
        public void LoadFire(ContentManager content, Vector2[] firePositions)
        {
            fire = new FireAnimated[firePositions.Length];
            for (int i = 0; i < fire.Length; i++)
            {
                fire[i] = new FireAnimated();
                fire[i].LoadFire(content, firePositions[i]);
            }
        }

        private void GetInput(KeyboardState keyboard, KeyboardState keyboardCopy, MouseState mouse, MouseState mouseCopy)
        {
            if (keyboard.IsKeyDown(Keys.E) && keyboardCopy.IsKeyUp(Keys.E))
            {
                for (int i = 0; i < alavanca.Length; i++)
                {
                    if ((player.leftChar.rect.Intersects(alavanca[i].colision) || player.rightChar.rect.Intersects(alavanca[i].colision)) && alavanca[i].active == false)
                    {
                        alavanca[i].active = true;
                        brokenTotems++;

                        switchEffect.Play();
                    }
                }
            }
        }

        /// <summary>
        /// fisics and other things
        /// </summary>
        public virtual bool Update(ContentManager content, GameTime gameTime, MouseState mouse, MouseState mouseCopy, KeyboardState keyboard, KeyboardState keyboardCopy)
        {
            this.mouse.X = (int)(mouse.X - Assist.camPosition.X);
            this.mouse.Y = (int)(mouse.Y - Assist.camPosition.Y);
            this.mouseCopy.X = (int)(mouseCopy.X - Assist.camPosition.X);
            this.mouseCopy.Y = (int)(mouseCopy.Y - Assist.camPosition.Y);

            ObjectsUpdate(gameTime, mouse, mouseCopy, keyboard, keyboardCopy);

            player.Update(keyboard, keyboardCopy, gameTime);

            Collisions(player);

            player.UpdateStates(gameTime);

            Assist.followPosition = new Vector2(player.position.X + 100, player.position.Y + 60);

            GetInput(keyboard, keyboardCopy, mouse, mouseCopy);

            //Debugs
            #region Debugs
            Debug.Write("Posição X: " + player.position.X + " Y: " + player.position.Y + "\n");
            Debug.Write(player.playerState + "\n");
            Debug.Write("Cam" + Assist.camPosition.X + "\n");
            #endregion

            if (dragingPlataform)
            {
                DragingNewPlataform(content, mouse, mouseCopy);
            }

            if (platform.Length > platformLimit)
            {
                Plataform[] _platform = platform;

                platform = new Plataform[_platform.Length - 1];

                for (int i = 0; i < platform.Length; i++)
                {
                    platform[i] = _platform[i + 1];
                }
            }

            if (mouse.RightButton == ButtonState.Pressed && mouseCopy.RightButton == ButtonState.Released)
            {
                dragingPlataform = true;
            }

            if (alavanca != null && totem != null)
            {
                for (int i = 0; i < totem.Length; i++)
                {
                    totem[i].broken = alavanca[i].active;
                }
            }

            if (interfaceBtn.Update(content, gameTime, mouse, mouseCopy))
            {
                return true;
            }

            cam.Update();

            return false;
        }

        public virtual bool CheckTotem()
        {
            bool check = false;
            for (int i = 0; i < totem.Length; i++)
            {
                check = totem[i].broken;
                if (!check) break;
            }
            return check;
        }

        private void DragingNewPlataform(ContentManager content, MouseState mouse, MouseState mouseCopy)
        {
            if (dragingPlataformSprite == null)
            {
                dragingPlataformSprite = new Plataform();
                dragingPlataformSprite.Load(content, new Vector2(mouse.X - (int)Assist.PlataformRectangleSize.X / 2, mouse.Y - (int)Assist.PlataformRectangleSize.Y / 2));
            }
            else
            {
                dragingPlataformSprite.rect.X = mouse.X - (int)Assist.PlataformRectangleSize.X / 2;
                dragingPlataformSprite.rect.Y = mouse.Y - (int)Assist.PlataformRectangleSize.Y / 2;

            }

            if (mouse.LeftButton == ButtonState.Pressed && mouseCopy.LeftButton == ButtonState.Released)
            {
                dragingPlataform = false;

                Plataform[] _platform = new Plataform[platform.Length + 1];

                for (int i = 0; i < platform.Length; i++)
                {
                    _platform[i] = platform[i];
                }
                _platform[_platform.Length - 1] = dragingPlataformSprite;
                _platform[_platform.Length - 1].rect.X = (int)(dragingPlataformSprite.rect.X + cam.Position.X - Assist.Resolution.X / 2);
                _platform[_platform.Length - 1].rect.Y = (int)(dragingPlataformSprite.rect.Y + cam.Position.Y - Assist.Resolution.Y / 2);
                _platform[_platform.Length - 1].color = Color.White;
                dragingPlataformSprite = null;
                platform = new Plataform[_platform.Length];
                for (int i = 0; i < platform.Length; i++)
                {
                    platform[i] = _platform[i];
                }
            }
        }


        private void Collisions(Player player)
        {
            //Colisão com plataformas
            bool _platcolisionBot = false;
            bool _platcolisionLeft = false;
            bool _platcolisionRight = false;
            bool _platcolisionTop = false;

            for (int i = 0; i < platform.Length; i++)
            {
                _platcolisionLeft = player.leftChar.rect.Intersects(platform[i].rect);

                if (_platcolisionLeft)
                {
                    player.position.X = player.position.X < player.positionCopy.X ? player.positionCopy.X : player.position.X;
                }

                _platcolisionRight = player.rightChar.rect.Intersects(platform[i].rect);

                if (_platcolisionRight)
                {
                    player.position.X = player.position.X > player.positionCopy.X ? player.positionCopy.X : player.position.X;
                }

                _platcolisionTop = player.topChar.rect.Intersects(platform[i].rect);

                if (_platcolisionTop)
                {
                    if (player.playerState == PlayerState.jump)
                    {
                        if (player.position.Y < player.positionCopy.Y)
                        {
                            player.position.Y = player.positionCopy.Y;
                        }                        
                        player.jumpTime = 0.0f;
                        player.isJumping = false;
                        _platcolisionTop = false;
                    }
                }


            }

            for (int i = 0; i < platform.Length; i++)
            {
                _platcolisionBot = player.botChar.rect.Intersects(platform[i].rect);

                if (_platcolisionBot)
                {
                    if (player.playerState == PlayerState.jump && player.playerStateCopy == PlayerState.jump)
                    {
                        player.playerState = PlayerState.land;
                    }
                    else if (player.playerState == PlayerState.stand || player.playerState == PlayerState.land || player.playerState == PlayerState.walk)
                    {
                        player.position.Y = platform[i].rect.Y - player.frameHeight + 5;
                    }
                    break;
                }

            }
            if (!_platcolisionBot && player.playerState != PlayerState.jump)
            {
                player.playerState = PlayerState.jump;
            }

        }


        private void WaterColision()
        {

        }

        private void ObjectsUpdate(GameTime gameTime, MouseState mouse, MouseState mouseCopy, KeyboardState keyboard, KeyboardState keyboardCopy)
        {



            if (fire != null)
            {
                for (int i = 0; i < fire.Length; i++)
                {
                    fire[i].UpdateFrame(gameTime);
                }
            }

            //if (waterSource != null)
            //{
            //    for (int i = 0; i < waterSource.Length; i++)
            //    {
            //        waterSource[i].UpdateAnimated(gameTime, Assist.ControlState, pointer, keyboard, keyboardCopy);
            //    }
            //}

            if (totem != null)
            {
                for (int i = 0; i < totem.Length; i++)
                {
                    totem[i].Update(gameTime);
                }
            }

            if (fallingBranch != null)
            {
                for (int i = 0; i < fallingBranch.Length; i++)
                {
                    fallingBranch[i].Update(fallingBranch[i].rect.Intersects(player.botChar.rect));
                }
            }


        }

        /// <summary>
        /// Base Draw. Begin
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawBegin(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null, null, null, null,
                cam.Transform
                );
        }

        /// <summary>
        /// Base Draw. 
        /// Begin>fallingBranch!>fire!>totem!>platforms>player
        /// ! => Can be null (pode ser null)
        /// </summary>
        /// <param name="spriteBatch"></param
        /// <param name="colisionsBoxs">Draw Colisions Boxs</param>
        public virtual void Draw(SpriteBatch spriteBatch, bool colisionsBoxs, bool rectangleBoxs)
        {
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null, null, null, null,
                cam.Transform
                );

            if (fallingBranch != null) DrawFallingBranch(spriteBatch);
            if (fire != null) DrawFire(spriteBatch);
            if (totem != null) DrawTotem(spriteBatch);
            if (alavanca != null) DrawSwitch(spriteBatch);
            if (rectangleBoxs) DrawRectangles(spriteBatch);


            DrawPlayer(spriteBatch, colisionsBoxs);

            spriteBatch.End();
            spriteBatch.Begin();

            if (dragingPlataformSprite != null) dragingPlataformSprite.DrawSlice(spriteBatch);

            interfaceBtn.Draw(spriteBatch);

        }


        public virtual void Draw(SpriteBatch spriteBatch, bool colisionsBoxs)
        {
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null, null, null, null,
                cam.Transform
                );

            if (fallingBranch != null) DrawFallingBranch(spriteBatch);
            if (fire != null) DrawFire(spriteBatch);
            if (totem != null) DrawTotem(spriteBatch);
            if (colisionsBoxs)
            {
                DrawRectangles(spriteBatch);
            }

            DrawPlayer(spriteBatch, colisionsBoxs);

            spriteBatch.End();
            spriteBatch.Begin();

            if (dragingPlataformSprite != null) dragingPlataformSprite.DrawRectangle(spriteBatch);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                null, null, null, null,
                cam.Transform
                );

            if (fallingBranch != null) DrawFallingBranch(spriteBatch);
            if (fire != null) DrawFire(spriteBatch);
            if (totem != null) DrawTotem(spriteBatch);

            DrawRectangles(spriteBatch);


            DrawPlayer(spriteBatch, false);


        }

        public virtual void DrawSwitch(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < alavanca.Length; i++) alavanca[i].DrawSlice(spriteBatch);
        }

        public virtual void DrawTotem(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < totem.Length; i++) totem[i].DrawRectangle(spriteBatch);
        }

        public virtual void DrawFire(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < fire.Length; i++) fire[i].Draw(spriteBatch);
        }

        public virtual void DrawFallingBranch(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < fallingBranch.Length; i++) fallingBranch[i].Draw(spriteBatch);
        }

        public virtual void DrawPlayer(SpriteBatch spriteBatch, bool alpha)
        {
            player.Draw(spriteBatch, alpha);
        }

        public virtual void DrawWater(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < waterSource.Length; i++) waterSource[i].DrawAnimated(spriteBatch);
        }

        public virtual void DrawRectangles(SpriteBatch spriteBatch)
        {
            DrawExit(spriteBatch);
            for (int i = 0; i < platform.Length; i++) platform[i].DrawSlice(spriteBatch);
            if (wall != null) for (int i = 0; i < wall.Length; i++) wall[i].DrawRectangle(spriteBatch);


        }

        public virtual void DrawExit(SpriteBatch spriteBatch)
        {
            exit.DrawRectangle(spriteBatch);
        }
    }
}

