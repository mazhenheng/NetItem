namespace Model.Common
{
    /// <summary>
    /// 邮箱信息
    /// </summary>
    public class EmailInfoConst
    {
        public const string KEY = "Email";

        /// <summary>
        /// SMTP服务器地址
        /// </summary>
        public string SmtpServer { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码、授权码
        /// </summary>
        public string Password { get; set; }
    }
}