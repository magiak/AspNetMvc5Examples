using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.MetadataProviders
{
    public class MetadataProvider : AssociatedMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
            Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata = new ModelMetadata(this, containerType, modelAccessor, modelType, propertyName);
            if (propertyName != null)
            {
                var displayAttribute = attributes.OfType<DisplayAttribute>().FirstOrDefault();
                if (displayAttribute != null)
                {
                    int textId;
                    if (int.TryParse(displayAttribute.Name, out textId))
                    {
                        // TODO: get text from database
                        metadata.DisplayName = $"DB Text with id {Guid.NewGuid()} {textId}";
                    }
                    else
                    {
                        metadata.DisplayName = $"DbText 2 {Guid.NewGuid()}";
                    }
                }
            }
            return metadata;
        }
    }
}