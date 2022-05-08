using BattleShip.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Utils
{
    public class UtilsClone<T> where T : new()
    {
        public static T Clone(T obj)
        {
            var f = new T();
            Type type = typeof(T);
            var properties = type.GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                var interfaces = propertyInfo.PropertyType.GetInterfaces();
                if (interfaces.Contains(typeof(ICloneable)))
                {
                    var sourceVal = propertyInfo.GetValue(obj) as ICloneable;
                    propertyInfo.SetValue(f, sourceVal.Clone());
                }
                else
                {
                    var sourceVal = propertyInfo.GetValue(obj);
                    propertyInfo.SetValue(f, sourceVal);
                }
            }

            return f;
        }
    }
}
