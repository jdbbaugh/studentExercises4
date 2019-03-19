using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Models
{
    class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SlackHandle { get; set; }

        public Cohort CohortNumber { get; set; }
        public List<Exercise> CurrentExercises { get; set; }

        public Student(string firstName, string lastName, string slackHandle, Cohort cohort)
        {

            FirstName = firstName;
            LastName = lastName;
            SlackHandle = slackHandle;
            CohortNumber = cohort;
            CurrentExercises = new List<Exercise>();
            // cohort.Students.Add();
        }
    }
}
