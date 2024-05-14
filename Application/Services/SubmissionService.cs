using Application.Abstractions;
using Application.Model.Dtos.Request;
using Application.Wrapper;
using Domain.Entity;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IFormWindowRepository _formWindowRepository;
        public SubmissionService(ISubmissionRepository submissionRepository, IFormWindowRepository formWindowRepository)
        {
            _submissionRepository = submissionRepository;
            _formWindowRepository = formWindowRepository;
        }
        public async Task<Result<bool>> CreateSubmissionAsync(CreateSubmissionRequest request, Guid formWindowId)
        {
            var formWindow = await _formWindowRepository.GetAsync(x => x.Id == formWindowId);
            if (formWindow is not null)
            {
                var personalInformationSubmission = request.PersonalInformation.Adapt<PersonalInformation>();
                var otherResponsesSubmission = request.ApplicationResponse.Adapt<List<ApplicationResponse>>();
                var submission = new Submission
                {
                    FormWindowId = formWindowId,
                    PersonalInformation = personalInformationSubmission,
                    ApplicationResponses = otherResponsesSubmission
                };
                await _submissionRepository.CreateAsync(submission);
                await _submissionRepository.SaveChangesAsync();
                return await Result<bool>.SuccessAsync("Submission Successfully Created");
            }
            return await Result<bool>.FailAsync("Unable to find form window");
        }
    }
}
