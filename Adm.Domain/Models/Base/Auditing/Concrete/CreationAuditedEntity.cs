﻿using System.ComponentModel.DataAnnotations.Schema;
using Adm.Domain.Models.Base.BaseEntities;
using JurnalEdu.Domain.Models.Base.BaseEntities;

namespace Adm.Domain.Models.Base.Auditing;

/// <summary>
/// A shortcut of <see cref="CreationAuditedEntity{TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
/// </summary>
public abstract class CreationAuditedEntity : CreationAuditedEntity<int>, IEntity
{

}

/// <summary>
/// This class can be used to simplify implementing <see cref="ICreationAudited"/>.
/// </summary>
/// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, ICreationAudited
{
    /// <summary>
    /// Creation time of this entity.
    /// </summary>
    public virtual DateTime CreationTime { get; set; }

    /// <summary>
    /// Creator of this entity.
    /// </summary>
    public virtual long? CreatorUserId { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    protected CreationAuditedEntity()
    {
        CreationTime = DateTime.Now;
    }
}

/// <summary>
/// This class can be used to simplify implementing <see cref="ICreationAudited{TUser}"/>.
/// </summary>
/// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
/// <typeparam name="TUser">Type of the user</typeparam>
public abstract class CreationAuditedEntity<TPrimaryKey, TUser> : CreationAuditedEntity<TPrimaryKey>, ICreationAudited<TUser>
    where TUser : IEntity<long>
{
    /// <summary>
    /// Reference to the creator user of this entity.
    /// </summary>
    [ForeignKey(nameof(CreatorUserId))]
    public virtual TUser CreatorUser { get; set; }
}