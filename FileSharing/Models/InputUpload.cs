using Microsoft.Build.Framework;
using System.ComponentModel;

namespace FileSharing.Models
{
    public class InputUpload
    {
        [Required]
        public IFormFile File { get; set; }
    }
    public class UploadVm
    {
        public string FileName { get; set; } 
        public string Originalname { get; set; } 

        public decimal Size { get; set; }
        public string ContentType { get; set; }

        [DisplayName("Date")]
        public DateTime UploadDate { get; set; }
    }
}
