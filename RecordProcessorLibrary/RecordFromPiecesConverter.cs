using RecordProcessorLibrary.Domain;
using System;

namespace RecordProcessorLibrary
{
    public class RecordFromPiecesConverter : IRecordFromPiecesConverter
    {
        public Record Convert(string[] recordPices)
        {
            return new Record
            {
                FirstName = recordPices[0],
                LastName = recordPices[1],
                Gender = (Gender)Enum.Parse(typeof(Gender), recordPices[2]),
                FavoriteColor = recordPices[3],
                DateOfBirth = DateTime.Parse(recordPices[4])
            };
        }
    }
}
