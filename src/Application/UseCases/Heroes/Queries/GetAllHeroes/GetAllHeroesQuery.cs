using AutoMapper.QueryableExtensions;
using SSW.CleanArchitecture.Application.Common.Interfaces;

namespace SSW.CleanArchitecture.Application.UseCases.Heroes.Queries.GetAllHeroes;

public record GetAllHeroesQuery : IRequest<IReadOnlyList<HeroDto>>;

public sealed class GetAllHeroesQueryHandler(
    IMapper mapper,
    IApplicationDbContext dbContext) : IRequestHandler<GetAllHeroesQuery, IReadOnlyList<HeroDto>>
{
    public async Task<IReadOnlyList<HeroDto>> Handle(
        GetAllHeroesQuery request,
        CancellationToken cancellationToken)
    {
        return await dbContext.Heroes
            .ProjectTo<HeroDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}