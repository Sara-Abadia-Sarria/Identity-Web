using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Web.Models
{
    [Table("Student", Schema = "dbo")]
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Display(Name = "Nombres")]
        public string FirstMidName { get; set; }

        [Display(Name = "Fecha de inscripción")]
        public DateTime EnrollmentDate { get; set; }
    }
}
