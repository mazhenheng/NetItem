using MailKit.Net.Smtp;
using MimeKit;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// 发送有限，引用Mailkit包
    /// </summary>
    public class EmailHelper
    {
        readonly static EmailInfoConst emailInfo = ConfigHelper.Get<EmailInfoConst>(EmailInfoConst.KEY);
        public static string SendEmail(string title, string receiveNmae, string receiveEmail, TextPart body)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                //发件人
                message.From.Add(new MailboxAddress("发送方姓名", emailInfo.Username));
                //收件人
                message.To.Add(new MailboxAddress(receiveNmae, receiveEmail));
                //标题
                message.Subject = title;

                //创建Multipart添加附件
                Multipart multipart = new Multipart("mixed");
                multipart.Add(body);

                //正文
                message.Body = multipart;

                using (SmtpClient client = new SmtpClient())
                {
                    //Smtp服务器
                    client.Connect(emailInfo.SmtpServer, emailInfo.Port, true);
                    if (client.IsConnected)
                    {
                        //登录
                        client.Authenticate(emailInfo.Username, emailInfo.Password);
                        //发送
                        string result = client.Send(message);
                    }

                    //断开
                    client.Disconnect(true);
                    return "发送邮件成功";
                }
            }
            catch (Exception ex)
            {
                return "发送失败";
            }
        }
    }
}
