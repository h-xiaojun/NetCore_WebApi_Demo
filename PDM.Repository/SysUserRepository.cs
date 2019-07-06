using SqlSugar;
using PDM.Models;
using PDM.IRepository;
using System.Threading.Tasks;

namespace PDM.Repository
{
    public class SysUserRepository : BaseRepository<SysUser>, ISysUserRepository
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public async Task<SysUser> Login(SysUser model)
        {
            SugarParameter success = new SugarParameter("@Success", null, true);
            SugarParameter[] pars = new SugarParameter[] {
                new SugarParameter("@LoginId",model.LoginId),
                new SugarParameter("@Password",model.Password),
                success
            };
            Db.Ado.UseStoredProcedure().ExecuteCommand("UserLoginCheckVersionForAPI", pars);
            if (success.Value.ObjToInt() == 1)
            {
                //查询
               return await Db.Queryable<SysUser>().Where(
                   m => m.LoginId.Equals(model.LoginId)
                   //这里 是固定的值
                   && "C1358FD4-9937-4B4A-AD8A-02172737A804".Equals(m.CompanyId)
                ).FirstAsync();
            }
            return null;
        }
    }
}
