using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.Models;

namespace UserProjectTosend.Domain.ModelsConfig;

public class UserConfig:IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasOne<UserProfile>();
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.userName).HasColumnType("Nvarchar(50)").IsRequired();
        builder.Property(x => x.password).HasColumnType("Nvarchar(50)").IsRequired();
        builder.Property(x => x.email).HasColumnType("Nvarchar(50)").IsRequired();
    }

}
