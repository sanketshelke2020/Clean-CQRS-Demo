using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Exceptions;
using Clean.Application.Features.Students.Commands.CreateStudent;
using Clean.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Commands.RemoveStudent
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly ILogger<RemoveStudentCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public RemoveStudentCommandHandler(ILogger<RemoveStudentCommandHandler> logger, IMapper mapper, IStudentRepository studentRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._studentRepository = studentRepository;
        }
        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("RemoveStudent Handler Initiated!");
            var stuentToDelete = await _studentRepository.GetStudentByIdAsync(request.StudentId);

            if (stuentToDelete == null)
            {
                throw new NotFoundException(nameof(Student), request.StudentId);
            }
            await _studentRepository.DeleteAsync(stuentToDelete);
            return Unit.Value;
        }
    }
}
