using System.Linq;
using AutoMapper;
using Imi.Project.Herexamen.Api.Core.DTO_S.CombatRole;
using Imi.Project.Herexamen.Api.Core.DTO_S.Map;
using Imi.Project.Herexamen.Api.Core.DTO_S.Operation;
using Imi.Project.Herexamen.Api.Core.DTO_S.User;
using Imi.Project.Herexamen.Api.Core.Models;

namespace Imi.Project.Herexamen.Api.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Map, MapResponseDTO>();
            CreateMap<MapRequestDTO, Map>();
            CreateMap<CombatRole, CombatRoleResponseDTO>();
            CreateMap<CombatRoleRequestDTO, CombatRole>();
            CreateMap<Operation, OperationResponseDTO>();
            CreateMap<OperationRequestDTO, Operation>();
            CreateMap<User, UserResponseDTO>().ForMember(dto => dto.Operations, u => u.MapFrom(u => u.Participations.Select(p => p.Operation)));
            CreateMap<UserRequestDTO, User>();
        }
    }
}