using AutoMapper;
using Clean.Application.Contracts.Persistence;
using Clean.Application.Features.Students.Commands.CreateStudent;
using Clean.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Queries.GetStudentList
{
    public class GetStuentListQueryHandler : IRequestHandler<GetStudentListQuery, Response<List<GetStudentDto>>>
    {
        private readonly ILogger<GetStuentListQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public GetStuentListQueryHandler(ILogger<GetStuentListQueryHandler> logger, IMapper mapper, IStudentRepository studentRepository)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._studentRepository = studentRepository;
        }
        async Task<Response<List<GetStudentDto>>> IRequestHandler<GetStudentListQuery, Response<List<GetStudentDto>>>.Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get Student List Handler Initiated");
            var data = await _studentRepository.ListAllAsync();
            var studentList = _mapper.Map<List<GetStudentDto>>(data);
            var response = new Response<List<GetStudentDto>>(studentList);
            return response;
        }
    }
}
