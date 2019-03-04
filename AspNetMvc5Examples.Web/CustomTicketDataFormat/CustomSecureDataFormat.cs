using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AspNetMvc5Examples.Web.CustomTicketDataFormat
{
    public class CustomSecureDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public string Protect(AuthenticationTicket data)
        {
            var serializedObject = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            byte[] bytes = Encoding.ASCII.GetBytes(serializedObject);
            return this.Encode(bytes);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            var decodedBytes = this.Decode(protectedText);
            string decodedText = Encoding.ASCII.GetString(decodedBytes);
            return JsonConvert.DeserializeObject<AuthenticationTicket>(decodedText);
        }

        private string Encode(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        private byte[] Decode(string text)
        {
            return Convert.FromBase64String(text);
        }
    }
}