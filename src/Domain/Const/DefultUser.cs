using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anonymous_message.Domain.Const;
public class DefultUser
{
    public const string default_username = "user";
    public const string default_email = "user@secureapi.com";
    public const string default_password = "Pa$$w0rd.";
    public const RolesEnum default_role = RolesEnum.User;
}
