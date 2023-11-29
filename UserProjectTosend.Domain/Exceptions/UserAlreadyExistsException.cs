﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.Exceptions;

public class UserAlreadyExistsException:Exception
{
    public UserAlreadyExistsException() : base("UserName Already Used") { }
}
