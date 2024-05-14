using Application.Abstractions;
using Application.Model.Dtos.Request;
using Application.Wrapper;
using Domain.Entity;
using Mapster;

namespace Application.Services
{
    public class ApplicationProgramService : IApplicationProgramService
    {
        private readonly IFormWindowRepository _formWindowRepository;
        private readonly IApplicationProgramRepository _applicationProgramRepository;
        public ApplicationProgramService(IApplicationProgramRepository applicationProgramRepository, IFormWindowRepository formWindowRepository)
        {
            _formWindowRepository = formWindowRepository;
            _applicationProgramRepository = applicationProgramRepository;
        }
        public async Task<Result<bool>> CreateApplicationProgramWindowAsync(CreateApplicationProgramRequest request)
        {
            if (request is not null)
            {
                var applicationProgramWindow = request.Adapt<ApplicationProgram>();
                await _applicationProgramRepository.CreateAsync(applicationProgramWindow);
                var fromWindow = new FormWindow()
                {
                    ApplicationProgramId = applicationProgramWindow.Id,
                };
                await _formWindowRepository.CreateAsync(fromWindow);
                await _applicationProgramRepository.SaveChangesAsync();
                return await Result<bool>.SuccessAsync("Application Form Window Successfully Created");
            }
            return await Result<bool>.FailAsync();
        }
        public async Task<Result<bool>> UpdateApplicationProgramWindowAsync(UpdateApplicationProgramRequest request, Guid applicationProgramWindowId)
        {
            var applicationWindow = await _applicationProgramRepository.GetAsync(x => x.Id == applicationProgramWindowId);
            if (applicationWindow is not null)
            {
                applicationWindow.Title = request.Title ?? applicationWindow.Title;
                applicationWindow.Description = request.Description ?? applicationWindow.Description;
                await _applicationProgramRepository.UpdateAsync(applicationWindow);
                return await Result<bool>.SuccessAsync("Successfully Updated");
            }
            return await Result<bool>.FailAsync("Application Window not found");
        }
    }
}
