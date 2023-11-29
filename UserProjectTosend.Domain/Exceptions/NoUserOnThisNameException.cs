using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.Exceptions;

public class NoUserOnThisNameException:Exception
{
    public NoUserOnThisNameException() : base("There Is No User For This Name") { }
}
