namespace LoginAPI.Models
{
    public class Students
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Emial { get; set; }
        public string Phone { get; set; }
        public bool Subscribed { get; set; }
    }
}
