using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.Exceptions;

public class IncorrectPasswordException:Exception
{
    public IncorrectPasswordException() : base("Your Password or UserName is Incorrect,Try Again") { }
}
