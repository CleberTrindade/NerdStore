using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NS.Clientes.API.Models;
using NS.Core.DomainObjects;

namespace NS.Clientes.API.Data.Mappings
{
	public class ClienteMapping : IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder.HasKey( c => c.Id );

			builder.Property(c => c.Nome)
				.IsRequired()
				.HasColumnType("varchar(200)");

			builder.OwnsOne(c => c.Cpf, tf =>
			{
				tf.Property(c => c.Numero)
				.IsRequired()
				.HasMaxLength(Cpf.CpfMaxLength)
				.HasColumnName("Cpf")
				.HasColumnType($"varchar({Cpf.CpfMaxLength})");
			});

			builder.OwnsOne(c => c.Email, tf =>
			{
				tf.Property(c => c.Endereco)
				.IsRequired()
				.HasMaxLength(Email.EmailMaxLength)
				.HasColumnName("Email")
				.HasColumnType($"varchar({Email.EmailMaxLength})");
			});

			//1 : 1 => Cliente : Endereço
			builder.HasOne(c => c.Endereco)
				.WithOne(c => c.Cliente);

			builder.ToTable("Clientes");

		}
	}
}
