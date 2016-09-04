namespace Eron.core.DataModel.File
{
    public class File:EntityBase
    {

        public string Name { get; set; }

        public string FileUrl { get; set; }

        public long Downloaded { get; set; }

        public virtual string ContentId { get; set; }

        public virtual Content.Content Content { get; set; }
    }
}