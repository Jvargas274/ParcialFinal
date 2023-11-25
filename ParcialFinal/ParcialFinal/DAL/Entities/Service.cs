using System.ComponentModel.DataAnnotations;

namespace ParcialFinal.DAL.Entities
{
    public class Service : Entity
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String Name { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String Price { get; set; }
    }
}
