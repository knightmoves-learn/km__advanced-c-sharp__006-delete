using Microsoft.AspNetCore.Mvc;

namespace HomeEnergyUsageApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomesController : ControllerBase
    {
        private static List<Home> homesList = new List<Home>();

        [HttpGet]
        public IEnumerable<Home> Get()
        {
            return homesList;
        }

        [HttpGet("{id}")]
        public Home FindById(int id)
        {
            foreach (Home home in homesList)
            {
                if (home.id == id)
                    return home;
            }
            return null;
        }

        [HttpPost]
        public Home Post([FromBody] Home home)
        {
            homesList.Add(home);
            return home;
        }

        [HttpPut("{id}")]
        public Home Put([FromBody] Home newHome, [FromRoute] int id)
        {
            for (int i = 0; i < homesList.Count; i++)
            {
                if (homesList[i].id == id)
                {
                    homesList[i] = newHome;
                    return newHome;
                }
            }
            return null;
        }

        [HttpDelete("{id}")]

        public Home Remove(int id, Home home)
        {
            for (int i = 0; i < homesList.Count; i++)
            {
                if (home.id == id)
                {
                    var deletedHome = homesList[i];
                    homesList.Remove(deletedHome);
                    return deletedHome;
                }
            }
            return null;
        }
    }
}
