namespace TP_OH_6_15_2020_Prototype.Models
{
    internal class UserModel
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int credits { get; set; }
        public bool isAdmin { get; set; }
    }
}