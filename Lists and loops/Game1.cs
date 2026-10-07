using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;


namespace Lists_and_loops
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;



        Texture2D stratGuitar, sgGuitar, lesPaulGuitar, jacksonGuitar;
        Rectangle stratGuitarRect, sgGuitarRect, lesPaulGuitarRect, jacksonGuitarRect;
        Rectangle startButton;
        Texture2D redTexture;

        List<Texture2D> guitars = new List<Texture2D>();

        MouseState mouseState;

        Vector2 mousePosition;

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
            stratGuitarRect = new Rectangle(50, 470, 300, 100);
            sgGuitarRect = new Rectangle(300, 470, 300, 160);
            lesPaulGuitarRect = new Rectangle(110, 170, 270, 300);
            jacksonGuitarRect = new Rectangle(670, 130, 100, 350);

            startButton = new Rectangle(350, 50, 100, 50);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _font = Content.Load<SpriteFont>("Font");
            stratGuitar = Content.Load<Texture2D>("strat");
            sgGuitar = Content.Load<Texture2D>("sg");
            lesPaulGuitar = Content.Load<Texture2D>("les paul");
            jacksonGuitar = Content.Load<Texture2D>("jackson");
            redTexture = Content.Load<Texture2D>("red");
            guitars.Add(stratGuitar);
            guitars.Add(sgGuitar);
            guitars.Add(lesPaulGuitar);
            guitars.Add(jacksonGuitar);

           

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            screen = Screen.menu;
            mouseState = Mouse.GetState();
            mousePosition = mouseState.Position.ToVector2();
            if (mouseState.LeftButton == ButtonState.Pressed && startButton.Contains(mouseState.Position))
            {
                screen = Screen.main;
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // DrawString takes: font, text string, position (Vector2), and color
            _spriteBatch.DrawString(_font, "Curtis Apfelbeck", new Vector2(30, 100), Color.Red);

            if (screen == Screen.menu)
            {
                _spriteBatch.Draw(sgGuitar, sgGuitarRect, Color.White);
                _spriteBatch.Draw(lesPaulGuitar, lesPaulGuitarRect, Color.White);
                _spriteBatch.Draw(jacksonGuitar, jacksonGuitarRect, Color.White);
                _spriteBatch.Draw(stratGuitar, stratGuitarRect, null, Color.White, MathHelper.ToRadians(270), Vector2.Zero, SpriteEffects.None, 0);
                _spriteBatch.Draw(sgGuitar, sgGuitarRect, null, Color.White, MathHelper.ToRadians(270), Vector2.Zero, SpriteEffects.None, 0);
                _spriteBatch.Draw(redTexture, startButton, Color.White);
                _spriteBatch.DrawString(_font, "Start", new Vector2(30, 50), Color.Red);
                
            }
            else if (screen == Screen.main)
            {
                
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
