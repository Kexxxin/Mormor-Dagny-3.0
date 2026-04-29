using Api.Helpers;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MormorDagnyContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlite"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddAutoMapper(Options =>
{
    Options.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxODA4MDA2NDAwIiwiaWF0IjoiMTc3NjUxODUwMCIsImFjY291bnRfaWQiOiIwMTlkYTBiZTQyYWQ3MDRiYjVlNTZjMTA0NmE3YzJmZiIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa3BnYzI0MzA3cnMycXJjbTJkNGtyM2E1Iiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.Ct860-JG9cQrTS4jhJfQ0C2IV9nSDq72Rmz4yBU6dYrc_SLumfdXlIymIYqt1ElZ7S1UaP-ZnAxxaYlo4J1TBnxcYdXRN-U9YMLZei17AMORk8QkykI-87sZ6mc6hASgHaKSPxxOL28b5rTY9aZwR0jQdkfQ13k8xg5Taciojl46vbgl7AhaN-R9jq6uHSwNZ2Anpk54QL7GfK3h3BTV8nY5ad2ulxnTbth5zbOuzFIF98K82Y-f_5w5c1-tQgXr7gE5sE6PWrNbTatN9WikB02OOvKsXbMnKEuH0GQWLdgVm8-UmvF57D7PdC_eZhHgC97PR0by0hhZ3nmQerFIuQ";
    Options.AddProfile(new MappingProfiles());
});

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();


app.Run();
