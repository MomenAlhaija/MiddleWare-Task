namespace APIEx2.DTO
{
    public class AuthonticationResponse
    {
        public string? PersonName { get; set; }=string.Empty;
        public string? Email { get; set; }
        public string? Token { get; set;}

        public DateTime? Expiration { get; set;}
    }
}
