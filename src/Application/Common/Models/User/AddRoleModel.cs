using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymous_message.Application.Common.Models.User;
public class AddRoleModel
{
    [Required]
    public string Email { get; set; } = default!;
    [Required]
    public string Password { get; set; } =default!;
    [Required]
    public string Role { get; set; }= default!;
}
