using RecordProcessorLibrary.Domain;

namespace RecordProcessorLibrary
{
    public class StringRecordPrinter : IRecordPrinter<string>
    {
        public string PrintRecord(Record record)
        {
            return string.Format("Record: {0} {1} {2} {3:MM/dd/yyyy} {4}", record.FirstName, record.LastName, record.Gender, record.DateOfBirth, record.FavoriteColor);
        }
    }
}
