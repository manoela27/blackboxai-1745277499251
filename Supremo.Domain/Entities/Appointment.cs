namespace Supremo.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
