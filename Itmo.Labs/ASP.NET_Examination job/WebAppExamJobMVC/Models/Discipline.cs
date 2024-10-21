using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebAppExamJobMVC.Models
{
    public class Discipline
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле 'Учебная дисциплина' обязательно для заполнения.")]
        [DisplayName("Учебная дисциплина")]
        public string Name { get; set; }
    }
}
