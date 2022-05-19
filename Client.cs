using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CavesOfLiest
{
	class Client
	{
		public World world;
		private Vector2 tilesOccupied;
		public SpriteFont ChatFont;
		//Functions that draw additional info (chat, stats) with which the player cannot interact
		//(Interactable layouts are GUIs)
		public List<Action<Client, SpriteBatch>> Layouts;
		public GameChat Chat;
		public ClientInput clientInput;

		public Player player;

		public void OnResize(GraphicsDeviceManager gd)
		{
			var viewport = gd.GraphicsDevice.Viewport;
			tilesOccupied = new Vector2(viewport.Width / 2 / 16, viewport.Height / 1.3f / 16);
		}

		public Client(GraphicsDeviceManager gd, Texture2D atlas)
		{
			world = new World(atlas);
			world.Clear(new Tile(Color.White, false, CharTexture.period));
			
			OnResize(gd);
			Layouts = new List<Action<Client, SpriteBatch>>();
			Chat = new GameChat();
			clientInput = new ClientInput();
			Room.LoadDirectory(@"C:\Users\Maxim\source\repos\CavesOfLiest\CavesOfLiest\Content\rooms\");
			world.GenerateDungeon();
			//r1.AddToWorld(world, new Vector2(5));

			player = new Player(100, "Sbren Sbeve");
			player.Position = new Vector2(World.WorldSize / 2) + new Vector2(10, 4);

			//----Chat overlay
			Layouts.Add((Client c, SpriteBatch sb) =>
			{
				
				var gd = sb.GraphicsDevice;
				var msgcount = c.Chat.Messages.Count;	
				Vector2 baseoffset = new Vector2(0, gd.Viewport.Height / 1.3f);
				int fontheight = (int)c.ChatFont.MeasureString("g").Y;
				int msgdisplay = (int)(5 *( gd.Viewport.Height / 1.3f / fontheight / 24));
				msgdisplay = Math.Min(msgdisplay, msgcount);
				for (int i = msgcount - msgdisplay; i < msgcount; i++)
				{
					sb.DrawString(c.ChatFont, Chat.Messages[i].msg, 
						baseoffset + new Vector2(0, (fontheight + 2) * (i - (msgcount - msgdisplay) + 1)), 
						Chat.Messages[i].color, 0, Vector2.Zero, gd.Viewport.AspectRatio * 0.7f, SpriteEffects.None, 0);
				}
			});
		}
		public void Draw(SpriteBatch sb)
		{
			world.Draw(sb, Vector2.Zero, tilesOccupied, player);
			foreach(var drawlayout in Layouts)
			{
				drawlayout(this, sb);
			}
		}
		public void Update(KeyboardState kb)
		{
			clientInput.Update(kb);

			//--PLAYER MOVEMENT
			if(clientInput.IsPressed(Keys.A))
			{
				player.Move(world, new Vector2(-1, 0));
			} 
			else if (clientInput.IsPressed(Keys.D)) {
				player.Move(world, new Vector2(1, 0));
			}
			else if (clientInput.IsPressed(Keys.W))
			{
				Chat.AddMsg(new GameChat.ChatMsg($"plr pos {player.Position}", Color.AliceBlue));
				player.Move(world, new Vector2(0, -1));
			}
			else if (clientInput.IsPressed(Keys.S))
			{
				player.Move(world, new Vector2(0, 1));
			}
		}
	}
}
