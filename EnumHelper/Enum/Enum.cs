using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnumHelper.Enum
{
    public enum enumStatus
    {
        [Display(Name= "Rejected")]
        rejected,
        [Display(Name = "Replaced")]
        replaced,
        [Display(Name = "Local Bye")]
        local_bye,
        [Display(Name = "Remote Bye")]
        remote_bye
    }
}
