﻿namespace Adm.Core.BaseModels.BaseEntities;

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