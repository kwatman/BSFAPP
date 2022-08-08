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
            CreateMap<Operation, OperationResponseDTO>().ForMember(dto => dto.Participants, o => o.MapFrom(o => o.Participations.Select(p => p.User)));
            CreateMap<OperationRequestDTO, Operation>();
            CreateMap<User, UserResponseDTO>();
            CreateMap<UserRequestDTO, User>();
        }
    }
}