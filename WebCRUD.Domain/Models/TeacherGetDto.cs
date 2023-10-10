namespace WebCRUD.Domain.Models
{
    public class TeacherGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> Studentids { get; set; }
    }
}
