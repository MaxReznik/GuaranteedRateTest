using RecordProcessorLibrary.Domain;

namespace RecordProcessorLibrary
{
    public interface IRecordFromPiecesConverter
    {
        Record Convert(string[] recordPieces);
    }
}
