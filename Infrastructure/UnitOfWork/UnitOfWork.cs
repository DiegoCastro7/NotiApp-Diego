using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnityOfWork;

public class UnityOfWork : IUnityOfWork, IDisposable
{
    private readonly NotiAppContext _context;
    private AuditoriaRepository _auditorias;
    private BlockChainRepository _blockchains;
    private EstadoNotificacionRepository _estadosnotificaciones;
    private FormatosRepository _formatos;
    private GenericosVsSubmodulosRepository _genericosvssubmodulos;
    private HiloRespuestaNotificacionRepository _hilorespuestasnotificaciones;
    private MaestrosVsSubmodulosRepository _maestrosvssubmodulos;
    private ModuloNotificacionesRepository _modulosnotificaciones;
    private ModulosMaestrosRepository _modulosmaestros;
    private PermisosGenericosRepository _permisosgenericos;
    private RadicadosRepository _radicados;
    private RolRepository _roles;
    private RolVsMaestroRepository _rolvsmaestros;
    private SubModulosRepository _submodulos;
    private TipoNotificacionesRepository _tiposnotificaciones;
    private TipoRequerimientoRepository _tiposrequerimientos;

    public IAuditoriaRepository Auditorias
    {
        get
        {
            if (_auditorias == null)
            {
                _auditorias = new AuditoriaRepository(_context);
            }
            return _auditorias;
        }
    }

    public IBlockChainRepository Blockchains
    {
        get
        {
            if (_blockchains == null)
            {
                _blockchains = new BlockChainRepository(_context);
            }
            return _blockchains;
        }
    }

    public IEstadoNotificacionRepository EstadosNotificaciones
    {
        get
        {
            if (_estadosnotificaciones == null)
            {
                _estadosnotificaciones = new EstadoNotificacionRepository(_context);
            }
            return _estadosnotificaciones;
        }
    }

    public IFormatosRepository Formatos
    {
        get
        {
            if (_formatos == null)
            {
                _formatos = new FormatosRepository(_context);
            }
            return _formatos;
        }
    }

    public IGenericosVsSubmodulosRepository GenericosVsSubmodulos
    {
        get
        {
            if (_genericosvssubmodulos == null)
            {
                _genericosvssubmodulos = new GenericosVsSubmodulosRepository(_context);
            }
            return (IGenericosVsSubmodulosRepository)_genericosvssubmodulos;
        }
    }

    public IHiloRespuestaNotificacionRepository HiloRespuestasNotificaciones
    {
        get
        {
            if (_hilorespuestasnotificaciones == null)
            {
                _hilorespuestasnotificaciones = new HiloRespuestaNotificacionRepository(_context);
            }
            return _hilorespuestasnotificaciones;
        }
    }

    public IMaestrosVsSubmodulosRepository MaestrosVsSubmodulos
    {
        get
        {
            if (_maestrosvssubmodulos == null)
            {
                _maestrosvssubmodulos = new MaestrosVsSubmodulosRepository(_context);
            }
            return (IMaestrosVsSubmodulosRepository)_maestrosvssubmodulos;
        }
    }

    public IModuloNotificacionesRepository ModulosNotificaciones
    {
        get
        {
            if (_modulosnotificaciones == null)
            {
                _modulosnotificaciones = new ModuloNotificacionesRepository(_context);
            }
            return _modulosnotificaciones;
        }
    }

    public IModulosMaestrosRepository ModulosMaestros
    {
        get
        {
            if (_modulosmaestros == null)
            {
                _modulosmaestros = new ModulosMaestrosRepository(_context);
            }
            return _modulosmaestros;
        }
    }
    public IPermisosGenericosRepository PermisosGenericos
    {
        get
        {
            if (_permisosgenericos == null)
            {
                _permisosgenericos = new PermisosGenericosRepository(_context);
            }
            return _permisosgenericos;
        }
    }

    public IRadicadosRepository Radicados
    {
        get
        {
            if (_radicados == null)
            {
                _radicados = new RadicadosRepository(_context);
            }
            return _radicados;
        }
    }

    public IRolRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IRolVsMaestroRepository RolVsMaestros
    {
        get
        {
            if (_rolvsmaestros == null)
            {
                _rolvsmaestros = new RolVsMaestroRepository(_context);
            }
            return _rolvsmaestros;
        }
    }

    public ISubmodulosRepository Submodulos
    {
        get
        {
            if (_submodulos == null)
            {
                _submodulos = new SubModulosRepository(_context);
            }
            return (ISubmodulosRepository)_submodulos;
        }
    }

    public ITipoNotificacionesRepository TiposNotificaciones
    {
        get
        {
            if (_tiposnotificaciones == null)
            {
                _tiposnotificaciones = new TipoNotificacionesRepository(_context);
            }
            return _tiposnotificaciones;
        }
    }

    public ITipoRequerimientoRepository TiposRequerimientos
    {
        get
        {
            if (_tiposrequerimientos == null)
            {
                _tiposrequerimientos = new TipoRequerimientoRepository(_context);
            }
            return (ITipoRequerimientoRepository)_tiposrequerimientos;
        }
    }
    public UnityOfWork(NotiAppContext context)
    {
        _context = context;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}