using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueOnlineTicketFestival.Migrations
{
    /// <inheritdoc />
    public partial class InitWebDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    artistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    artistName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Artist__4F4393674FFC7E98", x => x.artistID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    identityCardNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    paymentInfo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__B611CB9D6901DB4F", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "EventPicture",
                columns: table => new
                {
                    eventImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventImageName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventPic__53AF40C725D8B205", x => x.eventImageID);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    eventTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventTyp__04ACC49D4C713A12", x => x.eventTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    locationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__30646B0E23C3E791", x => x.locationID);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    permissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permissionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permissi__D821317CFEA6E40E", x => x.permissionID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    roleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__CD98460A825BC1BF", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "TicketType",
                columns: table => new
                {
                    ticketTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TicketTy__D18F5C141E84C927", x => x.ticketTypeID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    password = table.Column<string>(type: "varchar(max)", unicode: false, maxLength: 2147483647, nullable: false),
                    userImage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__CB9A1CDFA9A7852D", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    eventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventTypeID = table.Column<int>(type: "int", nullable: false),
                    eventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    eventContent = table.Column<string>(type: "text", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Event__2DC7BD694B27AC64", x => x.eventID);
                    table.ForeignKey(
                        name: "FK__Event__eventType__0E6E26BF",
                        column: x => x.eventTypeID,
                        principalTable: "EventType",
                        principalColumn: "eventTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Role_Permission",
                columns: table => new
                {
                    roleID = table.Column<int>(type: "int", nullable: false),
                    permissionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role_Per__101A551D30C51342", x => new { x.roleID, x.permissionID });
                    table.ForeignKey(
                        name: "FK__Role_Perm__permi__04E4BC85",
                        column: x => x.permissionID,
                        principalTable: "Permission",
                        principalColumn: "permissionID");
                    table.ForeignKey(
                        name: "FK__Role_Perm__roleI__02FC7413",
                        column: x => x.roleID,
                        principalTable: "Role",
                        principalColumn: "roleID");
                });

            migrationBuilder.CreateTable(
                name: "User_Role",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false),
                    roleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User_Rol__774398BF5D9DB1FD", x => new { x.userID, x.roleID });
                    table.ForeignKey(
                        name: "FK__User_Role__roleI__03F0984C",
                        column: x => x.roleID,
                        principalTable: "Role",
                        principalColumn: "roleID");
                    table.ForeignKey(
                        name: "FK__User_Role__userI__01142BA1",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Artists_Invited",
                columns: table => new
                {
                    artistID = table.Column<int>(type: "int", nullable: false),
                    eventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Artists___CD9FE8B16AA3F331", x => new { x.artistID, x.eventID });
                    table.ForeignKey(
                        name: "FK__Artists_I__artis__0C85DE4D",
                        column: x => x.artistID,
                        principalTable: "Artist",
                        principalColumn: "artistID");
                    table.ForeignKey(
                        name: "FK__Artists_I__event__09A971A2",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "eventID");
                });

            migrationBuilder.CreateTable(
                name: "Event_Images",
                columns: table => new
                {
                    eventImageID = table.Column<int>(type: "int", nullable: false),
                    eventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Event_Im__D1733B11F198F4BF", x => new { x.eventImageID, x.eventID });
                    table.ForeignKey(
                        name: "FK__Event_Ima__event__06CD04F7",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "eventID");
                    table.ForeignKey(
                        name: "FK__Event_Ima__event__0F624AF8",
                        column: x => x.eventImageID,
                        principalTable: "EventPicture",
                        principalColumn: "eventImageID");
                });

            migrationBuilder.CreateTable(
                name: "Events_Locations",
                columns: table => new
                {
                    locationID = table.Column<int>(type: "int", nullable: false),
                    eventID = table.Column<int>(type: "int", nullable: false),
                    ticketQuantity = table.Column<int>(type: "int", nullable: true),
                    start_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    end_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Events_L__B2B810D83C06C84F", x => new { x.locationID, x.eventID });
                    table.ForeignKey(
                        name: "FK__Events_Lo__event__08B54D69",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "eventID");
                    table.ForeignKey(
                        name: "FK__Events_Lo__locat__0B91BA14",
                        column: x => x.locationID,
                        principalTable: "Location",
                        principalColumn: "locationID");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    newsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventID = table.Column<int>(type: "int", nullable: false),
                    newName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    newsContent = table.Column<string>(type: "text", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__News__5218047E8B72649A", x => x.newsID);
                    table.ForeignKey(
                        name: "FK__News__eventID__07C12930",
                        column: x => x.eventID,
                        principalTable: "Event",
                        principalColumn: "eventID");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ticketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    locationID = table.Column<int>(type: "int", nullable: false),
                    eventID = table.Column<int>(type: "int", nullable: false),
                    ticketTypeID = table.Column<int>(type: "int", nullable: false),
                    ticketName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ticket__3333C670A87837E0", x => x.ticketID);
                    table.ForeignKey(
                        name: "FK__Ticket__10566F31",
                        columns: x => new { x.locationID, x.eventID },
                        principalTable: "Events_Locations",
                        principalColumns: new[] { "locationID", "eventID" });
                    table.ForeignKey(
                        name: "FK__Ticket__customer__0D7A0286",
                        column: x => x.customerID,
                        principalTable: "Customer",
                        principalColumn: "customerID");
                    table.ForeignKey(
                        name: "FK__Ticket__ticketTy__0A9D95DB",
                        column: x => x.ticketTypeID,
                        principalTable: "TicketType",
                        principalColumn: "ticketTypeID");
                    table.ForeignKey(
                        name: "FK__Ticket__userID__02084FDA",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "TicketCheckin",
                columns: table => new
                {
                    ticketCheckinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ticketID = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    update_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TicketCh__73CB0A27F00460EC", x => x.ticketCheckinID);
                    table.ForeignKey(
                        name: "FK__TicketChe__ticke__05D8E0BE",
                        column: x => x.ticketID,
                        principalTable: "Ticket",
                        principalColumn: "ticketID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_Invited_eventID",
                table: "Artists_Invited",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_eventTypeID",
                table: "Event",
                column: "eventTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Images_eventID",
                table: "Event_Images",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Locations_eventID",
                table: "Events_Locations",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "IX_News_eventID",
                table: "News",
                column: "eventID");

            migrationBuilder.CreateIndex(
                name: "UQ__Permissi__70661EFC89C695A4",
                table: "Permission",
                column: "permissionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Permissi__D821317DDFB5AED9",
                table: "Permission",
                column: "permissionID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Role__B19478616F34A9AF",
                table: "Role",
                column: "roleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permission_permissionID",
                table: "Role_Permission",
                column: "permissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_customerID",
                table: "Ticket",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_locationID_eventID",
                table: "Ticket",
                columns: new[] { "locationID", "eventID" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ticketTypeID",
                table: "Ticket",
                column: "ticketTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_userID",
                table: "Ticket",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "UQ__Ticket__3333C6713A5EBE5D",
                table: "Ticket",
                column: "ticketID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketCheckin_ticketID",
                table: "TicketCheckin",
                column: "ticketID");

            migrationBuilder.CreateIndex(
                name: "UQ__TicketTy__D18F5C159DD69347",
                table: "TicketType",
                column: "ticketTypeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__User__CB9A1CDEF66D391D",
                table: "User",
                column: "userID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__User__F3DBC57293F17A33",
                table: "User",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Role_roleID",
                table: "User_Role",
                column: "roleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists_Invited");

            migrationBuilder.DropTable(
                name: "Event_Images");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Role_Permission");

            migrationBuilder.DropTable(
                name: "TicketCheckin");

            migrationBuilder.DropTable(
                name: "User_Role");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "EventPicture");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Events_Locations");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "TicketType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "EventType");
        }
    }
}
