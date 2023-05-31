namespace TaskAPI.Models
{
    public class SubTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public Tasks Tasks { get; set; }
    }
}
