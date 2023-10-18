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
}
