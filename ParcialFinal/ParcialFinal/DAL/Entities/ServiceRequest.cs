using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcialFinal.DAL.Entities
{
    public class ServiceRequest : Entity
    {

        [Display(Name = "Nombre del cliente")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string CustomerName { get; set; }

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string CarId { get; set; }

        [Display(Name = "Servicio")]
        public Guid SelectedServiceId { get; set; }

        [Display(Name = "Servicio Seleccionado")]
        [ForeignKey("SelectedServiceId")]
        public virtual Service SelectedService { get; set; }
    }
}
