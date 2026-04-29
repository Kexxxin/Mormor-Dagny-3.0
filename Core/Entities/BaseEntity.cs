using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public abstract class BaseEntity
{
    [Key]
    public string Id { get; set; } =
        Guid.NewGuid().ToString().Replace("-", "");

}
