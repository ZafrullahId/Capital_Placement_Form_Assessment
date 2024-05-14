using Application.Abstractions;
using Application.Model.Dtos.Request;
using Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FormWindowService
    {
        private readonly IFormWindowRepository _formWindowRepository;
        public FormWindowService(IFormWindowRepository formWindowRepository)
        {
            _formWindowRepository = formWindowRepository;
        }
    }
}
