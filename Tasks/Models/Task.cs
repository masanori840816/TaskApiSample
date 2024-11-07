
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApiSample.Tasks.Models;

[Table("task")]
public record Task
{
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; init; }
    [Column("title", TypeName = "varchar(128)")]
    public required string Title { get; init; }

    [Column("notes")]
    public required string Notes { get; init; }
    [Column(TypeName="timestamp with time zone")]
    public required DateTime LastUpdateDate { get; init; }
}