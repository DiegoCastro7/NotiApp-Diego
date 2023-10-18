using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class TipoRequerimiento : BaseEntity
{
    [Required]
    public string Nombre { get; set; }
}
