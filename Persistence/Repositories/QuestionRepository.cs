using Application.Abstractions;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationFormContext context)
        {
            _Context = context;
        }
        public async Task<List<Question>> GetQuestionsAsync(Guid formWindowId)
        {
            return await _Context.Questions.Where(x => x.FormWindowId == formWindowId).ToListAsync();
        }
    }
}
