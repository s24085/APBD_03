namespace LegacyApp
{
    public class Client
    {
        public string Name { get; init; }
        public int ClientId { get; init; }
        public string Email { get; init; }
        public string Address { get; internal set; }
        public string Type { get; init; }
    }
}