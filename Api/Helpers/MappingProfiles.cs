using Api.DTOs;
using Api.DTOs.Customers;
using Api.DTOs.Ingredients;
using Api.DTOs.Orders;
using Api.DTOs.Suppliers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Entities.Orders;
using Core.Entities.Purchases;

namespace Api.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Customer, GetCustomerDto>();
        CreateMap<Customer, GetCustomerByIdDto>()
            .ForMember(d => d.Orders, m => m.MapFrom(s => s.Orders));

        CreateMap<AddressDto, Address>();
        CreateMap<Address, AddressDto>();

        CreateMap<PostCustomerDto, Customer>()
            .ForMember(d => d.InvoiceAddress, m => m.MapFrom(s => s.InvoiceAddress))
            .ForMember(d => d.DeliveryAddress, m => m.MapFrom(s => s.DeliveryAddress));

        CreateMap<PatchCustomerDto, Customer>();

        CreateMap<SupplierIngredient, SupplierWithIngredientDto>()
               .ForMember(d => d.IngredientId, m => m.MapFrom(s => s.IngredientId))
               .ForMember(d => d.IngredientName, m => m.MapFrom(s => s.Ingredient.IngredientName))
               .ForMember(d => d.PricePerKg, m => m.MapFrom(s => s.PricePerKg));

        CreateMap<PostSupplierDto, Supplier>();
        CreateMap<Supplier, GetSupplierDto>();

        CreateMap<Supplier, GetSupplierIngredientsDto>()
            .ForMember(d => d.Ingredients, m => m.MapFrom(s => s.SupplierIngredients));

        CreateMap<Ingredient, GetIngredientDto>()
               .ForMember(d => d.Suppliers, m => m.MapFrom(s => s.SupplierIngredients));

        CreateMap<PutIngredientDto, Ingredient>();
        CreateMap<PostIngredientDto, Ingredient>();

        CreateMap<Order, GetOrdersDto>()
                .ForMember(d => d.CustomerName, m => m.MapFrom(s => s.Customer.CompanyName))
                .ForMember(d => d.CustomerEmail, m => m.MapFrom(s => s.Customer.Email))
                .ForMember(d => d.CustomerContact, m => m.MapFrom(s => s.Customer.ContactPerson))
                .ForMember(d => d.Items, m => m.MapFrom(s => s.OrderItems))
                .ForMember(d => d.SubTotal, m => m.MapFrom(s => s.SubTotal));


        CreateMap<OrderItem, GetOrderItemDto>()
                .ForMember(d => d.ProductName, m => m.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.Price, m => m.MapFrom(s => s.Price))
                .ForMember(d => d.Quantity, m => m.MapFrom(s => s.Quantity))
                .ForMember(d => d.SubTotal, m => m.MapFrom(s => s.Price * s.Quantity));


    }

}
