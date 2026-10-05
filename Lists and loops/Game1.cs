using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lists_and_loops
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;



        Texture2D stratGuitar, sgGuitar, lesPaulGuitar, jacksonGuitar;
        Rectangle stratGuitarRect, sgGuitarRect, lesPaulGuitarRect, jacksonGuitarRect;
        enum screen
        {
            menu,
            main,
        }
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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // DrawString takes: font, text string, position (Vector2), and color
            _spriteBatch.DrawString(_font, "Curtis Apfelbeck", new Vector2(30, 100), Color.Red);

            
            _spriteBatch.Draw(sgGuitar, sgGuitarRect, Color.White);
            _spriteBatch.Draw(lesPaulGuitar, lesPaulGuitarRect, Color.White);
            _spriteBatch.Draw(jacksonGuitar, jacksonGuitarRect, Color.White);
            _spriteBatch.Draw(stratGuitar, stratGuitarRect, null, Color.White, MathHelper.ToRadians(270), Vector2.Zero, SpriteEffects.None, 0);
            _spriteBatch.Draw(sgGuitar, sgGuitarRect, null, Color.White, MathHelper.ToRadians(270), Vector2.Zero, SpriteEffects.None, 0);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
