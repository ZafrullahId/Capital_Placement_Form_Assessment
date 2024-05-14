using Application.Abstractions;
using Domain.Entity;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class FormWindowRepository : BaseRepository<FormWindow>, IFormWindowRepository
    {
        public FormWindowRepository(ApplicationFormContext context)
        {
            _Context = context;
        }
    }
}
