using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Security.Permissions;

namespace mono_time_and_sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D BombTexture;
        Rectangle Bombrect;
        SpriteFont Timefont;
        float seconds;
        SoundEffect explode;
        MouseState mouseState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Bombrect = new Rectangle(50,50 , 700, 400);
            seconds = 10;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            BombTexture = Content.Load<Texture2D>("bomb");
            Timefont = Content.Load<SpriteFont>("Timefont");
            explode = Content.Load<SoundEffect>("explosion (1)");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            this.Window.Title = $"x = {mouseState.X},y = {mouseState.Y}";
           seconds -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (seconds < 0)
            {

                seconds = 10;
                explode.Play();
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(BombTexture, Bombrect, Color.White);
            _spriteBatch.DrawString(Timefont, seconds.ToString("00.0"), new Vector2(270, 200), Color.Black);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
