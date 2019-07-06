using PDM.Models;
using PDM.IServices;
using PDM.IRepository;
using System.Threading.Tasks;

namespace PDM.Services
{
    public class SysUserService : BaseServices<SysUser>, ISysUserService
    {
        ISysUserRepository _dal;
        public SysUserService(ISysUserRepository repository)
        {
            this._dal = repository;
            base.baseDal = repository;
        }
        /// <summary>
        /// 登录
        /// </summary>
        public async Task<SysUser> Login(SysUser model)
        {
            return await this._dal.Login(model);
        }
    }
}
