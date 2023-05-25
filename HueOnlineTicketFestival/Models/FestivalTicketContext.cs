using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HueOnlineTicketFestival.Models;

public partial class FestivalTicketContext : DbContext
{
    public FestivalTicketContext()
    {
    }

    public FestivalTicketContext(DbContextOptions<FestivalTicketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventPicture> EventPictures { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<EventsLocation> EventsLocations { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketCheckin> TicketCheckins { get; set; }

    public virtual DbSet<TicketType> TicketTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=THELUC;Initial Catalog=Festival_Ticket;Integrated Security=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("PK__Artist__4F4393674FFC7E98");

            entity.ToTable("Artist");

            entity.Property(e => e.ArtistId).HasColumnName("artistID");
            entity.Property(e => e.ArtistName)
                .HasMaxLength(50)
                .HasColumnName("artistName");

            entity.HasMany(d => d.Events).WithMany(p => p.Artists)
                .UsingEntity<Dictionary<string, object>>(
                    "ArtistsInvited",
                    r => r.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Artists_I__event__09A971A2"),
                    l => l.HasOne<Artist>().WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Artists_I__artis__0C85DE4D"),
                    j =>
                    {
                        j.HasKey("ArtistId", "EventId").HasName("PK__Artists___CD9FE8B16AA3F331");
                        j.ToTable("Artists_Invited");
                        j.IndexerProperty<int>("ArtistId").HasColumnName("artistID");
                        j.IndexerProperty<int>("EventId").HasColumnName("eventID");
                    });
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB9D6901DB4F");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Birthday)
                .HasColumnType("datetime")
                .HasColumnName("birthday");
            entity.Property(e => e.IdentityCardNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("identityCardNumber");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PaymentInfo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paymentInfo");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__2DC7BD694B27AC64");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.EventContent)
                .HasColumnType("text")
                .HasColumnName("eventContent");
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .HasColumnName("eventName");
            entity.Property(e => e.EventTypeId).HasColumnName("eventTypeID");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__eventType__0E6E26BF");
        });

