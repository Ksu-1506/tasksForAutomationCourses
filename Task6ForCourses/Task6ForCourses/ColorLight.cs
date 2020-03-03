namespace Task6ForCourses
{
	class ColorLight : Light
	{
		public ColorLight(LightsColor color)
		{
			LightsColor = color;
		}

		public ColorLight()
		{
		}

		public LightsColor LightsColor { get; set; }

		public override string ToString()
		{
			return $"{base.ToString()}, color: {LightsColor.ToString()}";
		}
	}
}