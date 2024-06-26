﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        Task<List<Question>> GetQuestionsAsync(Guid formWindowId);
    }
}
