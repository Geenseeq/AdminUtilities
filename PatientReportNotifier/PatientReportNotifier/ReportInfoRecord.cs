using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientReportNotifier
{
    class ReportInfoRecord
    {
        private string _patientName;
        private string _reportDate;
        private string _reportTypes;
        private string _reportComments;
        private string _salespersonName;

        public string PatientName { get { return _patientName; } }
        public string ReportDate { get { return _reportDate; } }
        public string ReportTypes { get { return _reportTypes; } }
        public string ReportComments { get { return _reportComments; } }
        public string SalespersonName { get { return _salespersonName; } }

        public ReportInfoRecord(string patientName, string reportDate, string reportTypes, string reportComments, string salespersonName) {
            _patientName = patientName;
            _reportDate = reportDate;
            _reportTypes = reportTypes;
            _reportComments = reportComments;
            _salespersonName = salespersonName;
        }
    }
}
