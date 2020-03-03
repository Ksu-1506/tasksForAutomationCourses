namespace Task6ForCourses
{
	class Light
	{
		public LightState LightState { get; set; }

		public override string ToString()
		{
			return $"state: {LightState.ToString()}";
		}
	}
}