#region Using Statements
using System;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace mgtest {
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game {
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Vector2 spritePosition = Vector2.Zero;
		Texture2D myTexture;
		Vector2 spriteSpeed = new Vector2(50.0f, 50.0f);

		SpriteFont font;
		string message = "Hello world!";

		Model model;

		Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
		Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 0), new Vector3(0, 0, 0), Vector3.UnitY);
		Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f/480f, 0.1f, 100f);


		public Game1() {
			graphics = new GraphicsDeviceManager(this);
			// Sort of wrong, buuuuuut...
			Content.RootDirectory = "../../Content";
			graphics.IsFullScreen = false;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize() {
			// TODO: Add your initialization logic here
			base.Initialize();

		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent() {
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Console.WriteLine(Directory.GetCurrentDirectory());
			Console.WriteLine(Content.RootDirectory);
			myTexture = Content.Load<Texture2D>("sprite1");

			model = Content.Load<Model>("cruiserish");

			// Apparently, not implemented in this version.  Ballsacks.
			//font = Content.Load<SpriteFont>("test");


		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime) {
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) {
				Exit();
			}
			UpdateSprite(gameTime);
			base.Update(gameTime);
		}

		void UpdateSprite(GameTime gt) {
			spritePosition += spriteSpeed * (float)gt.ElapsedGameTime.TotalSeconds;

			var maxx = graphics.GraphicsDevice.Viewport.Width - myTexture.Width;
			var minx = 0;
			var maxy = graphics.GraphicsDevice.Viewport.Height - myTexture.Height;
			var miny = 0;
			// Check for bounce.
			if (spritePosition.X > maxx) {
				spriteSpeed.X *= -1;
				spritePosition.X = maxx;
			}

			else if (spritePosition.X < minx) {
				spriteSpeed.X *= -1;
				spritePosition.X = minx;
			}

			if (spritePosition.Y > maxy) {
				spriteSpeed.Y *= -1;
				spritePosition.Y = maxy;
			}

			else if (spritePosition.Y < miny) {
				spriteSpeed.Y *= -1;
				spritePosition.Y = miny;
			}
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime) {
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();
			spriteBatch.Draw(myTexture, spritePosition, Color.White);
			//spriteBatch.DrawString(font, message, new Vector2(200, 200), Color.White);
			spriteBatch.End();




			base.Draw(gameTime);
		}

		private void DrawModel(Model model) {
			foreach(ModelMesh mesh in model.Meshes) {
				foreach(BasicEffect effect in mesh.Effects) {

				}
			}
		}
	}
}

