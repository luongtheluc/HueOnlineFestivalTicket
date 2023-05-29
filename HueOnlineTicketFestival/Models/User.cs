using System;
using System.Collections.Generic;

namespace HueOnlineTicketFestival.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = string.Empty;

    public string? UserImage { get; set; }

    public bool? IsActive { get; set; }

    public string? Address { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }
    public string? Email { get; set; }


    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public string? VerificationToken { get; set; }
    public DateTime? VerifyAt { get; set; }
    public string PasswordResetToken { get; set; } = string.Empty;
    public DateTime? ResetTokenExpries { get; set; }
    public string RefreshToken { get; set; } = string.Empty;

    public DateTime RefreshTokenCreated { get; set; }
    public DateTime RefreshTokenExpries { get; set; }



}
