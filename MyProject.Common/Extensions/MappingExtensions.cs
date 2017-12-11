using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Common.Extensions;
using AutoMapper;


namespace MyProject.Common.Extensions
{
    public static class MappingExtensions
    {
        public static TDest MapTo<TDest>(this object src)
        {
            Mapper.AssertConfigurationIsValid();
            return (TDest)Mapper.Map(src, src.GetType(), typeof(TDest));
        }
    }
}
