﻿using System.Reflection;
using Lms.Rpc.Runtime.Server.Parameter;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace Lms.Swagger.SwaggerGen.SwaggerGenerator
{
    public interface IParameterFilter
    {
        void Apply(OpenApiParameter parameter, ParameterFilterContext context);
    }

    public class ParameterFilterContext
    {
        public ParameterFilterContext(
            ParameterDescriptor apiParameterDescription,
            ISchemaGenerator schemaGenerator,
            SchemaRepository schemaRepository,
            PropertyInfo propertyInfo = null,
            ParameterInfo parameterInfo = null)
        {
            ApiParameterDescription = apiParameterDescription;
            SchemaGenerator = schemaGenerator;
            SchemaRepository = schemaRepository;
            PropertyInfo = propertyInfo;
            ParameterInfo = parameterInfo;
        }

        public ParameterDescriptor ApiParameterDescription { get; }

        public ISchemaGenerator SchemaGenerator { get; }

        public SchemaRepository SchemaRepository { get; }

        public PropertyInfo PropertyInfo { get; }

        public ParameterInfo ParameterInfo { get; }

        public string DocumentName => SchemaRepository.DocumentName;
    }
}
