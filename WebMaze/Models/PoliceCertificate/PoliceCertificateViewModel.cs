using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.PoliceCertificate
{
    public class PoliceCertificateViewModel
    {
        private DateTime? starts;

        /// <summary>
        /// Название специальности сертификата
        /// </summary>
        public string Speciality { get; set; }

        /// <summary>
        /// Время начала действия сертификата. Если не задано, то текущее время
        /// </summary>
        public DateTime Starts { get { if (starts == null) starts = DateTime.Today; return starts.GetValueOrDefault(); } set { starts = value; } }
        
        /// <summary>
        /// Дата окончания сертификата. Может быть NULL - то бишь без ограничения
        /// </summary>
        public DateTime? Expires { get; set; }
        
        /// <summary>
        /// Цена в долларах в месяц. Если <see cref="Expires"/> NULL, то без месяцев
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Название Контроллера, на который будет перенаправление
        /// </summary>
        public string RedirectToController { get; set; }

        /// /// <summary>
        /// Название Action'а, на который будет перенаправление
        /// </summary>
        public string RedirectToAction { get; set; }
    }
}
