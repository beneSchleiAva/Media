﻿using ModelInterface.Interface.ValueObjects;

namespace ReactApi.UIDto
{
    public class ProductIdUIDto : IProductId
    {
        public Guid Value { get; set; }

        public ProductIdUIDto()
        {
            Value = Guid.Empty;
        }

        public ProductIdUIDto(Guid value)
        {
            Value = value;
        }
    }
}
