using System.Collections.Generic;


namespace Task6ForCourses
{
	class ColorGarland : Garland<ColorLight>
	{
		public ColorGarland(int countColorLights) : base(countColorLights)
		{
		}

		public override List<ColorLight> Build(int lightsCount)
		{
			List<ColorLight> colorLights = new List<ColorLight>();
			for (int i = 0; i < lightsCount; i++)
			{
				var light = new ColorLight(DefineColor(i + 1));
				colorLights.Add(light);
			}

			return colorLights;
		}

		public LightsColor DefineColor(int index)
		{
			var a = index % 4;
			switch (a)
			{
				case 1:
					return LightsColor.Red;

				case 2:
					return LightsColor.Yellow;

				case 3:
					return LightsColor.Blue;

				case 4:
					return LightsColor.Green;

				default:
					return LightsColor.Clear;
			}
		}
	}
}