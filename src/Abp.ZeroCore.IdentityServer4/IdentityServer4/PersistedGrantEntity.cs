using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SqlSugar;

namespace Abp.IdentityServer4
{
    [SugarTable("AbpPersistedGrants")]
    public class PersistedGrantEntity : Entity<string>
    {
        [SugarColumn(IsPrimaryKey = true)]
        public virtual string Id { get; set; }
        public virtual string Type { get; set; }

        public virtual string SubjectId { get; set; }

        public virtual string ClientId { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual DateTime? Expiration { get; set; }

        public virtual string Data { get; set; }
    }
}