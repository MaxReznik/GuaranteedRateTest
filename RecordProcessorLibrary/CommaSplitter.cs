namespace RecordProcessorLibrary
{
    public class CommaSplitter : Records
    {
        protected override char splitCharacter { get { return ','; } }
    }
}
