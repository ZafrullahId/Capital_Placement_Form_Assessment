using Application.Abstractions;
using Application.Wrapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Dtos.Request
{
    public class CreateChoiceRequest
    {
        private List<string> _options = [];

        public List<string> Options
        {
            get => _options;
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Options list must not be empty.");
                }
                _options = value;
            }
        }

        public int MaxChoiceAllowed { get; set; }
    }
}
