using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces;

public interface IUnityOfWork
{

    IAuditoriaRepository Auditorias { get; }
    IBlockChainRepository Blockchains { get; }
    IEstadoNotificacionRepository EstadosNotificaciones { get; }
    IFormatosRepository Formatos { get; }
    IGenericosVsSubmodulosRepository GenericosVsSubmodulos { get; }
    IHiloRespuestaNotificacionRepository HiloRespuestasNotificaciones { get; }
    IMaestrosVsSubmodulosRepository MaestrosVsSubmodulos { get; }
    IModuloNotificacionesRepository ModulosNotificaciones { get; }
    IModulosMaestrosRepository ModulosMaestros { get; }
    IPermisosGenericosRepository PermisosGenericos { get; }
    IRadicadosRepository Radicados { get; }
    IRolRepository Roles { get; }
    IRolVsMaestroRepository RolVsMaestros { get; }
    ISubmodulosRepository Submodulos { get; }
    ITipoNotificacionesRepository TiposNotificaciones { get; }
    ITipoRequerimientoRepository TiposRequerimientos { get; }
    Task<int> SaveAsync();
}
