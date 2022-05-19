using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CavesOfLiest
{
	class ClientInput
	{
		KeyboardState prevState;
		public Keys[] pressedKeys;
		public int keysSize;
		public Keys[] keysList;
		public ClientInput()
		{
			keysSize = (int)Enum.GetValues(typeof(Keys)).Cast<Keys>().Max();
			keysList = (Keys[])Enum.GetValues(typeof(Keys));
			prevState = new KeyboardState();
		}
		public void Update(KeyboardState newState)
		{
			pressedKeys = new Keys[keysSize];
			foreach (Keys key in keysList) {
				if(newState.IsKeyDown(key) && prevState.IsKeyUp(key))
				{
					pressedKeys[(int)key] = key;
				}
			}
			prevState = newState;
		}
		public bool IsPressed(Keys key)
		{
			return pressedKeys.Contains(key);
		}
	}
}
