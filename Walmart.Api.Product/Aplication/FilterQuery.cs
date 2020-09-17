using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Walmart.Api.Product.Model;

namespace Walmart.Api.Product.Aplication
{
    public class FilterQuery
    {
        public class Products: IRequest<Model.ProductDTO>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Products, Model.ProductDTO>
        {
            private readonly Persistence.MongoDBContext _context;
            private readonly IMapper _mapper;

            public Handler(Persistence.MongoDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ProductDTO> Handle(Products request, CancellationToken cancellationToken)
            {
                FilterDefinition<Model.Product> filter = Builders<Model.Product>.Filter.Eq("Id", request.Id);
                var product = await _context.Product.Find(filter).FirstOrDefaultAsync();
                var productDto = _mapper.Map<Model.Product, Model.ProductDTO>(product);
                return productDto;
            }
        }
    }
}
