using RecordProcessorLibrary.Domain;
using System.Collections.Generic;
using System.Linq;

namespace RecordProcessorLibrary
{
    public interface IRecordSorter
    {
        IEnumerable<Record> Sort(IEnumerable<Record> records);
    }

    public interface IGenderSorter:IRecordSorter
    { }
    public interface IDateOfBirthSorter : IRecordSorter
    { }
    public interface ILastNameSorter : IRecordSorter
    { }

    public class GenderSorter : IGenderSorter
    {
        public IEnumerable<Record> Sort(IEnumerable<Record> records)
        {
            return records.OrderBy(x => x.Gender);
        }
    }

    public class DateOfBirthSorter : IDateOfBirthSorter
    {
        public IEnumerable<Record> Sort(IEnumerable<Record> records)
        {
            return records.OrderBy(x => x.DateOfBirth);
        }
    }

    public class LastNameSorter : ILastNameSorter
    {
        public IEnumerable<Record> Sort(IEnumerable<Record> records)
        {
            return records.OrderByDescending(x => x.LastName);
        }
    }
}
