﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tours_DB_First.Startup))]
namespace Tours_DB_First
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
