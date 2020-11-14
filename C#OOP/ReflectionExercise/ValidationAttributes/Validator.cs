using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objectType = obj.GetType();
            PropertyInfo[] propertyInfos = objectType.GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                List<MyValidationAttribute> allMyAttributes = propertyInfo
                    .GetCustomAttributes<MyValidationAttribute>()
                    .ToList();
                object propertyObj = propertyInfo.GetValue(obj);

                foreach (MyValidationAttribute myValidationAttribute in allMyAttributes)
                {
                    bool isValid = myValidationAttribute.IsValid(propertyObj);

                    if(!isValid)
                    {
                        return false;
                    }
                }
              
            }

            return true;
        }
    }
}
