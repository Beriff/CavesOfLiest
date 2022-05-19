using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CavesOfLiest
{
	class GameChat
	{
		public struct ChatMsg
		{
			public string msg;
			public Color color;
			public ChatMsg(string msg, Color color)
			{
				this.msg = msg;
				this.color = color;
			}
		}
		public List<ChatMsg> Messages;
		public void AddMsg(ChatMsg msg)
		{
			Messages.Add(msg);
		}
		public GameChat()
		{
			Messages = new List<ChatMsg>();
			AddMsg(new ChatMsg("[DEBUG] Game initialized", Color.LightGoldenrodYellow));
			AddMsg(new ChatMsg("Welcome to the Caves of Liest .", Color.White));
			AddMsg(new ChatMsg("Your goal is to get as deep as you can.", Color.White));
			AddMsg(new ChatMsg("Beware of enemies. Utilize the tools that game gives you.", Color.White));
			AddMsg(new ChatMsg("Losing is fun!", Color.White));
		}
	}
}
