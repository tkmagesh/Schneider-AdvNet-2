﻿using System;
using System.Collections.Generic;

namespace ProjectManagementApp
{
    public static class MyUtilities
    {
        public static string Format(this object obj,string delimeter = ",")
        {
            var type = obj.GetType();
            var result = string.Empty;
            var propertyInfos = type.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                result += propertyInfo.GetValue(obj, null) + delimeter;
            }
            return result;
        }


        public static MyCollection<T> Search<T>(this IEnumerable<T> list, ISearchCriteria<T> criteria)
        {
            var result = new MyCollection<T>();
            foreach (var item in list)
            {
                var tITem = (T)item;
                if (criteria.IsSatisfiedBy(tITem))
                    result.Add(tITem);
            }
            return result;
        }
        public static IEnumerable<T> Search<T>(this IEnumerable<T> list, CriteriaDelegate<T> criteria)
        {
            foreach (var item in list)
            {
                var tItem = (T)item;
                if (criteria(tItem))
                    yield return tItem;
            }
        }
        public static int Count<T>(this IEnumerable<T> list, CriteriaDelegate<T> criteria)
        {
            var result = 0;
            foreach (var item in list)
            {
                var tItem = (T)item;
                if (criteria(tItem)) result++;
            }
            return result;
        }

        public static int Min<T>(this IEnumerable<T> list, AttributeSelectorDelegate<T, int> attributeSelector)
        {
            var result = int.MaxValue;
            foreach (var item in list)
            {
                var tItem = (T)item;
                var attrValue = attributeSelector(tItem);
                if (attrValue < result)
                    result = attrValue;
            }
            return result;
        }
        public static decimal Min<T>(this IEnumerable<T> list, AttributeSelectorDelegate<T, decimal> attributeSelector)
        {
            var result = decimal.MaxValue;
            foreach (var item in list)
            {
                var tItem = (T)item;
                var attrValue = attributeSelector(tItem);
                if (attrValue < result)
                    result = attrValue;
            }
            return result;
        }
        public static int Max<T>(this IEnumerable<T> list, Func<T, int> attributeSelector)
        {
            var result = int.MinValue;
            foreach (var item in list)
            {
                var tItem = (T)item;
                var attrValue = attributeSelector(tItem);
                if (attrValue > result)
                    result = attrValue;
            }
            return result;
        }
        public static decimal Max<T>(this IEnumerable<T> list, Func<T, decimal> attributeSelector)
        {
            var result = decimal.MinValue;
            foreach (var item in list)
            {
                var tItem = (T)item;
                var attrValue = attributeSelector(tItem);
                if (attrValue > result)
                    result = attrValue;
            }
            return result;
        }

        public static IDictionary<TKey, IList<T>> GroupBy<T, TKey>(this IEnumerable<T> list, 
            Func<T, TKey> keySelector)
        {
            var result = new Dictionary<TKey, IList<T>>();
            foreach (var item in list)
            {
                var key = keySelector(item);
                if (!result.ContainsKey(key)) result.Add(key,new List<T>());
                result[key].Add(item);
            }
            return result;
        }
 
        public static IEnumerable<TResult> Join<T1, T2, TKey, TResult>(this IEnumerable<T1> list, 
            IEnumerable<T2> outer,
            Func<T1, TKey> innerKeySelector,
            Func<T2, TKey> outerKeySelector,
            Func<T1, T2, TResult> transform)
        {
            foreach (var item in list)
            {
                var innerKey = innerKeySelector(item);
                foreach (var outerItem in outer)
                {
                    var outerKey = outerKeySelector(outerItem);
                    if (innerKey.Equals(outerKey))
                        yield return transform(item, outerItem);
                }
            }
        } 
 

    }
}