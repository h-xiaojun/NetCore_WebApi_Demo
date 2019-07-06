using PDM.Models;
using PDM.IServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public async Task<SysUser> Login([FromBody] SysUser model)
        {
            // 这里要不要改成特性验证？
            if (model.LoginId == null || model.Password == null)
                throw new Exception("用户名或密码错误!");
            return await this._sysUserService.Login(model);
        }
    }
}