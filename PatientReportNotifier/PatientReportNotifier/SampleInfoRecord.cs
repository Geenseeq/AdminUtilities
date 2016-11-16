using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientReportNotifier
{
    class SampleInfoRecord
    {
        private string _patientName;
        private string _reportTypes;
        private string _salespersonName;

        public string PatientName { get { return _patientName; } }
        public string ReportTypes { get { return _reportTypes; } }
        public string SalespersonName { get { return _salespersonName; } }

        public SampleInfoRecord(string patientName, string reportTypes,  string salespersonName)
        {
            _patientName = patientName;
            _reportTypes = reportTypes;
            _salespersonName = salespersonName;
        }
    }
}
