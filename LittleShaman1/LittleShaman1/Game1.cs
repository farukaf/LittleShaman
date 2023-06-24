using LittleShaman1.Model;
using LittleShaman1.Scene;
using LittleShaman1.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace LittleShaman1
{

    public class Game1 : Game
    {

        //checkinreasons
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Song backgroundMusic;

        ScenePlay scenePlay;
        SceneIntro sceneIntro;
        SceneMenu sceneMenu;
        SceneLevelChoose levelChoose;
        SceneTutorial sceneTutorial;

        public Pointer pointer;

        SceneLevel1 level1;
        SceneLevel2 level2;
        SceneLevel3 level3;
        SceneLevel4 level4;
        SceneLevel5 level5;
        SceneLevel6 level6;
        SceneLevel7 level7;
        SceneLevel8 level8;
        //Button btnPaused;

        //InterfaceBtn iinterface;

        KeyboardState keyboard;
        KeyboardState keyboardCopy;

        InterfaceBtn interfaceBtn;


        MouseState mouse;
        MouseState mouseCopy;

        EnumScene sceneController = EnumScene.intro;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = (int)Assist.Resolution.X;
            graphics.PreferredBackBufferHeight = (int)Assist.Resolution.Y;

            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 60.0f);
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = false;
            base.Initialize();
        }


        protected override void LoadContent()
        {
            //iinterface = new InterfaceBtn();
            //iinterface.Load(Content);
            //btnPaused = new Button();

            //btnPaused.Load(Content, "Menu/Button/BtnPaused", new Vector2(700, 10), Color.White, 93, 63);
            pointer = new Pointer();
            pointer.LoadPointer(Content);

            if (backgroundMusic == null)
            {
                backgroundMusic = Content.Load<Song>("SoundEffects/AmbientBirds");
                MediaPlayer.Play(backgroundMusic);
                MediaPlayer.IsRepeating = true;
            }
            

            spriteBatch = new SpriteBatch(GraphicsDevice);

            #region SwitchSceneLoad
            switch (sceneController)
            {
                case EnumScene.tutorial:
                    sceneTutorial = new SceneTutorial();
                    sceneTutorial.Load(Content);
                    break;
                case EnumScene.intro:
                    sceneIntro = new SceneIntro();
                    sceneIntro.Load(Content);
                    break;
                case EnumScene.menu:
                    sceneMenu = new SceneMenu();
                    sceneMenu.Load(Content);

                    break;
                case EnumScene.chooseLevel:
                    levelChoose = new SceneLevelChoose();
                    levelChoose.Load(Content);
                    break;
                case EnumScene.gamePlay:
                    interfaceBtn = new InterfaceBtn();
                    interfaceBtn.Load(Content);
                    scenePlay = new ScenePlay();
                    scenePlay.Load(Content, GraphicsDevice);
                    break;
                case EnumScene.level1:
                    interfaceBtn = new InterfaceBtn();
                    interfaceBtn.Load(Content);
                    level1 = new SceneLevel1();
                    level1.Load(Content, GraphicsDevice);
                    break;
                case EnumScene.level2:
                    interfaceBtn = new InterfaceBtn();
                    interfaceBtn.Load(Content);
                    level2 = new SceneLevel2();
                    level2.Load(Content, GraphicsDevice);
                    break;
                case EnumScene.level3:
                    interfaceBtn = new InterfaceBtn();
                    interfaceBtn.Load(Content);
                    level3 = new SceneLevel3();
                    level3.Load(Content, GraphicsDevice);
                    break;
                case EnumScene.level4:
                    interfaceBtn = new InterfaceBtn();
                    interfaceBtn.Load(Content);
                    level4 = new SceneLevel4();
                    level4.Load(Content, GraphicsDevice);
                    break;
                case EnumScene.level5:
                    interfaceBtn = new InterfaceBtn();
                    interfaceBtn.Load(Content);
                    level5 = new SceneLevel5();
                    level5.Load(Content, GraphicsDevice);
                    break;
                case EnumScene.level6:
                    interfaceBtn = new InterfaceBtn();
                    interfaceBtn.Load(Content);
                    level6 = new SceneLevel6();
                    level6.Load(Content, GraphicsDevice);
                    break;
                case EnumScene.level7:
                    interfaceBtn = new InterfaceBtn();
                    interfaceBtn.Load(Content);
                    level7 = new SceneLevel7();
                    level7.Load(Content, GraphicsDevice);
                    break;
                case EnumScene.level8:
                    interfaceBtn = new InterfaceBtn();
                    interfaceBtn.Load(Content);
                    level8 = new SceneLevel8();
                    level8.Load(Content, GraphicsDevice);
                    break;
            }
            #endregion

        }
        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            mouse = Mouse.GetState();
            keyboard = Keyboard.GetState();
            //btnPaused.Update(mouse);


            #region SwitchSceneControllerUpdate
            switch (sceneController)
            {
                case EnumScene.tutorial:
                    sceneController = sceneTutorial.Update(gameTime, keyboard);
                    if (sceneController != EnumScene.tutorial) LoadContent();
                    break;
                case EnumScene.intro:
                    sceneController = sceneIntro.Update(gameTime);
                    if (sceneController != EnumScene.intro) LoadContent();
                    break;
                case EnumScene.menu:
                    sceneController = sceneMenu.Update(gameTime, keyboard, mouse, mouseCopy);
                    if (sceneController != EnumScene.menu)
                    {
                        LoadContent();
                    }
                    break;
                case EnumScene.chooseLevel:
                    sceneController = levelChoose.Update(gameTime, mouse);
                    if (sceneController != EnumScene.chooseLevel) LoadContent();
                    break;
                case EnumScene.gamePlay:
                    if (scenePlay.Update(Content, GraphicsDevice, gameTime, mouse, mouseCopy, keyboard, keyboardCopy))
                    {
                        sceneController = EnumScene.menu;
                        LoadContent();
                    }
                    break;
                case EnumScene.level1:
                    if (level1.Update(Content, GraphicsDevice, gameTime, mouse, mouseCopy, keyboard, keyboardCopy))
                    {
                        sceneController = EnumScene.menu;
                        LoadContent();
                    }
                    break;
                case EnumScene.level2:
                    level2.Update(Content, gameTime, mouse, mouseCopy, keyboard, keyboardCopy);
                    break;
                case EnumScene.level3:
                    level3.Update(Content, gameTime, mouse, mouseCopy, keyboard, keyboardCopy);
                    break;
                case EnumScene.level4:
                    level4.Update(Content, gameTime, mouse, mouseCopy, keyboard, keyboardCopy);
                    break;
                case EnumScene.level5:
                    level5.Update(Content, gameTime, mouse, mouseCopy, keyboard, keyboardCopy);
                    break;
                case EnumScene.level6:
                    level6.Update(Content, gameTime, mouse, mouseCopy, keyboard, keyboardCopy);
                    break;
                case EnumScene.level7:
                    level7.Update(Content, gameTime, mouse, mouseCopy, keyboard, keyboardCopy);
                    break;
                case EnumScene.level8:
                    level8.Update(Content, gameTime, mouse, mouseCopy, keyboard, keyboardCopy);
                    break;
            }
            #endregion
            pointer.Update(mouse);
            keyboardCopy = keyboard;
            mouseCopy = mouse;

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            #region SceneControllerDraw
            switch (sceneController)
            {
                case EnumScene.tutorial:
                    spriteBatch.Begin();
                    sceneTutorial.Draw(spriteBatch);
                    break;
                case EnumScene.intro:
                    spriteBatch.Begin();
                    sceneIntro.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.menu:
                    spriteBatch.Begin();
                    sceneMenu.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.chooseLevel:
                    spriteBatch.Begin();
                    levelChoose.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.gamePlay:
                    scenePlay.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.level1:
                    level1.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.level2:
                    level2.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.level3:
                    level3.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.level4:
                    level4.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.level5:
                    level5.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.level6:
                    level6.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.level7:
                    spriteBatch.Begin();
                    level7.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                case EnumScene.level8:
                    level8.Draw(spriteBatch);
                    //spriteBatch.End();
                    break;
                    //case EnumScene.level9:
                    //    spriteBatch.Begin();
                    //    level9.Draw(spriteBatch);
                    //    //spriteBatch.End();
                    //    break;
            }
            #endregion



            //iinterface.Draw(spriteBatch);
            //btnPaused.DrawRectangle(spriteBatch);

            pointer.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
