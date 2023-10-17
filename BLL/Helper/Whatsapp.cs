using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace BLL.Helper
{
    public class Whatsapp
    {
        public static void SendMessage(string body,string phone)
        {
            var accountSid = "ACf7f9bda7100be077cc03d1f1a3695161";
            var authToken = "bafb228a59e6bcc9d15f03e3e825a9fd";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber("whatsapp:+201280369080"));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = body;


            var message = MessageResource.Create(messageOptions);
            
        }
    }
}
