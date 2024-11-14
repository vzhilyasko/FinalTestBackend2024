namespace BuildingMonitoringSystem.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

       public ICollection<Building> Buildings { get; set; }

       public ICollection<Sensor> Sensors { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is User))
                return false;

            var user = (User)obj;

            return user.Login == Login
                   && user.Password == Password
                   && user.FIO == FIO;
        }

        public static bool operator ==(User first, User second)
        {
            var equals = first.Equals(second);
            return equals;
        }

        public static bool operator !=(User first, User second)
        {
            var equals = !first.Equals(second);
            return equals;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Login + Password + FIO + PhoneNumber + Email);
        }
    }
}
