namespace Core.Entiies.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }  
        public string Zipcode { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; } =  null!;
    }
}