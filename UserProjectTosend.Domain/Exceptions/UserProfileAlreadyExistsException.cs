using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.Exceptions;

public class UserProfileAlreadyExistsException:Exception
{
    public UserProfileAlreadyExistsException() :base("There Is Already UserProfile Registered By This Personal Number") { }
}
