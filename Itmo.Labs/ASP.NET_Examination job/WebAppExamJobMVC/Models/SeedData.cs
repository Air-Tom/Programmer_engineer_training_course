using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using WebAppExamJobMVC.Data;
using static System.Formats.Asn1.AsnWriter;

namespace WebAppExamJobMVC.Models
{
    class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<StudentContext>>()))
            {
                if (context == null || context.Students == null)
                {
                    throw new ArgumentNullException("Null CreditContext");
                }
                // Если в базе данных уже есть кредиты,
                // то возвращается инициализатор заполнения и кредиты не добавляются
                if (context.Students.Any())
                {
                    return;
                }
                context.Students.Add(new Student { FirstName = "Буркин", LastName = "Артём", Group = "124/03", Phone = "+7-921-561-49-54", Email = "Fort42184@bk.ru", Score = 5, DisciplineId = 1 });
                context.Students.Add(new Student { FirstName = "Буркин", LastName = "Артём", Group = "124/03", Phone = "+7-921-561-49-54", Email = "Fort42184@bk.ru", Score = 3, DisciplineId = 2 });
                context.Students.Add(new Student { FirstName = "Спалин", LastName = "Иофис", Group = "120/07", Phone = "+7-920-354-10-16", Email = "Spalin@mail.ru", Score = 2, DisciplineId = 1 });
                // можно использовать метод AddRange
                context.Students.AddRange(

                new Student
                {
                    FirstName = "Спалин",
                    LastName = "Иофис",
                    Group = "120/07",
                    Phone = "+7-920-354-10-16",
                    Email = "Spalin@mail.ru",
                    Score = 4,
                    DisciplineId = 4
                },
                new Student
                {
                    FirstName = "Самсон",
                    LastName = "Лев",
                    Group = "118/02",
                    Phone = "+7-981-568-18-28",
                    Email = "Lev@gmail.ru",
                    Score = 1,
                    DisciplineId = 1
                }
                );
                context.SaveChanges();
            }
        }
    }
}

