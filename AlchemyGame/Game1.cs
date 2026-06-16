using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace AlchemyGame;

public class Game1 : Core
{
    // fih texture
    // private Texture2D _fih;

    // texture region that defines the slime sprite in the atlas.
    private TextureRegion _slime;

    // texture region that defines the bat sprite in the atlas.
    private TextureRegion _bat;
    
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
        // _fih = Content.Load<Texture2D>("images/fih");
        // ^ all the fih stuff is inefficient and CRINGE

        // Create the texture atlas from XML configuration file
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");

        // retrieve the slime region from the atlas.
        _slime = atlas.GetRegion("slime");

        // retrieve the bat region from the atlas.
        _bat = atlas.GetRegion("bat");
        // base.LoadContent();
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
        // Clear the back buffer.
        GraphicsDevice.Clear(Color.Orchid);

        // TODO: Add drawing code here

        // Begin sprite batch to prep for rendering. SamplerState.PointClamp keeps scaled pixel art sharp, apparently.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw the slime texture region at a scale of 4.0
        _slime.Draw(SpriteBatch, Vector2.Zero, Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 0.0f);

        // Draw the bat texture region 10px to the right of the slime at a scale of 4.0
        _bat.Draw(SpriteBatch, new Vector2(_slime.Width * 4.0f + 10, 0), Color.White, 0.0f, Vector2.One, 4.0f, SpriteEffects.None, 1.0f);

        // Always end sprite batch when finished
        SpriteBatch.End();

        /*
        // basic sprite rendering with fih. Might not ever reuse, probably safe to delete, but has useful notes.
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
        */

        base.Draw(gameTime);
    }
}
