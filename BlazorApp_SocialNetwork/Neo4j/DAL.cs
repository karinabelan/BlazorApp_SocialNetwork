using Neo4jClient;
using Neo4jClient.Cypher;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_SocialNetwork.Neo4j
{
    public class Person
    {
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }
    }
    public class PostNeo4j
    {
        [JsonProperty(PropertyName = "postId")]
        public string PostId { get; set; }
    }
    public class DAL
    {
        public GraphClient client;
        public DAL()
        {
            client = new GraphClient(new Uri("http://localhost:7474/db/data/"), "Belan", "1111");
            client.ConnectAsync();
        }
        public void Create(string userId, string postId)
        {
            client.Cypher
              .Match("(user:Person {userId: {userId}})", "(post:PostNeo4j {postId: {postId}})")
              .WithParam("userId", userId)
              .WithParam("postId", postId)
              .Create("(user)-[:Like]->(post)")
              .ExecuteWithoutResultsAsync();
        }

        public int PathLengthInOneDirection(string userId, string postId)
        {
            try
            {
                var path = client.Cypher
           .Match("(user:Person {userId:{userId}} )",
                  "(post:PostNeo4j { postId:{postId}})",
                  "p = shortestPath((user) -[:Like *]->(post))")
           .WithParam("userId", userId)
           .WithParam("postId", postId)
           .Return(p => Return.As<int>("length(p)"))
           .ResultsAsync;
                int p = Convert.ToInt32(path.Result);
                return p;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void Delete(string userId, string postId)
        {

            client.Cypher
            .Match("(user:Person{userId:{userId}})-[l:Like]->(post:PostNeo4j{postId:{postId}})")
            .WithParam("userId", userId)
            .WithParam("postId", postId)
            .Delete("l")
            .ExecuteWithoutResultsAsync();
        }
    }
}
