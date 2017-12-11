using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyProject.Model.ViewModels;
using MyProject.DAL.EntityModels.DataSources.SQLSERVER;
using MyProject.Model;

namespace MyProject.Common.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            CreateMap<tbl_User, User>()
                .ForMember(dest => dest.FirstName,
                    opts => opts.MapFrom(src => src.usr_FirstName))
                .ForMember(dest => dest.Age,
                    opts => opts.MapFrom(src => src.usr_YrsOld))
                .ForMember(dest => dest.Email,
                    opts => opts.MapFrom(src => src.usr_Email))
                .ForMember(dest => dest.ID,
                    opts => opts.MapFrom(src => src.idUser))
                .ForMember(dest => dest.LastName,
                    opts => opts.MapFrom(src => src.usr_LastName))
                .ForMember(dest => dest.UserName,
                    opts => opts.MapFrom(src => src.usr_name))
                .ForMember(dest => dest.Gender,
                    opts => opts.MapFrom(src => src.usr_gender))
                .ForMember(dest => dest.IsActive,
                    opts => opts.MapFrom(src => src.usr_Active))
                .ForMember(dest => dest.Title,
                    opts => opts.MapFrom(src => src.usr_Title))
                .ForMember(dest => dest.Approbation,
                    opts => opts.MapFrom(src => src.usr_Approbation))
                .ForMember(dest => dest.TagInit,
                    opts => opts.MapFrom(src => src.usr_TagInit))
                .ForMember(dest => dest.idWorkShift,
                    opts => opts.MapFrom(src => src.idwrkShift))
                .ForMember(dest => dest.idWorkArea,
                    opts => opts.MapFrom(src => src.idwrkArea))
                .ForMember(dest => dest.Password,
                    opts => opts.MapFrom(src => src.usr_Pass))
                .ForMember(dest => dest.IsConnected,
                    opts => opts.MapFrom(src => src.usr_IsConnected))
                .ForMember(dest => dest.LastLoginDevice,
                    opts => opts.Ignore())
                .ForMember(dest => dest.NewAreaName,
                    opts => opts.Ignore())
                .ForMember(dest => dest.NewWorkShiftName,
                    opts => opts.Ignore())
                .ForMember(dest => dest.NewWorkShiftStartTime,
                    opts => opts.Ignore())
                .ForMember(dest => dest.NewWorkshiftEndTime,
                    opts => opts.Ignore())
                .ForMember(dest => dest.ERROR,
                    opts => opts.Ignore());

            CreateMap<User, UserViewModel>()
            .ForMember(dest => dest.FirstName,
                opts => opts.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.Age,
                opts => opts.MapFrom(src => src.Age))
            .ForMember(dest => dest.Email,
                opts => opts.MapFrom(src => src.Email))
            .ForMember(dest => dest.ID,
                opts => opts.MapFrom(src => src.ID));
            //CreateMap<UserViewModel, User>();
        }
    }
}
