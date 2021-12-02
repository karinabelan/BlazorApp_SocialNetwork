using BlazorApp_SocialNetwork.Data;
using BlazorApp_SocialNetwork.IService;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_SocialNetwork.Service
{
    public class ServiceBlogger : IServiceObj<Blogger>
    {
        private MongoClient _mongoClient = null;
        private IMongoCollection<Blogger> _actorTable = null;
        private IMongoDatabase _database = null;

        public ServiceBlogger()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017/");
            _database = _mongoClient.GetDatabase("SocialNetwork");
            _actorTable = _database.GetCollection<Blogger>("bloggres");
        }

        public string Delete(string userId)
        {
            _actorTable.DeleteOne(x => x.Id == userId);
            return "Succsesfull deleted!";
        }

        public Blogger GetUser(string userId)
        {
            return _actorTable.Find(x => x.Id == userId).FirstOrDefault();
        }

        public List<Blogger> GetUsers()
        {
            return _actorTable.Find(FilterDefinition<Blogger>.Empty).ToList();
        }


        public void SaveOrUpdate(Blogger actor)
        {
            var userObj = _actorTable.Find(x => x.Id == actor.Id).FirstOrDefault();
            if (userObj == null)
            {
                _actorTable.InsertOne(actor);
            }
            else
            {
                _actorTable.ReplaceOne(x => x.Id == actor.Id, actor);
            }
        }
    }
}
