﻿// <auto-generated />
using System;
using HueOnlineTicketFestival.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HueOnlineTicketFestival.Migrations
{
    [DbContext(typeof(FestivalTicketContext))]
    [Migration("20230518041915_InitWebDB")]
    partial class InitWebDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistsInvited", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int")
                        .HasColumnName("artistID");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    b.HasKey("ArtistId", "EventId")
                        .HasName("PK__Artists___CD9FE8B16AA3F331");

                    b.HasIndex("EventId");

                    b.ToTable("Artists_Invited", (string)null);
                });

            modelBuilder.Entity("EventImage", b =>
                {
                    b.Property<int>("EventImageId")
                        .HasColumnType("int")
                        .HasColumnName("eventImageID");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    b.HasKey("EventImageId", "EventId")
                        .HasName("PK__Event_Im__D1733B11F198F4BF");

                    b.HasIndex("EventId");

                    b.ToTable("Event_Images", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("artistID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("ArtistName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("artistName");

                    b.HasKey("ArtistId")
                        .HasName("PK__Artist__4F4393674FFC7E98");

                    b.ToTable("Artist", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime")
                        .HasColumnName("birthday");

                    b.Property<string>("IdentityCardNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("identityCardNumber");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PaymentInfo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("paymentInfo");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__B611CB9D6901DB4F");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("EventContent")
                        .HasColumnType("text")
                        .HasColumnName("eventContent");

                    b.Property<string>("EventName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("eventName");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int")
                        .HasColumnName("eventTypeID");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.HasKey("EventId")
                        .HasName("PK__Event__2DC7BD694B27AC64");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.EventPicture", b =>
                {
                    b.Property<int>("EventImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("eventImageID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventImageId"));

                    b.Property<string>("EventImageName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("eventImageName");

                    b.HasKey("EventImageId")
                        .HasName("PK__EventPic__53AF40C725D8B205");

                    b.ToTable("EventPicture", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.EventType", b =>
                {
                    b.Property<int>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("eventTypeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventTypeId"));

                    b.Property<string>("EventTypeName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("eventTypeName");

                    b.HasKey("EventTypeId")
                        .HasName("PK__EventTyp__04ACC49D4C713A12");

                    b.ToTable("EventType", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.EventsLocation", b =>
                {
                    b.Property<int>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("locationID");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<DateTime?>("EndAt")
                        .HasColumnType("datetime")
                        .HasColumnName("end_at");

                    b.Property<DateTime?>("StartAt")
                        .HasColumnType("datetime")
                        .HasColumnName("start_at");

                    b.Property<int?>("TicketQuantity")
                        .HasColumnType("int")
                        .HasColumnName("ticketQuantity");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.HasKey("LocationId", "EventId")
                        .HasName("PK__Events_L__B2B810D83C06C84F");

                    b.HasIndex("EventId");

                    b.ToTable("Events_Locations", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("locationID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("description");

                    b.Property<string>("LocationName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("locationName");

                    b.HasKey("LocationId")
                        .HasName("PK__Location__30646B0E23C3E791");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("newsID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsId"));

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    b.Property<string>("NewName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("newName");

                    b.Property<string>("NewsContent")
                        .HasColumnType("text")
                        .HasColumnName("newsContent");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.HasKey("NewsId")
                        .HasName("PK__News__5218047E8B72649A");

                    b.HasIndex("EventId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("permissionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionId"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("permissionName");

                    b.HasKey("PermissionId")
                        .HasName("PK__Permissi__D821317CFEA6E40E");

                    b.HasIndex(new[] { "PermissionName" }, "UQ__Permissi__70661EFC89C695A4")
                        .IsUnique();

                    b.HasIndex(new[] { "PermissionId" }, "UQ__Permissi__D821317DDFB5AED9")
                        .IsUnique();

                    b.ToTable("Permission", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("roleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("roleName");

                    b.HasKey("RoleId")
                        .HasName("PK__Role__CD98460A825BC1BF");

                    b.HasIndex(new[] { "RoleName" }, "UQ__Role__B19478616F34A9AF")
                        .IsUnique();

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ticketID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customerID");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("eventID");

                    b.Property<int>("LocationId")
                        .HasColumnType("int")
                        .HasColumnName("locationID");

                    b.Property<int?>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("status");

                    b.Property<string>("TicketName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ticketName");

                    b.Property<int>("TicketTypeId")
                        .HasColumnType("int")
                        .HasColumnName("ticketTypeID");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.HasKey("TicketId")
                        .HasName("PK__Ticket__3333C670A87837E0");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TicketTypeId");

                    b.HasIndex("UserId");

                    b.HasIndex("LocationId", "EventId");

                    b.HasIndex(new[] { "TicketId" }, "UQ__Ticket__3333C6713A5EBE5D")
                        .IsUnique();

                    b.ToTable("Ticket", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.TicketCheckin", b =>
                {
                    b.Property<int>("TicketCheckinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ticketCheckinID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketCheckinId"));

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<int>("TicketId")
                        .HasColumnType("int")
                        .HasColumnName("ticketID");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.HasKey("TicketCheckinId")
                        .HasName("PK__TicketCh__73CB0A27F00460EC");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketCheckin", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.TicketType", b =>
                {
                    b.Property<int>("TicketTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ticketTypeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketTypeId"));

                    b.Property<string>("TicketTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ticketTypeName");

                    b.HasKey("TicketTypeId")
                        .HasName("PK__TicketTy__D18F5C141E84C927");

                    b.HasIndex(new[] { "TicketTypeId" }, "UQ__TicketTy__D18F5C159DD69347")
                        .IsUnique();

                    b.ToTable("TicketType", (string)null);
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("address");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("create_at");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("phone");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime")
                        .HasColumnName("update_at");

                    b.Property<string>("UserImage")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("userImage");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("PK__User__CB9A1CDFA9A7852D");

                    b.HasIndex(new[] { "UserId" }, "UQ__User__CB9A1CDEF66D391D")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "UQ__User__F3DBC57293F17A33")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("roleID");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int")
                        .HasColumnName("permissionID");

                    b.HasKey("RoleId", "PermissionId")
                        .HasName("PK__Role_Per__101A551D30C51342");

                    b.HasIndex("PermissionId");

                    b.ToTable("Role_Permission", (string)null);
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("roleID");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PK__User_Rol__774398BF5D9DB1FD");

                    b.HasIndex("RoleId");

                    b.ToTable("User_Role", (string)null);
                });

            modelBuilder.Entity("ArtistsInvited", b =>
                {
                    b.HasOne("HueOnlineTicketFestival.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .IsRequired()
                        .HasConstraintName("FK__Artists_I__artis__0C85DE4D");

                    b.HasOne("HueOnlineTicketFestival.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__Artists_I__event__09A971A2");
                });

            modelBuilder.Entity("EventImage", b =>
                {
                    b.HasOne("HueOnlineTicketFestival.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__Event_Ima__event__06CD04F7");

                    b.HasOne("HueOnlineTicketFestival.Models.EventPicture", null)
                        .WithMany()
                        .HasForeignKey("EventImageId")
                        .IsRequired()
                        .HasConstraintName("FK__Event_Ima__event__0F624AF8");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Event", b =>
                {
                    b.HasOne("HueOnlineTicketFestival.Models.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__Event__eventType__0E6E26BF");

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.EventsLocation", b =>
                {
                    b.HasOne("HueOnlineTicketFestival.Models.Event", "Event")
                        .WithMany("EventsLocations")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__Events_Lo__event__08B54D69");

                    b.HasOne("HueOnlineTicketFestival.Models.Location", "Location")
                        .WithMany("EventsLocations")
                        .HasForeignKey("LocationId")
                        .IsRequired()
                        .HasConstraintName("FK__Events_Lo__locat__0B91BA14");

                    b.Navigation("Event");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.News", b =>
                {
                    b.HasOne("HueOnlineTicketFestival.Models.Event", "Event")
                        .WithMany("News")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__News__eventID__07C12930");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Ticket", b =>
                {
                    b.HasOne("HueOnlineTicketFestival.Models.Customer", "Customer")
                        .WithMany("Tickets")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Ticket__customer__0D7A0286");

                    b.HasOne("HueOnlineTicketFestival.Models.TicketType", "TicketType")
                        .WithMany("Tickets")
                        .HasForeignKey("TicketTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__Ticket__ticketTy__0A9D95DB");

                    b.HasOne("HueOnlineTicketFestival.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Ticket__userID__02084FDA");

                    b.HasOne("HueOnlineTicketFestival.Models.EventsLocation", "EventsLocation")
                        .WithMany("Tickets")
                        .HasForeignKey("LocationId", "EventId")
                        .IsRequired()
                        .HasConstraintName("FK__Ticket__10566F31");

                    b.Navigation("Customer");

                    b.Navigation("EventsLocation");

                    b.Navigation("TicketType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.TicketCheckin", b =>
                {
                    b.HasOne("HueOnlineTicketFestival.Models.Ticket", "Ticket")
                        .WithMany("TicketCheckins")
                        .HasForeignKey("TicketId")
                        .IsRequired()
                        .HasConstraintName("FK__TicketChe__ticke__05D8E0BE");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("RolePermission", b =>
                {
                    b.HasOne("HueOnlineTicketFestival.Models.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .IsRequired()
                        .HasConstraintName("FK__Role_Perm__permi__04E4BC85");

                    b.HasOne("HueOnlineTicketFestival.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__Role_Perm__roleI__02FC7413");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("HueOnlineTicketFestival.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__User_Role__roleI__03F0984C");

                    b.HasOne("HueOnlineTicketFestival.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__User_Role__userI__01142BA1");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Customer", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Event", b =>
                {
                    b.Navigation("EventsLocations");

                    b.Navigation("News");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.EventsLocation", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Location", b =>
                {
                    b.Navigation("EventsLocations");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.Ticket", b =>
                {
                    b.Navigation("TicketCheckins");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.TicketType", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("HueOnlineTicketFestival.Models.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
