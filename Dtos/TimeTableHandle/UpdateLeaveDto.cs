using System;

namespace YukonTest.Dtos.TimeTableHandle
{
    public class UpdateLeaveDto
    {
        public int TeacherID{ get; set; }
        public string AbsentDate{ get; set; }
        public bool Leave{ get; set; }
    }
}