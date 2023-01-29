namespace lab_Day1_MVC.Models
{
    public class GuestData
    {
        public static List<Guest> guests = new List<Guest>()
        {
            new Guest{name="Ahmed",email="ahmed@gmail.com",phone="0123456789",willAttend="True"},
            new Guest{name="Mohamed",email="mohamed@gmail.com",phone="01457666645",willAttend="True"},
            new Guest{name="Ebrahim",email="ebrahim@gmail.com",phone="044445555",willAttend="True"}
        };
        public static List<Guest> getAll() => guests.ToList();
        public static void AddGuest(Guest guest)
        {
            guests.Add(guest);
        }
    }
}
