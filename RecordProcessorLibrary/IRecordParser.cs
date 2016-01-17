using RecordProcessorLibrary.Domain;
using System.Collections.Generic;

namespace RecordProcessorLibrary
{
    public interface IRecordParser
    {
        IEnumerable<Record> Parse(IEnumerable<string> record);
    }
}
