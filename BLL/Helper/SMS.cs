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
    public class SMS
    {
        public static void sendSMS(string phone,string body)
        {
            var accountSid = "AC388e9ce41da2f5c799be2a1cdb7a1572";
            var authToken = "b2f71e19d4a720d00b50c354e9ece347";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
              new PhoneNumber("+201280369080"));
            messageOptions.From = new PhoneNumber("+19738132115");
            messageOptions.Body = body;


            var message = MessageResource.Create(messageOptions);
            //Console.WriteLine(message.Body);
        }
    }
}
