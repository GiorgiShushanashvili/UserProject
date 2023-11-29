using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.Exceptions;

public class NoUsersException:Exception
{
    public NoUsersException() : base("There Are No Users") { }
}
