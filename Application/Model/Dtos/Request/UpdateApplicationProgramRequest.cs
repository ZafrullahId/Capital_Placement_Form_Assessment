﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Dtos.Request
{
    public class UpdateApplicationProgramRequest
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
