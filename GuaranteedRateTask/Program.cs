using Ninject;
using RecordProcessorLibrary;
using RecordProcessorLibrary.Domain;
using RecordProcessorLibrary.Repositories;
using System;
using System.Collections.Generic;

namespace GuaranteedRateTask
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load<Bindings>();

            var repository = kernel.Get<IRecordRepository>();
            var records = repository.Read(args[0]);

            var recordParser = kernel.Get<IRecordParser>();
            var recs = recordParser.Parse(records);
            
            var printer = kernel.Get<IRecordPrinter<string>>();

            SortAndPrint(printer, kernel.Get<IGenderSorter>(), recs);
            SortAndPrint(printer, kernel.Get<IDateOfBirthSorter>(), recs);
            SortAndPrint(printer, kernel.Get<ILastNameSorter>(), recs);
            
            Console.WriteLine("Press <Enter> to exit.");
            Console.ReadLine();
        }

        static private void SortAndPrint(IRecordPrinter<string> printer, IRecordSorter sorter, IEnumerable<Record> records)
        {
            Console.WriteLine("Sorting with {0}", sorter);
            
            foreach (var record in sorter.Sort(records))
            {
                Console.WriteLine(printer.PrintRecord(record));
            }
        }
    }
}
