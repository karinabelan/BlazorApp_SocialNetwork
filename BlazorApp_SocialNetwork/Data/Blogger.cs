using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_SocialNetwork.Data
{
    public class Blogger
    {
        public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string HomeTown { get; set; } = "";
        public int Follower { get; set; } = 0;
    }
}
