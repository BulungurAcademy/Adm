﻿namespace Adm.Domain.Models.Base.BaseEntities;

/// <summary>
/// Implement this interface for an entity which may optionally have TenantId.
/// </summary>
public interface IMayHaveTenant
{
    /// <summary>
    /// TenantId of this entity.
    /// </summary>
    int? TenantId { get; set; }
}