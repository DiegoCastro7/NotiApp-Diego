using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class TipoNotificaciones : BaseEntity
{
    [Required]
    public string NombreTipo { get; set; }
    public ICollection<BlockChain> BlockChains { get; set; }
    public ICollection<ModuloNotificaciones> ModuloNotificaciones { get; set; }
}
