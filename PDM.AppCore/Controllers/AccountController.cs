using PDM.Models;
using PDM.IServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PDM.AppCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISysUserService _sysUserService;

        public AccountController(ISysUserService sysUser)
        {
            this._sysUserService = sysUser;
        }

        /// <summary>
        /// 登录并获取用信息
        /// </summary>
        [HttpPost,Route("Login")]
        public async Task<SysUser> Login([FromForm] SysUser model)
        {
            return await this._sysUserService.Login(model);
        }
    }
}