using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class ModuloNotificaciones : BaseEntity
{
    [Required]
    public string AsuntoNotificacion { get; set; }
    [Required]
    public string TextoNotificacion { get; set; }
    public TipoNotificaciones TipoNotificaciones { get; set; }
    public int IdTipoNotificacionFk { get; set; }
    public Radicados Radicados { get; set; }
    public int IdRadicadoFk { get; set; }
    public EstadoNotificacion EstadoNotificaciones { get; set; }
    public int IdEstadoNotificacionFk { get; set; }
    public HiloRespuestaNotificacion HiloRespuestaNtfs { get; set; }
    public int IdHiloRespuestaFk { get; set; }
    public Formatos Formatos { get; set; }
    public int IdFormatoFk { get; set; }
    public TipoRequerimiento TipoRequerimientos { get; set; }
    public int IdRequerimientoFk { get; set; }
}
