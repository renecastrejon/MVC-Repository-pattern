using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyProject.Common.App_Start;
using MyProject.Common.Profiles;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(App_Init), "Init")]
namespace MyProject.Common.App_Start
{
    public class App_Init
    {
        public static void Init()
        {
             Mapper.Initialize(c => c.AddProfile<MappingProfile>());
        }
    }
}
