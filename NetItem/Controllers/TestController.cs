using Common;
using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MimeKit;
using Model.Common;

namespace NetItem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class TestController : ControllerBase
    {
        /// <summary>
        /// 雪花id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<long> TestXueHuaId()
        {
            var id = IdHelper.NextId();
            return id;
        }
        [HttpGet]
        public ActionResult<string> TestEmail()
        {

            //生成一个支持Html的TextPart
            TextPart body = new TextPart(TextFormat.Html)
            {
                Text = "<h1>测试邮件</h1> "
            };
            body.Text += $"<p> 请勿回复     </p>";
            string sendResult = EmailHelper.SendEmail( "邮箱测试", "接收人", "mazhenheng@ctgbs.cn", body);
            return sendResult;
        }
        [HttpGet]
        public ActionResult<string> TestConfig()
        {
            EmailInfoConst emailInfo = ConfigHelper.Get<EmailInfoConst>(EmailInfoConst.KEY);
            string userName = ConfigHelper.Get(EmailInfoConst.KEY, "Username");
            return userName;
        }
        
    }
}
