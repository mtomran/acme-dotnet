using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{   
    [Route("/api/v1/device")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        [HttpGet(Name = nameof(GetDevice))]
        public IActionResult GetDevice(){
            var response = new {
                response = Mongo.get(),
                message = "get devices successful",
                error = false
            };

            return Ok(response);
        }

        [HttpPost(Name = nameof(PostDevice))]
        public IActionResult PostDevice(){
            var response = new {
                response = new {
                    id = "test id"
                },
                message = "post devices successful"
            };

            return Ok(response);
        }
        
        [HttpPut(Name = nameof(PutDevice))]
        public IActionResult PutDevice(){
            var response = new {
                response = new {
                    id = "test id"
                },
                message = "put devices successful"
            };

            return Ok(response);
        }

        [HttpDelete(Name = nameof(DeleteDevice))]
        public IActionResult DeleteDevice(string id){
            var response = new {
                response = new {
                    id = "test id"
                },
                message = "delete device successful",
                error = false
            };
            
            Console.WriteLine("***********"+ id);
            return Ok(response);
        }
    }
}
