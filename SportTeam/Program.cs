using SportTeam.DataAccess;
using SportTeam.Services;
using System;

namespace SportTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=A-305-11;Database=SportTeam;Trusted_Connection=true;";
            using(var context = new TeamContext(connectionString))
            {
                var searchService = new SearchService(context);
                searchService.ShowAllPlayers();
            }
        }
    }
}
