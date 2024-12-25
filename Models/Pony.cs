using System.Text.Json.Serialization;

namespace Api_One_Trick_Pony_Br.Models
{
    public class Pony : Account
    {
        public int Id { get; set; }
        //public string Nick { get; set; } This is already in Account
        public int IconID { get; set; } 
        public string Bio { get; set; }
        public int Karma { get; set; }
        public string Champion { get; set; }
        public string Elo { get; set; }
        public int Pdl { get; set; }

        //[JsonIgnore]
        //public List<Account> Accounts { get; set; }

        //[JsonIgnore]
        //public List<SocialMedia> SocialMedias { get; set; }

        [JsonIgnore]
        public List<Comment> Comments { get; set; }
    }
}
