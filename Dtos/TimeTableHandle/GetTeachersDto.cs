namespace YukonTest.Dtos.TimeTableHandle
{
    public class GetTeachersDto
    {
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public bool Leave { get; set; }
    }
}