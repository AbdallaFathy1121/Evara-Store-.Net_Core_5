using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaraStore.Models
{
    public partial class TbSetting
    {
        [Key]
        public int SettingId { get; set; }
        public int MainPhone { get; set; }
        public int HotLinePhone { get; set; }
        public string Address { get; set; }
        public string Facebook { get; set; }
        public string Insatgram { get; set; }
        public string Pinterest { get; set; }
        public string Twitter { get; set; }
        public string YouTube { get; set; }
    }
}
