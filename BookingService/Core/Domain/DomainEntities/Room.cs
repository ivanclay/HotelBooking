namespace Domain.DomainEntities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }
        public bool HasGuest { 
            //verify open bookings to this room
            get { return true; } 
        }
        public bool IsAvailable
        {
            get 
            { 
                if(this.InMaintenance || this.HasGuest)
                {
                    return false;
                }
                return true;
            }
            
        }

    }
}
