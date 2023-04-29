using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Tickets.Shared.Enums;

namespace Tickets.Shared.DTOs
{
	public class TicketDTO
	{
        public int Id { get; set; }

        [Display(Name = "Ticket")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TicketId { get; set; } = null!;

        [Display(Name = "Fecha de uso")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime? UseDate { get; set; } = null;

        public bool isUsed { get; set; } = false;

        [Display(Name = "Portería")]
        public EntranceType? Entrance { get; set; } = null;
    }
}

