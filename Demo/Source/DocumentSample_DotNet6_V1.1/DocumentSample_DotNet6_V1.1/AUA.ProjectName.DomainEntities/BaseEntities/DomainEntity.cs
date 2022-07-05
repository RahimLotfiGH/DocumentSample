namespace AUA.ProjectName.DomainEntities.BaseEntities
{

    public class DomainEntity<TPrimaryKey> : BaseDomainEntity<TPrimaryKey>, IAuditInfo, ICreationAudited, IDeletionAudited
    {
        public DateTime RegistrationDate { get; set; }

        public long? CreatorUserId { get; set; }

        public long? DeleterUserId { get; set; }

        public DateTime? DeletionDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}