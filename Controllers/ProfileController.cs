using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineCVAPI.BusinessLayer.Interfaces;
using OnlineCVAPI.Models;

namespace OnlineCVAPI.Controllers
{
    [Route("api/[controller]")]
    public class Profileontroller : Controller
    {
        private IPersonalProfileService _profileservice;
        public Profileontroller(IPersonalProfileService profileservice)
        {
            _profileservice=profileservice;
        }
        // GET api/values
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // // GET api/values/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]PersonalProfile profile)
        {
            try{
            int id = _profileservice.SavePersonalPrfile(profile);
            if(id==-1)
                return StatusCode(500,"An error ocuured in creating profile profile");
            return Ok(id);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.ToString());
            }
        }

        // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody]string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
