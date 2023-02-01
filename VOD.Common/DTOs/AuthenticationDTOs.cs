using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD.Common.DTOs
{
    public record LoginUserDTO(string Email, string Password);
    public record RegisterUserDTO(string Email, string Password, List<string> Roles);
    public record PaidCustomerDTO(string Email);


}
