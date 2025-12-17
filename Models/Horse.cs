using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HorsesDB_API.Models;

public partial class Horse
{
    [Key]
    [Column("HorseID")]
    public int HorseId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? HorseName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? BreedName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? BreedOrigin { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? OwnerFirstName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? OwnerLastName { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? OwnerContact { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Gender { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Color { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? RaceName { get; set; }

    public DateOnly? RaceDate { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? RaceLocation { get; set; }

    public int? RaceDistance { get; set; }

    public int? FinishPosition { get; set; }
}
