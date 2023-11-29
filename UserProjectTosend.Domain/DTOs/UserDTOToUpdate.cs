using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProjectTosend.Domain.DTOs;

public class UserDTOToUpdate
{
    public int Id { get;set; }
    public string userName {  get;set; } 
    public string password {  get;set; }
    public string email { get;set; }
    public bool isActive { get; set; }
    public int UserProfileId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalNumber { get; set; }
}
