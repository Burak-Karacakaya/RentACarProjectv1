using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeletedBrandCommand : IRequest<DeletedBrandResponse>
{
    public Guid Id { get; set; }

    public class DeeltedBrandCommandHandler : IRequestHandler<DeletedBrandCommand,DeletedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeeltedBrandCommandHandler(IBrandRepository brandRepository,IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<DeletedBrandResponse> Handle(DeletedBrandCommand request,CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id,
                cancellationToken: cancellationToken);

            await _brandRepository.DeleteAsync(brand);
            return _mapper.Map<DeletedBrandResponse>(brand);
        }
    }
}