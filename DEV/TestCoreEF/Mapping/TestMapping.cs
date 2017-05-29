using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using TestCoreEF.Models;

namespace TestCoreEF.Mapping
{
    public class TestMapping
    {
        public TestMapping(EntityTypeBuilder<SYS_Model> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.PassWord).IsRequired().HasMaxLength(50);
        }
    }
}
