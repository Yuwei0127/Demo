using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Demo.Controllers.Api
{
    [ApiExplorerSettings(GroupName = "會員")]
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public DemoController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [SwaggerOperation(Summary = "取得全部會員資訊",Description = "阿就會員")]
        [Route("/info")]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _memberService.GetAllMemberInfoAsync();

            return Ok(result);
        }

        [SwaggerOperation(Summary = "用 Id 取得特定會員資訊")]
        [Route("/info/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var result = await _memberService.GetMemberInfoAsync(id);
            
            return Ok(result);
        }
    }
}
