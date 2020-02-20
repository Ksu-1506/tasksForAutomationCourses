namespace Task5ForCourses
{
	class Program
	{
		static void Main(string[] args)
		{
			Estimation estimation = new Estimation();

			estimation.RecordInputTasks();
			estimation.PrintExecutionTimeForAllTasks();
			estimation.PrintTasksByPriority();
			estimation.PrintTasksCompleteInEnteredDays();
		}
	}
}
