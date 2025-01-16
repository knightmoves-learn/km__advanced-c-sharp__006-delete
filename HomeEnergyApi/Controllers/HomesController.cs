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

        //start
        [HttpDelete("{id}")]
        public Home Delete(int id)
        {
            Home homeToDelete = null;

            foreach(Home home in homesList)
            {
                if(home.id == id)
                    homeToDelete = home;
            }

            if (homeToDelete != null)
            {
                homesList.Remove(homeToDelete);
                return homeToDelete;
            }
            else
            {
                return null;
            }
        }
        //end
    }
}
