using System.ComponentModel.DataAnnotations;

namespace bootstrap_project.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя обязательно для заполнения.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Адрес обязателен для заполнения.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Телефон обязателен для заполнения.")]
        [Phone(ErrorMessage = "Введите корректный номер телефона.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Выберите продукт.")]
        public int ProductId { get; set; }

        // Навигационное свойство
        public virtual Product Product { get; set; }
    }

}

