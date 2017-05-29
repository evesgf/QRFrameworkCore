using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAll.Entitys;

namespace TestAll.Mappings
{
    public class UserMapping
    {
        public UserMapping(EntityTypeBuilder<Sys_User> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.PassWord).IsRequired().HasMaxLength(50);
        }
    }
}
