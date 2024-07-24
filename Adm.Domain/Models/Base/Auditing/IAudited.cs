﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adm.Domain.Models.Base.BaseEntities;

namespace Adm.Domain.Models.Base.Auditing;

/// <summary>
/// This interface is implemented by entities which must be audited.
/// Related properties automatically set when saving/updating <see cref="Entity"/> objects.
/// </summary>
public interface IAudited : ICreationAudited, IModificationAudited
{

}

/// <summary>
/// Adds navigation properties to <see cref="IAudited"/> interface for user.
/// </summary>
/// <typeparam name="TUser">Type of the user</typeparam>
public interface IAudited<TUser> : IAudited, ICreationAudited<TUser>, IModificationAudited<TUser>
    where TUser : IEntity<long>
{

}