namespace DanmarkMusik.Models
{
    public class MusikRecord
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public int Duration { get; set; }
        public int PublicationYear { get; set; }

        public override string ToString()
        {
            return $"Title {Title}, Artist {Artist}, Duration {Duration}, Publication Year {PublicationYear}";
        }

        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Title cannot be null");
            }

            if (Title.Length < 2)
            {
                throw new ArgumentException("Title must be more than 2 characters");
            }
        }

        public void ValidateArtist()
        {
            if (Artist == null)
            {
                throw new ArgumentNullException("Artist cannot be null");
            }

            if (Artist.Length < 2)
            {
                throw new ArgumentException("Artist must be more than 2 characters");
            }
        }

        public void ValidateDuration()
        {
            if (Duration <= 0)
            {
                throw new ArgumentOutOfRangeException("The duration of the music must be more than 0 seconds");
            }
        }

        public void ValidatePublicationYear()
        {
            if (PublicationYear <= 0)
            {
                throw new ArgumentOutOfRangeException("The publication year cannot be 0 or negative number");
            }
        }

    }
}
