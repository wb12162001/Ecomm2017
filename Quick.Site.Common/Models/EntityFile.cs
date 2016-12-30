using System.ComponentModel.DataAnnotations;

namespace Quick.Site.Common.Models
{
    public enum FileType
    {
        Avatar = 1, Photo
    }
    public class EntityFile<T>
    {
        public int FileId { get; set; }
        //[StringLength(255)]
        public string FileName { get; set; }
        //[StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int PersonId { get; set; }
        public virtual T Person { get; set; }
    }
}
