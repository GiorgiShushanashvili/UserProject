using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.Exceptions;

public class NoUserOnThisIdException:Exception
{
    public NoUserOnThisIdException() : base("There Is No User For This Id") { }
}
