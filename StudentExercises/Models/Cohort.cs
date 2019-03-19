using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Models
{
    class Cohort
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Instructor> Instructors { get; set; }

        public Cohort(string name)
        {
            Name = name;
            Students = new List<Student>();
            Instructors = new List<Instructor>();
        }
    }
}
