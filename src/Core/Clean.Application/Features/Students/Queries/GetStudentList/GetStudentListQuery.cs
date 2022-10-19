using Clean.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Queries.GetStudentList
{
    public class GetStudentListQuery:IRequest<Response<List<GetStudentDto>>>
    {
    }
}
