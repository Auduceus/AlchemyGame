using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;

namespace AlchemyGame;

public class Game1 : Core
{
    // fih texture
    private Texture2D _fih;
    
    public Game1() : base("Alchemy Game", 1280, 720, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load game content here
        // Loads the fih texture
        _fih = Content.Load<Texture2D>("images/fih");

        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Orchid);

        // TODO: Add drawing code here

        // Begin sprite batch to prep for rendering.
        SpriteBatch.Begin();

        // Draw fih texture, and place it in center coords by dividing window's dimensions in half
        SpriteBatch.Draw(
            _fih,                           // texture
            new Vector2(                    // position at center of screen
                Window.ClientBounds.Width,
                Window.ClientBounds.Height) * 0.5f,
                null,                       // sourceRectangle. Useful for rendering portions of a texture    
                Color.White,                // color. Color.White renders the texture with no tint. Multiplying alters transparency
                0.0f,                     // rotation
                // MathHelper.ToRadians(90),   // rotate fih 90 degrees. Rotation is done in radians, so this converts 90 deg to radians
                new Vector2(                // origin, but set to the center of the sprite instead of top left
                    _fih.Width,
                    _fih.Height) * 0.5f,           
                0.5f,                       // scale, but halved since fih is too damn big
                // new Vector2(1.5f, 0.5f)    // scale applied to x and y axes independently
                SpriteEffects.None,         // effects
                0.0f                        // LayerDepth. Need to change sortMode in SpriteBatch.Begin() to either FrontToBack or BackToFront

        );

        // Always end sprite batch when finished
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
