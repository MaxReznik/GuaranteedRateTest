namespace RecordProcessorLibrary
{
    public class PipeSplitter : Records
    {
        protected override char splitCharacter { get { return '|'; } }
    }
}
