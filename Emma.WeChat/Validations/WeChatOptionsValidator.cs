using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Emma.WeChat.Validations
{
    public class WeChatOptionsValidator : IValidateOptions<WeChatOptions>
    {
        public ValidateOptionsResult Validate(string name, WeChatOptions options)
        {

            if (options is null)
                return ValidateOptionsResult.Fail("选项配置不能为空");

            if (options.AppConfigs is null || options.AppConfigs.Count == 0)
                return ValidateOptionsResult.Fail($"{nameof(options.AppConfigs)} 不能为空");


            var index = 0;
            var urls = new HashSet<string>();
            var names = new HashSet<string>();
            var appIds = new HashSet<string>();
            foreach (var config in options.AppConfigs)
            {
                index++;
                ValidationContext context = new ValidationContext(config);
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(config, context, validationResults, true);
                if (!isValid)
                {
                    return ValidateOptionsResult.Fail($"第{index}个AppConfig配置错误：{validationResults.First().ErrorMessage}");
                }
                if (!urls.Add(config.Url))
                {
                    return ValidateOptionsResult.Fail($"第{index}个AppConfig配置错误：{nameof(config.Url)}不能与其他配置重复");
                }
                if (!names.Add(config.AppName))
                {
                    return ValidateOptionsResult.Fail($"第{index}个AppConfig配置错误：{nameof(config.AppName)}不能与其他配置重复");
                }
                if (!appIds.Add(config.AppId))
                {
                    return ValidateOptionsResult.Fail($"第{index}个AppConfig配置错误：{nameof(config.AppId)}不能与其他配置重复");
                }
            }

            return ValidateOptionsResult.Success;
        }
    }
}
