using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class MaestrosVsSubmodulos : BaseEntity
{
    public ModulosMaestros ModulosMaestros { get; set; }
    public int IdMaestroFk { get; set; }
    public Submodulos Submodulos { get; set; }
    public int IdSubmodulosFk { get; set; }
    public ICollection<GenericosVsSubmodulos> GenericosVsSubmodulos { get; set;}
}
