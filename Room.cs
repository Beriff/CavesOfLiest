using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CavesOfLiest
{
	enum RoomType
	{
		Common,
		Treasure,
		Boss,
		Shop,

	}
	class Room
	{
		public List<List<Tile>> tileSpace;
		public string name;
		public int[,] spawnnodes;
		public RoomType rtype;
		static public List<Room> rooms = new List<Room>();
		public Room(List<List<Tile>> space, string name, RoomType rtype, int[,] spawnnodes)
		{
			tileSpace = space;
			this.name = name;
			this.rtype = rtype;
			this.spawnnodes = spawnnodes;
		}
		public static readonly int SizeX = 8;
		public static readonly int SizeY = 20;
		static public Dictionary<string, Tile> tiles = new Dictionary<string, Tile>() 
		{ 
			["def_wall"] = new Tile(Color.White, true, CharTexture.lblock),
			["def_floor"] = new Tile(Color.Gray, false, CharTexture.period),
		};

		public static Room LoadRoom(string name, List<string> map, Dictionary<char, string> keys, int rtype, int[,] spawnnodes)
		{
			List<List<Tile>> roomSpace = new List<List<Tile>>();
			for(int x = 0; x < map.Count; x++)
			{
				roomSpace.Add(new List<Tile>());
				for(int y = 0; y < map[x].Length; y++)
				{
					roomSpace[x].Add(Room.tiles[keys[map[x][y]]]);
				}
			}
			return new Room(roomSpace, name, (RoomType)rtype, spawnnodes);

		}
		public static Room LoadFromJson(string path)
		{
			string json = File.ReadAllText(path);
			dynamic dynRoom = JObject.Parse(json);
			return Room.LoadRoom(
				dynRoom.name.Path, 
				dynRoom.map.ToObject<List<string>>(), 
				dynRoom.keys.ToObject<Dictionary<char, string>>(), 
				dynRoom.roomtype.ToObject<int>(),
				dynRoom.spawnnodes.ToObject<int[,]>());
			//return;
		
		}
		public void AddToWorld(World world, Vector2 origin)
		{
			int xoffset = (int)origin.X;
			int yoffset = (int)origin.Y;

			for (int x = 0; x < tileSpace.Count; x++)
			{
				for (int y = 0; y < tileSpace[x].Count; y++)
				{
					world.ChangeTile(x + xoffset, y + yoffset, tileSpace[x][y]);
				}
			}
		}
		public Room WithExits(bool[] exits)
		{
			//For some unholy reason (porbably Tile is a reference type) whatever i tried to do, it just referenced this.tileSpace,
			//so i had to manually recreate the array.
			List<List<Tile>> ntSpace = new List<List<Tile>>();
			for(int x = 0; x < tileSpace.Count; x++)
			{
				ntSpace.Add(new List<Tile>());
				for (int y = 0; y < tileSpace[x].Count; y++)
				{
					Tile t = tileSpace[x][y];
					ntSpace[x].Add(new Tile(t.color, t.collision, t.texture));
				}
			}
			Room copy = new Room(ntSpace, name, rtype, spawnnodes);
			if (exits[2])
			{
				copy.tileSpace[0][((int)SizeY) / 2] = tiles["def_floor"];
				copy.tileSpace[0][((int)SizeY) / 2 - 1] = tiles["def_floor"];
			}
				
			if (exits[3])
			{
				copy.tileSpace[SizeX - 1][((int)SizeY) / 2] = tiles["def_floor"];
				copy.tileSpace[SizeX - 1][((int)SizeY) / 2 - 1] = tiles["def_floor"];
			}
				
			if (exits[0])
			{
				copy.tileSpace[((int)SizeX) / 2][0] = tiles["def_floor"];
				copy.tileSpace[((int)SizeX) / 2 - 1][0] = tiles["def_floor"];
			}

			if(exits[1])
			{
				copy.tileSpace[((int)SizeX) / 2][SizeY - 1] = tiles["def_floor"];
				copy.tileSpace[((int)SizeX) / 2 - 1][SizeY - 1] = tiles["def_floor"];
			}
			return copy;

		}

		public static void LoadDirectory(string dirpath)
		{
			string[] files = Directory.GetFiles(dirpath, "*.json", SearchOption.TopDirectoryOnly);
			foreach(string filepath in files)
			{
				Room room = Room.LoadFromJson(filepath);
				rooms.Add(room);
			}
		}
	}
}
