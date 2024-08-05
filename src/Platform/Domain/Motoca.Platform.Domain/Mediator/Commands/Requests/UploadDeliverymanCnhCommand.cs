using MediatR;

namespace Motoca.Platform.Domain.Mediator.Commands.Requests;

public class UploadDeliverymanCnhCommand : IRequest<Unit>
{
    public long DeliverymanId { get; set; }
    public byte[] Buffer { get; set; }
}