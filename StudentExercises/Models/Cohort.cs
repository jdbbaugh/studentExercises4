﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Models
{
    class Cohort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Instructor> Instructors { get; set; }
    }
}
