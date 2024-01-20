namespace APIMovies2.Model
{
    public class RegisterModel
    {
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]

        public string LastName { get; set; }
        [StringLength(100)]

        public string UserName { get; set; }
        [StringLength(265)]
        public string Password { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
    }
}
