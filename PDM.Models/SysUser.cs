namespace PDM.Models
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class SysUser
    {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string EmplId { get; set; }
        public string EmplName { get; set; }
        public string PasswordExpDate { get; set; }
        public string LastLoginOn { get; set; }
        public short LastAppVersionMajor { get; set; }
        public short LastAppVersionMinor { get; set; }
        public short LastAppVersionBuild { get; set; }
        public short LastAppVersionRevision { get; set; }
        public string LastVersion { get; set; }
        public string LastLanguage { get; set; }
        public string Email { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public bool IsSuspend { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string LastUpdBy { get; set; }
        public string LastUpdOn { get; set; }
        public string DeletedBy { get; set; }
        public string DeletedOn { get; set; }
        public bool IsPrintFromLocal { get; set; }
    }
}
