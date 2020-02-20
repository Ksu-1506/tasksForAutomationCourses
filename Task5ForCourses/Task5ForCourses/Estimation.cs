using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5ForCourses
{
    public class Estimation
    {
        List<Task> tasks = new List<Task>();

        public void RecordInputTasks()
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"Start creation of a new task.");

                var priority = EnumHelper.RequestForEnumValue<Priority>();
                var complexity= EnumHelper.RequestForEnumValue<Complexity>();
                var descriptionName= ValidationHelper.GetValidDescription();

                tasks.Add(new Task(priority, complexity, descriptionName));

                Console.WriteLine($"{Environment.NewLine}Maybe you want to create another task?");
            } while (EnumHelper.RequestForEnumValue<YesNo>() == YesNo.Yes);
        }

        public void PrintExecutionTimeForAllTasks()
        {
            int executionTime = 0;

            foreach (Task task in tasks)
            {
                executionTime += EnumHelper.GetEnumValueAttribute<Complexity>(task.Complexity);
            }

            Console.WriteLine($"{executionTime} working hours are needed to complete all your tasks.{Environment.NewLine}");
            Console.ReadKey();
        }

        public void PrintTasksByPriority()
        {
            Priority inputPriority;

            do
            {
                Console.Clear();
                Console.WriteLine($"Displaying tasks by selected priority.{Environment.NewLine}");
                inputPriority = EnumHelper.RequestForEnumValue<Priority>();

                List<Task> selectedTasks = tasks.Where(x => x.Priority == inputPriority).ToList();

                foreach (Task task in selectedTasks)
                {
	                Console.WriteLine($"{Environment.NewLine}Task priority: {task.Priority}");
	                Console.WriteLine($"Task complexity: {task.Complexity}");
	                Console.WriteLine($"Task description: {task.Description}");
                }

                Console.WriteLine($"{Environment.NewLine}Maybe you want to see the tasks of another priority?");
            } while (EnumHelper.RequestForEnumValue<YesNo>() == YesNo.Yes);
        }

        public void PrintTasksCompleteInEnteredDays()
        {
	        tasks = tasks.OrderBy(y => y.Complexity)
							.ThenBy(x => x.Priority).ToList();
	        

            do
            {
                Console.Clear();
                Console.WriteLine($"Please enter desired number of working days. You will see your tasks that can be completed in a given number of days (considering {Constants.WorkingHoursPerDay} working hours per day)");
                                 
                var inputHours = ValidationHelper.GetValidDays() * Constants.WorkingHoursPerDay;

                foreach (Task task in tasks)
                {
                    if (inputHours >= EnumHelper.GetEnumValueAttribute<Complexity>(task.Complexity))
                    {
                        inputHours -= EnumHelper.GetEnumValueAttribute<Complexity>(task.Complexity);
                        Console.WriteLine($"{Environment.NewLine}Task priority: {task.Priority}");
                        Console.WriteLine($"Task complexity: {task.Complexity}");
                        Console.WriteLine($"Task description: {task.Description}");
                    }

                    else
                    {
                        break;
                    }
                }

                Console.WriteLine($"{Environment.NewLine}Maybe you want to enter another number of working days?");
            } while (EnumHelper.RequestForEnumValue<YesNo>() == YesNo.Yes);
        }
    }
}
