using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class ModulosMaestros : BaseEntity
{
    [Required]
    public string NombreModulo { get; set; }
    public ICollection<RolVsMaestro> RolVsMaestros { get; set; }
    public ICollection<MaestrosVsSubmodulos> MaestrosVsSubmodulos { get; set; }
}
