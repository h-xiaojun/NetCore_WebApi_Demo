using PDM.Models;
using System.Threading.Tasks;

namespace PDM.IRepository
{
    /// <summary>
    /// 用户 仓储
    /// </summary>
    public interface ISysUserRepository:IBaseRepository<SysUser>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model">用户名和密码都用这个模型封装</param>
        /// <returns></returns>
        Task<SysUser> Login(SysUser model);
    }
}
