global using System.ComponentModel.DataAnnotations;

namespace Fabi.Ef.Entities;
public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } =DateTime.Now;
}
