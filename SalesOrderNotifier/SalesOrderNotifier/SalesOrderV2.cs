using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderNotifier
{
    class SalesOrderV2
    {
        private string _orderNumber;
        private string _patientName;
        private string _cancerType;
        private string _checkupType;
        private string _orderDate;
        private string _hospital;
        private string _department;
        private string _doctorName;
        private string _paymentStatus;
        private string _salesperson;
        private string _city;
        private string _province;
        private string _currentState;
        private string _reportDate;

        public string OrderNumber
        {
            get
            {
                return _orderNumber;
            }

            set
            {
                _orderNumber = value;
            }
        }
        public string PatientName
        {
            get
            {
                return _patientName;
            }

            set
            {
                _patientName = value;
            }
        }
        public string CancerType
        {
            get
            {
                return _cancerType;
            }

            set
            {
                _cancerType = value;
            }
        }
        public string CheckupType
        {
            get
            {
                return _checkupType;
            }

            set
            {
                _checkupType = value;
            }
        }
        public string OrderDate
        {
            get
            {
                return _orderDate;
            }

            set
            {
                _orderDate = value;
            }
        }
        public string Hospital
        {
            get
            {
                return _hospital;
            }

            set
            {
                _hospital = value;
            }
        }
        public string Department
        {
            get
            {
                return _department;
            }

            set
            {
                _department = value;
            }
        }
        public string DoctorName
        {
            get
            {
                return _doctorName;
            }

            set
            {
                _doctorName = value;
            }
        }
        public string PaymentStatus
        {
            get
            {
                return _paymentStatus;
            }

            set
            {
                _paymentStatus = value;
            }
        }
        public string Salesperson
        {
            get
            {
                return _salesperson;
            }

            set
            {
                _salesperson = value;
            }
        }
        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }
        public string Province
        {
            get
            {
                return _province;
            }

            set
            {
                _province = value;
            }
        }
        public string CurrentState
        {
            get
            {
                return _currentState;
            }

            set
            {
                _currentState = value;
            }
        }
        public string ReportDate
        {
            get
            {
                return _reportDate;
            }

            set
            {
                _reportDate = value;
            }
        }

        public static string OrderNumberHeader = "订单号";
        public static string PatientNameHeader = "病人姓名";
        public static string CancerTypeHeader = "癌种";
        public static string CheckupTypeHeader = "检测项目";
        public static string OrderDateHeader = "下单日期";
        public static string CurrentStateHeader = "状态";
        public static string ReportDateHeader = "出报告日期";
        public static string HospitalHeader = "所属医院";
        public static string DepartmentHeader = "送检科室";
        public static string DoctorNameHeader = "主治医生";
        public static string PaymentStatusHeader = "是否缴费";
        public static string SalespersonHeader = "销售代表";
        public static string CityHeader = "所属县市";
        public static string ProvinceHeader = "所属省份";

        public static string excelSheetName = "Report";



        public SalesOrderV2( string orderNumber, string patientName, string cancerType, string checkupType,
                    string orderDate, string currentState, string reportDate, string hospital, string department, 
                    string doctorName, string salesperson, string paymentStatus, string city, string province)
        {
            OrderNumber = orderNumber;
            PatientName = patientName;
            CancerType = cancerType;
            CheckupType = checkupType;
            OrderDate = OrderDate;
            CurrentState = currentState;
            ReportDate = reportDate;
            Hospital = hospital;
            Department = department;
            DoctorName = doctorName;
            Salesperson = salesperson;
            PaymentStatus = paymentStatus;
            City = city;
            Province = province;
        }
        public override string ToString(){
            return string.Format("{0,10}  {1,6}  {2,10}  {3,100}  {4,12}  {5,8}  {6,12}  {7,12}  {8,8}  {9,6}  {10,2}  {11,6}  {12,6}  {13,6}\n",
                OrderNumber, new string('X', PatientName.Length), CancerType, CheckupType, OrderDate, CurrentState, ReportDate,
                new string('X', Hospital.Length), new string('X', Department.Length), new string('X', DoctorName.Length), PaymentStatus, Salesperson, City, Province);
        }

        public string GetHeaderString()
        {
            return string.Format("{0,10}  {1,6}  {2,10}  {3,100}  {4,12}  {5,8}  {6,12}  {7,12}  {8,8}  {9,6}  {10,2}  {11,6}  {12,6}  {13,6}\n",
                OrderNumberHeader, PatientNameHeader, CancerTypeHeader, CheckupTypeHeader, OrderDateHeader, CurrentStateHeader, ReportDateHeader, 
                HospitalHeader, DepartmentHeader, DoctorNameHeader, PaymentStatusHeader, SalespersonHeader, CityHeader, ProvinceHeader);
        }

        public string[] ToArray()
        {
            return new string[] { OrderNumber, new string('X',PatientName.Length), CancerType, CheckupType, OrderDate, CurrentState, ReportDate,
                new string('X', Hospital.Length), new string('X', Department.Length), new string('X', DoctorName.Length), PaymentStatus, Salesperson, City, Province };
        }

        public string[] GetHeaderArray()
        {
            return new string[] { OrderNumberHeader, PatientNameHeader, CancerTypeHeader, CheckupTypeHeader, OrderDateHeader, CurrentStateHeader,
                ReportDateHeader, HospitalHeader, DepartmentHeader, DoctorNameHeader, PaymentStatusHeader, SalespersonHeader, CityHeader, ProvinceHeader };
        }
    }
}
