using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blog.Infrastructure.Resources;

namespace Blog.Infrastructure.Services
{
   public class PropertyMappingService:IPropertyMappingService
   {
        //定义post实体和dto之间的映射关系
       private readonly Dictionary<string, PropertyMappingValue> _postPropertyMapping=
           new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
           {
               {"Id", new PropertyMappingValue(new List<string>{"Id"}) },
               {"Title", new PropertyMappingValue(new List<string>{"Title"}) },
               {"Content", new PropertyMappingValue(new List<string>{"Content"}) },
               {"Author", new PropertyMappingValue(new List<string>{ "Author"})},
               {"LastModified", new PropertyMappingValue(new List<string>{"LastModified"})},
               {"Remark", new PropertyMappingValue(new List<string>{"Remark"})}
           };
        private readonly IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();
        public PropertyMappingService()
        { 
            //注册映射关系
            _propertyMappings.Add(new PropertyMapping<PostResource,Post>(_postPropertyMapping));
        }
        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            var matchingMapping = _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();

            var propertyMappings = matchingMapping.ToList();
            if (propertyMappings.Count == 1)
            {
                return propertyMappings.First().MappingDictionary;
            }

            throw new Exception($"无法找到唯一的映射关系：{typeof(TSource)}, {typeof(TDestination)}");
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            var fieldAfterSplit = fields.Split(",");
            foreach (var field in fieldAfterSplit)
            {
                var trimmedField = field.Trim();
                var indexOfFirstSpace = trimmedField.IndexOf(" ", StringComparison.Ordinal);
                var propertyName = indexOfFirstSpace == -1 ? trimmedField
                    : trimmedField.Remove(indexOfFirstSpace);

                if (!propertyMapping.ContainsKey(propertyName))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
