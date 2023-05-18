using Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mappers;

public class MatchTicketEntityMap: IEntityTypeConfiguration<MatchTicket>
{
    public void Configure(EntityTypeBuilder<MatchTicket> builder)
    {
        builder.ToTable("MatchTickets");

        builder.HasKey(mt => mt.TicketId);

        builder.HasOne(mt => mt.Match)
            .WithMany(m => m.MatchTickets)
            .HasForeignKey(mt => mt.MatchId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(mt => mt.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(u => u.UserId)
            .IsRequired();

        builder.Property(mt => mt.Row)
            .IsRequired();

        builder.Property(mt => mt.Seat)
            .IsRequired();
    }
}