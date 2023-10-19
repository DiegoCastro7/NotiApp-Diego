using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class EstadoNotificacion : BaseEntity
{
    [Required]
    public string NombreEstado { get; set; }
    public ICollection<ModuloNotificaciones> ModuloNotificaciones { get; set;}
}
