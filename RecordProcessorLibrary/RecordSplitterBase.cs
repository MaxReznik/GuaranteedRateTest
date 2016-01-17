using System.Linq;

namespace RecordProcessorLibrary
{
    public abstract class Records : IRecordSplitter
    {
        protected abstract char splitCharacter { get; }

        public virtual string[] Split(string str)
        {
            return str.Split(splitCharacter);
        }

        public virtual bool CanSplit(string record)
        {
            return record.Contains(splitCharacter);
        }
    }
}
