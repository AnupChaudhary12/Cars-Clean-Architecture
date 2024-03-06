namespace Cars.Application.Features.Queries.GetBrand
{
    public record GetBrandQuery(int Id): IRequest<BrandGetDto>
    {
    }
}