        modelBuilder.Entity<EventPicture>(entity =>
        {
            entity.HasKey(e => e.EventImageId).HasName("PK__EventPic__53AF40C725D8B205");

            entity.ToTable("EventPicture");

            entity.Property(e => e.EventImageId).HasColumnName("eventImageID");
            entity.Property(e => e.EventImageName)
                                .HasMaxLength(int.MaxValue)

                .IsUnicode(false)
                .HasColumnName("eventImageName");

            entity.HasMany(d => d.Events).WithMany(p => p.EventImages)
                .UsingEntity<Dictionary<string, object>>(
                    "EventImage",
                    r => r.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Event_Ima__event__06CD04F7"),
                    l => l.HasOne<EventPicture>().WithMany()
                        .HasForeignKey("EventImageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Event_Ima__event__0F624AF8"),
                    j =>
                    {
                        j.HasKey("EventImageId", "EventId").HasName("PK__Event_Im__D1733B11F198F4BF");
                        j.ToTable("Event_Images");
                        j.IndexerProperty<int>("EventImageId").HasColumnName("eventImageID");
                        j.IndexerProperty<int>("EventId").HasColumnName("eventID");
                    });
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeId).HasName("PK__EventTyp__04ACC49D4C713A12");

            entity.ToTable("EventType");

            entity.Property(e => e.EventTypeId).HasColumnName("eventTypeID");
            entity.Property(e => e.EventTypeName)
                .HasMaxLength(50)
                .HasColumnName("eventTypeName");
        });

        modelBuilder.Entity<EventsLocation>(entity =>
        {
            entity.HasKey(e => new { e.LocationId, e.EventId }).HasName("PK__Events_L__B2B810D83C06C84F");

            entity.ToTable("Events_Locations");

            entity.Property(e => e.LocationId).HasColumnName("locationID");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.EndAt)
                .HasColumnType("datetime")
                .HasColumnName("end_at");
            entity.Property(e => e.StartAt)
                .HasColumnType("datetime")
                .HasColumnName("start_at");
            entity.Property(e => e.TicketQuantity).HasColumnName("ticketQuantity");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.Event).WithMany(p => p.EventsLocations)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Events_Lo__event__08B54D69");

            entity.HasOne(d => d.Location).WithMany(p => p.EventsLocations)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Events_Lo__locat__0B91BA14");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__30646B0E23C3E791");

            entity.ToTable("Location");

            entity.Property(e => e.LocationId).HasColumnName("locationID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.LocationName)
                .HasMaxLength(50)
                .HasColumnName("locationName");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PK__News__5218047E8B72649A");

            entity.Property(e => e.NewsId).HasColumnName("newsID");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.NewName)
                .HasMaxLength(50)
                .HasColumnName("newName");
            entity.Property(e => e.NewsContent)
                .HasColumnType("text")
                .HasColumnName("newsContent");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.Event).WithMany(p => p.News)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__News__eventID__07C12930");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__D821317CFEA6E40E");

            entity.ToTable("Permission");

            entity.HasIndex(e => e.PermissionName, "UQ__Permissi__70661EFC89C695A4").IsUnique();

            entity.HasIndex(e => e.PermissionId, "UQ__Permissi__D821317DDFB5AED9").IsUnique();

            entity.Property(e => e.PermissionId).HasColumnName("permissionID");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.PermissionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("permissionName");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__CD98460A825BC1BF");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__B19478616F34A9AF").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("roleID");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("roleName");

            entity.HasMany(d => d.Permissions).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RolePermission",
                    r => r.HasOne<Permission>().WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Role_Perm__permi__04E4BC85"),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Role_Perm__roleI__02FC7413"),
                    j =>
                    {
                        j.HasKey("RoleId", "PermissionId").HasName("PK__Role_Per__101A551D30C51342");
                        j.ToTable("Role_Permission");
                        j.IndexerProperty<int>("RoleId").HasColumnName("roleID");
                        j.IndexerProperty<int>("PermissionId").HasColumnName("permissionID");
                    });
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__3333C670A87837E0");

            entity.ToTable("Ticket");

            entity.HasIndex(e => e.TicketId, "UQ__Ticket__3333C6713A5EBE5D").IsUnique();

            entity.Property(e => e.TicketId).HasColumnName("ticketID");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EventId).HasColumnName("eventID");
            entity.Property(e => e.LocationId).HasColumnName("locationID");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TicketName)
                .HasMaxLength(50)
                .HasColumnName("ticketName");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticketTypeID");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ticket__customer__0D7A0286");

            entity.HasOne(d => d.TicketType).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ticket__ticketTy__0A9D95DB");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ticket__userID__02084FDA");

            entity.HasOne(d => d.EventsLocation).WithMany(p => p.Tickets)
                .HasForeignKey(d => new { d.LocationId, d.EventId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ticket__10566F31");
        });

        modelBuilder.Entity<TicketCheckin>(entity =>
        {
            entity.HasKey(e => e.TicketCheckinId).HasName("PK__TicketCh__73CB0A27F00460EC");

            entity.ToTable("TicketCheckin");

            entity.Property(e => e.TicketCheckinId).HasColumnName("ticketCheckinID");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.TicketId).HasColumnName("ticketID");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketCheckins)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TicketChe__ticke__05D8E0BE");
        });

        modelBuilder.Entity<TicketType>(entity =>
        {
            entity.HasKey(e => e.TicketTypeId).HasName("PK__TicketTy__D18F5C141E84C927");

            entity.ToTable("TicketType");

            entity.HasIndex(e => e.TicketTypeId, "UQ__TicketTy__D18F5C159DD69347").IsUnique();

            entity.Property(e => e.TicketTypeId).HasColumnName("ticketTypeID");
            entity.Property(e => e.TicketTypeName)
                .HasMaxLength(50)
                .HasColumnName("ticketTypeName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__CB9A1CDFA9A7852D");

            entity.ToTable("User");

            entity.HasIndex(e => e.UserId, "UQ__User__CB9A1CDEF66D391D").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__User__F3DBC57293F17A33").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasColumnName("create_at");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(int.MaxValue)
                .IsUnicode(false)
                .HasColumnName("password");
            // entity.Property(e => e.VerificationToken).HasColumnName("VerificationToken").HasMaxLength(int.MaxValue);
            // entity.Property(e => e.PasswordResetToken).HasColumnName("PasswordResetToken").HasMaxLength(int.MaxValue);
            // entity.Property(e => e.VerifyAt).HasColumnType("datetime").HasColumnName("VerifyAt");
            // entity.Property(e => e.ResetTokenExpries).HasColumnType("datetime").HasColumnName("ResetTokenExpries");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UserImage)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userImage");
            entity.Property(e => e.Username)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Role__roleI__03F0984C"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__User_Role__userI__01142BA1"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__User_Rol__774398BF5D9DB1FD");
                        j.ToTable("User_Role");
                        j.IndexerProperty<int>("UserId").HasColumnName("userID");
                        j.IndexerProperty<int>("RoleId").HasColumnName("roleID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
