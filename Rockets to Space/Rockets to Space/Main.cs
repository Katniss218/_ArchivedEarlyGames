using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Rockets_to_Space
{
	public class Main : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphicsDevice;
		SpriteBatch spriteBatch;
		private Model model;
		private Model terrain;
		
		private Vector3 position = new Vector3(0, 0, 0);
		private float angle = 0;
		private float angle2 = 0;
		private float angle3 = 0;
 		
        private Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
        private Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 5, 0), Vector3.UnitY);
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(90), 800f / 480f, 0.1f, 100f);
 		
        public static KeyboardState KeyboardState;
		public static MouseState MouseState;
        
        public Main()
		{
			graphicsDevice = new GraphicsDeviceManager(this);
			graphicsDevice.PreferredBackBufferWidth = 1260;
			graphicsDevice.PreferredBackBufferHeight = 750;
			Content.RootDirectory = "Content";
		}
        protected override void Initialize()
        {
        	this.IsMouseVisible = true;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
 
            model = Content.Load<Model>("Ship");
            terrain = Content.Load<Model>("a");
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
        	KeyboardState = Keyboard.GetState();
			MouseState = Mouse.GetState();
			if( KeyboardState.IsKeyDown( Keys.W ) )
			{
				position -= new Vector3( (float)Math.Sin(MathHelper.ToRadians(angle)) * 0.1f, -(float)Math.Cos(MathHelper.ToRadians(angle)) * 0.1f, -(float)Math.Sin(MathHelper.ToRadians(angle3)) * 0.1f);
			}
			if( KeyboardState.IsKeyDown( Keys.S ) )
			{
				position += new Vector3( (float)Math.Sin(MathHelper.ToRadians(angle)) * 0.1f, -(float)Math.Cos(MathHelper.ToRadians(angle)) * 0.1f, -(float)Math.Sin(MathHelper.ToRadians(angle3)) * 0.1f);
			}
			if( KeyboardState.IsKeyDown( Keys.A ) )
			{
				if( angle2 > -30 )
					angle2 -= 3f;
				angle += 0.5f;
			}
			if( KeyboardState.IsKeyDown( Keys.D ) )
			{
				if( angle2 < 30 )
					angle2 += 3f;
				
				angle -= 0.5f;
			}
			if( KeyboardState.IsKeyDown( Keys.LeftShift ) )
			{
				if( angle3 > -60 )
					angle3 -= 2f;
			}
			if( KeyboardState.IsKeyDown( Keys.LeftControl ) )
			{
				if( angle3 < 60 )
					angle3 += 2f;
			}
			if( angle2 >= 1 )
				angle2 -= 1f;
			if( angle2 <= -1 )
				angle2 += 1f;
			view = Matrix.CreateLookAt(new Vector3(position.X, position.Y, position.Z + 0.5f), new Vector3(-(float)Math.Sin(MathHelper.ToRadians(angle)) * position.X + 2, (float)Math.Cos(MathHelper.ToRadians(angle)) * position.Y + 2, position.Z -1), Vector3.UnitY);
 			world = Matrix.CreateRotationX(MathHelper.ToRadians(angle3)) * Matrix.CreateRotationY(MathHelper.ToRadians(angle2)) * Matrix.CreateRotationZ(MathHelper.ToRadians(angle)) * Matrix.CreateTranslation(position);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
        	spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
 			            DrawModel(terrain, Matrix.CreateTranslation(new Vector3( 0, 0, -5f)), view, projection);
            DrawModel(model, world, view, projection);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
            for(int index = 0; index < model.Meshes.Count; index++)
    		{
       			ModelMesh mesh = model.Meshes[index];
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }
 
                mesh.Draw();
            }
        }
	}
}
