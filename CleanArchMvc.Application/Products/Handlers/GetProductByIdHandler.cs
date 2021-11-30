using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepoitory;
        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepoitory = productRepository;
        }
        public async Task<Product> Handle(GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepoitory.GetByIdAsync(request.Id);
        }
    }
}
