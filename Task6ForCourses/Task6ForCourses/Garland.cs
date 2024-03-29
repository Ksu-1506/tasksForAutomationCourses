﻿using System;
using System.Collections.Generic;

namespace Task6ForCourses
{
	abstract class Garland<TLights>
		where TLights : Light
	{
		private int _currentMinute;
		private readonly List<TLights> _lights;

		protected Garland(int countLights)
		{
			// ReSharper disable once VirtualMemberCallInConstructor
			_lights = Build(countLights);
		}

		public abstract List<TLights> Build(int lightsCount);

		public void SetLightState()
		{
			_currentMinute = DateTime.Now.Minute;
			bool isEvenMinute = _currentMinute % 2 == 0;
			for (int i = 0; i < _lights.Count; i++)
			{
				if ((i % 2 == 0 && isEvenMinute) || (i % 2 == 1 && !isEvenMinute))
				{
					_lights[i].LightState = LightState.Off;
				}
				else
				{
					_lights[i].LightState = LightState.On;
				}
			}
		}

		public void PrintGarlandState()
		{
			SetLightState();
			Console.WriteLine($"Current Minute: {_currentMinute}");
			foreach (var light in _lights)
			{
				Console.WriteLine($"{light.ToString()}");
			}
		}
	}
}