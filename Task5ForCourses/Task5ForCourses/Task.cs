namespace Task5ForCourses
{
	public class Task
	{
		public static int ID = 1;
		public int TaskId { get; set; }
		public Priority Priority { get; set; }
		public Complexity Complexity { get; set; }
		public string Description { get; set; }

		public Task(Priority priority, Complexity complexity, string descriptionName)
		{
			TaskId = ID++;
			Priority = priority;
			Complexity = complexity;
			Description = descriptionName;
		}
	}
}
