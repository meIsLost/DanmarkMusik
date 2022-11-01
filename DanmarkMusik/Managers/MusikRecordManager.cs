
using DanmarkMusik.Models;

namespace DanmarkMusik.Managers
{
    public class MusikRecordManager
    {
       
        
            private static int _nextId = 1;

            private static readonly List<MusikRecord> Data = new List<MusikRecord>
        {
            new MusikRecord { Id = _nextId++, Artist = "The Script", Duration = 300, Title = "Hall of Fame", PublicationYear= 2012},
            new MusikRecord { Id = _nextId++, Artist = "Denmark", Duration = 210, Title = "Zealand", PublicationYear= 2010},
            new MusikRecord { Id = _nextId++, Artist = "Andres", Duration = 120, Title = "JavaScript", PublicationYear= 2022},
            new MusikRecord { Id = _nextId++, Artist = "The Script", Duration = 180, Title = "Paint the town green", PublicationYear= 2011}
        };

            public List<MusikRecord> GetAll()
            {
                return new List<MusikRecord>(Data);
            }

            public MusikRecord? GetById(int id)
            {
                return Data.Find(music => music.Id == id);
            }

            public MusikRecord Add(MusikRecord newMusikRecord)
            {
                newMusikRecord.Id = _nextId++;
                Data.Add(newMusikRecord);
                return newMusikRecord;
            }

            public MusikRecord? Delete(int id)
            {
                MusikRecord? music = Data.Find(music1 => music1.Id == id);
                if (music == null) return null;
                Data.Remove(music);
                return music;
            }

            public MusikRecord? Update(int id, MusikRecord updates)
            {
                MusikRecord? music = Data.Find(music1 => music1.Id == id);
                if (music == null) return null;

                music.Title = updates.Title;
                music.Artist = updates.Artist;
                music.Duration = updates.Duration;
                music.PublicationYear = updates.PublicationYear;
                return music;
            }
    }
    
}
