using RecordProcessorLibrary.Domain;
using System.Collections.Generic;
using System.Linq;

namespace RecordProcessorLibrary
{
    public class RecordParser : IRecordParser
    {
        private IEnumerable<IRecordSplitter> _splitters;
        private IRecordFromPiecesConverter _converter;

        public RecordParser(IEnumerable<IRecordSplitter> splitters, IRecordFromPiecesConverter converter)
        {
            _splitters = splitters;
            _converter = converter;
        }

        public IEnumerable<Record> Parse(IEnumerable<string> records)
        {
            var splitter = getSplitter(records.First());

            foreach (var record in records)
            {
                yield return _converter.Convert(splitter.Split(record));
            }
        }

        private IRecordSplitter getSplitter(string firstRecord)
        {
            return _splitters.FirstOrDefault(x => x.CanSplit(firstRecord));
        }
    }

}
