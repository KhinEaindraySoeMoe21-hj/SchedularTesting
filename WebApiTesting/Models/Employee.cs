using System.ComponentModel.DataAnnotations;

namespace WebApiTesting.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public DateTime EmpBd { get; set; }
        public string EmpPh { get; set; }
        public string EmpAdd { get; set; }
    }
}
