using System;

namespace RecordProcessorLibrary.Domain
{
    public class Record
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FavoriteColor { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }    
}
