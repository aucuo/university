namespace server
{
    public class ClientFeedback
    {
        public int FeedbackID { get; set; }
        public int ProjectID { get; set; }
        public int ClientID { get; set; }
        public DateTime? Date { get; set; }
        public string? Text { get; set; }
        public Client? Client { get; set; }
    }
}
