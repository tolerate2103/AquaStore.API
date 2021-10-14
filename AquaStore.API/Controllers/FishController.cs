using AquaStore.API.Models;
using AquaStore.API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquaStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishController : ControllerBase
    {
        // I'm Using PostMan to test my post and get data into this API 

        [Route("Post")]
        [HttpPost]
        public IActionResult Post(FishModel item)
        {
            var vm = new FishVm();

            if (item != null)
                vm.Item = item;

            vm.Post(item.FishId);

            return new JsonResult(vm);
        }


        [Route("Get")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var vm = new FishVm();
            vm.Get(id);

            return new JsonResult(vm);
        }

    }
}
