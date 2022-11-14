using EmployeeManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManagement.Configurations.BaseConfigurations;

namespace EmployeeManagement.Configurations;

public class DeparmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.AddBaseEntityConfiguration();
        builder.Property(d => d.Name).IsRequired().HasMaxLength(64);

        builder
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId);

    }
}
