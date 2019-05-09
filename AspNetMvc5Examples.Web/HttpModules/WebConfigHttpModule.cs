using System;
using System.Diagnostics;
using System.Web;

namespace AspNetMvc5Examples.Web.HttpModules
{
    public class WebConfigHttpModule : IHttpModule
    {
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public WebConfigHttpModule() { }

        public void Init(HttpApplication application)
        {
            application.BeginRequest += new EventHandler(this.BeginRequest);
            application.EndRequest += new EventHandler(this.EndRequest);
            application.AcquireRequestState += new EventHandler(this.AcquireRequestState);

            // AcquireRequestState: Call this event to allow the module to acquire or create the state(for example, session) for the request.
            // AuthenticateRequest: Call this event when a security module needs to authenticate the user before it processes the request.
            // AuthorizeRequest: Call this event by a security module when the request needs to be authorized.Called after authentication.
            // BeginRequest: Call this event to notify a module that new request is beginning.
            // Disposed: Call this event to notify the module that the application is ending for some reason.Allows the module to perform internal cleanup.
            // EndRequest: Call this event to notify the module that the request is ending.
            // Error: Call this event to notify the module of an error that occurs during request processing.
            // PostRequestHandlerExecute: Call this event to notify the module that the handler has finished processing the request.
            // PreRequestHandlerExecute: Call this event to notify the module that the handler for the request is about to be called.
            // PreSendRequestContent: Call this event to notify the module that content is about to be sent to the client.
            // PreSendRequestHeaders: Call this event to notify the module that the HTTP headers are about to be sent to the client.
            // ReleaseRequestState: Call this event to allow the module to release state because the handler has finished processing the request.
            // ResolveRequestCache: Call this event after authentication. Caching modules use this event to determine if the request should be processed by its cache or if a handler should process the request.
            // UpdateRequestCache: Call this event after a response from the handler.Caching modules should update their cache with the response.
        }

        public void BeginRequest(object sender, EventArgs e)
        {
            this.WriteLog(sender);
        }

        public void EndRequest(object sender, EventArgs e)
        {
            this.WriteLog(sender);
        }

        public void AcquireRequestState(object sender, EventArgs e)
        {
            this.WriteLog(sender);
        }

        private void WriteLog(object sender)
        {
            var context = GetContext(sender);
            if (!context.Request.Path.Contains("ApplicationEvents"))
            {
                return;
            }

            var name = GetCurrentMethod();
            context.Response.Write(name + " ");
        }

        private static HttpContext GetContext(object sender)
        {
            return ((HttpApplication)sender).Context;
        }

        private static string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(2);

            return sf.GetMethod().Name;
        }
    }
}