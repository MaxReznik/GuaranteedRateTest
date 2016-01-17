using Ninject.Modules;
using RecordProcessorLibrary;
using RecordProcessorLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaranteedRateTask
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IRecordParser>().To<RecordParser>();
            Bind<IRecordFromPiecesConverter>().To<RecordFromPiecesConverter>();
            Bind<IRecordSplitter>().To<PipeSplitter>();
            Bind<IRecordSplitter>().To<SpaceSplitter>();
            Bind<IRecordSplitter>().To<CommaSplitter>();
            Bind<IRecordRepository>().To<RecordRepository>();
            Bind<IRecordPrinter<string>>().To<StringRecordPrinter>();
            Bind<IDateOfBirthSorter>().To<DateOfBirthSorter>();
            Bind<IGenderSorter>().To<GenderSorter>();
            Bind<ILastNameSorter>().To<LastNameSorter>();
        }
    }
}
