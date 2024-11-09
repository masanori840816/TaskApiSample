using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TaskApiSample.AppUsers;

[Table("app_user")]
public class AppUser: IdentityUser<long>
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [PersonalData]
    public override required long Id { get; set; } = default!;

    [ProtectedPersonalData]
    [Column("user_name")]
    public override required string? UserName { get; set; }

    [ProtectedPersonalData]
    [Column("email")]
    public override required string? Email { get; set; }

    [Column("password")]
    public override string? PasswordHash { get; set; }
    
    [Column(TypeName="datetimeoffset")]
    public required DateTimeOffset LastUpdateDate { get; init; }

    [NotMapped]
    public override string? NormalizedUserName { get; set; }
    [NotMapped]
    public override string? NormalizedEmail { get; set; }

    [NotMapped]
    [PersonalData]
    public override bool EmailConfirmed { get; set; }
    [NotMapped]
    public override string? SecurityStamp { get; set; }

    [NotMapped]
    public override string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

    [ProtectedPersonalData]
    [NotMapped]
    public override string? PhoneNumber { get; set; }


    [PersonalData]
    [NotMapped]
    public override bool PhoneNumberConfirmed { get; set; }

    [PersonalData]
    [NotMapped]
    public override bool TwoFactorEnabled { get; set; }

    [NotMapped]
    public override DateTimeOffset? LockoutEnd { get; set; }

    [NotMapped]
    public override bool LockoutEnabled { get; set; }

    [NotMapped]
    public override int AccessFailedCount { get; set; }
}