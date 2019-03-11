using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.MetadataProviders
{
    public class LocalizableModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            var validators = base.GetValidators(metadata, context, attributes);
            return validators.Select(validator => new LocalizableModelValidator(validator, metadata, context)).ToList();
        }
    }
}