using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebAppExamJobMVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения.")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле 'Фамилия' обязательно для заполнения.")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле 'Группа' обязательно для заполнения.")]
        [DisplayName("Группа")]
        public string Group { get; set; }

        [DisplayName("Телефон")]
        public string Phone { get; set; }

        [DisplayName("Электронная почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле 'Оценка' обязательно для заполнения.")]
        [Range(1, 5, ErrorMessage = "Сумма должна быть в пределах от 1 до 5.")]
        [DisplayName("Оценка")]
        public int? Score { get; set; }

        [DisplayName("Учебная дисциплина")]
        public int DisciplineId { get; set; }

        [DisplayName("Учебная дисциплина")]
        public Discipline Discipline { get; set; }
    }
}
