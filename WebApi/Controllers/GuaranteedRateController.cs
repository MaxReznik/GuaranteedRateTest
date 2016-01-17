using RecordProcessorLibrary;
using RecordProcessorLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class GuaranteedRateController: Controller
    {
        IRecordParser _parser;
        IGenderSorter _genderSorter;
        IDateOfBirthSorter _dateOfBirthSorter;
        ILastNameSorter _lastNameSorter;

        public GuaranteedRateController(IRecordParser parser, IGenderSorter genderSorter, IDateOfBirthSorter dateOfBirthSorter, ILastNameSorter lastNameSorter)
        {
            _parser = parser;
            _genderSorter = genderSorter;
            _dateOfBirthSorter = dateOfBirthSorter;
            _lastNameSorter = lastNameSorter;
        }


        private List<Record> getRecordsFromSession()
        {
            var records = Session["Records"] as List<Record>;
            if (records == null)
            {
                records = new List<Record>();
                Session["Records"] = records;
            }
            return records;
        }

        [System.Web.Mvc.HttpPost]
        public void Records(string data)
        {
            var records = getRecordsFromSession();
            records.AddRange(_parser.Parse(data.Split('\n')));
        }
        
        public ActionResult Gender()
        {
            var records = getRecordsFromSession();
            return new JsonResult { Data = _genderSorter.Sort(records).ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        
        public ActionResult BirthDate()
        {
            var records = getRecordsFromSession();
            return new JsonResult { Data = _dateOfBirthSorter.Sort(records).ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        
        public ActionResult Name()
        {
            var records = getRecordsFromSession();
            return new JsonResult { Data = _lastNameSorter.Sort(records).ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}