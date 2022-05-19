using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CavesOfLiest
{
	class Player : Entity
	{
		public class PlayerStats
		{
			public int Strength;
			public int Dexterity;
			public int Intelligence;
			public int Wisdom;
			public int Charisma;
			public int Luck;

			public PlayerStats()
			{
				Strength = Dexterity = Intelligence = Wisdom = Charisma = Luck = 1;
			}
			public PlayerStats(int str, int dex, int intell, int wis, int cha, int luck)
			{
				Strength = str;
				Dexterity = dex;
				Intelligence = intell;
				Wisdom = wis;
				Charisma = cha;
				Luck = luck;
			}
			public void AllStatsUp(int amount)
			{
				Strength += amount;
				Dexterity += amount;
				Intelligence += amount;
				Wisdom += amount;
				Charisma += amount;
				Luck += amount;
			}
		}

		public int Level;
		public int Exp;
		public PlayerStats Stats;
		public Player(int hp, string name) : base(hp, name, new Tile(Color.LightGreen, false, CharTexture.face))
		{
			Stats = new PlayerStats();
		}
		public void LevelUp()
		{
			Level += 1;
			Stats.AllStatsUp(
				(int)Math.Max(Math.Floor(Math.Log10(Math.Pow(Level, 0.5f * Math.Sqrt(Level)))) + 1, 1)
				);
		}
		public void AddExp(int amount)
		{
			int lvlup = (int)Math.Floor(Math.Pow(Level, 1.5f));
			if(Exp + amount < lvlup)
			{
				Exp += amount;
			} else if (Exp + amount == lvlup)
			{
				LevelUp();
				Exp = 0;
			} else
			{
				Exp = 0;
				AddExp(amount - lvlup);
			}
		}
	}
}
