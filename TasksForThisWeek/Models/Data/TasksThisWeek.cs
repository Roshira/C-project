namespace TasksForThisWeek.Models.Data
{
    public enum DaysOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public class TasksThisWeek
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DaysOfWeek Day { get; set; } 
    }
}
