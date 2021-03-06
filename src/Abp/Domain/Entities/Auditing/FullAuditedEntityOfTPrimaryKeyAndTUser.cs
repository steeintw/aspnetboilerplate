using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abp.Domain.Entities.Auditing
{
    /// <summary>
    /// Implements <see cref="IFullAudited{TUser}"/> to be a base class for full-audited entities.
    /// </summary>
    /// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
    /// <typeparam name="TUser">Type of the user</typeparam>
    public abstract class FullAuditedEntity<TPrimaryKey, TUser> : AuditedEntity<TPrimaryKey, TUser>, IFullAudited<TUser>
        where TUser : IEntity<long>
    {
        /// <summary>
        /// Is this entity Deleted?
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Reference to the deleter user of this entity.
        /// </summary>
        [ForeignKey("DeleterUserId")]
        public TUser DeleterUser { get; set; }

        /// <summary>
        /// Which user deleted this entity?
        /// </summary>
        public long? DeleterUserId { get; set; }

        /// <summary>
        /// Deletion time of this entity.
        /// </summary>
        public DateTime? DeletionTime { get; set; }
    }
}