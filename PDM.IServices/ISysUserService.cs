using PDM.Models;
using System.Threading.Tasks;

namespace PDM.IServices
{
    /// <summary>
    /// 用户服务
    /// </summary>
    public interface ISysUserService : IBaseServices<SysUser>
    {
        /// <summary>
        /// 登录
        /// </summary>
        Task<SysUser> Login(SysUser model);
    }
}
