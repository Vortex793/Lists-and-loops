using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


namespace Lists_and_loops
{
    public class Game1 : Game
    {
        //CURTIS APFELBECK

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _menuFont, _font, _smallerFont;

        Random random = new Random();

        Texture2D stratGuitar, sgGuitar, lesPaulGuitar, jacksonGuitar, classicalGuitar;
        Rectangle stratGuitarRect, sgGuitarRect, lesPaulGuitarRect, jacksonGuitarRect, classicalGuitarRect;
        Rectangle startButton, window, clicksCounter;
        Texture2D redTexture, guitarBG;

        List<Texture2D> guitars = new List<Texture2D>();
        List<Rectangle> guitarRects = new List<Rectangle>();
        List <Texture2D> guitarTextures = new List<Texture2D>();

        MouseState mouseState;

        MouseState previousMouseState;

        Vector2 mousePosition;

        int clicks = 0;

        

        SoundEffect note;
        Song missingPiece;

        Random generator = new Random();
        enum Screen
        {
            menu,
            main,
        }
        Screen screen;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            stratGuitarRect = new Rectangle(50, 470, 300, 100);
            sgGuitarRect = new Rectangle(300, 470, 300, 160);
            lesPaulGuitarRect = new Rectangle(110, 170, 270, 300);
            jacksonGuitarRect = new Rectangle(670, 130, 100, 350);
            classicalGuitarRect = new Rectangle(450, 160, 200, 315);

            startButton = new Rectangle(420, 200, 100, 50);
            clicksCounter = new Rectangle(0, 0, 800, 50);

            screen = Screen.menu;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _menuFont = Content.Load<SpriteFont>("File");
            _font = Content.Load<SpriteFont>("font");
            _smallerFont = Content.Load<SpriteFont>("smallerFont");
            stratGuitar = Content.Load<Texture2D>("strat");
            sgGuitar = Content.Load<Texture2D>("sg");
            lesPaulGuitar = Content.Load<Texture2D>("les paul");
            jacksonGuitar = Content.Load<Texture2D>("jackson");
            classicalGuitar = Content.Load<Texture2D>("classical");
            redTexture = Content.Load<Texture2D>("red");
            guitarBG = Content.Load<Texture2D>("guitarBG");
            note = Content.Load<SoundEffect>("note");
            missingPiece = Content.Load<Song>("MissingDemo");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(missingPiece);
            guitars.Add(stratGuitar);
            guitars.Add(sgGuitar);
            guitars.Add(lesPaulGuitar);
            guitars.Add(jacksonGuitar);


            //for (int i = 0; i < 0; i++)
            //{
            //    guitarRects.Add
            //    (
            //        new Rectangle(generator.Next(window.Width - 25),
            //        generator.Next(window.Height - 25), 25, 25)
            //    );
            //}

            //for (int i = 0; i < guitarRects.Count; i++)
            //{
            //    guitarTextures.Add(guitars[generator.Next(guitars.Count)]);
            //}


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            
            mouseState = Mouse.GetState();
            mousePosition = mouseState.Position.ToVector2();

            


            // MENU
            if (screen == Screen.menu)
            {
                if (mouseState.LeftButton == ButtonState.Pressed &&
                    startButton.Contains(mouseState.Position))
                {
                    screen = Screen.main;
                }

            }

            // MAIN SCREEN
            else if (screen == Screen.main)
            {

                // Left click = add a guitar
                if (mouseState.LeftButton == ButtonState.Pressed &&
                    previousMouseState.LeftButton == ButtonState.Released)
                {               
                    int guitarIndex = random.Next(guitars.Count);

                    guitarTextures.Add(guitars[guitarIndex]);
                    int width, height;
                    width = generator.Next(50, 151);
                    height = generator.Next(50, 151);
                    guitarRects.Add(new Rectangle(generator.Next(window.Width - width), generator.Next(window.Height - height), width, height));

                    note.Play();
                    //clicks++;
                }
                // Right click = remove a guitar
                if (mouseState.RightButton == ButtonState.Pressed &&
                    previousMouseState.RightButton == ButtonState.Released)
                {
                    if (guitarTextures.Count >= 1)
                    {
                        guitarTextures.RemoveAt(guitarTextures.Count - 1);
                        guitarRects.RemoveAt(guitarRects.Count - 1);
                        //clicks--;
                    }
                  


                }

                
            }

            previousMouseState = mouseState;



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // DrawString takes: font, text string, position (Vector2), and color
            

            if (screen == Screen.menu)
            {
                _spriteBatch.DrawString(_menuFont, "Curtis Apfelbeck", new Vector2(30, 500), Color.Red);

                _spriteBatch.Draw(lesPaulGuitar, lesPaulGuitarRect, Color.White);
                _spriteBatch.Draw(jacksonGuitar, jacksonGuitarRect, Color.White);
                _spriteBatch.Draw(stratGuitar, stratGuitarRect, null, Color.White, MathHelper.ToRadians(270), Vector2.Zero, SpriteEffects.None, 0);
                _spriteBatch.Draw(sgGuitar, sgGuitarRect, null, Color.White, MathHelper.ToRadians(270), Vector2.Zero, SpriteEffects.None, 0);
                _spriteBatch.Draw(classicalGuitar, classicalGuitarRect, Color.White);
                _spriteBatch.Draw(redTexture, startButton, Color.White);
                _spriteBatch.DrawString(_menuFont, "Guitar Clicker ii", new  Vector2(30, 50), Color.Red);
                _spriteBatch.DrawString(_smallerFont, "Start", new Vector2(425, 215), Color.White);

            }
            else if (screen == Screen.main)
            {

                _spriteBatch.Draw(guitarBG, window, Color.White);
                for (int i = 0; i < guitarRects.Count; i++)
                    {
                        _spriteBatch.Draw(guitarTextures[i], guitarRects[i], Color.White);
                        
                }

                
                _spriteBatch.Draw(redTexture, clicksCounter, Color.White);
                _spriteBatch.DrawString(_font, "Guitars: " + guitarRects.Count, new Vector2(10, 10), Color.White);
                _spriteBatch.DrawString(_font, "Left click to add a guitar and right click to remove a guitar", new Vector2(300, 10), Color.White);
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
