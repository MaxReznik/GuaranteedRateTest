using System.IO;

namespace RecordProcessorLibrary.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        public string[] Read(string repositoryName)
        {
            return File.ReadAllLines(repositoryName);
        }
    }
}
