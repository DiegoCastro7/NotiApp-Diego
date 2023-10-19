using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class RolVsMaestro : BaseEntity
{
    public Rol Roles { get; set; }
    public int IdRolFk { get; set; }
    public ModulosMaestros ModulosMaestros { get; set; }
    public int IdMaestroFk { get; set; }
}
