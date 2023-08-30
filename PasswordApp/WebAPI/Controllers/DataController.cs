using BL.Interfaces;
using BL.Models;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataMethods methods;

        public DataController(IDataMethods _methods)
        {
            methods = _methods;
        }

        [HttpGet("getUsersData"), Authorize]
        public async Task<IActionResult> GetDataByUserNameAsync()
        {
            string userName = GetUserNameFromClaim();
                
            if(userName != null)
            {
                return Ok(await methods.GetAllUserDataByNameAsync(userName));
            }

            return BadRequest();
        }

        [HttpPost("setNewDataToUser"), Authorize]
        public async Task<IActionResult> SetNewDataAsync(DataDto data)
        {
            string userName = GetUserNameFromClaim();
            await methods.SetNewData(data, userName);
            return Ok();
        }

        [HttpPost("deleteDataByUserName"), Authorize]
        public async Task<IActionResult> DeleteDataByNameAsync(string dataName)
        {
            string userName = GetUserNameFromClaim();
            await methods.DeleteDataByNameAsync(dataName, userName);
            return Ok();
        }

        [HttpPost("updateDataByUserName"), Authorize]
        public async Task<IActionResult> UpdateDataByNameAsync(string dataName, DataDto newData)
        {
            string userName = GetUserNameFromClaim();
            await methods.UpdateDataByName(userName, dataName, newData);
            return Ok();
        }

        [HttpPost("getDataByName"), Authorize]
        public async Task<IActionResult> GetDataByNameAsync(string dataName)
        {
            string userName = GetUserNameFromClaim();
            return Ok(await methods.GetDataByNameAsync(userName, dataName));
        }

        private string GetUserNameFromClaim()
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var claims = claimsIdentity.Claims;
            return claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        }
    }
}
