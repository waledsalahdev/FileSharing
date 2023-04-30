using Microsoft.Build.Framework;

namespace FileSharing.Models
{
    public class UploadsVM
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
