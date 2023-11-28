using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.Models;

namespace UserProjectTosend.Domain.ModelsConfig;

public class UserProfileConfig:IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("UserProfile");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasColumnType("Nvarchar(50)").IsRequired();
        builder.Property(x => x.LastName).HasColumnType("Nvarchar(50)").IsRequired();
        builder.Property(x => x.personalNumber).HasColumnType("Nvarchar(11)").IsRequired();
    }
}
