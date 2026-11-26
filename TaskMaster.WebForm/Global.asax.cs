using Autofac;
using Autofac.Integration.Web;
using System;
using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Application.Interfaces;
using TaskMaster.Persistence.DataAccess;
using TaskMaster.Persistence.DataBaseContext;
using TaskMaster.Persistence.Hash;

namespace TaskMaster.WebForm
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        public static IContainerProvider _containerProvider;
        public IContainerProvider ContainerProvider { get { return _containerProvider; } }
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HashPassword>()
                   .As<IHashPassword>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<LoginUser>()
                   .As<ILoginUser>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<PersonDataAccess>()
                    .As<IPersonDataAccess>()
                    .InstancePerLifetimeScope();

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