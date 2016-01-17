using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordProcessorLibrary
{
    public class SpaceSplitter : Records
    {
        protected override char splitCharacter { get { return ' '; } }
    }
}
