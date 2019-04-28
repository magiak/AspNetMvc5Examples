namespace AspNetMvc5Examples.Entities.IdentityManagers.IdentityMessageService
{
    using System.Configuration;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);

            // TODO await configSendGridAsync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        //private async Task configSendGridAsync( IdentityMessage message )
        //{
            //var myMessage = new SendGridMessage( );
            //myMessage.AddTo( message.Destination );
            //myMessage.From = new EmailAddress(
            //                    "Joe@contoso.com", "Joe S." );
            //myMessage.Subject = message.Subject;
            //myMessage. = message.Body;
            //myMessage.Html = message.Body;

            //var credentials = new NetworkCredential(
            //           ConfigurationManager.AppSettings["mailAccount"],
            //           ConfigurationManager.AppSettings["mailPassword"]
            //           );

            //// Create a Web transport for sending email.
            //var transportWeb = new Web( credentials );

            //// Send the email.
            //if ( transportWeb != null )
            //{
            //    await transportWeb.DeliverAsync( myMessage );
            //}
            //else
            //{
            //    Trace.TraceError( "Failed to create Web transport." );
            //    await Task.FromResult( 0 );
            //}
        //}
    }

}
