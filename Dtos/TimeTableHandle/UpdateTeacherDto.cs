namespace YukonTest.Dtos.TimeTableHandle
{
    public class UpdateTeacherDto
    {
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public bool Leave { get; set; }
    }
}