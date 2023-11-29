using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectToSend.Apliaction.AbstractionServices;

public interface ISecurityService
{
    public string GetPasswordHash(string password);
    public dynamic CreateToken(int userId);
}
