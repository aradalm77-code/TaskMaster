using System.Data.Entity.ModelConfiguration;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Persistence.MapEntity
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(u => u.Id);
            HasRequired(u => u.Person)
                .WithMany()
                .HasForeignKey(u => u.PersonId);
        }
    }
}
