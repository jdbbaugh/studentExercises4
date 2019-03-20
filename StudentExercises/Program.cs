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
            Console.WriteLine("ADDED-----------------------------");
            Console.WriteLine();
            Console.WriteLine();

            Exercise dotNetLesson = new Exercise
            {
                Name = "Employees and Departments",
                CodeLanguage = ".NET"
            };
            repository.AddExercise(dotNetLesson);

            Console.WriteLine("ALL EXERCISES INCLUDING NEW ADDED ONE---------------------");

            List<Exercise> exercises2 = repository.GetAllExercises();

            foreach (Exercise assignment in exercises2)
            {

                Console.WriteLine($"{assignment.Name} using {assignment.CodeLanguage}");
            }

            //=================================================================================================
            // INSTRUCTORS
            //=================================================================================================

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ALL INSTRUCTORS PLUS THEIR COHORT -----------------------------");
            List<Instructor> allInstructorsList = repository.GetAllInstructors();

            foreach (Instructor instructor in allInstructorsList)
            {
                Console.WriteLine($"{instructor.FirstName} {instructor.LastName} is the instructor for {instructor.CohortNumber.Name}");
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("SHOW ALL COHORTS -----------------------------");

            List<Cohort> allCohorts = repository.GetallCohorts();
            
            foreach(Cohort cohort in allCohorts)
            {
                Console.WriteLine($"{cohort.Name} ID is {cohort.Id}");
            }

            Cohort steveCohort = allCohorts[1];


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ADD A NEW INSTRUCTOR WITH A COHORT ASSINGMENT -----------------------------");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("NOW SHOW ALL INSTRUCTORS AGAIN...BUT WITH STEVE ADDED-----------------------------");

            
            Instructor newInstructor = new Instructor("Steve", "Brownlee", "StB", steveCohort);

            repository.AddInstructor(newInstructor);

            List<Instructor> withNewInstructorsList = repository.GetAllInstructors();

            foreach (Instructor instructor in withNewInstructorsList)
            {
                Console.WriteLine($"{instructor.FirstName} {instructor.LastName} is the instructor for {instructor.CohortNumber.Name}");
            }

            //=================================================================================================
            // STUDENT
            //=================================================================================================
            Console.WriteLine();
            Console.WriteLine();

            List<Student> assignTo = repository.GetAllStudents();
            Console.WriteLine($"ASSIGN {assignTo[1].FirstName} {assignTo[1].LastName} {exercises2[5].Name} EXERCISE-----------------------------");

            repository.AssignExerciseToStudent(assignTo[1], exercises2[5]);



            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ASSIGNED-----------------------------");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("NOW SHOW ALL STUDENTS-----------------------------");

            List<Student> studentsList = repository.GetAllStudents();

            foreach(Student student in studentsList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }



            Console.ReadKey();
        }
    }
}
