using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Commands.RemoveStudent
{
    public class RemoveStudentCommand : IRequest
    {
        public int StudentId { get; set; }
    }
}
