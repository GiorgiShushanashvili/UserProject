using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public bool isActive { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile profile { get; set; }
}
