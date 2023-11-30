using System.ComponentModel.DataAnnotations;

namespace nemtudom.Models;

public class ContentModel
{
    [Key]
    public int content_id { get; set; }
    
    public string content_title { get; set; }
    
    public string content_body { get; set; }
    
    public string content_img { get; set; }
    
    public string content_video { get; set; }
    
    public string content_link { get; set; }

}