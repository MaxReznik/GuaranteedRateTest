using RecordProcessorLibrary.Domain;

namespace RecordProcessorLibrary
{
    public interface IRecordPrinter<T>
    {
        T PrintRecord(Record record);
    }
}
