﻿using System.ComponentModel.DataAnnotations.Schema;
using Adm.Core.BaseModels.BaseEntities;

namespace Adm.Core.BaseModels.Auditing;

/// <summary>
/// A shortcut of <see cref="AuditedEntity{TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
/// </summary>
public abstract class AuditedEntity : AuditedEntity<int>, IEntity
{

}
public abstract class AuditedEntityWithName : AuditedEntity
{
    public required string Name { get; set; }
}
/// <summary>
/// This class can be used to simplify implementing <see cref="IAudited"/>.
/// </summary>
/// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
public abstract class AuditedEntity<TPrimaryKey> : CreationAuditedEntity<TPrimaryKey>, IAudited
{
    /// <summary>
    /// Last modification date of this entity.
    /// </summary>
    public virtual DateTime? LastModificationTime { get; set; }

    /// <summary>
    /// Last modifier user of this entity.
    /// </summary>
    public virtual long? LastModifierUserId { get; set; }
}

/// <summary>
/// This class can be used to simplify implementing <see cref="IAudited{TUser}"/>.
/// </summary>
/// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
/// <typeparam name="TUser">Type of the user</typeparam>
public abstract class AuditedEntity<TPrimaryKey, TUser> : AuditedEntity<TPrimaryKey>, IAudited<TUser>
    where TUser : IEntity<long>
{
    /// <summary>
    /// Reference to the creator user of this entity.
    /// </summary>
    [ForeignKey(nameof(CreatorUserId))]
    public virtual TUser CreatorUser { get; set; }

    /// <summary>
    /// Reference to the last modifier user of this entity.
    /// </summary>
    [ForeignKey(nameof(LastModifierUserId))]
    public virtual TUser LastModifierUser { get; set; }
}
