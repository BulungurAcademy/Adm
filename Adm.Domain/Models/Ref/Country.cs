using Adm.Core.BaseModels.Auditing;

namespace Adm.Domain.Models.Ref;

public class Country : AuditedEntity, IAudited
{
    public required string Name { get; set; }
}
