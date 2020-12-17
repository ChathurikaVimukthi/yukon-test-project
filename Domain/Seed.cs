using System;
using System.Collections.Generic;
using System.Linq;
using YukonTest.Models;

namespace YukonTest.Domain
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Teachers.Any())
            {
                var teachers = new List<Teacher>{
                    new Teacher{TeacherID = 001,Name = "Chathu",SubjectID = 101,Leave = false},
                    new Teacher{TeacherID = 002,Name = "Kalani",SubjectID = 201,Leave = true},
                    new Teacher{TeacherID = 003,Name = "Ruvini",SubjectID = 301,Leave = false},
                    new Teacher{TeacherID = 004,Name = "Hasini",SubjectID = 401,Leave = false},
                    new Teacher{TeacherID = 005,Name = "Janaki",SubjectID = 501,Leave = false},
                    new Teacher{TeacherID = 006,Name = "Hasara",SubjectID = 604,Leave = false},
                    new Teacher{TeacherID = 007,Name = "Dilsha",SubjectID = 701,Leave = true},
                    new Teacher{TeacherID = 008,Name = "Naduni",SubjectID = 801,Leave = false}
                };
                context.Teachers.AddRange(teachers);
                context.SaveChanges();
            }

            if (!context.Absents.Any())
            {
                var absents = new List<Absent>{
                    new Absent{AbsentID = 1, TeacherID = 002, AbsentDay = Convert.ToDateTime("2020/01/15")},
                    new Absent{AbsentID = 2, TeacherID = 007, AbsentDay = Convert.ToDateTime("2020/01/17")}
                };
                context.Absents.AddRange(absents);
                context.SaveChanges();
            }

            if (!context.Subjects.Any())
            {
                var subjects = new List<Subject>{
                    new Subject{SubjectId = 101,SubjectName = "Science"},
                    new Subject{SubjectId = 201,SubjectName = "Maths"},
                    new Subject{SubjectId = 301,SubjectName = "English"},
                    new Subject{SubjectId = 401,SubjectName = "History"},
                    new Subject{SubjectId = 501,SubjectName = "Sinhala"},
                    new Subject{SubjectId = 601,SubjectName = "Art"},
                    new Subject{SubjectId = 701,SubjectName = "ICT"},
                    new Subject{SubjectId = 801,SubjectName = "Buddhism"}
            };
                context.Subjects.AddRange(subjects);
                context.SaveChanges();
            }

            if (!context.Days.Any())
            {
                var days = new List<Day>{
                    new Day{DayID = 1,DayName = Convert.ToDateTime("2020/01/15")},
                    new Day{DayID = 2,DayName = Convert.ToDateTime("2020/01/16") },
                    new Day{DayID = 3,DayName = Convert.ToDateTime("2020/01/17")},
                    new Day{DayID = 4,DayName = Convert.ToDateTime("2020/01/18")},
                    new Day{DayID = 5,DayName = Convert.ToDateTime("2020/01/19")}

            };
                context.Days.AddRange(days);
                context.SaveChanges();
            }

            if (!context.Periods.Any())
            {
                var periods = new List<Period>{
                    new Period{PeriodID = 1,PeriodName = "1st Period"},
                    new Period{PeriodID = 2,PeriodName = "2nd Period"},
                    new Period{PeriodID = 3,PeriodName = "3rd Period"},
                    new Period{PeriodID = 4,PeriodName = "4th Period"},
                    new Period{PeriodID = 5,PeriodName = "5th Period"},
                    new Period{PeriodID = 6,PeriodName = "6th Period"},
                    new Period{PeriodID = 7,PeriodName = "7th Period"},
                    new Period{PeriodID = 8,PeriodName = "8th Period"}

            };
                context.Periods.AddRange(periods);
                context.SaveChanges();
            }

            if (!context.PeriodByDays.Any())
            {
                var periodByDays = new List<PeriodByDay>{
                    new PeriodByDay{Id = 1, DayID = 1,PeriodID = 1,SubjectID = 101,TeacherID = 001},
                    new PeriodByDay{Id = 2, DayID = 1,PeriodID = 2,SubjectID = 201,TeacherID = 002},
                    new PeriodByDay{Id = 3, DayID = 1,PeriodID = 3,SubjectID = 301,TeacherID = 003},
                    new PeriodByDay{Id = 4, DayID = 1,PeriodID = 4,SubjectID = 401,TeacherID = 004},
                    new PeriodByDay{Id = 5, DayID = 1,PeriodID = 5,SubjectID = 501,TeacherID = 005},
                    new PeriodByDay{Id = 6, DayID = 1,PeriodID = 6,SubjectID = 601,TeacherID = 006},
                    new PeriodByDay{Id = 7, DayID = 1,PeriodID = 7,SubjectID = 701,TeacherID = 007},
                    new PeriodByDay{Id = 8, DayID = 1,PeriodID = 8,SubjectID = 801,TeacherID = 007},
                    new PeriodByDay{Id = 9, DayID = 2,PeriodID = 1,SubjectID = 501,TeacherID = 005},
                    new PeriodByDay{Id = 10, DayID = 2,PeriodID = 2,SubjectID = 601,TeacherID = 006},
                    new PeriodByDay{Id = 11, DayID = 2,PeriodID = 3,SubjectID = 701,TeacherID = 007},
                    new PeriodByDay{Id = 12, DayID = 2,PeriodID = 4,SubjectID = 801,TeacherID = 008},
                    new PeriodByDay{Id = 13, DayID = 2,PeriodID = 5,SubjectID = 101,TeacherID = 001},
                    new PeriodByDay{Id = 14, DayID = 2,PeriodID = 6,SubjectID = 201,TeacherID = 002},
                    new PeriodByDay{Id = 15, DayID = 2,PeriodID = 7,SubjectID = 301,TeacherID = 003},
                    new PeriodByDay{Id = 16, DayID = 2,PeriodID = 8,SubjectID = 401,TeacherID = 004}

            };
                context.PeriodByDays.AddRange(periodByDays);
                context.SaveChanges();
            }
            
        }
    }
}