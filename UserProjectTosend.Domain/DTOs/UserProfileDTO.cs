using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.DTOs;

public class UserProfileDTO
{
    public string firstName { get;set; }
    public string lastName { get;set; }
    public string personalNumber { get;set; }
    public int userId { get; set; }
}
