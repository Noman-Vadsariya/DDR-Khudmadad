using System.Globalization;

namespace DDR_Khudmadad.DTO
{
    public class GigOfferModel
    {
        public int clientId { get; set; }
        public int freelancerId { get; set; }
        public int gigId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string freelancerDescription { get; set; }
        public string gigDescription { get; set; }
        public string gigName { get; set; }
        public string deadline { get; set; }
        public double pay { get; set; }
        public bool status { get; set; }   
    }
}
