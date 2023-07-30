namespace BlogAppMVC.Dto
{
    public class BlogVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class BlogDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}