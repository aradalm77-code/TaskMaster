using Autofac;
using System;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess;
using Autofac.Integration.Web;
using TaskMasterEntity.src.Core.Application.BaseInfo.UserManagment;

namespace TaskMasterEntity.src.WebForms
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        public static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider { get { return _containerProvider; } }
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UpdateUser>()
                   .As<IUpdateUser>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<SearchPersons>()
                   .As<ISearchPersons>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<SearchUsers>()
                   .As<ISearchUsers>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<DataBaseContext>()
                   .AsSelf()
                   .As<IDb>()
                   .InstancePerLifetimeScope();

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

            var container = builder.Build();
            _containerProvider = new ContainerProvider(container);
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