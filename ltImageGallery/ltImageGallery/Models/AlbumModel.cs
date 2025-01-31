namespace ltImageGallery.Models
{
    public class Album
    {
        public int albumId { get; set; }
        public List<Photo> photos { get; set; }
    }

    public class Photo
    {
        public int photoId { get; set; }
        public string url { get; set; }
        public int albumId { get; set; }
        public string title { get; set; }
    }
}




