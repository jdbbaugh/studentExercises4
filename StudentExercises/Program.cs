using System;
using System.Collections.Generic;
using System.Linq;
using StudentExercises.Data;
using StudentExercises.Models;


namespace StudentExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();

            //EXERCISES ----------------------------------------------------

            Console.WriteLine("ALL EXERCISES ---------------------");

            List<Exercise> exercises = repository.GetAllExercises();

            foreach(Exercise assignment in exercises)
            {

            Console.WriteLine($"{assignment.Name} using {assignment.CodeLanguage}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("EXERCISES THAT USE JAVASCRIPT-----------------------------");
            List<Exercise> javascriptExercises = repository.ExercisesWithJavaScript();

            foreach(Exercise assignment in javascriptExercises)
            {
                Console.WriteLine($"{assignment.Name} using {assignment.CodeLanguage}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ADD NEW EXERCISE-----------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("DONE-----------------------------");

            Exercise dotNetLesson = new Exercise
            {
                Name = "Employees and Departments",
                CodeLanguage = ".NET"
            };
            repository.AddExercise(dotNetLesson);

            Console.WriteLine("ALL EXERCISES WITH Employees and Departments ADDED---------------------");

            List<Exercise> exercises2 = repository.GetAllExercises();

            foreach (Exercise assignment in exercises2)
            {

                Console.WriteLine($"{assignment.Name} using {assignment.CodeLanguage}");
            }


            Console.ReadKey();
        }
    }
}
