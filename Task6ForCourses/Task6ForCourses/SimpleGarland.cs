using System.Collections.Generic;

namespace Task6ForCourses
{
	class SimpleGarland : Garland<Light>
	{
		public SimpleGarland(int countSimpleGarland) : base(countSimpleGarland)
		{
		}

		public override List<Light> Build(int lightsCount)
		{
			List<Light> lights = new List<Light>();
			for (int i = 0; i < lightsCount; i++)
			{
				lights.Add(new Light());
			}
			return lights;
		}
	}
}
