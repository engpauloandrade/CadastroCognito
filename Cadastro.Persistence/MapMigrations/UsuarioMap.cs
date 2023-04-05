using Cadastro.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Persistence.MapMigrations
{
    [ExcludeFromCodeCoverage]
    public class UsuarioMap : BaseMap<Usuario>
    {
        public UsuarioMap() : base("default") { }

        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);
        }
    }
}
