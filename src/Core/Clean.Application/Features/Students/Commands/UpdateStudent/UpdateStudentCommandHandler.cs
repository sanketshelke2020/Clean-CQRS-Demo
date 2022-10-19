using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Application.Features.Events.Commands.UpdateEvent;
using Clean.Application.Responses;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Response<int>>
    {
        private readonly ILogger<UpdateStudentCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(ILogger<UpdateStudentCommandHandler> logger, IMapper mapper, IStudentRepository studentRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._studentRepository = studentRepository;
        }
        public async Task<Response<int>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UpdateHandler Initiated");
            var studentToUpdate = await _studentRepository.GetStudentByIdAsync(request.StudentId);
            if (studentToUpdate == null)
            {
                throw new NotFoundException(nameof(Student), request.StudentId);
            }

            studentToUpdate.Age = request.Age;
            studentToUpdate.Name = request.Name;
            studentToUpdate.LastModifiedDate = DateTime.UtcNow;

            await _studentRepository.UpdateAsync(studentToUpdate);

            return new Response<int>(request.StudentId, "Updated successfully ");
        }
    }
}
