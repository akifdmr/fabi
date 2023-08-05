global using System.ComponentModel.DataAnnotations;

namespace Fabi.Core.Entities;
public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } =DateTime.Now;
}
