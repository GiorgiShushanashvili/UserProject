using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectToSend.Apliaction.Asbtractions;

public interface ISecurityService
{
    public byte[] GetPasswordHash(string password, byte[] passwordSalt);
    public dynamic CreateToken(int userId, string role);
}
