using Clean.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace Clean.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
