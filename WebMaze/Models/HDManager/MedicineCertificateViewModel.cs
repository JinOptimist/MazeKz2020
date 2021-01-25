using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.Models.CustomAttribute;

namespace WebMaze.Models.HDManager
{
    public class MedicineCertificateViewModel
    {
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public virtual string Position { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [CheckStartDate(ErrorMessage = "Необходимо установить сегодняшнюю дату")]
        public virtual DateTime DateOfIssue { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [CheckEndDate(ErrorMessage = "Необходимо установить дату больше сегодняшней")]
        public virtual DateTime DateExpiration { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [CheckOwnerId(ErrorMessage = "Не найден")]
        public virtual long UserId { get; set; }

        public virtual long Id { get; set; }
    }
}
