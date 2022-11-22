using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProfissionais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProfissionais.Infra.Data.Mappings
{
    public class ProfissionalMapping : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.ToTable("PROFISSIONAL");

            builder.HasKey(p => p.IdProfissional);

            builder.Property(p => p.IdProfissional)
                .HasColumnName("IDPROFISSIONAL")
                .IsRequired();

            builder.Property(p => p.IdUsuario)
              .HasColumnName("IDUSUARIO")
              .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.Property(p => p.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(p => p.Cpf)
                .IsUnique();

            builder.Property(p => p.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(p => p.Telefone)
                .IsUnique();

            builder.HasOne(p => p.Usuario)
                .WithMany(u => u.Profissionais)
                .HasForeignKey(p => p.IdUsuario);
                
            

        }
    }
}
