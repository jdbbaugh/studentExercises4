using System;
using System.Linq;
using StudentExercises.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace StudentExercises.Data
{
    class Repository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Server=DESKTOP-ALG4281\\SQLEXPRESS;Database=StudentExercises2;Trusted_Connection=True;";
                return new SqlConnection(_connectionString);
            }
        }

        //=======================================================================================
        //EXERCISES:
        //=======================================================================================

        public List<Exercise> GetAllExercises ()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, ExerciseName, ExerciseLanguage FROM Exercise";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while(reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int exerciseNameColumnPosition = reader.GetOrdinal("ExerciseName");
                        string exerciseNameValue = reader.GetString(exerciseNameColumnPosition);

                        int exerciseLanguageColumnPosition = reader.GetOrdinal("ExerciseLanguage");
                        string exerciseLanguageValue = reader.GetString(exerciseLanguageColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Name = exerciseNameValue,
                            CodeLanguage = exerciseLanguageValue
                        };
                        exercises.Add(exercise);
                    }
                    reader.Close();

                    return exercises;
                }
            }
        }

        public List<Exercise> ExercisesWithJavaScript()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, ExerciseName, ExerciseLanguage FROM Exercise WHERE ExerciseLanguage = 'Javascript'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int exerciseNameColumnPosition = reader.GetOrdinal("ExerciseName");
                        string exerciseNameValue = reader.GetString(exerciseNameColumnPosition);

                        int exerciseLanguageColumnPosition = reader.GetOrdinal("ExerciseLanguage");
                        string exerciseLanguageValue = reader.GetString(exerciseLanguageColumnPosition);

                        Exercise exercise = new Exercise
                        {
                            Id = idValue,
                            Name = exerciseNameValue,
                            CodeLanguage = exerciseLanguageValue
                        };
                        exercises.Add(exercise);
                    }
                    reader.Close();

                    return exercises;
                }
            }
        }

        public void AddExercise(Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES (@exerciseName, @exerciseLanguage)";
                    cmd.Parameters.Add(new SqlParameter("@exerciseName", exercise.Name));
                    cmd.Parameters.Add(new SqlParameter("@exerciseLanguage", exercise.CodeLanguage));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //=======================================================================================
        //INSTRUCTORS:
        //=======================================================================================

        public List<Instructor> GetAllInstructors()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT i.Id, i.FirstName, i.LastName, i.SlackHandle,c.Id AS CohortID, c.CohortName FROM Instructor i INNER JOIN Cohort c ON i.CohortId = c.id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();

                    while(reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");

                        int idValue = reader.GetInt32(idColumnPosition);

                        int firstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string instFirstNameValue = reader.GetString(firstNameColumnPosition);

                        int lastNameColumnPosition = reader.GetOrdinal("LastName");
                        string instLastNameValue = reader.GetString(lastNameColumnPosition);

                        int slackHandleColumnPosition = reader.GetOrdinal("SlackHandle");
                        string slackHandleValue = reader.GetString(lastNameColumnPosition);

                        int cohoritIdColumnPosition = reader.GetOrdinal("CohortId");
                        int cohortId = reader.GetInt32(cohoritIdColumnPosition);

                        int cohortNameColumnPosition = reader.GetOrdinal("CohortName");
                        string cohortName = reader.GetString(cohortNameColumnPosition);



                        Cohort instructorsCohort = new Cohort
                        {
                            Id = cohortId,
                            Name = cohortName
                        };

                        Instructor instructor = new Instructor(instFirstNameValue, instLastNameValue, slackHandleValue, instructorsCohort);

                        instructors.Add(instructor);
                    }
                    reader.Close();
                    return instructors;
                }
            }
        }
        public void AddInstructor(Instructor newInstructor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) VALUES (@firstName, @lastName, @slackHandle, @cohortId)";
                    cmd.Parameters.Add(new SqlParameter("@firstName", newInstructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", newInstructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@slackHandle", newInstructor.SlackHandle));
                    cmd.Parameters.Add(new SqlParameter("@cohortId", newInstructor.CohortNumber.Id));
                    cmd.ExecuteNonQuery();
                }
            }

        }

        //====================================================================================
        //Cohort
        //====================================================================================
        public List<Cohort> GetallCohorts()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, CohortName FROM Cohort";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cohort> cohorts = new List<Cohort>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int cohortNameColumnPosition = reader.GetOrdinal("CohortName");
                        string cohortNameValue = reader.GetString(cohortNameColumnPosition);

                        Cohort cohort = new Cohort
                        {
                            Id = idValue,
                            Name = cohortNameValue };

                        cohorts.Add(cohort);
                    }
                    reader.Close();
                    return cohorts;
                }
            }
        }
        //====================================================================================
        //STUDENT
        //====================================================================================



        public List<Student> GetAllStudentsOverkill()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT e.id AS ExerciseId, e.ExerciseName,e.ExerciseLanguage,s.Id AS StudentId,s.FirstName, s.LastName, s.SlackHandle, c.id AS CohortId, c.CohortName FROM Exercise e LEFT JOIN AssignedExercise a ON a.ExerciseId = e.Id LEFT JOIN Student s ON s.id = a.StudentId LEFT JOIN Cohort c ON c.id = s.CohortId WHERE s.Id is not null";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();
                    

                    while (reader.Read())
                    {
                        int exerciseIdColumnPosition = reader.GetOrdinal("ExerciseId");
                        int exerciseIdValue = reader.GetInt32(exerciseIdColumnPosition);

                        int exerciseNameColumnPosition = reader.GetOrdinal("ExerciseName");
                        string exerciseNameValue = reader.GetString(exerciseNameColumnPosition);

                        int exerciseLanguageColumnPosition = reader.GetOrdinal("ExerciseLanguage");
                        string exerciseLanguageValue = reader.GetString(exerciseLanguageColumnPosition);

                        int studentIdColumnPosition = reader.GetOrdinal("StudentId");
                        int studentIdValue = reader.GetInt32(studentIdColumnPosition);

                        int stuFirstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string stuFirstNameValue = reader.GetString(stuFirstNameColumnPosition);

                        int stuLastNameColumnPosition = reader.GetOrdinal("LastName");
                        string stuLastNameValue = reader.GetString(stuLastNameColumnPosition);

                        int stuSlackNameColumnPosition = reader.GetOrdinal("SlackHandle");
                        string stuSlackNameValue = reader.GetString(stuSlackNameColumnPosition);

                        int stuCohortIdColumnPosition = reader.GetOrdinal("CohortId");
                        int stuCohortIdValue = reader.GetInt32(stuCohortIdColumnPosition);

                        int stuCohortNameColumnPosition = reader.GetOrdinal("CohortName");
                        string stuCohortNameValue = reader.GetString(stuCohortNameColumnPosition);

                        Cohort stuCohort = new Cohort
                        {
                            Id = stuCohortIdValue,
                            Name = stuCohortNameValue
                        };

                        Exercise exercises = new Exercise()
                        {
                            Id = exerciseIdValue,
                            Name = exerciseNameValue,
                            CodeLanguage = exerciseLanguageValue
                        };

                        List<Exercise> studentclass = new List<Exercise>();
                        studentclass.Add(exercises);

                        Student student = new Student
                        {
                            Id = studentIdValue,
                            FirstName = stuFirstNameValue,
                            LastName = stuLastNameValue,
                            SlackHandle = stuSlackNameValue,
                            CohortNumber = stuCohort,
                            CurrentExercises = studentclass
                        };

                        students.Add(student);
                    }
                    reader.Close();
                    return students;
                }
            }
        }

        public void AssignExerciseToStudent(Student student, Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (@exerciseId, @studentId)";
                    cmd.Parameters.Add(new SqlParameter("@exerciseId", exercise.Id));
                    cmd.Parameters.Add(new SqlParameter("@studentId", student.Id));
                    cmd.ExecuteNonQuery();

                }
            }
        }


        /* ANDYS SOLUTION FOR GETTING ALL STUDENTS AND THEIR LESSONS
        public List<Student> GetAllStudents()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select s.id as StudentId,
                                       s.FirstName,
                                       s.LastName,
                                       s.SlackHandle,
                                       s.CohortId,
                                       c.[Name] as CohortName,
                                       e.id as ExerciseId,
                                       e.[name] as ExerciseName,
                                       e.[Language]
                                  from student s
                                       left join Cohort c on s.CohortId = c.id
                                       left join StudentExercise se on s.id = se.studentid
                                       left join Exercise e on se.exerciseid = e.id;";
                    SqlDataReader reader = cmd.ExecuteReader();

                    Dictionary<int, Student> students = new Dictionary<int, Student>();
                    while (reader.Read())
                    {
                        int studentId = reader.GetInt32(reader.GetOrdinal("StudentId"));
                        if (!students.ContainsKey(studentId))
                        {
                            Student newStudent = new Student
                            {
                                Id = studentId,
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
                                CohortId = reader.GetInt32(reader.GetOrdinal("CohortId")),
                                Cohort = new Cohort
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("CohortId")),
                                    Name = reader.GetString(reader.GetOrdinal("CohortName"))
                                }
                            };

                            students.Add(studentId, newStudent);
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("ExerciseId")))
                        {
                            Student currentStudent = students[studentId];
                            currentStudent.Exercises.Add(
                                new Exercise
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("ExerciseId")),
                                    Language = reader.GetString(reader.GetOrdinal("Language")),
                                    Name = reader.GetString(reader.GetOrdinal("ExerciseName")),
                                }
                            );
                        }
                    }

                    reader.Close();

                    return students.Values.ToList();
                }
            }
        }
        */



        public List<Student> GetAllStudents()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT i.Id, i.FirstName, i.LastName, i.SlackHandle,c.Id AS CohortID, c.CohortName FROM Student i INNER JOIN Cohort c ON i.CohortId = c.id; ";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int firstNameColumnPosition = reader.GetOrdinal("FirstName");
                        string firstNameValue = reader.GetString(firstNameColumnPosition);

                        int lastNameColumnPosition = reader.GetOrdinal("LastName");
                        string lastNameValue = reader.GetString(lastNameColumnPosition);

                        int slackHandleColumnPosition = reader.GetOrdinal("SlackHandle");
                        string slackHandleValue = reader.GetString(slackHandleColumnPosition);

                        int cohortIdColumnPosition = reader.GetOrdinal("CohortID");
                        int cohortIdValue = reader.GetInt32(cohortIdColumnPosition);

                        int cohortNameColumnPosition = reader.GetOrdinal("CohortName");
                        string cohortNameValue = reader.GetString(cohortNameColumnPosition);

                        Cohort stuCohort = new Cohort
                        {
                            Id = cohortIdValue,
                            Name = cohortNameValue
                        };

                        List<Exercise> bigListOExercises = listStudentExercises(firstNameValue, lastNameValue);



                        Student student = new Student
                        {
                            Id = idValue,
                            FirstName = firstNameValue,
                            LastName = lastNameValue,
                            SlackHandle = slackHandleValue,
                            CohortNumber = stuCohort,
                            CurrentExercises = bigListOExercises
                        };

                        students.Add(student);
                    }
                    reader.Close();
                    return students;
                }
                }
            }
        //HEREREERERERERE-----------------------------------------------
        public List<Exercise> listStudentExercises(string firstName, string lastName)
        {
            //ExercisesWithJavaScript() Student name spin through full list of name/Exercises and get them here somehow
            List<Student> workPlease = this.GetAllStudentsOverkill();

            List<Exercise> studentExercise = new List<Exercise>();

            workPlease.ForEach(student =>
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {

                    foreach (Exercise exercise in student.CurrentExercises)
                    {
                        studentExercise.Add(exercise);
                    }
                }
            });
            return studentExercise;
        }

        public void assignToCohort(Exercise exercise, Cohort cohort)
        {
            List<Student> studentsToAssign = this.GetAllStudents();

            List<Student> studentsByCohort = studentsToAssign.Where(student => student.CohortNumber.Id.Equals(cohort.Id)).ToList();

            List<Exercise> addNewExercise = new List<Exercise>();
            //HEERERERERERERE---------------------------------------------------
            foreach (Student student in studentsByCohort)
            {
                string fullName = $"{student.FirstName} {student.LastName}";
                Console.WriteLine($"{student.FirstName} {student.CohortNumber.Name}");
                if (student.CurrentExercises.Exists(ex => ex.Id ==exercise.Id))
                {
                    Console.WriteLine($" {fullName} has already been assigned {exercise.Name}");
                }
                else
                {
                    Console.WriteLine($" {fullName} has been assigned {exercise.Name}");
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO AssignedExercise (ExerciseId, StudentId) VALUES (@exerciseId, @studentId)";
                    cmd.Parameters.Add(new SqlParameter("@exerciseId", exercise.Id));
                    cmd.Parameters.Add(new SqlParameter("@studentId", student.Id));
                    cmd.ExecuteNonQuery();
                }
            }
                };
            };


        }
        }

    }

