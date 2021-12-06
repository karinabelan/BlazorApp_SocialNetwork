using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_SocialNetwork.Neo4j
{
    public class ServiceNeo4j
    {
        DAL graph;
        public ServiceNeo4j()
        {
            graph = new DAL();
        }
        public void LikeUserPostGraph(string userId, string postId)
        {
            graph.Create(userId, postId);
        }
        public void UnLikeUserPostGraph(string userId, string postId)
        {
            graph.Delete(userId, postId);
        }
        public int GetPathLength(string userId, string postId)
        {
            return (graph.PathLengthInOneDirection(userId, postId));
        }
    }
}
