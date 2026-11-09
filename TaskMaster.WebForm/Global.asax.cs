using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess;

namespace TaskMasterEntity.src.WebForms
{
    public class Global : System.Web.HttpApplication
    {
        public static IContainer Container { get; set; }
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataBaseContext>().As<IDb>().InstancePerLifetimeScope();

            builder.RegisterType<UserDataAccess>()
                   .As<IUserDataAccess>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<CreateUser>()
                   .As<ICreateUser>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<DeleteUser>()
                   .As<IDeleteUser>()
                   .InstancePerLifetimeScope();
            builder.RegisterType<GetUsers>()
                   .As<IGetUsers>()
                   .InstancePerLifetimeScope();

            Container = builder.Build();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}