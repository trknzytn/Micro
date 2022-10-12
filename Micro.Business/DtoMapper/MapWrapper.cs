using AutoMapper;
using AutoMapper.Configuration;
using Micro.Model;
using Micro.Model.Dto;
using System.Diagnostics.Metrics;

namespace Micro.Business.DtoMapper
{
    public class MapWrapper
    {
        public static void Run()
        {
            SetMappings();
        }

        private static void SetMappings()
        {
            var config = new MapperConfigurationExpression();
            config.CreateMap<User, UserDto>();
            config.CreateMap<UserDto, User>();
        }
    }
}
