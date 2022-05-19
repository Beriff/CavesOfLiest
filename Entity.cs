using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CavesOfLiest
{
	class Entity
	{
		public int Hp;
		public int MaxHp;
		public string Name;
		public Vector2 Position;

		public Tile EntityTile;

		public Entity(int hp, string name, Tile entitytile)
		{
			Hp = hp;
			MaxHp = Hp;
			Name = name;
			EntityTile = entitytile;
		}
		public void Damage(int amount)
		{
			if (Hp - amount < 0)
			{
				Hp = 0;
			} else if (Hp - amount > MaxHp)
			{
				Hp = MaxHp;
			} else
			{
				Hp -= amount;
			}
		}
		public void Move(World world, Vector2 shift)
		{
			var dest = Position + shift;
			if(world.IsInBounds(dest) && !((Tile)world.TileAt(dest)).collision && !world.IsEntityAt(dest))
			{
				Position += shift;
			}
		}
	}
}
