﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models.Entities;

[Table("user_accoutn")]

public class User_Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_name")]
    [MaxLength(100)]
    public string? UserName { get; set; }

    [Column("password")]
    [MaxLength(100)]
    public string? Password { get; set; }

    [Column("role")]
    [MaxLength(20)]
    public string? Role { get; set; }
}
