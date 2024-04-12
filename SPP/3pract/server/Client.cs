namespace server
{
    public class Client
    {
        public int ClientID { get; set; }
        public string? Name { get; set; }
        public string? Industry { get; set; }
        public string? ContactPerson { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public ICollection<ClientFeedback>? ClientFeedback { get; set; }
    }
}
