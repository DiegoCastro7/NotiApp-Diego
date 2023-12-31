using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class Submodulos : BaseEntity
{
    [Required]
    public string NombreSubmodulo { get; set; }
    public ICollection<MaestrosVsSubmodulos> MaestrosVsSubmodulos { get; set; }
}
