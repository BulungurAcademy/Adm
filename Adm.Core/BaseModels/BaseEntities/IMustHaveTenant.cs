﻿namespace Adm.Domain.Models.Base.BaseEntities;

/// <summary>
/// Implement this interface for an entity which must have TenantId.
/// </summary>
public interface IMustHaveTenant
{
    /// <summary>
    /// TenantId of this entity.
    /// </summary>
    int TenantId { get; set; }
}