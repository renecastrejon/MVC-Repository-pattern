using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MyProject.Model;
using MyProject.Model.ViewModels;

namespace MVC_Dependency_Injection.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<User, UserViewModel>();
            //    cfg.CreateMap<UserViewModel, User>();
            //});
        }
        //TODO - Terminar de implementar ViewModels y refactorizar la inicializacion
        //
    }
}