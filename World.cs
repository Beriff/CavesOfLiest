using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CavesOfLiest
{
	enum CharTexture
	{
		a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,
		A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,
		one,two,three,four,five,six,seven,eight,nine,zero,excl,
		at,dollar,percent,caret,amp,asterisk,lbraket,rbraket,
		minus,eq,tilde,dash,plus,degree,heart,diamond,dot,slash,ques,
		bslash,colon,period,apos,quote,dtilde,lblock, mblock, hblock,
		square,triangle,less,greater,hash,face,theta,omega,setin,fgr,flw,sh,rp
	}
	struct Tile
	{
		public bool collision;
		public CharTexture texture;
		public Color color;
		public static Vector2 getAtlasOffset(CharTexture texture) => texture switch
					{
						CharTexture.a => new Vector2(1, 1),
						CharTexture.b => new Vector2(2, 1),
						CharTexture.c => new Vector2(3, 1),
						CharTexture.d => new Vector2(4, 1),
						CharTexture.e => new Vector2(5, 1),
						CharTexture.f => new Vector2(6, 1),
						CharTexture.g => new Vector2(7, 1),
						CharTexture.h => new Vector2(8, 1),
						CharTexture.i => new Vector2(9, 1),
						CharTexture.j => new Vector2(10, 1),
						CharTexture.k => new Vector2(11, 1),
						CharTexture.l => new Vector2(12, 1),
						CharTexture.m => new Vector2(13, 1),
						CharTexture.n => new Vector2(14, 1),
						CharTexture.o => new Vector2(15, 1),
						CharTexture.p => new Vector2(16, 1),
						CharTexture.q => new Vector2(17, 1),
						CharTexture.r => new Vector2(18, 1),
						CharTexture.s => new Vector2(19, 1),
						CharTexture.t => new Vector2(20, 1),
						CharTexture.u => new Vector2(21, 1),
						CharTexture.v => new Vector2(22, 1),
						CharTexture.w => new Vector2(23, 1),
						CharTexture.x => new Vector2(24, 1),
						CharTexture.y => new Vector2(25, 1),
						CharTexture.z => new Vector2(26, 1),
						CharTexture.A => new Vector2(1, 2),
						CharTexture.B => new Vector2(2, 2),
						CharTexture.C => new Vector2(3, 2),
						CharTexture.D => new Vector2(4, 2),
						CharTexture.E => new Vector2(5, 2),
						CharTexture.F => new Vector2(6, 2),
						CharTexture.G => new Vector2(7, 2),
						CharTexture.H => new Vector2(8, 2),
						CharTexture.I => new Vector2(9, 2),
						CharTexture.J => new Vector2(10, 2),
						CharTexture.K => new Vector2(11, 2),
						CharTexture.L => new Vector2(12, 2),
						CharTexture.M => new Vector2(13, 2),
						CharTexture.N => new Vector2(14, 2),
						CharTexture.O => new Vector2(15, 2),
						CharTexture.P => new Vector2(16, 2),
						CharTexture.Q => new Vector2(17, 2),
						CharTexture.R => new Vector2(18, 2),
						CharTexture.S => new Vector2(19, 2),
						CharTexture.T => new Vector2(20, 2),
						CharTexture.U => new Vector2(21, 2),
						CharTexture.V => new Vector2(22, 2),
						CharTexture.W => new Vector2(23, 2),
						CharTexture.X => new Vector2(24, 2),
						CharTexture.Y => new Vector2(25, 2),
						CharTexture.Z => new Vector2(26, 2),
						CharTexture.one => new Vector2(1, 3),
						CharTexture.two => new Vector2(2, 3),
						CharTexture.three => new Vector2(3, 3),
						CharTexture.four => new Vector2(4, 3),
						CharTexture.five => new Vector2(5, 3),
						CharTexture.six => new Vector2(6, 3),
						CharTexture.seven => new Vector2(7, 3),
						CharTexture.eight => new Vector2(8, 3),
						CharTexture.nine => new Vector2(9, 3),
						CharTexture.zero => new Vector2(10, 3),
						CharTexture.excl => new Vector2(11, 3),
						CharTexture.at => new Vector2(12, 3),
						CharTexture.dollar => new Vector2(13, 3),
						CharTexture.percent => new Vector2(14, 3),
						CharTexture.caret => new Vector2(15, 3),
						CharTexture.amp => new Vector2(16, 3),
						CharTexture.asterisk => new Vector2(17, 3),
						CharTexture.lbraket => new Vector2(18, 3),
						CharTexture.rbraket => new Vector2(19, 3),
						CharTexture.minus => new Vector2(20, 3),
						CharTexture.eq => new Vector2(21, 3),
						CharTexture.tilde => new Vector2(22, 3),
						CharTexture.dash => new Vector2(23, 3),
						CharTexture.plus => new Vector2(24, 3),
						CharTexture.degree => new Vector2(25, 3),
						CharTexture.heart => new Vector2(26, 3),
						CharTexture.diamond => new Vector2(1, 4),
						CharTexture.dot => new Vector2(2, 4),
						CharTexture.slash => new Vector2(3, 4),
						CharTexture.ques => new Vector2(4, 4),
						CharTexture.bslash => new Vector2(5, 4),
						CharTexture.colon => new Vector2(6, 4),
						CharTexture.period => new Vector2(7, 4),
						CharTexture.apos => new Vector2(8, 4),
						CharTexture.quote => new Vector2(9, 4),
						CharTexture.dtilde => new Vector2(10, 4),
						CharTexture.lblock => new Vector2(11, 4),
						CharTexture.mblock => new Vector2(12, 4),
						CharTexture.hblock => new Vector2(13, 4),
						CharTexture.square => new Vector2(14, 4),
						CharTexture.triangle => new Vector2(15, 4),
						CharTexture.less => new Vector2(16, 4),
						CharTexture.greater => new Vector2(17, 4),
						CharTexture.hash => new Vector2(18, 4),
						CharTexture.face => new Vector2(19, 4),
						CharTexture.theta => new Vector2(20, 4),
						CharTexture.omega => new Vector2(21, 4),
						CharTexture.setin => new Vector2(22, 4),
						CharTexture.fgr => new Vector2(23, 4),
						CharTexture.flw => new Vector2(24, 4),
						CharTexture.sh => new Vector2(25, 4),
						CharTexture.rp => new Vector2(26, 4),
						_ => throw new Exception("are you fucking retarded")
					};
		public Tile(Color col, bool coll = false, CharTexture texture = CharTexture.hash)
		{
			color = col;
			collision = coll;
			this.texture = texture;
		}
	}
	class World
	{
		public Tile[,] tileSpace;
		public Texture2D tileAtlas;
		public List<Entity> entities;
		public static class Camera
		{
			public static int FocusX = 10;
			public static int FocusY = 10;
			public static int SpanX = 0;
			public static int SpanY = 0;
			public static Vector2 GetCoord(int x, int y)
			{
				return new Vector2(FocusX - SpanX / 2 + x, FocusY - SpanY / 2 + y);
			}
		}

		public static readonly int WorldSize = 160;

		//TODO REWORK THIS SHIT
		public void Draw(SpriteBatch sb, Vector2 pos, Vector2 tiles, Player plr)
		{
			var plrTextureOffset = (Tile.getAtlasOffset(plr.EntityTile.texture) - Vector2.One) * new Vector2(16, 16);
			int plr_x = (int)plr.Position.X;
			int plr_y = (int)plr.Position.Y;

			//I hate how Vector2 X and Y are float type
			Camera.SpanX = (int)tiles.X;
			Camera.SpanY = (int)tiles.Y;
			Camera.FocusX = plr_x;
			Camera.FocusY = plr_y;

			for(int x = 0; x < tiles.X; x++)
			{
				for(int y = 0; y < tiles.Y; y++)
				{
					Vector2 tileCoords = Camera.GetCoord(x, y);
					if (tileCoords.X < 0 || tileCoords.X >= WorldSize || tileCoords.Y < 0 || tileCoords.Y >= WorldSize)
					{
						continue;
					}
						
					if (IsEntityAt(tileCoords))
					{
						Entity ent = EntityAt(tileCoords);
						var tOffset = (Tile.getAtlasOffset(ent.EntityTile.texture) - Vector2.One) * new Vector2(16);
						sb.Draw(tileAtlas, new Vector2(x * 16, y * 16), new Rectangle(tOffset.ToPoint(), new Point(16)), ent.EntityTile.color);
					}
					else if (tileCoords.X == plr_x && tileCoords.Y == plr_y)
					{
						sb.Draw(tileAtlas, new Vector2(x * 16, y * 16), new Rectangle(plrTextureOffset.ToPoint(), new Point(16, 16)), plr.EntityTile.color);
					}
					else
					{
						Tile tile = (Tile)TileAt(tileCoords);
						var tOffset = (Tile.getAtlasOffset(tile.texture) - Vector2.One) * new Vector2(16);
						sb.Draw(tileAtlas, new Vector2(x * 16, y * 16), new Rectangle(tOffset.ToPoint(), new Point(16)), tile.color);
					}
				}
			}
			
			
		}
		public void Clear(Tile tile)
		{
			//GetLength 0 and 1 returns width and height
			for (int x = 0; x < tileSpace.GetLength(0); x++)
			{
				for (int y = 0; y < tileSpace.GetLength(1); y++)
				{
					tileSpace[x, y] = tile;
				}
			}
		}
		public bool IsInBounds(Vector2 pos)
		{
			return pos.X >= 0 && pos.Y >= 0 && pos.X <= tileSpace.GetLength(0) && pos.Y <= tileSpace.GetLength(1);
		}
		public World(Texture2D atlas)
		{
			tileSpace = new Tile[WorldSize, WorldSize];
			tileAtlas = atlas;
			entities = new List<Entity>();
		}
		public Tile? TileAt(Vector2 coord)
		{
			try
			{
				int x = (int)coord.X;
				int y = (int)coord.Y;
				return tileSpace[x, y];
			} catch (IndexOutOfRangeException)
			{
				return null;
			}
			
		}
		public bool IsEntityAt(Vector2 coords)
		{
			foreach(Entity ent in entities)
			{
				if (ent.Position == coords)
					return true;
			}
			return false;
		}
		public Entity EntityAt(Vector2 coords)
		{
			foreach (Entity ent in entities)
			{
				if (ent.Position == coords)
					return ent;
			}
			return null;
		}
		public void ChangeTile(int x, int y, Tile tile)
		{
			tileSpace[y, x] = tile;
		}
		public void GenerateDungeon()
		{
			bool[,] room_map = new bool[WorldSize / Room.SizeX, WorldSize / Room.SizeY];
			Vector2 position = new Vector2(WorldSize / 2 / Room.SizeX, WorldSize / 2 / Room.SizeY);
			Random r = new Random();
			List<Vector2> taken_tiles = new List<Vector2>();

			//up, down, left, right
			bool[] getneighbors(int x, int y)
			{
				bool[] neighbors = new bool[4];
				neighbors[0] = taken_tiles.Contains(new Vector2(x, y - 1));
				neighbors[1] = taken_tiles.Contains(new Vector2(x, y + 1));
				neighbors[2] = taken_tiles.Contains(new Vector2(x - 1, y));
				neighbors[3] = taken_tiles.Contains(new Vector2(x + 1, y));
				return neighbors;
			}

			//random walk
			for(int i = 0; i < 10; i++)
			{	
				
				try
				{
					if(!taken_tiles.Contains(position))
					{
						//room_map[(int)position.X, (int)position.Y] = true;
						taken_tiles.Add(new Vector2(position.X, position.Y));
					} else
					{
						i--;
						int start_t_index = r.Next(0, taken_tiles.Count);
						position = taken_tiles[start_t_index];
						//continue;
					}
				
				} catch (ArgumentOutOfRangeException)
				{
					i--;
					continue;
				}
				Vector2 shift = new Vector2();
				shift.X = r.Next(-1, 1);
				if (shift.X != 0)
				{
					shift.Y = 0;
				} else
				{
					shift.Y = r.Next(-1, 1);
				}
				position += shift;
				
			}
			//generate rooms for taken_tiles entries
			foreach(Vector2 roompos in taken_tiles)
			{
				bool[] filter = getneighbors((int)roompos.X, (int)roompos.Y);
				System.Diagnostics.Debug.WriteLine(filter[0].ToString() + filter[1].ToString() + filter[2].ToString() + filter[3].ToString());
				int r_roomindex = r.Next(0, Room.rooms.Count);
				Room formatted_room = Room.rooms[r_roomindex]
					.WithExits(filter);
				formatted_room.AddToWorld(this, roompos * new Vector2(Room.SizeX, Room.SizeY));
			}

		}
	}
}
