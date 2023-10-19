using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
            CreateMap<TipoRequerimiento, TipoRequerimientoDto>().ReverseMap();
            CreateMap<Radicados, RadicadosDto>().ReverseMap();
            CreateMap<ModuloNotificaciones, ModuloNotificacionesDto>().ReverseMap();
            CreateMap<EstadoNotificacion, EstadoNotificacionDto>().ReverseMap();
            CreateMap<Formatos, FormatosDto>().ReverseMap();
            CreateMap<Auditoria, AuditoriaDto>().ReverseMap();
            CreateMap<TipoNotificaciones, TipoNotificacionesDto>().ReverseMap();
            CreateMap<HiloRespuestaNotificacion, HiloRespuestaNotificacionDto>().ReverseMap();
            CreateMap<BlockChain, BlockChainDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<RolVsMaestro, RolVsMaestroDto>().ReverseMap();
            CreateMap<ModulosMaestros, ModulosMaestrosDto>().ReverseMap();
            CreateMap<PermisosGenericos, PermisosGenericosDto>().ReverseMap();
            CreateMap<GenericosVsSubmodulos, GenericosVsSubmodulosDto>().ReverseMap();
            CreateMap<MaestrosVsSubmodulos, MaestrosVsSubmodulosDto>().ReverseMap();
            CreateMap<Submodulos, SubmodulosDto>().ReverseMap();
        }
    }
}
