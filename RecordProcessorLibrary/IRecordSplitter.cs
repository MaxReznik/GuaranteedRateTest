namespace RecordProcessorLibrary
{
    public interface IRecordSplitter
    {
        bool CanSplit(string record);
        string[] Split(string record);
    }
}
