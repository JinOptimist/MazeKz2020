using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Medicine;
using WebMaze.Models.CustomAttribute;

namespace WebMaze.Models.HealthDepartment
{
    public class MedicalInsuranceViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [CheckOwnerId(ErrorMessage = "Не найден")]
        public long OwnerId { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public bool IsMaried { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        public bool HaveChildren { get; set; }

        [CheckStartDate(ErrorMessage = "Необходимо установить сегодняшнюю дату")]
        public DateTime StartPeriod { get; set; }

        [CheckEndDate(ErrorMessage = "Необходимо установить дату больше сегодняшней")]
        public DateTime EndPeriod { get; set; }
        public string Type { get; set; }
        public decimal Coast { get; set; }

    }
}
