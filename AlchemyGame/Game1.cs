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
    //private Sprite _slime;

    // Defines the slime animated sprite
    private AnimatedSprite _slime;

    // texture region that defines the bat sprite in the atlas.
    //private Sprite _bat;

    // Defines the bat animated sprite
    private AnimatedSprite _bat;
    
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
        // fret not. He's been shot to death.

        // Create the texture atlas from XML configuration file
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");

        // retrieve the slime region from the atlas.
        _slime = atlas.CreateAnimatedSprite("slime-animation");
        _slime.Scale = new Vector2(4.0f, 4.0f);

        // retrieve the bat region from the atlas.
        // _bat = atlas.CreateSprite("bat");
        _bat = atlas.CreateAnimatedSprite("bat-animation");
        _bat.Scale = new Vector2(4.0f, 4.0f);
        // base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add update logic here

        // Update the slime animated sprite.
        _slime.Update(gameTime);

        // Update the bat animated sprite.
        _bat.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // Clear the back buffer.
        GraphicsDevice.Clear(Color.Orchid);

        // TODO: Add drawing code here

        // Begin sprite batch to prep for rendering. SamplerState.PointClamp keeps scaled pixel art sharp, apparently.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw the slime sprite
        // _slime.Draw(SpriteBatch, Vector2.Zero);
        _slime.Draw(SpriteBatch, new Vector2(Window.ClientBounds.Width -100, Window.ClientBounds.Height) * 0.5f);

        // Draw the bat sprite 10px to the right of the slime
        // _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));
        _bat.Draw(SpriteBatch, new Vector2(Window.ClientBounds.Width + 100, Window.ClientBounds.Height) * 0.5f);

        // Always end sprite batch when finished
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
