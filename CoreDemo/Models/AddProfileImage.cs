namespace CoreDemo.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public IFormFile Image { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
