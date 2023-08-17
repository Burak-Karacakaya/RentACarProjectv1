using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelQuery : IRequest<GetListResponse<GetListModelListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery,GetListResponse<GetListModelListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IModelRepository _modelRepository;

        public GetListModelQueryHandler(IMapper mapper,IModelRepository modelRepository)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
        }

        public async Task<GetListResponse<GetListModelListItemDto>> Handle(GetListModelQuery request,
            CancellationToken cancellationToken)
        {
            var models = await _modelRepository.GetListAsync(
                include: m => m
                    .Include(m => m.Brand)
                    .Include(m => m.Fuel)
                    .Include(m => m.Transmission),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
                ,cancellationToken: cancellationToken);

            var response = _mapper.Map<GetListResponse<GetListModelListItemDto>>(models);
            return response;
        }
    }
}