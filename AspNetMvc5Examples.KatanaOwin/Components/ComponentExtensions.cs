namespace AspNetMvc5Examples.KatanaOwin.Components
{
    using System;
    using Owin;

    public static class ComponentExtensions
    {
        public static IAppBuilder UseMyWelcomePage(this IAppBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.Use(typeof(MyWelcomePageComponent));
        }
    }
}
