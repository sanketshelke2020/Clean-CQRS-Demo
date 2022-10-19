using AutoMapper;
using Clean.Application.Features.Categories.Commands.CreateCategory;
using Clean.Application.Features.Categories.Commands.StoredProcedure;
using Clean.Application.Features.Categories.Queries.GetCategoriesList;
using Clean.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Clean.Application.Features.Employees.Queries.GetEmployeeList;
using Clean.Application.Features.Events.Commands.CreateEvent;
using Clean.Application.Features.Events.Commands.Transaction;
using Clean.Application.Features.Events.Commands.UpdateEvent;
using Clean.Application.Features.Events.Queries.GetEventDetail;
using Clean.Application.Features.Events.Queries.GetEventsExport;
using Clean.Application.Features.Events.Queries.GetEventsList;
using Clean.Application.Features.Orders.GetOrdersForMonth;
using Clean.Application.Features.Students.Commands.CreateStudent;
using Clean.Application.Features.Students.Queries.GetStudentList;
using Clean.Domain.Entities;

namespace Clean.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {          
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, TransactionCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();
            CreateMap<Employee, GetEmployeeDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, GetStudentDto>().ReverseMap();
            CreateMap<Student, UpdateEventCommand>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, StoredProcedureCommand>();
            CreateMap<Category, StoredProcedureDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
        }
    }
}
