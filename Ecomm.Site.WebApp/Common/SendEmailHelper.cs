using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace Ecomm.Site.WebApp.Common
{
    public class SendEmailHelper
    {
        [Import]
        public Ecomm.Core.Service.SysConfig.ISYS_CONFIGService SYS_CONFIGService { get; set; }

        private void Compose()
        {
            ////指定目录为当前执行的程序集  
            //var catalog = new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly());
            ////使用AssemblyCatalog创建组合容器  
            //var container = new CompositionContainer(catalog);
            ////调用组合部件方法  
            //container.ComposeParts(this);

            var container = System.Web.HttpContext.Current.Application["Container"] as CompositionContainer;
            if (SYS_CONFIGService == null)
            {
                SYS_CONFIGService = container.GetExportedValueOrDefault<Ecomm.Core.Service.SysConfig.ISYS_CONFIGService>();
            }
        }
        /// <summary>
        /// SMTP服务器
        /// </summary>
        public static string strSMTPServer { get { return GetConfigValueById("292CFB6B-B3F0-4B1A-8082-17ADD9BFB542"); } }
        /// <summary>
        /// 发送人邮箱
        /// </summary>
        public static string strEmailFrom { get { return GetConfigValueById("DE777B13-A660-4C23-B529-4FCC9CAA2918"); } }
        /// <summary>
        /// 发送人用户名
        /// </summary>
        public static string strEmailUserName { get { return GetConfigValueById("61B8A792-D960-4E27-892F-8E144FD6BFDC"); } }
        /// <summary>
        /// 发送人密码
        /// </summary>
        public static string strEmailPassword { get { return GetConfigValueById("F785EB64-53AB-451D-9AB1-FA762566741D"); } }
        /// <summary>
        /// 邮件抄送
        /// </summary>
        public static string strEmailCc { get { return GetConfigValueById("FA86BF9E-1863-4F4D-AFA4-1C492C5528D5"); } }
        /// <summary>
        /// 邮件密送
        /// </summary>
        public static string strEmailBcc { get { return GetConfigValueById("027FCBD5-FB88-4521-8AE2-4DB7EF38C855"); } }

        public static int EmailPort
        {
            get
            {
                string port = GetConfigValueById("8D6D4A60-2880-4D96-9D7E-96F7F1224B47");
                int p = 25;
                int.TryParse(port, out p);
                return p;
            }
        }

        public static bool EnableSsl
        {
            get
            {
                string isSSL = GetConfigValueById("B2E490B4-D61F-4B4A-A683-151D0492E0B4");
                bool p = false;
                bool.TryParse(isSSL, out p);
                return p;
            }
        }


        /// <summary>
        /// 注册模块收件人地址
        /// </summary>
        public static string Reg_EmailTo { get { return GetConfigValueById("8E08A010-1433-4C9E-B40F-DEED91DBEADD"); } }
        /// <summary>
        /// 注册模块发送主题
        /// </summary>
        public static string Reg_MailSubject { get { return GetConfigValueById("D6FE9F76-8A81-425A-B348-05C0A663A722"); } }
        /// <summary>
        /// 注册模块发送模板
        /// </summary>
        public static string Reg_TemplateFile { get { return GetConfigValueById("FB48D2CD-FC55-400A-A0CE-4FEB0808C765"); } }
        /// <summary>
        /// Sample Request email
        /// </summary>
        public static string Sample_EmailTo { get { return GetConfigValueById("17AB0794-7D34-477E-B84F-F603F251E90C"); } }

        /// <summary>
        /// 忘记密码模块收件人地址
        /// </summary>
        public static string Fw_EmailTo { get { return GetConfigValueById("5C2699B1-26EC-40C8-BCD9-4742253C88C3"); } }
        /// <summary>
        /// 忘记密码模块发送主题
        /// </summary>
        public static string Fw_MailSubject { get { return GetConfigValueById("49476AF5-F498-4D33-8B00-FF0361894156"); } }
        /// <summary>
        /// 忘记密码模块发送模板
        /// </summary>
        public static string Fw_TemplateFile { get { return GetConfigValueById("CE687456-2606-4725-A053-C61C375ECB7D"); } }



        //订单完成后发送邮件主题
        public static string Order_MailSubject { get { return GetConfigValueById("8DFD04EA-6091-4F6D-8898-852EE33C4612"); } }


        /// <summary>
        /// 反馈建议模块收件人地址
        /// </summary>
        public static string Fb_EmailTo { get { return GetConfigValueById("A0BC3675-4B04-47D4-B329-FE4F68C48F90"); } }
        /// <summary>
        /// 反馈建议模块发送主题
        /// </summary>
        public static string Fb_MailSubject { get { return GetConfigValueById("4A8C44D8-D979-42E9-8CCE-6861E3E13383"); } }
        /// <summary>
        /// 反馈建议模块发送模板
        /// </summary>
        public static string Fb_TemplateFile { get { return GetConfigValueById("D662D713-3B82-428E-A83A-8F8EB162D8ED"); } }


        /// <summary>
        /// 审核返回模板
        /// </summary>
        public static string ApproveTemplateFile { get { return GetConfigValueById("F5FFB26F-EB87-4E66-BF2D-BEC9D0DF246D"); } }

        /// <summary>
        /// Hold eorder发送人邮箱
        /// </summary>
        public static string strHoldEmailFrom { get { return GetConfigValueById("B9715065-8B41-4395-B370-1191D4459FEB"); } }
        /// <summary>
        /// Hold eorder发送人邮箱模板
        /// </summary>
        public static string strHoldTemplateFile { get { return GetConfigValueById("E167A5ED-CC00-489A-80ED-AEA59CF0F449"); } }
        /// <summary>
        /// Hold eorder发送人邮箱主题
        /// </summary>
        public static string strHoldMailSubject { get { return GetConfigValueById("3784D63A-8FC6-46ED-9BD4-62B0EE6D2127"); } }


        /// <summary>
        /// 根据ID获取Sysconfig内容值
        /// </summary>
        /// <param name="Id">configID</param>
        /// <returns></returns>
        public static string GetConfigValueById(string Id)
        {
            string result = string.Empty;
            SendEmailHelper sendEmail = new SendEmailHelper();
            sendEmail.Compose();
            object obj= sendEmail.SYS_CONFIGService.GetSysConfigContent(Id);
            if (obj != null) return obj.ToString();
            return string.Empty;
        }
        /// <summary>
        /// Sends an mail message
        /// </summary>
        /// <param name="from">Sender address</param>
        /// <param name="recepient">Recepient address</param>
        /// <param name="bcc">Bcc recepient</param>
        /// <param name="cc">Cc recepient</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        public static int Send_Email(string from, string recepient, string bcc, string cc, string subject, string body, bool isBodyHtml)
        {
            // Instantiate a new instance of MailMessage
            Int16 I = default(Int16);
            MailMessage mMailMessage = new MailMessage();

            try
            {
                // Set the sender address of the mail message
                mMailMessage.From = new MailAddress(from);
                // Set the recepient address of the mail message
                mMailMessage.To.Add(new MailAddress(recepient));

                // Check if the bcc value is nothing or an empty string
                //if ((bcc != null) & bcc != string.Empty)
                if (!string.IsNullOrEmpty(bcc.Trim()) && bcc.Contains("@"))
                {
                    // Set the Bcc address of the mail message
                    mMailMessage.Bcc.Add(new MailAddress(bcc));
                }

                // Check if the cc value is nothing or an empty value
                //if ((cc != null) & cc != string.Empty)
                if (!string.IsNullOrEmpty(cc.Trim()) && cc.Contains("@"))
                {
                    // Set the CC address of the mail message
                    mMailMessage.CC.Add(new MailAddress(cc));
                }

                // Set the subject of the mail message
                mMailMessage.Subject = subject;
                // Set the body of the mail message
                mMailMessage.Body = body;

                // Set the format of the mail message body as HTML
                mMailMessage.IsBodyHtml = isBodyHtml;
                // Set the priority of the mail message to normal
                mMailMessage.Priority = MailPriority.Normal;

                // Instantiate a new instance of SmtpClient
                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Host = strSMTPServer;

                //Credentials 
                if (!string.IsNullOrEmpty(strEmailUserName))
                {
                    mSmtpClient.Credentials = new System.Net.NetworkCredential(strEmailUserName, strEmailPassword);
                }

                // Send the mail message
                mSmtpClient.Send(mMailMessage);
                I = 0;
                mMailMessage = null;
            }
            catch (Exception ex)
            {
                Elmah.ErrorLog log = new Elmah.MemoryErrorLog();
                log.Log(new Elmah.Error(ex));

                mMailMessage = null;
                I = 9;
                //throw new ApplicationException(ex.Message);
            }

            return I;
        }

        /// <summary>
        /// Sends an mail message
        /// </summary>
        /// <param name="from">Sender address</param>
        /// <param name="recepient">Recepient address</param>
        /// <param name="bcc">Bcc recepient</param>
        /// <param name="cc">Cc recepient</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        public static int Send_Email(string from, string recepient, List<string> bcc, string cc, string subject, string body, bool isBodyHtml)
        {
            // Instantiate a new instance of MailMessage
            Int16 I = default(Int16);
            MailMessage mMailMessage = new MailMessage();

            try
            {
                // Set the sender address of the mail message
                mMailMessage.From = new MailAddress(from);
                // Set the recepient address of the mail message
                mMailMessage.To.Add(new MailAddress(recepient));

                // Check if the bcc value is nothing or an empty string
                //if ((bcc != null) & bcc != string.Empty)
                if (bcc.Count > 0)
                {
                    foreach (var bcc_email in bcc)
                    {
                        if (!string.IsNullOrEmpty(bcc_email.Trim()) && bcc_email.Contains("@"))
                        {
                            mMailMessage.Bcc.Add(new MailAddress(bcc_email));
                        }
                    }
                }

                // Check if the cc value is nothing or an empty value
                //if ((cc != null) & cc != string.Empty)
                if (!string.IsNullOrEmpty(cc.Trim()) && cc.Contains("@"))
                {
                    // Set the CC address of the mail message
                    mMailMessage.CC.Add(new MailAddress(cc));
                }

                // Set the subject of the mail message
                mMailMessage.Subject = subject;
                // Set the body of the mail message
                mMailMessage.Body = body;

                // Set the format of the mail message body as HTML
                mMailMessage.IsBodyHtml = isBodyHtml;
                // Set the priority of the mail message to normal
                mMailMessage.Priority = MailPriority.Normal;

                // Instantiate a new instance of SmtpClient
                SmtpClient mSmtpClient = new SmtpClient();
                mSmtpClient.Host = strSMTPServer;

                //here it goes!!!
                //client.Port = 25; //163等都是默认25;  //gmail 与QQ都是SSL 验证, 使用465端口
                if (EnableSsl)
                {
                    mSmtpClient.Port = EmailPort; //gmail ssl port
                    mSmtpClient.EnableSsl = EnableSsl;
                }

                //Credentials 
                if (!string.IsNullOrEmpty(strEmailUserName))
                {
                    mSmtpClient.Credentials = new System.Net.NetworkCredential(strEmailUserName, strEmailPassword);
                }

                // Send the mail message
                mSmtpClient.Send(mMailMessage);
                I = 0;
                mMailMessage = null;
            }
            catch (Exception ex) //Elmah.ApplicationException ex
            {
                Elmah.MemoryErrorLog log = new Elmah.MemoryErrorLog();
                log.Log(new Elmah.Error(ex)); //这个只是记录到Elmah 内存中

                Elmah.ErrorSignal.FromCurrentContext().Raise(ex); //这个才是手动记录;
                mMailMessage = null;
                I = 9;

            }

            return I;
        }



        /// <summary>
        /// Sends an mail message
        /// </summary>
        /// <param name="from">Sender address</param>
        /// <param name="recepient">Recepient address</param>
        /// <param name="bcc">Bcc recepient</param>
        /// <param name="cc">Cc recepient</param>
        /// <param name="subject">Subject of mail message</param>
        /// <param name="body">Body of mail message</param>
        public static int Send_Email(string from, string recepient, string cc, string subject, string body)
        {
            return Send_Email(from, recepient, string.Empty, cc, subject, body, true);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="recepient">接收人</param>
        /// <param name="body">正文</param>
        /// <param name="mailsubject">邮件标题</param>
        /// <returns></returns>
        public static int Send_Email(string recepient, string bcc, string body, string mailsubject)
        {
            return Send_Email(recepient, bcc, body, mailsubject, true);
        }
        public static int Send_Email(string recepient, string bcc, string body, string mailsubject, bool isBodyHtml)
        {
            List<string> bccs = new List<string>();
            if (!string.IsNullOrEmpty(bcc)) bccs.Add(bcc);

            if (!string.IsNullOrEmpty(strEmailBcc))
            {
                string[] str = strEmailBcc.Split(new char[] { ',', ';', ' ' });//以空格、逗号、分号分开都可以
                if (str != null && str.Length > 0)
                {
                    foreach (string item in str)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            bccs.Add(item);
                        }
                    }
                }
            }
            return Send_Email(strEmailFrom, recepient, bccs, strEmailCc, mailsubject, body, isBodyHtml);
        }
        public static int Send_Email(string recepient, string body, string mailsubject, bool isBodyHtml)
        {
            return Send_Email(recepient, string.Empty, body, mailsubject, isBodyHtml);
        }

        /// <summary>
        /// 发送Hold邮件
        /// </summary>
        /// <param name="mailTo">接收人</param>
        /// <param name="body">正文</param>
        /// <returns></returns>
        public static int Send_HoldEmail(string mailTo, string body)
        {
            return Send_Email(strHoldEmailFrom, mailTo, string.Empty, strHoldMailSubject, body);
        }

        public static void Send_QuoteEmail(string repEmailto, string repFName, string Userid, string shopperid, string sku)
        {
            //    MailMessage MailMsg = new MailMessage(new MailAddress("webmaster@snell.co.nz"), new MailAddress(repEmailto));
            //    //session("repEmail")
            //    string body = null;

            //    body = "Hi " + repFName + "," + System.Environment.NewLine;
            //    body = body + "There is a New Quote for you. Please check Quote List in Intranet!!!" + System.Environment.NewLine + System.Environment.NewLine;
            //    body = body + "Userid :" + Userid + System.Environment.NewLine + "Customer : " + shopperid + System.Environment.NewLine + "Product Code : " + sku + System.Environment.NewLine;



            //    MailMsg.Subject = "**** New Quote from Customer";
            //    //MailMsg.Body = "A real nice body text here"
            //    MailMsg.Body = body;
            //    //MailMsg.Sender = shopperid
            //    SmtpClient SmtpMail = new SmtpClient();
            //    SmtpMail.Host = "192.168.61.217";
            //    SmtpMail.Send(MailMsg);
        }

        public static int Send_EmbroideryQuoteEmail(string mailTo, string cc, string mailSubject, string body)
        {
            return Send_Email(strEmailFrom, mailTo, cc, mailSubject, body);
        }

        private static System.Timers.Timer timer;
        protected static void Send_Email_Start()
        {
            timer = new System.Timers.Timer(60000);//一分钟执行一次,单位为毫秒
            timer.Elapsed += new System.Timers.ElapsedEventHandler((s, e) => timer_Elapsed(s, e));
            timer.AutoReset = false; //只执行一次
            timer.Enabled = true; //启动定时器
        }

        protected static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //MailMessage mailmsg = new MailMessage(); //需引用using System.Net和using System.Net.Mail;
            //mailmsg.From = new MailAddress("chenflyingsky@126.com", "发件人姓名");
            //mailmsg.To.Add("1271672886@qq.com");
            //mailmsg.Subject = "邮件主题";
            //mailmsg.Body = "邮件内容";
            //mailmsg.BodyEncoding = System.Text.Encoding.UTF8;
            //mailmsg.IsBodyHtml = true;
            //SmtpClient sendmsg = new SmtpClient();
            //sendmsg.Host = "smtp.126.com";
            //sendmsg.UseDefaultCredentials = false;
            //sendmsg.Credentials = new NetworkCredential("chenflyingsky@126.com", "该邮箱密码");
            //sendmsg.DeliveryMethod = SmtpDeliveryMethod.Network;
            //sendmsg.Send(mailmsg);
            //mailmsg.Dispose();

        }

    }
}