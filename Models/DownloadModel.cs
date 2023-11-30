using System.ComponentModel.DataAnnotations;

namespace nemtudom.Models;

public class DownloadModel
{
    [Key]
    public int download_id { get; set; }
    public string file_name { get; set; }
    public string file_path { get; set; }
    public bool is_active { get; set; }
    public DateTime uploaded_At { get; set; }
}