using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreModel
{
    public class Config : IEntityTypeConfiguration<EventInfo>
    {
        public void Configure(EntityTypeBuilder<EventInfo> builder)
        {
            builder.ToTable("EventInfo");
        }
    }
}
