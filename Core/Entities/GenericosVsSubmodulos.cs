using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class GenericosVsSubmodulos : BaseEntity
{
    public PermisosGenericos PermisosGenericos { get; set;}
    public int IdGenericosFk { get; set; }
    public MaestrosVsSubmodulos MaestrosVsSubmodulos { get; set; }
    public int IdSubmodulosFk { get; set; }
    public Rol Roles { get; set; }
    public int IdRolFk { get; set; }
}
