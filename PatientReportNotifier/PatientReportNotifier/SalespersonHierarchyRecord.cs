using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel;

namespace PatientReportNotifier
{
    class SalespersonHierarchyRecord
    {
        private string _salesperson;
        private string _salesAssistant;
        private string _areaManager;
        private string _regionManager;
        private string _medicalRepresentative;

        public string Salesperson { get { return _salesperson; } }
        public string SalesAssistant { get { return _salesAssistant; } }
        public string AreaManager { get { return _areaManager; } }
        public string RegionManager { get { return _regionManager; } }
        public string MedicalRepresentative { get { return _medicalRepresentative; } }

        public SalespersonHierarchyRecord(Cell salesperson, Cell salesAssistant, Cell areaManager, Cell regionManager, Cell medicalRepresentative)
        {
            _salesperson = salesperson != null ? salesperson.Text : "";
            _salesAssistant = salesAssistant != null ? salesAssistant.Text : "";
            _areaManager = areaManager != null ? areaManager.Text : "";
            _regionManager = regionManager != null ? regionManager.Text : "";
            _medicalRepresentative = medicalRepresentative != null ? medicalRepresentative.Text : "";
        }

        /// <summary>
        /// Returns a distinct list of strings for each non-empty salesperson's superior's name, includes medRep name.
        /// </summary>
        public List<string> GetSalespersonSuperiorsNamesList(string reportSalesperson)
        {
            List<string> outList = new List<string>();

            if (reportSalesperson==_salesperson){
                if (!string.IsNullOrEmpty(_medicalRepresentative))
                    outList.Add(_medicalRepresentative);
                if (!string.IsNullOrEmpty(_regionManager))
                    outList.Add(_regionManager);
                if (!string.IsNullOrEmpty(_areaManager))
                    outList.Add(_areaManager);
                if (!string.IsNullOrEmpty(_salesAssistant))
                    outList.Add(_salesAssistant);
            }
            else if (reportSalesperson == _salesAssistant)
            {
                if (!string.IsNullOrEmpty(_medicalRepresentative))
                    outList.Add(_medicalRepresentative);
                if (!string.IsNullOrEmpty(_regionManager))
                    outList.Add(_regionManager);
                if (!string.IsNullOrEmpty(_areaManager))
                    outList.Add(_areaManager);
            }
            if (reportSalesperson == _areaManager)
            {
                if (!string.IsNullOrEmpty(_medicalRepresentative))
                    outList.Add(_medicalRepresentative);
                if (!string.IsNullOrEmpty(_regionManager))
                    outList.Add(_regionManager);
            }
            if (reportSalesperson == _regionManager)
            {
                if (!string.IsNullOrEmpty(_medicalRepresentative))
                    outList.Add(_medicalRepresentative);
            }

            return outList;
        }
    }
}
