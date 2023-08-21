
using Convey.MessageBrokers;

namespace Notification.Application.UseCases.Dto
{
    [Message("timeslots", "timeslots.slotAdded", "scheduling.slotAdded")]
    public record SchedulingAnAppointmentEventDto(Guid SlotId);
}
