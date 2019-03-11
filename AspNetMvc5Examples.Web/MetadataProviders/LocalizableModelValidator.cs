using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc5Examples.Web.MetadataProviders
{
    public class LocalizableModelValidator : ModelValidator
    {
        private readonly ModelValidator innerValidator;

        public LocalizableModelValidator(ModelValidator innerValidator, ModelMetadata metadata, ControllerContext controllerContext)
            : base(metadata, controllerContext)
        {
            this.innerValidator = innerValidator;
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rules = this.innerValidator.GetClientValidationRules();
            var modelClientValidationRules = rules as ModelClientValidationRule[] ?? rules.ToArray();
            foreach (var rule in modelClientValidationRules)
            {
                int textId;
                if (Int32.TryParse(rule.ErrorMessage, out textId))
                {
                    // TODO: read text from database
                    rule.ErrorMessage = "DB_Text_" + textId;
                }
            }
            return modelClientValidationRules;
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            // execute the inner validation which doesn't have localization
            var results = this.innerValidator.Validate(container);
            // convert the error message (text id) to the localized value
            return results.Select(result =>
            {
                int textId;
                if (Int32.TryParse(result.Message, out textId))
                {
                    // TODO: read text from database
                    result.Message = "DB text with id " + textId;
                }
                return new ModelValidationResult() { Message = result.Message };
            });
        }
    }
}