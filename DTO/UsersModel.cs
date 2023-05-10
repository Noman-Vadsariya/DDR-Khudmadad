namespace DDR_Khudmadad.DTO
{
    public class UsersModel
    {
        public int userId { get; set; }
        public int roleId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dob { get; set; }
        public string? description { get; set; } = null;
        public string phoneNumber { get; set; }

    }
}
