using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public DemoController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [Route("/info")]
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _memberService.GetMemberInfoAsync();

            return Ok(result);
        }
        
        
    }
}
