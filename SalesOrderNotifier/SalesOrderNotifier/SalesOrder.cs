using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderNotifier
{
    class SalesOrder
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
        //city and province currently not in excel file
        //private string _city;
        //private string _province;
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
        //public string City
        //{
        //    get
        //    {
        //        return _city;
        //    }

        //    set
        //    {
        //        _city = value;
        //    }
        //}
        //public string Province
        //{
        //    get
        //    {
        //        return _province;
        //    }

        //    set
        //    {
        //        _province = value;
        //    }
        //}
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

        public string OrderNumberHeader = "编码";
        public string OrderDateHeader = "创建时间";
        public string PatientNameHeader = "姓名";
        public string CancerTypeHeader = "肿瘤类型";
        public string CheckupTypeHeader = "检测项目";
        public string HospitalHeader = "医疗机构";
        public string DepartmentHeader = "送检科室";
        public string DoctorNameHeader = "主治医生";
        public string SalespersonHeader = "销售代表";
        public string CurrentStateHeader = "状态名称";
        public string ReportDateHeader = "出报告日期";


        SalesOrder( string orderNumber, string orderDate, string patientName, string cancerType, string checkupType,  
                    string hospital, string department, string doctorName, string salesperson, 
                    string currentState, string paymentStatus, string reportDate)
        {
            OrderNumber = orderNumber;
            OrderDate = OrderDate;
            PatientName = patientName;
            CancerType = cancerType;
            CheckupType = checkupType;
            Hospital = hospital;
            Department = department;
            DoctorName = doctorName;
            Salesperson = salesperson;
            //City = city;
            //Province = province;
            CurrentState = currentState;
            //PaymentStatus = paymentStatus;
            ReportDate = reportDate;
        }
        public override string ToString(){
            return string.Format("{0,10}  {1,12}  {2,6}  {3,10}  {4,100}  {5,15}  {6,15}  {7,8}  {8,8}  {9,6}  {10,12}\n",
                OrderNumber, OrderDate, PatientName, CancerType, CheckupType, Hospital, Department, DoctorName, Salesperson, CurrentState, ReportDate);
        }
    }
}
