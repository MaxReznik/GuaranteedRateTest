namespace RecordProcessorLibrary.Repositories
{
    public interface IRecordRepository
    {
        string[] Read(string repositoryName);
    }    
}
