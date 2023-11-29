using System.ComponentModel.DataAnnotations;

namespace nemtudom.Models;

public class ContactModel
{
    [Key]
    public int contact_id { get; set; }
    public string phonenumber { get; set; }
    public string email { get; set; }
    public string socialmedia { get; set; }
}